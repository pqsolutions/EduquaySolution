using EduquayAPI.Contracts.V1.Request.ANMCHCShipment;
using EduquayAPI.Contracts.V1.Response.ANMCHCShipment;
using EduquayAPI.DataLayer.ANMCHCShipment;
using EduquayAPI.Models.ANMCHCShipment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Services.ANMCHCShipment
{
    public class ANMCHCShipmentService : IANMCHCShipmentService
    {
        private readonly IANMCHCShipmentData _anmchcShipmentData;

        public ANMCHCShipmentService(IANMCHCShipmentDataFactory anmchcShipmentDataFactory)
        {
            _anmchcShipmentData = new ANMCHCShipmentDataFactory().Create();
        }

        public async Task<AddShipmentResponse> AddANMCHCShipment(AddShipmentANMCHCRequest asData)
        {
            var shipmentResponse = new AddShipmentResponse();
            try
            {
                var msg = checkANMValidation(asData);
                if (msg == "")
                {
                    var shipmentDetails = _anmchcShipmentData.AddANMCHCShipment(asData);
                    foreach (var shipment in shipmentDetails)
                    {
                        shipmentResponse.Status = "true";
                        shipmentResponse.Message = "";
                        shipmentResponse.Shipment = shipment;
                    }
                }
                else
                {
                    shipmentResponse.Status = "false";
                    shipmentResponse.Message = msg;
                }
            }
            catch(Exception e)
            {
                shipmentResponse.Status = "false";
                shipmentResponse.Message = e.Message;
            }
            return shipmentResponse;
        }

        public string checkANMValidation(AddShipmentANMCHCRequest asData)
        {
            var message = "";
            if (asData.barcodeNo == "")
            {
                message = "Barcodes Should not Empty";
            }
            else if (asData.anmId <= 0)
            {
                message = "Invalid ANM Id";
            }
            else if (asData.testingCHCId <= 0)
            {
                message = "Invalid Testing CHC Id";
            }
            else if (asData.riId <= 0)
            {
                message = "Invalid RI Id";
            }
            else if (asData.ilrId <= 0)
            {
                message = "Invalid ILR Id";
            }
            else if (asData.avdId <= 0)
            {
                message = "Invalid AVD Id";
            }
            if (asData.avdContactNo == "")
            {
                message = "AVD ContactNo Should not Empty";
            }
            return message;
        }

        public string checkCHCValidation(AddShipmentCHCCHCRequest csData)
        {
            var message = "";
            if (csData.barcodeNo == "")
            {
                message = "Barcodes Should not Empty";
            }
            else if (csData.chcUserId <= 0)
            {
                message = "Invalid chc user Id";
            }
            else if (csData.testingCHCId <= 0)
            {
                message = "Invalid Testing CHC Id";
            }
            else if (csData.collectionCHCId <= 0)
            {
                message = "Invalid Collection CHC Id";
            }
            else if (csData.logisticsProviderId <= 0)
            {
                message = "Invalid Logistics Provider Id";
            }
            else if (csData.deliveryExecutiveName =="")
            {
                message = "Delivery Executive Name Should not Empty";
            }
            if (csData.executiveContactNo == "")
            {
                message = "Executive ContactNo Should not Empty";
            }
            return message;
        }


        public async Task<AddShipmentResponse> AddCHCCHCShipment(AddShipmentCHCCHCRequest csData)
        {
            var shipmentResponse = new AddShipmentResponse();
            try
            {
                var msg = checkCHCValidation(csData);
                if (msg == "")
                {
                    var shipmentDetails = _anmchcShipmentData.AddCHCCHCShipment(csData);
                    foreach (var shipment in shipmentDetails)
                    {
                        shipmentResponse.Status = "true";
                        shipmentResponse.Message = "";
                        shipmentResponse.Shipment = shipment;
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

        public async Task<ANMCHCShipmentLogsResponse> RetrieveShipmentLogs(ANMCHCShipmentLogRequest asData)
        {
            var shipmentDetails = _anmchcShipmentData.RetrieveShipmentLog(asData);
            var shipmentLogResponse = new ANMCHCShipmentLogsResponse();
            var shipmentLogs = new List<ShipmentLogs>();
            try
            {
               var shipmentId = "";
                foreach (var shipment in shipmentDetails.ShipmentLog)
                {
                    var shipmentLog = new ShipmentLogs();
                    if (shipmentId != shipment.shipmentId)
                    {
                        var shipmentDetail = shipmentDetails.ShipmentSubjectDetail.Where(sd => sd.shipmentId == shipment.id).ToList();
                        shipmentLog.id = shipment.id;
                        shipmentLog.shipmentId = shipment.shipmentId;
                        shipmentLog.anmName = shipment.anmName;
                        shipmentLog.testingCHC = shipment.testingCHC;
                        shipmentLog.avdName = shipment.avdName;
                        shipmentLog.contactNo = shipment.contactNo;
                        shipmentLog.ilrPoint = shipment.ilrPoint;
                        shipmentLog.riPoint = shipment.riPoint;
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

        public async Task<CHCCHCShipmentLogsResponse> RetrieveCHCShipmentLogs(ANMCHCShipmentLogRequest asData)
        {
            var shipmentDetails = _anmchcShipmentData.RetrieveCHCShipmentLog(asData);
            var shipmentLogResponse = new CHCCHCShipmentLogsResponse();
            var shipmentLogs = new List<CHC2CHCShipmentLog>();
            try
            {
                var shipmentId = "";
                foreach (var shipment in shipmentDetails.ShipmentLog)
                {
                    var shipmentLog = new CHC2CHCShipmentLog();
                    if (shipmentId != shipment.shipmentId)
                    {
                        var shipmentDetail = shipmentDetails.ShipmentSubjectDetail.Where(sd => sd.shipmentId == shipment.id).ToList();
                        shipmentLog.id = shipment.id;
                        shipmentLog.shipmentId = shipment.shipmentId;
                        shipmentLog.collectionCHCName = shipment.collectionCHCName;
                        shipmentLog.testingCHC = shipment.testingCHC;
                        shipmentLog.logisticsProviderName = shipment.logisticsProviderName;
                        shipmentLog.contactNo = shipment.contactNo;
                        shipmentLog.deliveryExecutiveName = shipment.deliveryExecutiveName;
                        shipmentLog.chcLabTechnicianName = shipment.chcLabTechnicianName;
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
