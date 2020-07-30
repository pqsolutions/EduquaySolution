using EduquayAPI.Contracts.V1.Request.CentralLab;
using EduquayAPI.Contracts.V1.Response.CentralLab;
using EduquayAPI.DataLayer.CentralLab;
using EduquayAPI.Models.ANMSubjectRegistration;
using EduquayAPI.Models.CentralLab;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Services.CentralLab
{
    public class CentralLabService : ICentralLabService
    {
        private readonly ICentralLabData _centralLabReceiptData;

        public CentralLabService(ICentralLabDataFactory centralLabDataFactory)
        {
            _centralLabReceiptData = new CentralLabDataFactory().Create();
        }

        public async Task<CentralLabReceivedShipmentResponse> AddReceivedShipment(AddCentralLabShipmentReceiptRequest clRequest)
        {
            var rsResponse = new CentralLabReceivedShipmentResponse();
            List<BarcodeSampleDetail> barcodes = new List<BarcodeSampleDetail>();
            var barcodeNo = "";
            var shipmentId = "";
            try
            {
                foreach (var sample in clRequest.shipmentReceivedRequest)
                {
                    var slist = new BarcodeSampleDetail();
                    barcodeNo = sample.barcodeNo;
                    shipmentId = sample.shipmentId;
                    _centralLabReceiptData.AddReceivedShipment(sample);
                    slist.barcodeNo = sample.barcodeNo;
                    barcodes.Add(slist);
                }
                rsResponse.Status = "true";
                rsResponse.Message = barcodes.Count + " Samples received successfully in shipment id: " + shipmentId;
                rsResponse.Barcodes = barcodes;
            }
            catch (Exception e)
            {
                rsResponse.Status = "false";
                rsResponse.Message = "Partially " + barcodes.Count + " samples received successfully, From this (" + barcodeNo + ") onwards not received. " + e.Message;
                rsResponse.Barcodes = barcodes;
            }
            return rsResponse;
        }

        public List<HPLCTest> RetrieveHPLC(int CentralLabId)
        {
            var cbc = _centralLabReceiptData.RetrieveHPLC(CentralLabId);
            return cbc;
        }

        public async Task<CentralLabReceiptResponse> RetrieveCentralLabReceipts(int CentralLabId)
        {
            var centralLabReceiptDetails = _centralLabReceiptData.RetrieveCentralLabReceipts(CentralLabId);
            var centralLabReceiptsResponse = new CentralLabReceiptResponse();
            var centralLabReceiptLog = new List<CentralLabReceiptLog>();
            try
            {
                var shipmentId = "";
                foreach (var receipt in centralLabReceiptDetails.ReceiptLog)
                {
                    var rLog = new CentralLabReceiptLog();
                    if (shipmentId != receipt.shipmentId)
                    {
                        var receiptDetail = centralLabReceiptDetails.ReceiptDetail.Where(sd => sd.shipmentId == receipt.id).ToList();
                        rLog.id = receipt.id;
                        rLog.shipmentId = receipt.shipmentId;
                        rLog.shipmentDateTime = receipt.shipmentDateTime;
                        rLog.district = receipt.district;
                        rLog.centralLabName = receipt.centralLabName;
                        rLog.labTechnicianName = receipt.labTechnicianName;
                        rLog.testingCHC = receipt.testingCHC;
                        rLog.ReceiptDetail = receiptDetail;
                        shipmentId = receipt.shipmentId;
                        centralLabReceiptLog.Add(rLog);
                    }
                }
                centralLabReceiptsResponse.CentralLabReceipts = centralLabReceiptLog;
                centralLabReceiptsResponse.Status = "true";
                centralLabReceiptsResponse.Message = string.Empty;
            }
            catch (Exception e)
            {
                centralLabReceiptsResponse.Status = "false";
                centralLabReceiptsResponse.Message = e.Message;
            }
            return centralLabReceiptsResponse;
        }

        public  async Task<HPLCAddResponse> AddHPLCTest(HPLCTestAddRequest hplcRequest)
        {
            var rsResponse = new HPLCAddResponse();
            List<BarcodeSampleDetail> barcodes = new List<BarcodeSampleDetail>();
            var barcodeNo = "";
            try
            {
                foreach (var sample in hplcRequest.HPLCTestRequest)
                {
                    var slist = new BarcodeSampleDetail();
                    barcodeNo = sample.barcodeNo;
                    _centralLabReceiptData.AddHPLCTest(sample);
                    slist.barcodeNo = sample.barcodeNo;
                    barcodes.Add(slist);
                }
                rsResponse.Status = "true";
                rsResponse.Message = barcodes.Count + " samples tested successfully";
                rsResponse.Barcodes = barcodes;

            }
            catch (Exception e)
            {
                rsResponse.Status = "false";
                rsResponse.Message = "Partially " + barcodes.Count + " samples tested successfully, From this (" + barcodeNo + ") onwards not tested. " + e.Message;
                rsResponse.Barcodes = barcodes;
            }
            return rsResponse;
        }
    }
}
