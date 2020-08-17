using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EduquayAPI.Contracts.V1.Request;
using EduquayAPI.Contracts.V1.Response;
using EduquayAPI.DataLayer;
using EduquayAPI.Models;

namespace EduquayAPI.Services
{
    public class SampleCollectionService : ISampleCollectionService
    {
        private readonly ISampleCollectionData _sampleCollectionData;

        public SampleCollectionService(ISampleCollectionDataFactory sampleCollectionDataFactory)
        {
            _sampleCollectionData = new SampleCollectionDataFactory().Create();
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
                        sResponse.Message = $"Unable to collect sampele for this uniquesubjectid - {ssData.uniqueSubjectId}";
                        return sResponse;
                    }
                    else
                    {
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

        public List<SubjectSamples> Retrieve(SubjectSampleRequest ssData)
        {
            var subjectSamples = _sampleCollectionData.Retrieve(ssData);
            return subjectSamples;
        }
    }
}
