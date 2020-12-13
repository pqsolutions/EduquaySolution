using EduquayAPI.Contracts.V1.Request.Reports;
using EduquayAPI.Contracts.V1.Response.Reports;
using EduquayAPI.DataLayer.Reports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Services.Reports
{
    public class ReportsService : IReportsService
    {
        private readonly IReportsData _reportsData;

        public ReportsService(IReportsDataFactory reportsDataFactory)
        {
            _reportsData = new ReportsDataFactory().Create();
        }
        public async Task<TrackingANWSubjectResponse> RetrieveANWSubjects(string uniqueSubjectId)
        {
            var tResponse = new TrackingANWSubjectResponse();
            try
            {
                var result = _reportsData.RetrieveANWSubjects(uniqueSubjectId);
                if(result.subjectId != null)
                {
                    tResponse.status = "true";
                    tResponse.message = "";
                    tResponse.data = result;
                }
                else
                {
                    tResponse.status = "false";
                    tResponse.message = "Record not found";
                    tResponse.data = null;
                }
               
            }
            catch (Exception e)
            {
                tResponse.status = "false";
                tResponse.message = e.Message;
            }
            return tResponse;
        }

        public async Task<TrackingSubjectResponse> RetrieveSubjectsForTracking(string uniqueSubjectId)
        {
            var tResponse = new TrackingSubjectResponse();
            try
            {
                var result = _reportsData.RetrieveSubjectsForTracking(uniqueSubjectId);
                if (result.subjectId != null)
                {
                    tResponse.status = "true";
                    tResponse.message = "";
                    tResponse.data = result;
                }
                else
                {
                    tResponse.status = "false";
                    tResponse.message = "Record not found";
                    tResponse.data = null;

                }
            }
            catch (Exception e)
            {
                tResponse.status = "false";
                tResponse.message = e.Message;
            }
            return tResponse;
        }

        public async Task<NHMReportResponse> RetriveNHMReportsDetail(NHMRequest nhmData)
        {
            var tResponse = new NHMReportResponse();
            try
            {
                if(nhmData.searchType == 1)
                {
                    var result = _reportsData.RetrieveNHMReports(nhmData);
                    tResponse.status = "true";
                    tResponse.message = "";
                    tResponse.data = result;
                }
                else if (nhmData.searchType == 2)
                {
                    if (string.IsNullOrEmpty(nhmData.userInput))
                    {
                        tResponse.status = "false";
                        tResponse.message = "Please give some input for search";
                    }
                    else
                    {
                        var result = _reportsData.RetrieveParticularNHMReports(nhmData);
                        tResponse.status = "true";
                        tResponse.message = "";
                        tResponse.data = result;
                    }
                }
            }
            catch (Exception e)
            {
                tResponse.status = "false";
                tResponse.message = e.Message;
            }
            return tResponse;

        }
    }
}
