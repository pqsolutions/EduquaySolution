using EduquayAPI.Contracts.V1.Request.Haematologist;
using EduquayAPI.Contracts.V1.Response.Haematologist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Services.Haematologist
{
    public interface IHaematologistService
    {
        Task<CompletedMolecularTestResponse> RetrieveCompletedMolecularDetail(int molecularLabId);
        Task<ReviewResultResponse> AddDecision(AddPregnancyDecisionRequest prData);
    }
}
