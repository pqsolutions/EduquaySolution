using EduquayAPI.Contracts.V1.Request.DistrictCoordinator;
using EduquayAPI.Contracts.V1.Response;
using EduquayAPI.DataLayer.DistrictCoordinator;
using EduquayAPI.Models.DiscrictCoordinator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Services.DistrictCoordinator
{
    public class DCService:IDCService 
    {

        private readonly IDCData _dcData;

        public DCService(IDCDataFactory dcData)
        {
            _dcData = new DCDataFactory().Create();
        }

        public List<NotificationSamples> GetDamagedSamples(int districtId)
        {
            var notificationSamples = _dcData.GetDamagedSamples(districtId);
            return notificationSamples;
        }

        public List<MTPReferal> GetMTPReferal(int districtId)
        {
            var mtpReferal = _dcData.GetMTPReferal(districtId);
            return mtpReferal;
        }

        public List<PNDTReferal> GetPNDTReferal(int districtId)
        {
            var pndtReferal = _dcData.GetPNDTReferal(districtId);
            return pndtReferal;
        }

        public List<DCPositiveSamples> GetPositiveSampeles(int districtId)
        {
            var notificationSamples = _dcData.GetPositiveSampeles(districtId);
            return notificationSamples;
        }

        public List<NotificationSamples> GetTimeoutSamples(int districtId)
        {
            var notificationSamples = _dcData.GetTimeoutSamples(districtId);
            return notificationSamples;
        }

        public List<NotificationSamples> GetUnsentSamples(int districtId)
        {
            var notificationSamples = _dcData.GetUnsentSamples(districtId);
            return notificationSamples;
        }

        public ServiceResponse UpdatePositiveSubjectStatus(NotificationDCRequest nData)
        {
            var response = new ServiceResponse();
            try
            {

                if (nData.userId <= 0)
                {
                    response.Status = "false";
                    response.Message = "Invalid user id";
                }
                else if (string.IsNullOrEmpty(nData.barcodeNo))
                {
                    response.Status = "false";
                    response.Message = "Barcode is missing";
                }
                else
                {
                    var result = _dcData.UpdatePositiveSubjectStatus(nData);
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

        public ServiceResponse UpdateSampleStatus(NotificationDCRequest nData)
        {
            var response = new ServiceResponse();
            try
            {

                if (nData.userId <= 0)
                {
                    response.Status = "false";
                    response.Message = "Invalid user id";
                }
                else if (string.IsNullOrEmpty(nData.barcodeNo))
                {
                    response.Status = "false";
                    response.Message = "Barcode is missing";
                }
                else
                {
                    var result = _dcData.UpdateSampleStatus(nData);
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
    }
}
