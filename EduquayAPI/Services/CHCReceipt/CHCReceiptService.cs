using EduquayAPI.Contracts.V1.Request.CHCReceiptProcessing;
using EduquayAPI.Contracts.V1.Response.CHCReceipt;
using EduquayAPI.DataLayer;
using EduquayAPI.DataLayer.CHCReceipt;
using EduquayAPI.Models.ANMSubjectRegistration;
using EduquayAPI.Models.CHCReceipt;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace EduquayAPI.Services.CHCReceipt
{
    public class CHCReceiptService : ICHCReceiptService
    {
        private readonly ICHCReceiptData _chcReceiptData;
        private readonly ISampleCollectionData _sampleCollectionData;
        private readonly IConfiguration _config;

        public CHCReceiptService(ICHCReceiptDataFactory chcReceiptDataFactory, ISampleCollectionDataFactory sampleCollectionDataFactory, IConfiguration config)
        {
            _chcReceiptData = new CHCReceiptDataFactory().Create();
            _sampleCollectionData = new SampleCollectionDataFactory().Create();
            _config = config;
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

                        if (sample.sampleDamaged == true || sample.sampleTimeout == true)
                        {
                            var smsSampleDetails = _sampleCollectionData.FetchSMSSamplesByBarcode(sample.barcodeNo);
                            if (!string.IsNullOrEmpty(smsSampleDetails.barcodeNo))
                            {
                                var subjectMobileNo = smsSampleDetails.subjectMobileNo;
                                var subjectName = smsSampleDetails.subjectName;
                                var anmName = smsSampleDetails.anmName;
                                var anmMobileNo = smsSampleDetails.anmMobileNo;
                                barcodeNo = smsSampleDetails.barcodeNo;

                                var smsToANMURL = _config.GetSection("RegistrationSamplingOdiyaSMStoSubject").GetSection("SMStoANMSampleTimeoutDamaged").Value;
                                var smsURLANMLink = smsToANMURL.Replace("#MobileNo", subjectMobileNo).Replace("#SubjectName", subjectName).Replace("#BarcodeNo", barcodeNo).Replace("#ANMName", anmName).Replace("#ANMMobile", anmMobileNo);
                                GetResponse(smsURLANMLink);

                                var smsToSubjectURL = _config.GetSection("RegistrationSamplingOdiyaSMStoSubject").GetSection("SMStoSubjectSampleTimeoutDamaged").Value;
                                var smsURLSubjectLink = smsToSubjectURL.Replace("#MobileNo", subjectMobileNo).Replace("#SubjectName", subjectName).Replace("#BarcodeNo", barcodeNo).Replace("#ANMName", anmName).Replace("#ANMMobile", anmMobileNo);
                                GetResponse(smsURLSubjectLink);
                            }
                        }

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
        public static string GetResponse(string sURL)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(sURL);
            request.MaximumAutomaticRedirections = 4;
            request.Credentials = CredentialCache.DefaultCredentials;
            try
            {
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream receiveStream = response.GetResponseStream();
                StreamReader readStream = new StreamReader(receiveStream, Encoding.UTF8);
                string sResponse = readStream.ReadToEnd();
                response.Close();
                readStream.Close();
                return sResponse;
            }
            catch
            {
                return "";
            }
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
            else  if (csData.executiveContactNo == "")
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

        public List<CHCSampleStatus> RetrieveSampleStatus()
        {
            var allData = _chcReceiptData.RetrieveSampleStatus();
            return allData;
        }

        public List<CHCSampleStatusReports> RetriveCHCReports(CHCReportsRequest mrData)
        {
            var allSubject = _chcReceiptData.RetriveCHCReports(mrData);
            return allSubject;
        }

        public List<CBCTest> RetrieveCBCTest(int testingCHCId)
        {
            var cbc = _chcReceiptData.RetrieveCBCTest(testingCHCId);
            return cbc;
        }

        public async Task<AddCBCResponse> AddCBC(AddCBCTestResultRequest cbcData)
        {
            var cbcResponse = new AddCBCResponse();
            try
            {
                if (cbcData.confirmStatus <= 0)
                {
                    cbcResponse.Status = "false";
                    cbcResponse.Message= "Invalid submit request";
                }
                else if (cbcData.testingCHCId <= 0)
                {
                    cbcResponse.Status = "false";
                    cbcResponse.Message = "Invalid testing CHC id";
                }
                else if (cbcData.testedId <= 0)
                {
                    cbcResponse.Status = "false";
                    cbcResponse.Message = "Invalid tested  id";
                }
                else if (cbcData.subjectId == "")
                {
                    cbcResponse.Status = "false";
                    cbcResponse.Message = "Subject Id is missing";
                }
                else
                {
                    var msgs =  _chcReceiptData.AddCBCTestResult(cbcData);
                    cbcResponse.Status = "true";
                    cbcResponse.Message = msgs.msg;
                }
            }
            catch (Exception e)
            {
                cbcResponse.Status = "false";
                cbcResponse.Message = e.Message;
            }
            return cbcResponse;
        }

        public async Task<CHCReciptReportResponse> RetriveCHCReciptReportsDetail(CHCSampleReportRequest rData)
        {
            var tResponse = new CHCReciptReportResponse();
            try
            {
                if (rData.searchSection == 1)
                {
                    var result = _chcReceiptData.RetrieveSampleRecpReport(rData);
                    tResponse.status = "true";
                    tResponse.message = "";
                    tResponse.data = result;
                }
                else if (rData.searchSection == 2)
                {
                    var result = _chcReceiptData.RetrieveTimeoutDamagedReport(rData);
                    tResponse.status = "true";
                    tResponse.message = "";
                    tResponse.data = result;
                }
                else if (rData.searchSection == 3)
                {
                    var result = _chcReceiptData.RetrieveCBCPendingReport(rData);
                    tResponse.status = "true";
                    tResponse.message = "";
                    tResponse.data = result;
                }
                else if (rData.searchSection == 4)
                {
                    var result = _chcReceiptData.RetrieveSSTPendingReport(rData);
                    tResponse.status = "true";
                    tResponse.message = "";
                    tResponse.data = result;
                }
                else if (rData.searchSection == 5)
                {
                    var result = _chcReceiptData.RetrievePositiveReport(rData);
                    tResponse.status = "true";
                    tResponse.message = "";
                    tResponse.data = result;
                }
                else if (rData.searchSection == 6)
                {
                    var result = _chcReceiptData.RetrieveNegativeReport(rData);
                    tResponse.status = "true";
                    tResponse.message = "";
                    tResponse.data = result;
                }
                else if (rData.searchSection == 7)
                {
                    var result = _chcReceiptData.RetrieveShipmentStatusReport(rData);
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
