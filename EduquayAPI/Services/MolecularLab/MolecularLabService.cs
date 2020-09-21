using EduquayAPI.Contracts.V1.Request.MolecularLab;
using EduquayAPI.Contracts.V1.Response;
using EduquayAPI.Contracts.V1.Response.MolecularLab;
using EduquayAPI.DataLayer.MolecularLab;
using EduquayAPI.Models.ANMSubjectRegistration;
using EduquayAPI.Models.MolecularLab;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Services.MolecularLab
{
    public class MolecularLabService : IMolecularLabService
    {
        private readonly IMolecularLabData _molecularLabReceiptData;

        public MolecularLabService(IMolecularLabDataFactory molecularLabDataFactory)
        {
            _molecularLabReceiptData = new MolecularLabDataFactory().Create();
        }

        public async Task<ServiceResponse> AddMolecularResult(AddMolecularResultRequest mrData)
        {
            var sResponse = new ServiceResponse();
            string message = CheckVal(mrData);
            try
            {
                if(message == "")
                {
                    var result = _molecularLabReceiptData.AddMolecularResult(mrData);
                    if (string.IsNullOrEmpty(result))
                    {
                        sResponse.Status = "false";
                        sResponse.Message = $"Unable to update the molecular result for this uniquesubjectid - {mrData.uniqueSubjectId}";
                        return sResponse;
                    }
                    else
                    {
                        sResponse.Status = "true";
                        sResponse.Message = result;
                        return sResponse;
                    }
                }
                else
                {
                    sResponse.Status = "false";
                    sResponse.Message = message;
                    return sResponse;
                }
            }
            catch (Exception e)
            {
                sResponse.Status = "false";
                sResponse.Message = $"Unable to update the molecular result - {e.Message}";
                return sResponse;
            }
        }

        public  string CheckVal(AddMolecularResultRequest mrData)
        {
            string msg = "";
            if (string.IsNullOrEmpty(mrData.uniqueSubjectId))
            {
                msg = "Uniquesubjectid is missing";
            }
            else if (string.IsNullOrEmpty(mrData.barcodeNo))
            {
                msg = "Barcode is missing";
            }
            else if (mrData.processSample == true)
            {
                if (mrData.diagnosisId <= 0)
                {
                    msg = "Invalid diagnosis Id";
                }
                else if (mrData.resultId <= 0)
                {
                    msg = "Invalid result Id";
                }
            }
            else if (mrData.processSample == false)
            {
                if (string.IsNullOrEmpty(mrData.remarks))
                {
                    msg = "Remark is missing";
                }
            }
            if (mrData.userId <= 0)
            {
                msg = "Invalid us er Id";
            }
            return msg;

        }

        public async Task<MolecularReceiptResponse> AddReceivedShipment(AddMolecularLabReceiptRequest mlRequest)
        {
            var rsResponse = new MolecularReceiptResponse();
            List<BarcodeSampleDetail> barcodes = new List<BarcodeSampleDetail>();
            var barcodeNo = "";
            var shipmentId = "";
            try
            {
                foreach (var sample in mlRequest.shipmentReceivedRequest)
                {
                    var slist = new BarcodeSampleDetail();
                    barcodeNo = sample.barcodeNo;
                    shipmentId = sample.shipmentId;
                    _molecularLabReceiptData.AddReceivedShipment(sample);
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

        public async Task<MolecularLabReceiptResponse> RetrieveMolecularLabReceipts(int MolecularLabId)
        {
            var molecularLabReceiptDetails = _molecularLabReceiptData.RetrieveMolecularLabReceipts(MolecularLabId);
            var molecularLabReceiptsResponse = new MolecularLabReceiptResponse();
            var molecularLabReceiptLog = new List<MolecularLabReceiptLog>();
            try
            {
                var shipmentId = "";
                foreach (var receipt in molecularLabReceiptDetails.ReceiptLog)
                {
                    var rLog = new MolecularLabReceiptLog();
                    if (shipmentId != receipt.shipmentId)
                    {
                        var receiptDetail = molecularLabReceiptDetails.ReceiptDetail.Where(sd => sd.shipmentId == receipt.id).ToList();
                        rLog.id = receipt.id;
                        rLog.shipmentId = receipt.shipmentId;
                        rLog.shipmentDateTime = receipt.shipmentDateTime;
                        rLog.centralLabName = receipt.centralLabName;
                        rLog.labTechnicianName = receipt.labTechnicianName;
                        rLog.molecularLabName = receipt.molecularLabName;
                        rLog.ReceiptDetail = receiptDetail;
                        shipmentId = receipt.shipmentId;
                        molecularLabReceiptLog.Add(rLog);
                    }
                }
                molecularLabReceiptsResponse.MolecularLabReceipts = molecularLabReceiptLog;
                molecularLabReceiptsResponse.Status = "true";
                molecularLabReceiptsResponse.Message = string.Empty;
            }
            catch (Exception e)
            {
                molecularLabReceiptsResponse.Status = "false";
                molecularLabReceiptsResponse.Message = e.Message;
            }
            return molecularLabReceiptsResponse;
        }

        public List<MolecularSubjectsForTest> RetriveSubjectForMolecularTest(int molecularLabId)
        {
            var allSubject = _molecularLabReceiptData.RetriveSubjectForMolecularTest(molecularLabId);
            return allSubject;
        }

        public List<MolecularReports> RetriveMolecularReports(MolecularReportRequest mrData)
        {
            var allSubject = _molecularLabReceiptData.RetriveMolecularReports(mrData);
            return allSubject;
        }

        public List<MolecularSampleStatus> RetrieveSampleStatus()
        {
            var allData = _molecularLabReceiptData.RetrieveSampleStatus();
            return allData;
        }
    }
}
