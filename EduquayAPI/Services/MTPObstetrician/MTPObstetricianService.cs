using EduquayAPI.Contracts.V1.Request.Obstetrician;
using EduquayAPI.Contracts.V1.Response.Obstetrician;
using EduquayAPI.DataLayer.MTPObstetrician;
using EduquayAPI.Models.MTPObstetrician;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Services.MTPObstetrician
{
    public class MTPObstetricianService : IMTPObstetricianService
    {


        private readonly IMTPObstetricianData _mtpObstetricianData;

        public MTPObstetricianService(IMTPObstetricianDataFactory mtpObstetricianData)
        {
            _mtpObstetricianData = new MTPObstetricianDataFactory().Create();
        }

        public async Task<AddMTPResponse> AddMTPService(AddMTPTestRequest aData)
        {
            var sResponse = new AddMTPResponse();
            try
            {
                if (aData.obstetricianId <= 0)
                {
                    sResponse.Status = "false";
                    sResponse.Message = "Invalid Obstetrician";
                    return sResponse;
                }
                else if (string.IsNullOrEmpty(aData.mtpDateTime))
                {
                    sResponse.Status = "false";
                    sResponse.Message = "MTP date and time is missing";
                    return sResponse;
                }
                else if (string.IsNullOrEmpty(aData.clinicalHistory))
                {
                    sResponse.Status = "false";
                    sResponse.Message = "Clinical history is missing";
                    return sResponse;
                }
                else if (string.IsNullOrEmpty(aData.examination))
                {
                    sResponse.Status = "false";
                    sResponse.Message = "Examination is missing";
                    return sResponse;
                }
                else if (string.IsNullOrEmpty(aData.procedureOfTesting))
                {
                    sResponse.Status = "false";
                    sResponse.Message = "Procedure for testing is missing";
                    return sResponse;
                }
                else if (string.IsNullOrEmpty(aData.mtpComplecationsId))
                {
                    sResponse.Status = "false";
                    sResponse.Message = "Complications are missing";
                    return sResponse;
                }
                else if (aData.dischargeConditionId <= 0)
                {
                    sResponse.Status = "false";
                    sResponse.Message = "Invalid condition of discharge";
                    return sResponse;
                }
                else
                {
                    var pndtMsg = _mtpObstetricianData.AddMTPService(aData);
                    sResponse.Status = "true";
                    sResponse.Message = string.Empty;
                    sResponse.data = pndtMsg;
                    return sResponse;
                }

            }
            catch (Exception e)
            {
                sResponse.Status = "false";
                sResponse.Message = $"Unable to add PND Test - {e.Message}";
                return sResponse;
            }
        }

        public List<MTPSummary> GetMTPCompleted(ObstetricianRequest oData)
        {
            var completedData = _mtpObstetricianData.GetMTPCompleted(oData);
            return completedData;
        }

        public List<MTPPending> GetMTPPending(ObstetricianRequest oData)
        {
            var pendingData = _mtpObstetricianData.GetMTPPending(oData);
            return pendingData;
        }

        public List<MTPSummary> GetMTPSummary()
        {
            var summaryData = _mtpObstetricianData.GetMTPSummary();
            return summaryData;
        }
    }
}
