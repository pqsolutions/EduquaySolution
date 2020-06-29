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
            var shipmentDetails = _anmchcShipmentData.AddANMCHCShipment(asData);
            var shipmentResponse = new AddShipmentResponse();
            try
            {
                foreach (var shipment in shipmentDetails)
                {
                    shipmentResponse.Status = "true";
                    shipmentResponse.Message = "";
                    shipmentResponse.Shipment = shipment;
                }
            }
            catch(Exception e)
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
                        shipmentLog.ContactNo = shipment.ContactNo;
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
    }
}
