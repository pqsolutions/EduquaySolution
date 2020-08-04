using EduquayAPI.Contracts.V1.Response.Pathologist;
using EduquayAPI.DataLayer.Pathologist;
using EduquayAPI.Models.Pathologist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace EduquayAPI.Services.Pathologist
{
    public class PathologistService : IPathologistService
    {
        private readonly IPathologistData _pathologistData;

        public PathologistService(IPathologistDataFactory pathologistDataFactory)
        {
            _pathologistData = new PathologistDataFactory().Create();
        }
        public async Task<HPLCTestDetailResponse> HPLCResultDetail(int centralLabId)
        {
            var hplcResultResponse = new HPLCTestDetailResponse();
            try
            {
                var hplcData = _pathologistData.HPLCResultDetail(centralLabId);
                hplcResultResponse.Status = "true";
                hplcResultResponse.Message = "";
                hplcResultResponse.SubjectDetails = hplcData;
            }
            catch (Exception e)
            {
                hplcResultResponse.Status = "true";
                hplcResultResponse.Message = e.Message;
            }
            return hplcResultResponse;
        }
    }
}
