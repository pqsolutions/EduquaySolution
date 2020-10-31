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
    }
}
