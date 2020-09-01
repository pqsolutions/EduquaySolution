using EduquayAPI.Contracts.V1.Request.Obstetrician;
using EduquayAPI.Contracts.V1.Response.Obstetrician;
using EduquayAPI.DataLayer.PNDTObstetrician;
using EduquayAPI.Models.PNDTObstetrician;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Services.PNDTObstetrician
{
    public class PNDTObstetricianService : IPNDTObstetricianService
    {
        private readonly IPNDTObstetricianData _pndtObstetricianData;

        public PNDTObstetricianService(IPNDTObstetricianDataFactory pndtObstetricianData)
        {
            _pndtObstetricianData = new PNDTObstetricianDataFactory().Create();
        }

        public async Task<AddPNDTResponse> AddPNDTest(AddPNDTestRequest aData)
        {
            var sResponse = new AddPNDTResponse();
            try
            {
                if (aData.obstetricianId <= 0)
                {
                    sResponse.Status = "false";
                    sResponse.Message = "Invalid Obstetrician";
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
                else if (aData.procedureOfTestingId <= 0)
                {
                    sResponse.Status = "false";
                    sResponse.Message = "Invalid procedure for testing id";
                    return sResponse;
                }
                else if (string.IsNullOrEmpty(aData.pndtComplecationsId))
                {
                    sResponse.Status = "false";
                    sResponse.Message = "Complecations are missing";
                    return sResponse;
                }
                else
                {
                    var pndtMsg = _pndtObstetricianData.AddPNDTest(aData);
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

        public List<PNDTCompletedSummary> GetPNDTCompletedSummary(PNDTCompletedSummaryRequest oData)
        {
            var completedData = _pndtObstetricianData.GetPNDTCompletedSummary(oData);
            return completedData;
        }

        public List<PNDTNotCompleted> GetPNDTNotCompleted(ObstetricianRequest oData)
        {
            var notCompletedData = _pndtObstetricianData.GetPNDTNotCompleted(oData);
            return notCompletedData;
        }

        public List<PNDTPending> GetPNDTPending(ObstetricianRequest oData)
        {
            var pendingData = _pndtObstetricianData.GetPNDTPending(oData);
            return pendingData;
        }
    }
}
