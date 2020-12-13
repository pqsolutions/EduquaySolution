using EduquayAPI.Contracts.V1.Request.Reports;
using EduquayAPI.Contracts.V1.Response.Reports;
using EduquayAPI.Models.Reports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Services.Reports
{
    public interface IReportsService
    {
        Task<TrackingANWSubjectResponse> RetrieveANWSubjects(string uniqueSubjectId);
        Task<TrackingSubjectResponse> RetrieveSubjectsForTracking(string uniqueSubjectId);
        Task<NHMReportResponse> RetriveNHMReportsDetail(NHMRequest nhmData);
    }
}
