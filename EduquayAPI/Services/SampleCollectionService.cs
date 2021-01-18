using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using EduquayAPI.Contracts.V1.Request;
using EduquayAPI.Contracts.V1.Response;
using EduquayAPI.DataLayer;
using EduquayAPI.Models;
using Microsoft.Extensions.Configuration;

namespace EduquayAPI.Services
{
    public class SampleCollectionService : ISampleCollectionService
    {
        private readonly ISampleCollectionData _sampleCollectionData;
        private readonly IConfiguration _config;

        public SampleCollectionService(ISampleCollectionDataFactory sampleCollectionDataFactory, IConfiguration config)
        {
            _sampleCollectionData = new SampleCollectionDataFactory().Create();
            _config = config;
        }

        public async  Task<ServiceResponse> AddSample(AddSubjectSampleRequest ssData)
        {
            ServiceResponse sResponse = new ServiceResponse();
            try
            {
                if (string.IsNullOrEmpty(ssData.uniqueSubjectId))
                {
                    sResponse.Status = "false";
                    sResponse.Message = "Uniquesubjectid is missing";
                    return sResponse;
                }
                if (string.IsNullOrEmpty(ssData.barcodeNo))
                {
                    sResponse.Status = "false";
                    sResponse.Message = "Barcode is missing";
                    return sResponse;
                }
                if (string.IsNullOrEmpty(ssData.sampleCollectionDate))
                {
                    sResponse.Status = "false";
                    sResponse.Message = "Sample collection date is missing";
                    return sResponse;
                }
                if (string.IsNullOrEmpty(ssData.sampleCollectionTime))
                {
                    sResponse.Status = "false";
                    sResponse.Message = "Sample collection time is missing";
                    return sResponse;
                }
                if (ssData.collectionFrom <= 0)
                {
                    sResponse.Status = "false";
                    sResponse.Message = "Invalid collection from data";
                    return sResponse;
                }
                if (ssData.collectedBy <= 0)
                {
                    sResponse.Status = "false";
                    sResponse.Message = "Invalid collection by data";
                    return sResponse;
                }

                var barcode =  _sampleCollectionData.FetchBarcode(ssData.barcodeNo);
                if (barcode.Count <= 0)
                {
                    var result = _sampleCollectionData.AddSample(ssData);
                    if(string.IsNullOrEmpty(result))
                    {
                        sResponse.Status = "false";
                        sResponse.Message = $"Unable to collect sample for this uniquesubjectid - {ssData.uniqueSubjectId}";
                        return sResponse;
                    }
                    else
                    {
                        var smsSampleDetails = _sampleCollectionData.FetchSMSSamples(ssData.barcodeNo, ssData.uniqueSubjectId);
                        var barcodeNo = smsSampleDetails.barcodeNo;
                        var subjectMobileNo = smsSampleDetails.subjectMobileNo;
                        var subjectName = smsSampleDetails.subjectName;
                        var anmName = smsSampleDetails.anmName;
                        var anmMobileNo = smsSampleDetails.anmMobileNo;
                        var smsURL = _config.GetSection("RegistrationSamplingSMS").GetSection("SMSAPILink").Value;

                        var smsURLLink = smsURL.Replace("#MobileNo", subjectMobileNo).Replace("#SubjectName", subjectName).Replace("#SubjectId", ssData.uniqueSubjectId).Replace("#BarcodeNo", ssData.barcodeNo).Replace("#ANMName", anmName).Replace("#ANMMobile", anmMobileNo);
                        GetResponse(smsURLLink);

                        sResponse.Status = "true";
                        sResponse.Message = result;
                        return sResponse;
                    }
                }
                else
                {
                    sResponse.Status = "false";
                    sResponse.Message = $" This barcode no- {ssData.barcodeNo} is already associated with another subject";
                    return sResponse;
                }
            }
            catch (Exception e)
            {
                sResponse.Status = "false";
                sResponse.Message = $"Unable to collect sampele for this uniquesubjectid - {ssData.uniqueSubjectId} - {e.Message}";
                return sResponse;
            }
        }

        public static string GetResponse(string sURL)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(sURL);
            request.MaximumAutomaticRedirections = 4;
            request.Credentials = CredentialCache.DefaultCredentials;
            try
            {
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream receiveStream = response.GetResponseStream();
                StreamReader readStream = new StreamReader(receiveStream, Encoding.UTF8);
                string sResponse = readStream.ReadToEnd();
                response.Close();
                readStream.Close();
                return sResponse;
            }
            catch
            {
                return "";
            }
        }

        public List<SubjectSamples> Retrieve(SubjectSampleRequest ssData)
        {
            var subjectSamples = _sampleCollectionData.Retrieve(ssData);
            return subjectSamples;
        }
    }
}
