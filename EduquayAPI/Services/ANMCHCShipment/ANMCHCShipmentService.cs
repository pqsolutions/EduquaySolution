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

        public string checkANMValidation(AddShipmentANMCHCRequest asData)
        {
            var message = "";
            if (asData.barcodeNo == "")
            {
                message = "Barcode is missing";
            }
            else if (asData.anmId <= 0)
            {
                message = "Invalid ANM id";
            }
            else if (asData.testingCHCId <= 0)
            {
                message = "Invalid testing CHC id";
            }
            else if (asData.riId <= 0)
            {
                message = "Invalid RI id";
            }
            else if (asData.ilrId <= 0)
            {
                message = "Invalid ILR id";
            }
            else if (asData.avdId <= 0)
            {
                message = "Invalid AVD id";
            }
            if (asData.avdContactNo == "")
            {
                message = "AVD contactno is missing";
            }
            return message;
        }

        public string checkCHCValidation(AddShipmentCHCCHCRequest csData)
        {
            var message = "";
            if (csData.barcodeNo == "")
            {
                message = "Barcode is missing";
            }
            else if (csData.chcUserId <= 0)
            {
                message = "Invalid chc user id";
            }
            else if (csData.testingCHCId <= 0)
            {
                message = "Invalid testing CHC id";
            }
            else if (csData.collectionCHCId <= 0)
            {
                message = "Invalid collection CHC id";
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

                    if (shipmentId != shipment.shipmentId)
                    {
                        var shipmentLog = new ShipmentLogs();
                        var shipmentDetail = shipmentDetails.ShipmentSubjectDetail.Where(sd => sd.shipmentId == shipment.id).ToList();
                        shipmentLog.id = shipment.id;
                        shipmentLog.shipmentId = shipment.shipmentId;
                        shipmentLog.anmName = shipment.anmName;
                        shipmentLog.testingCHC = shipment.testingCHC;
                        shipmentLog.avdName = shipment.avdName;
                        shipmentLog.contactNo = shipment.contactNo;
                        shipmentLog.alternateAVD = shipment.alternateAVD;
                        shipmentLog.alternateAVDContactNo = shipment.alternateAVDContactNo;
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
                    if (shipmentId != shipment.shipmentId)
                    {
                        var shipmentLog = new CHC2CHCShipmentLog();
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
