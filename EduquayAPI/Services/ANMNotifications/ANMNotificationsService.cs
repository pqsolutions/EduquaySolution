using EduquayAPI.Contracts.V1.Request.ANMNotifications;
using EduquayAPI.Contracts.V1.Response;
using EduquayAPI.Contracts.V1.Response.ANMNotifications;
using EduquayAPI.DataLayer.ANMNotifications;
using EduquayAPI.Models.ANMNotifications;
using Microsoft.Extensions.DependencyInjection;
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
                    sResponse.Message = $" This barcode no- {srData.barcodeNo} is already associated with another subject";
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


        public ServiceResponse UpdateSampleStatus(NotificationUpdateStatusRequest usData)
        {
            var response = new ServiceResponse();
            try
            {

                if (usData.anmId <= 0)
                {
                    response.Status = "false";
                    response.Message = "Invalid ANM id";
                }
                else if (string.IsNullOrEmpty(usData.barcodeNo))
                {
                    response.Status = "false";
                    response.Message = "Barcode is missing";
                }
                else
                {
                    var result = _anmNotificationsData.UpdateSampleStatus(usData);
                    if (string.IsNullOrEmpty(result))
                    {
                        response.Status = "false";
                        response.Message = "Unable to update sample status data";
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

        public ANMTimeoutResponse MoveTimeout(NotificationUpdateStatusRequest usData)
        {
            var response = new ANMTimeoutResponse();
            try
            {
                if (usData.anmId <= 0)
                {
                    response.Status = "false";
                    response.Message = "Invalid ANM id";
                }
                else if (string.IsNullOrEmpty(usData.barcodeNo))
                {
                    response.Status = "false";
                    response.Message = "Barcode is missing";
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
                    var unsentSample = new ANMUnsentSample();
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
                    anmUnsent.Add(unsentSample);
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

        public ServiceResponse UpdatePositiveSubjectStatus(NotificationUpdateStatusRequest usData)
        {
            var response = new ServiceResponse();
            try
            {
                if (usData.anmId <= 0)
                {
                    response.Status = "false";
                    response.Message = "Invalid ANM id";
                }
                else if (string.IsNullOrEmpty(usData.barcodeNo))
                {
                    response.Status = "false";
                    response.Message = "Barcodeno is missing";
                }
                else 
                { 
                    var result = _anmNotificationsData.UpdatePositiveSubjectStatus(usData); 
                    if (string.IsNullOrEmpty(result))
                    {
                        response.Status = "false";
                        response.Message = "Unable to update positive subject status data";
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
                response.Message =e.Message;
            }
            return response;
        }

        public List<ANMPNDTReferal> GetPNDTReferal(int userId)
        {
            var pndtReferal = _anmNotificationsData.GetPNDTReferal(userId);
            return pndtReferal;
        }

        public List<ANMMTPReferal> GetMTPReferal(int userId)
        {
            var mtpReferal = _anmNotificationsData.GetMTPReferal(userId);
            return mtpReferal;
        }

        public ServiceResponse UpdatePNDTReferalStatus(ANMReferalRequest rData)
        {
            var response = new ServiceResponse();
            try
            {

                if (rData.userId <= 0)
                {
                    response.Status = "false";
                    response.Message = "Invalid user id";
                }
                else if (string.IsNullOrEmpty(rData.referalId))
                {
                    response.Status = "false";
                    response.Message = "referal id is missing";
                }
                else
                {
                    var result = _anmNotificationsData.UpdatePNDTReferalStatus(rData);
                    if (string.IsNullOrEmpty(result))
                    {
                        response.Status = "false";
                        response.Message = "Unable to update pndt referal status data";
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

        public ServiceResponse UpdateMTPReferalStatus(ANMReferalRequest rData)
        {
            var response = new ServiceResponse();
            try
            {

                if (rData.userId <= 0)
                {
                    response.Status = "false";
                    response.Message = "Invalid user id";
                }
                else if (string.IsNullOrEmpty(rData.referalId))
                {
                    response.Status = "false";
                    response.Message = "referal id is missing";
                }
                else
                {
                    var result = _anmNotificationsData.UpdateMTPReferalStatus(rData);
                    if (string.IsNullOrEmpty(result))
                    {
                        response.Status = "false";
                        response.Message = "Unable to update mtp referal status data";
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

        public List<ANMPostMTPFollowUp> FetchMTPFollowUp(int userId)
        {
            var mtpFollowUp = _anmNotificationsData.FetchMTPFollowUp(userId);
            return mtpFollowUp;
        }

        public ServiceResponse UpdateMTPFollowUpStatus(AddFollowUpStatus fData)
        {
            var response = new ServiceResponse();
            try
            {

                if (fData.userId <= 0)
                {
                    response.Status = "false";
                    response.Message = "Invalid user id";
                }
                else if (fData.mtpId <= 0)
                {
                    response.Status = "false";
                    response.Message = "Invalid mtp id";
                }
                else if (fData.followUpNo <= 0)
                {
                    response.Status = "false";
                    response.Message = "Invalid followup no";
                }
                else
                {
                    var result = _anmNotificationsData.UpdateMTPFollowUpStatus(fData);
                    if (string.IsNullOrEmpty(result))
                    {
                        response.Status = "false";
                        response.Message = "Unable to update mtp follow up status";
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
    }
}
