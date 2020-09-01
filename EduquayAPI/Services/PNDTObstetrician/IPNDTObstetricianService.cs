using EduquayAPI.Contracts.V1.Request.Obstetrician;
using EduquayAPI.Contracts.V1.Response.Obstetrician;
using EduquayAPI.Models.PNDTObstetrician;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Services.PNDTObstetrician
{
    public interface IPNDTObstetricianService
    {
        List<PNDTPending> GetPNDTPending(ObstetricianRequest oData);
        Task<AddPNDTResponse> AddPNDTest(AddPNDTestRequest aData);
        List<PNDTNotCompleted> GetPNDTNotCompleted(ObstetricianRequest oData);
        List<PNDTCompletedSummary> GetPNDTCompletedSummary(PNDTCompletedSummaryRequest oData);

    }
}
