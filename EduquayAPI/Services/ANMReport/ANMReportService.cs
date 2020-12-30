using EduquayAPI.Contracts.V1.Request.ANMReports;
using EduquayAPI.Contracts.V1.Response.ANMReport;
using EduquayAPI.DataLayer.ANMReport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Services.ANMReport
{
    public class ANMReportService : IANMReportService
    {
        private readonly IANMReportData _anmReportData;
        public ANMReportService(IANMReportDataFactory anmReportDataFactory)
        {
            _anmReportData = new ANMReportDataFactory().Create();
        }
        public async Task<ANMReportResponse> RetriveANMReportsDetail(ANMReportRequest anmData)
        {
            var tResponse = new ANMReportResponse();
            try
            {
                if (anmData.searchSection == 1)
                {
                    var result = _anmReportData.RetrieveANMReportsSampling(anmData);
                    tResponse.status = "true";
                    tResponse.message = "";
                    tResponse.data = result;
                }
                else if (anmData.searchSection == 2)
                {
                    var result = _anmReportData.RetrieveANMReportsShipment(anmData);
                    tResponse.status = "true";
                    tResponse.message = "";
                    tResponse.data = result;
                }
                else if (anmData.searchSection == 3)
                {
                    var result = _anmReportData.RetrieveANMReportsTimeoutDamaged(anmData);
                    tResponse.status = "true";
                    tResponse.message = "";
                    tResponse.data = result;
                }
                else if (anmData.searchSection == 4)
                {
                    var result = _anmReportData.RetrieveANMReportsCHC(anmData);
                    tResponse.status = "true";
                    tResponse.message = "";
                    tResponse.data = result;
                }
                else if (anmData.searchSection == 5)
                {
                    var result = _anmReportData.RetrieveANMReportsHPLC(anmData);
                    tResponse.status = "true";
                    tResponse.message = "";
                    tResponse.data = result;
                }
                else if (anmData.searchSection == 6)
                {
                    var result = _anmReportData.RetrieveANMReportsPrePNDTC(anmData);
                    tResponse.status = "true";
                    tResponse.message = "";
                    tResponse.data = result;
                }
                else if (anmData.searchSection == 7)
                {
                    var result = _anmReportData.RetrieveANMReportsPNDT(anmData);
                    tResponse.status = "true";
                    tResponse.message = "";
                    tResponse.data = result;
                }
                else if (anmData.searchSection == 8)
                {
                    var result = _anmReportData.RetrieveANMReportsPostPNDTC(anmData);
                    tResponse.status = "true";
                    tResponse.message = "";
                    tResponse.data = result;
                }
                else if (anmData.searchSection == 9)
                {
                    var result = _anmReportData.RetrieveANMReportsMTP(anmData);
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
