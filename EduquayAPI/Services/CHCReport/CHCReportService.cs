using EduquayAPI.Contracts.V1.Request.CHCReports;
using EduquayAPI.Contracts.V1.Response.CHCReport;
using EduquayAPI.DataLayer.CHCReport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Services.CHCReport
{
    public class CHCReportService : ICHCReportService
    {
        private readonly ICHCReportData _chcReportData;
        public CHCReportService(ICHCReportDataFactory chcReportDataFactory)
        {
            _chcReportData = new CHCReportDataFactory().Create();
        }
        public async Task<CHCReportsResponse> RetriveCHCReportsDetail(CHCReportRequest chcData)
        {
            var tResponse = new CHCReportsResponse();
            try
            {
                if (chcData.searchSection == 1)
                {
                    var result = _chcReportData.RetrieveCHCReportsSampling(chcData);
                    tResponse.status = "true";
                    tResponse.message = "";
                    tResponse.data = result;
                }
                else if (chcData.searchSection == 2)
                {
                    var result = _chcReportData.RetrieveCHCReportsShipment(chcData);
                    tResponse.status = "true";
                    tResponse.message = "";
                    tResponse.data = result;
                }
                else if (chcData.searchSection == 3)
                {
                    var result = _chcReportData.RetrieveCHCReportsTimeoutDamaged(chcData);
                    tResponse.status = "true";
                    tResponse.message = "";
                    tResponse.data = result;
                }
                else if (chcData.searchSection == 4)
                {
                    var result = _chcReportData.RetrieveCHCReportsCHC(chcData);
                    tResponse.status = "true";
                    tResponse.message = "";
                    tResponse.data = result;
                }
                else if (chcData.searchSection == 5)
                {
                    var result = _chcReportData.RetrieveCHCReportsHPLC(chcData);
                    tResponse.status = "true";
                    tResponse.message = "";
                    tResponse.data = result;
                }
                else if (chcData.searchSection == 6)
                {
                    var result = _chcReportData.RetrieveCHCReportsPrePNDTC(chcData);
                    tResponse.status = "true";
                    tResponse.message = "";
                    tResponse.data = result;
                }
                else if (chcData.searchSection == 7)
                {
                    var result = _chcReportData.RetrieveCHCReportsPNDT(chcData);
                    tResponse.status = "true";
                    tResponse.message = "";
                    tResponse.data = result;
                }
                else if (chcData.searchSection == 8)
                {
                    var result = _chcReportData.RetrieveCHCReportsPostPNDTC(chcData);
                    tResponse.status = "true";
                    tResponse.message = "";
                    tResponse.data = result;
                }
                else if (chcData.searchSection == 9)
                {
                    var result = _chcReportData.RetrieveCHCReportsMTP(chcData);
                    tResponse.status = "true";
                    tResponse.message = "";
                    tResponse.data = result;
                }
                else
                {
                    tResponse.status = "false";
                    tResponse.message = "Please give some valid search section";
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
