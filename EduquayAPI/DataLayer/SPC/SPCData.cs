using EduquayAPI.Contracts.V1.Request.SPC;
using EduquayAPI.Models.SPC;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.DataLayer.SPC
{
    public class SPCData : ISPCData
    {
        private const string FetchSPCPathoDiagnosisReports = "SPC_FetchSPCPathoDiagnosisReports";
        public List<SPCPathoReports> RetrivePathologistReports(SPCPathoReportRequest prData)
        {
            string stProc = FetchSPCPathoDiagnosisReports;
            var pList = new List<SqlParameter>()
            {
                new SqlParameter("@DistrictId", prData.districtId),
                new SqlParameter("@BlockId", prData.blockId),
                new SqlParameter("@CHCID", prData.chcId),
                new SqlParameter("@ANMID", prData.anmId),
                new SqlParameter("@SampleStatus", prData.sampleStatus),
                new SqlParameter("@FromDate", prData.fromDate),
                new SqlParameter("@ToDate", prData.toDate)
            };
            var allData = UtilityDL.FillData<SPCPathoReports>(stProc, pList);
            return allData;
        }
    }

}
