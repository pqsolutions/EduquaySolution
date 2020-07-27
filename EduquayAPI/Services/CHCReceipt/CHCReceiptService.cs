using EduquayAPI.Contracts.V1.Request.CHCReceiptProcessing;
using EduquayAPI.Contracts.V1.Response.CHCReceipt;
using EduquayAPI.DataLayer.CHCReceipt;
using EduquayAPI.Models.ANMSubjectRegistration;
using EduquayAPI.Models.CHCReceipt;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Services.CHCReceipt
{
    public class CHCReceiptService : ICHCReceiptService
    {
        private readonly ICHCReceiptData _chcReceiptData;

        public CHCReceiptService(ICHCReceiptDataFactory chcReceiptDataFactory)
        {
            _chcReceiptData = new CHCReceiptDataFactory().Create();
        }

        public async Task<CHCReceivedShipmentResponse> AddReceivedShipment(AddCHCShipmentReceiptRequest chcSRRequest)
        {
            CHCReceivedShipmentResponse rsResponse = new CHCReceivedShipmentResponse();
            List<BarcodeSampleDetail> barcodes = new List<BarcodeSampleDetail>();
            var barcodeNo = "";
            var shipmentId = "";
            try
            {
                //var msg = CheckValidation(chcSRRequest);
                //if (msg == "")
                //{
                    foreach (var sample in chcSRRequest.shipmentReceivedRequest)
                    {
                        var slist = new BarcodeSampleDetail();
                        barcodeNo = sample.barcodeNo;
                        shipmentId = sample.shipmentId;
                        _chcReceiptData.AddReceivedShipment(sample);
                        slist.barcodeNo = sample.barcodeNo;
                        barcodes.Add(slist);
                    }
                    rsResponse.Status = "true";
                    rsResponse.Message = barcodes.Count + " Samples received successfully in shipment id: " + shipmentId;
                    rsResponse.Barcodes = barcodes;
                //}
                //else
                //{

                //}
            }
            catch (Exception e)
            {
                rsResponse.Status = "false";
                rsResponse.Message = "Partially " + barcodes.Count + " samples received successfully, From this (" + barcodeNo + ") onwards not received. " + e.Message;
                rsResponse.Barcodes = barcodes;
            }
            return rsResponse;
        }

        public string CheckValidation(AddCHCShipmentReceiptRequest chcSRRequest)
        {
            var message = "";
            var count = 0;
            foreach (var sample in chcSRRequest.shipmentReceivedRequest)
            {
                count += 1;
                if (sample.receivedDate == "")
                {
                    message = "No: " + count + " sample received date is missing";
                }

                if (sample.proceesingDateTime == "")
                {
                    message = "No: " + count + " sample processing date and time is missing";
                }
            }
            return message;
        }

        public List<CBCSSTest> RetrieveCBC(int testingCHCId)
        {
            var cbc = _chcReceiptData.RetrieveCBC(testingCHCId);
            return cbc;
        }

        public List<CBCSSTest> RetrieveSST(int testingCHCId)
        {
            var sst = _chcReceiptData.RetrieveSST(testingCHCId);
            return sst;
        }

        public async Task<CHCReceiptResponse> RetrieveCHCReceipts(int testingCHCId)
        {
            var chcReceiptDetails = _chcReceiptData.RetrieveCHCReceipts(testingCHCId);
            var chcReceiptsResponse = new CHCReceiptResponse();
            var chcReceiptLog = new List<Contracts.V1.Response.CHCReceipt.CHCReceiptLog>();
            try
            {
                var shipmentId = "";
                foreach (var receipt in chcReceiptDetails.ReceiptLog)
                {
                    var rLog = new Contracts.V1.Response.CHCReceipt.CHCReceiptLog();
                    if (shipmentId != receipt.shipmentId)
                    {
                        var receiptDetail = chcReceiptDetails.ReceiptDetail.Where(sd => sd.shipmentId == receipt.id).ToList();
                        rLog.id = receipt.id;
                        rLog.shipmentId = receipt.shipmentId;
                        rLog.senderName = receipt.senderName;
                        rLog.sendingLocation = receipt.sendingLocation;
                        rLog.shipmentDateTime = receipt.shipmentDateTime;
                        rLog.collectionCHC = receipt.collectionCHC;
                        rLog.ilrPoint = receipt.ilrPoint;
                        rLog.riPoint = receipt.riPoint;
                        rLog.shipmentFromId = receipt.shipmentFromId;
                        rLog.shipmentFrom = receipt.shipmentFrom;
                        rLog.testingCHC = receipt.testingCHC;
                        rLog.ReceiptDetail = receiptDetail;
                        shipmentId = receipt.shipmentId;
                        chcReceiptLog.Add(rLog);
                    }
                }
                chcReceiptsResponse.CHCReceipts = chcReceiptLog;
                chcReceiptsResponse.Status = "true";
                chcReceiptsResponse.Message = string.Empty;
            }
            catch (Exception e)
            {
                chcReceiptsResponse.Status = "false";
                chcReceiptsResponse.Message = e.Message;
            }
            return chcReceiptsResponse;
        }

        public async Task<CBCSSTAddResponse> AddCBCTest(CBCTestAddRequest cbcRequest)
        {
            CBCSSTAddResponse rsResponse = new CBCSSTAddResponse();
            List<BarcodeSampleDetail> barcodes = new List<BarcodeSampleDetail>();
            var barcodeNo = "";
            try
            {
                foreach (var sample in cbcRequest.CBCTestRequest)
                {
                    var slist = new BarcodeSampleDetail();
                    barcodeNo = sample.barcodeNo;
                    _chcReceiptData.AddCBCTest(sample);
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

        public async Task<CBCSSTAddResponse> AddSSTest(SSTestAddRequest ssRequest)
        {
            CBCSSTAddResponse rsResponse = new CBCSSTAddResponse();
            List<BarcodeSampleDetail> barcodes = new List<BarcodeSampleDetail>();
            var barcodeNo = "";
            try
            {
                foreach (var sample in ssRequest.SSTestRequest)
                {
                    var slist = new BarcodeSampleDetail();
                    barcodeNo = sample.barcodeNo;
                    _chcReceiptData.AddSSTest(sample);
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

        public List<CHCCentralPickandPackSample> RetrievePickandPack(int testingCHCId)
        {
            var pickpack = _chcReceiptData.RetrievePickandPack(testingCHCId);
            return pickpack;
        }

        public async  Task<CHCShipmentResponse> AddCHCShipment(AddCHCShipmentRequest csData)
        {
            var shipmentResponse = new CHCShipmentResponse();
            try
            {
                var msg = checkCHCValidation(csData);
                if (msg == "")
                {
                    var shipmentDetails = _chcReceiptData.AddCHCShipment(csData);
                    foreach (var shipment in shipmentDetails)
                    {
                        shipmentResponse.Shipment = shipment;

                        if (!string.IsNullOrEmpty(shipmentResponse.Shipment.shipmentId))
                        {
                            shipmentResponse.Status = "true";
                            shipmentResponse.Message = "";
                        }
                        else
                        {
                            shipmentResponse.Status = "false";
                            shipmentResponse.Message = shipmentResponse.Shipment.errorMessage;
                        }
                    }
                }
                else
                {
                    shipmentResponse.Status = "false";
                    shipmentResponse.Message = msg;
                }
            }
            catch (Exception e)
            {
                shipmentResponse.Status = "false";
                shipmentResponse.Message = e.Message;
            }
            return shipmentResponse;
        }

        public string checkCHCValidation(AddCHCShipmentRequest csData)
        {
            var message = "";
            if (csData.barcodeNo == "")
            {
                message = "Barcode is missing";
            }
            if (csData.labTechnicianName  == "")
            {
                message = "Lab Technician name is missing";
            }
            else if (csData.chcUserId <= 0)
            {
                message = "Invalid chc user id";
            }
            else if (csData.testingCHCId <= 0)
            {
                message = "Invalid testing CHC id";
            }
            else if (csData.receivingCentralLabId  <= 0)
            {
                message = "Invalid central lab id";
            }
            else if (csData.logisticsProviderId <= 0)
            {
                message = "Invalid logistics provider id";
            }
            else if (csData.deliveryExecutiveName == "")
            {
                message = "Delivery executive name is missing";
            }
            if (csData.executiveContactNo == "")
            {
                message = "Executive contactno is missing";
            }
            return message;
        }

        public async Task<CHCShipmentLogsResponse> RetrieveCHCShipmentLogs(int testingCHCId)
        {
            var shipmentDetails = _chcReceiptData.RetrieveCHCShipmentLog(testingCHCId);
            var shipmentLogResponse = new CHCShipmentLogsResponse();
            var shipmentLogs = new List<CHCShipmentLog>();
            try
            {
                var shipmentId = "";
                foreach (var shipment in shipmentDetails.ShipmentLog)
                {
                    var shipmentLog = new CHCShipmentLog();
                    if (shipmentId != shipment.shipmentId)
                    {
                        var shipmentDetail = shipmentDetails.ShipmentSubjectDetail.Where(sd => sd.shipmentId == shipment.id).ToList();
                        shipmentLog.id = shipment.id;
                        shipmentLog.shipmentId = shipment.shipmentId;
                        shipmentLog.receivingCentralLab = shipment.receivingCentralLab;
                        shipmentLog.testingCHC = shipment.testingCHC;
                        shipmentLog.logisticsProviderName = shipment.logisticsProviderName;
                        shipmentLog.contactNo = shipment.contactNo;
                        shipmentLog.deliveryExecutiveName = shipment.deliveryExecutiveName;
                        shipmentLog.labTechnicianName = shipment.labTechnicianName;
                        shipmentLog.shipmentDateTime = shipment.shipmentDateTime;
                        shipmentLog.SamplesDetail = shipmentDetail;
                        shipmentId = shipment.shipmentId;
                        shipmentLogs.Add(shipmentLog);
                    }
                }
                shipmentLogResponse.ShipmentLogs = shipmentLogs;
                shipmentLogResponse.Status = "true";
                shipmentLogResponse.Message = string.Empty;
            }
            catch (Exception e)
            {
                shipmentLogResponse.Status = "false";
                shipmentLogResponse.Message = e.Message;
            }
            return shipmentLogResponse;
        }
    }
}
