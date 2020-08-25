﻿using EduquayAPI.Contracts.V1.Request.CentralLab;
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

        public List<CentralLabPickandPack> RetrievePickandPack(int centralLabId)
        {
            var pickpack = _centralLabReceiptData.RetrievePickandPack(centralLabId);
            return pickpack;
        }

        public  async Task<CentralLabShipmentResponse> AddCentralLabShipment(AddCentralLabShipmentRequest csData)
        {
            var shipmentResponse = new CentralLabShipmentResponse();
            try
            {
                var msg = checkCHCValidation(csData);
                if (msg == "")
                {
                    var shipmentDetails = _centralLabReceiptData.AddCentralLabShipment(csData);
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

        public string checkCHCValidation(AddCentralLabShipmentRequest csData)
        {
            var message = "";
            if (csData.barcodeNo == "")
            {
                message = "Barcode is missing";
            }
            if (csData.labTechnicianName == "")
            {
                message = "Lab Technician name is missing";
            }
            else if (csData.centralLabId <= 0)
            {
                message = "Invalid central lab id";
            }
            else if (csData.centralLabUserId <= 0)
            {
                message = "Invalid central lab user id";
            }
            else if (csData.centralLabLocation == "")
            {
                message = "Centrallab location is missing";
            }
            else if (csData.receivingMolecularLabId <= 0)
            {
                message = "Invalid molecular lab id";
            }
            else if (csData.logisticsProviderName == "")
            {
                message = "Logistics provider name is missing";
            }
            else if (csData.deliveryExecutiveName == "")
            {
                message = "Delivery executive name is missing";
            }
            else  if (csData.executiveContactNo == "")
            {
                message = "Executive contactno is missing";
            }
            else if (csData.dateOfShipment == "")
            {
                message = "Shipment date is missing";
            }
            else if (csData.timeOfShipment == "")
            {
                message = "Shipment time is missing";
            }
            return message;
        }

        public async Task<CentralLabShipmentLogsResponse> RetrieveCentralLabShipmentLog(int centralLabId)
        {
            var shipmentDetails = _centralLabReceiptData.RetrieveCentralLabShipmentLog(centralLabId);
            var shipmentLogResponse = new CentralLabShipmentLogsResponse();
            var shipmentLogs = new List<CLShipmentLog>();
            try
            {
                var shipmentId = "";
                foreach (var shipment in shipmentDetails.ShipmentLog)
                {
                    var shipmentLog = new CLShipmentLog();
                    if (shipmentId != shipment.shipmentId)
                    {
                        var shipmentDetail = shipmentDetails.ShipmentSubjectDetail.Where(sd => sd.shipmentId == shipment.id).ToList();
                        shipmentLog.id = shipment.id;
                        shipmentLog.shipmentId = shipment.shipmentId;
                        shipmentLog.receivingMolecularLab = shipment.receivingMolecularLab;
                        shipmentLog.centralLabName = shipment.centralLabName;
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