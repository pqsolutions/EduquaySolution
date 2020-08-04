using EduquayAPI.Contracts.V1.Response.Pathologist;
using EduquayAPI.Models.Pathologist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Services.Pathologist
{
    public interface IPathologistService
    {
        Task<HPLCTestDetailResponse> HPLCResultDetail(int centralLabId);

    }
}
