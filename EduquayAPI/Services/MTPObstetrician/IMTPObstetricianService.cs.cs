using EduquayAPI.Contracts.V1.Request.Obstetrician;
using EduquayAPI.Contracts.V1.Response.Obstetrician;
using EduquayAPI.Models.MTPObstetrician;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Services.MTPObstetrician
{
    public interface IMTPObstetricianService
    {
        List<MTPPending> GetMTPPending(ObstetricianRequest oData);
        Task<AddMTPResponse> AddMTPService(AddMTPTestRequest aData);
        List<MTPSummary> GetMTPCompleted(ObstetricianRequest oData);
        List<MTPSummary> GetMTPSummary();

    }
}
