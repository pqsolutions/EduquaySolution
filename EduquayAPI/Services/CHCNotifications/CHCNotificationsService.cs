using EduquayAPI.Contracts.V1.Request.ANMNotifications;
using EduquayAPI.Contracts.V1.Request.CHCNotifications;
using EduquayAPI.Contracts.V1.Response;
using EduquayAPI.Contracts.V1.Response.CHCNotifications;
using EduquayAPI.DataLayer.CHCNotifications;
using EduquayAPI.Models.CHCNotifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Services.CHCNotifications
{
    public class CHCNotificationsService : ICHCNotificationsService
    {
        private readonly ICHCNotificationsData _chcNotificationsData;

        public CHCNotificationsService(ICHCNotificationsDataFactory chcNotificationsDataFactory)
        {
            _chcNotificationsData = new CHCNotificationsDataFactory().Create();
        }

        public async Task<ServiceResponse> AddSampleRecollection(SampleRecollectionRequest srData)
        {
            var sResponse = new ServiceResponse();

            try
            {
                if (string.IsNullOrEmpty(srData.uniqueSubjectId))
                {
                    sResponse.Status = "false";
                    sResponse.Message = "Uniquesubjectid is missing";
                    return sResponse;
                }
                if (string.IsNullOrEmpty(srData.barcodeNo))
                {
                    sResponse.Status = "false";
                    sResponse.Message = "Barcode is missing";
                    return sResponse;
                }
                if (string.IsNullOrEmpty(srData.sampleCollectionDate))
                {
                    sResponse.Status = "false";
                    sResponse.Message = "Sample collection date is missing";
                    return sResponse;
                }
                if (string.IsNullOrEmpty(srData.sampleCollectionTime))
                {
                    sResponse.Status = "false";
                    sResponse.Message = "Sample collection time is missing";
                    return sResponse;
                }
                if (string.IsNullOrEmpty(srData.reason))
                {
                    sResponse.Status = "false";
                    sResponse.Message = "Invalid Reason";
                    return sResponse;
                }
                if (srData.collectionFrom <= 0)
                {
                    sResponse.Status = "false";
                    sResponse.Message = "Invalid collection from data";
                    return sResponse;
                }
                if (srData.collectedBy <= 0)
                {
                    sResponse.Status = "false";
                    sResponse.Message = "Invalid collection by data";
                    return sResponse;
                }
                var barcode = _chcNotificationsData.FetchBarcode(srData.barcodeNo);
                if (barcode.Count <= 0)
                {
                    var result = _chcNotificationsData.AddSampleRecollection(srData);
                    if (string.IsNullOrEmpty(result))
                    {
                        sResponse.Status = "false";
                        sResponse.Message = $"Unable to collect sampele for this uniquesubjectid - {srData.uniqueSubjectId}";
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
                    sResponse.Message = $"This Barcode No - {srData.barcodeNo} already exist";
                    return sResponse;
                }
            }
            catch (Exception e)
            {
                sResponse.Status = "false";
                sResponse.Message = $"Unable to collect sampele for this uniquesubjectid - {srData.uniqueSubjectId} - {e.Message}";
                return sResponse;
            }
        }

        public List<CHCNotificationSample> GetCHCNotificationSamples(CHCNotificationSamplesRequest cnData)
        {
            var notificationSamples = _chcNotificationsData.GetCHCNotificationSamples(cnData);
            return notificationSamples;
        }

        public CHCTimeoutResponse MoveTimeout(CHCNotificationTimeoutRequest cnData) 
        {
            CHCTimeoutResponse response = new CHCTimeoutResponse();
            try
            {
                if (cnData.userId <= 0)
                {
                    response.Status = "false";
                    response.Message = "Invalid user id";
                }
                else if(string.IsNullOrEmpty(cnData.barcodeNo))
                {
                    response.Status = "false";
                    response.Message = "Barcode is missing";
                }
                else
                {
                    var result = _chcNotificationsData.AddTimeoutExpiry(cnData);

                    if (string.IsNullOrEmpty(result))
                    {
                        response.Status = "false";
                        response.Message = "Unable to move timeout expiry samples";
                    }
                    else
                    {
                        response.Status = "true";
                        response.Message = result;
                    }
                }
            }
            catch (Exception e)
            {
                response.Status = "false";
                response.Message = e.Message;
            }
            return response;
        }

        public async Task<CHCUnsentSamplesResponse> RetrieveUnsentSamples(CHCNotificationSamplesRequest cnData)
        {
            var chcUnsentresponse = new CHCUnsentSamplesResponse();
            try
            {
                var unsentSampleDetail = _chcNotificationsData.GetANMUnsentSamples(cnData);

                var chcUnsent = new List<CHCUnsentSample>();

                foreach (var unsent in unsentSampleDetail)
                {
                    var unsentSample = new CHCUnsentSample();
                    unsentSample.barcodeNo = unsent.barcodeNo;
                    unsentSample.contactNo = unsent.contactNo;
                    unsentSample.gestationalAge = unsent.gestationalAge;
                    unsentSample.rchId = unsent.rchId;
                    unsentSample.sampleCollectionId = unsent.sampleCollectionId;
                    unsentSample.subjectName = unsent.subjectName;
                    unsentSample.uniqueSubjectId = unsent.uniqueSubjectId;
                    unsentSample.sampleDateTime = unsent.sampleDateTime;
                    DateTime myDate1 = DateTime.Now;
                    DateTime myDate2 = Convert.ToDateTime(unsent.sampleDateTime);
                    TimeSpan difference = myDate1.Subtract(myDate2);
                    double totalHours = Math.Round(difference.TotalHours);
                    unsentSample.sampleAging = Convert.ToString(totalHours); //+ " Hrs";
                    chcUnsent.Add(unsentSample);
                }
                chcUnsentresponse.UnsentSamplesDetail = chcUnsent;
                chcUnsentresponse.Status = "true";
                chcUnsentresponse.Message = string.Empty;
            }
            catch (Exception e)
            {
                chcUnsentresponse.Status = "false";
                chcUnsentresponse.Message = e.Message;
            }
            return chcUnsentresponse;

        }
    }
}
