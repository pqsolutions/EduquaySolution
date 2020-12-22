using EduquayAPI.Contracts.V1.Request.NHMReport;
using EduquayAPI.Contracts.V1.Response.Reports;
using EduquayAPI.DataLayer.NHMReport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Services.NHMReport
{
    public class NHMReportService : INHMReportService
    {
        private readonly INHMReportData _nhmReportData;

        public NHMReportService(INHMReportDataFactory nhmReportDataFactory)
        {
            _nhmReportData = new NHMReportDataFactory().Create();
        }
        public async Task<NHMReportResponse> RetriveNHMReportsDetail(NHMReportsRequest nhmData)
        {
            var tResponse = new NHMReportResponse();
            try
            {
                if (nhmData.searchSection == 1)
                {
                    var result = _nhmReportData.RetrieveNHMReportsSampling(nhmData);
                    tResponse.status = "true";
                    tResponse.message = "";
                    tResponse.data = result;
                }
                else if (nhmData.searchSection == 2)
                {
                    var result = _nhmReportData.RetrieveNHMReportsCHCDetails(nhmData);
                    tResponse.status = "true";
                    tResponse.message = "";
                    tResponse.data = result;
                }
                else if (nhmData.searchSection == 3)
                {
                    var result = _nhmReportData.RetrieveNHMReportsHPLCPathoDetails(nhmData);
                    tResponse.status = "true";
                    tResponse.message = "";
                    tResponse.data = result;
                }
                else if (nhmData.searchSection == 4)
                {
                    var result = _nhmReportData.RetrieveNHMReportsSpouseRegDetails(nhmData);
                    tResponse.status = "true";
                    tResponse.message = "";
                    tResponse.data = result;
                }
                else if (nhmData.searchSection == 5)
                {
                    var result = _nhmReportData.RetrieveNHMReportsPrePNDTCdetails(nhmData);
                    tResponse.status = "true";
                    tResponse.message = "";
                    tResponse.data = result;
                }
                else if (nhmData.searchSection == 6)
                {
                    var result = _nhmReportData.RetrieveNHMReportsPNDTDetails(nhmData);
                    tResponse.status = "true";
                    tResponse.message = "";
                    tResponse.data = result;
                }
                else if (nhmData.searchSection == 7)
                {
                    var result = _nhmReportData.RetrieveNHMReportsPostPNDTCDetails(nhmData);
                    tResponse.status = "true";
                    tResponse.message = "";
                    tResponse.data = result;
                }
                else if (nhmData.searchSection == 8)
                {
                    var result = _nhmReportData.RetrieveNHMReportsMTPDetails(nhmData);
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
