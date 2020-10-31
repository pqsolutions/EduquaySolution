using EduquayAPI.Models.Reports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.DataLayer.Reports
{
    public interface IReportsData
    {
        TrackingANWSubject RetrieveANWSubjects(string uniqueSubjectId);
        TrackingSubjects RetrieveSubjectsForTracking(string uniqueSubjectId);
    }
    public interface IReportsDataFactory
    {
        IReportsData Create();
    }
    public class ReportsDataFactory : IReportsDataFactory
    {
        public IReportsData Create()
        {
            return new ReportsData();
        }
    }
}
