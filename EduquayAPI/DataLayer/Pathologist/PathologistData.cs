using EduquayAPI.Models.Pathologist;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.DataLayer.Pathologist
{
    public class PathologistData : IPathologistData
    {
        private const string FetchPathoDiognosticSubjectsList = "SPC_FetchPathoDiognosticSubjectsList";
        public PathologistData()
        {

        }

        public List<HPLCTestDetails> HPLCResultDetail(int centralLabId)
        {
            string stProc = FetchPathoDiognosticSubjectsList;
            var pList = new List<SqlParameter>() { new SqlParameter("@CentralLabId", centralLabId) };
            var allSampleData = UtilityDL.FillData<HPLCTestDetails>(stProc, pList);
            return allSampleData;
        }
    }
}
