using EduquayAPI.Contracts.V1.Request.ANMNotifications;
using EduquayAPI.Contracts.V1.Response;
using EduquayAPI.Contracts.V1.Response.ANMNotifications;
using EduquayAPI.DataLayer.ANMNotifications;
using EduquayAPI.Models.ANMNotifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Services.ANMNotifications
{
    public class ANMNotificationsService : IANMNotificationsService
    {
        private readonly IANMNotificationsData _anmNotificationsData;

        public ANMNotificationsService(IANMNotificationsDataFactory anmNotificationsDataFactory)
        {
            _anmNotificationsData = new ANMNotificationsDataFactory().Create();
        }

        public async Task<ServiceResponse> AddSampleRecollection(SampleRecollectionRequest srData)
        {
            ServiceResponse sResponse = new ServiceResponse();

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
                var barcode = _anmNotificationsData.FetchBarcode(srData.barcodeNo);
                if (barcode.Count <= 0)
                {
                    var result = _anmNotificationsData.AddSampleRecollection(srData);
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


        public string UpdateSampleStatus(NotificationUpdateStatusRequest usData)
        {
            try
            {

                if (usData.anmId <= 0)
                {
                    return "Invalid ANM id";
                }

                var result = _anmNotificationsData.UpdateSampleStatus(usData);
                return string.IsNullOrEmpty(result) ? $"Unable to update sample status data" : result;
            }
            catch (Exception e)
            {
                return $"Unable to update  sample status - {e.Message}";
            }
        }

        public ANMTimeoutResponse MoveTimeout(NotificationUpdateStatusRequest usData)
        {
            ANMTimeoutResponse response = new ANMTimeoutResponse();
            try
            {
                if (usData.anmId <= 0)
                {
                    response.Status = "false";
                    response.Message = "Invalid ANM id";
                }
                else
                {
                    var result = _anmNotificationsData.AddTimeoutExpiry(usData);

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

        public List<ANMNotificationSample> GetANMNotificationSamples(NotificationSamplesRequest nsData)
        {
            var notificationSamples = _anmNotificationsData.GetANMNotificationSamples(nsData);
            return notificationSamples;
        }

        public async Task<ANMUnsentSamplesResponse> RetrieveUnsentSamples(int userId)
        {
            var anmUnsentresponse = new ANMUnsentSamplesResponse();
            try
            {
                var unsentSampleDetail = _anmNotificationsData.GetANMUnsentSamples(userId);
               
                var anmUnsent = new List<ANMUnsentSample>();

                foreach (var unsent in unsentSampleDetail)
                {
                    var unsentsample = new ANMUnsentSample();
                    unsentsample.barcodeNo = unsent.barcodeNo;
                    unsentsample.contactNo = unsent.contactNo;
                    unsentsample.gestationalAge = unsent.gestationalAge;
                    unsentsample.rchId = unsent.rchId;
                    unsentsample.sampleCollectionId = unsent.sampleCollectionId;
                    unsentsample.subjectName = unsent.subjectName;
                    unsentsample.uniqueSubjectId = unsent.uniqueSubjectId;
                    unsentsample.sampleDateTime = unsent.sampleDateTime;
                    DateTime myDate1 = DateTime.Now;
                    DateTime myDate2 = Convert.ToDateTime(unsentsample.sampleDateTime);
                    TimeSpan difference = myDate1.Subtract(myDate2);
                    double totalHours = Math.Round(difference.TotalHours);
                    unsentsample.sampleAging = Convert.ToString(totalHours); //+ " Hrs";
                    anmUnsent.Add(unsentsample);
                }
                anmUnsentresponse.UnsentSamplesDetail = anmUnsent;
                anmUnsentresponse.Status = "true";
                anmUnsentresponse.Message = string.Empty;
            }
            catch (Exception e)
            {
                anmUnsentresponse.Status = "false";
                anmUnsentresponse.Message = e.Message;
            }
            return anmUnsentresponse;
        }

        public List<ANMHPLCPositiveSamples> GetPositiveDetails(int userId)
        {
            var positiveSubjects = _anmNotificationsData.GetPositiveDetails(userId);
            return positiveSubjects;
        }

        public string UpdatePositiveSubjectStatus(NotificationUpdateStatusRequest usData)
        {
            try
            {

                if (usData.anmId <= 0)
                {
                    return "Invalid ANM id";
                }

                var result = _anmNotificationsData.UpdatePositiveSubjectStatus(usData);
                return string.IsNullOrEmpty(result) ? $"Unable to update positive subject status data" : result;
            }
            catch (Exception e)
            {
                return $"Unable to update positive subject status - {e.Message}";
            }
        }
    }
}
