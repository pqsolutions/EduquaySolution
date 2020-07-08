using EduquayAPI.Contracts.V1.Request.CHCReceiptProcessing;
using EduquayAPI.Contracts.V1.Response.CHCReceipt;
using EduquayAPI.DataLayer.CHCReceipt;
using EduquayAPI.Models.ANMSubjectRegistration;
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
                    rsResponse.Status = true;
                    rsResponse.Message = barcodes.Count + " Samples received successfully in Shipment ID: " + shipmentId;
                    rsResponse.Barcodes = barcodes;
                //}
                //else
                //{

                //}
            }
            catch (Exception e)
            {
                rsResponse.Status = false;
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
                    message = "No: " + count + " sample Received Date Should not Empty";
                }

                if (sample.proceesingDateTime == "")
                {
                    message = "No: " + count + " sample Processing Date and Time Should not Empty";
                }
            }
            return message;
        }
        public async Task<CHCReceiptResponse> RetrieveCHCReceipts(int testingCHCId)
        {
            var chcReceiptDetails = _chcReceiptData.RetrieveCHCReceipts(testingCHCId);
            var chcReceiptsResponse = new CHCReceiptResponse();
            var chcReceiptLog = new List<CHCReceiptLog>();
            try
            {
                var shipmentId = "";
                foreach (var receipt in chcReceiptDetails.ReceiptLog)
                {
                    var rLog = new CHCReceiptLog();
                    if (shipmentId != receipt.shipmentId)
                    {
                        var receiptDetail = chcReceiptDetails.ReceiptDetail.Where(sd => sd.shipmentId == receipt.id).ToList();
                        rLog.id = receipt.id;
                        rLog.shipmentId = receipt.shipmentId;
                        rLog.senderName = receipt.senderName;
                        rLog.sendingLocation = receipt.sendingLocation;
                        rLog.shipmentDateTime = receipt.shipmentDateTime;
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
    }
}
