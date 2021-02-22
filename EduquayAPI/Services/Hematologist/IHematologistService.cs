using EduquayAPI.Contracts.V1.Response.Hematologist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Services.Hematologist
{
    public interface IHematologistService
    {
        Task<CompletedMolecularTestResponse> RetrieveCompletedMolecularDetail(int molecularLabId);
    }
}
