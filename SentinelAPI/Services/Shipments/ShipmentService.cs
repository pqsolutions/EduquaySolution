using SentinelAPI.Contracts.V1.Response.Shipments;
using SentinelAPI.DataLayer.Shipments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SentinelAPI.Services.Shipments
{
    public class ShipmentService : IShipmentService
    {

        private readonly IShipmentData _shipmentData;

        public ShipmentService(IShipmentDataFactory shipmentDataFactory)
        {
            _shipmentData = new ShipmentDataFactory().Create();
        }
        public async Task<ShipmentLogResponse> RetrieveShipmentLogs(int userId)
        {
            var shipmentLogDetails = _shipmentData.RetrieveShipmentLog(userId);
            var shipmentLogResponse = new ShipmentLogResponse();
            var shipmentLogs = new List<ShipmentLogs>();
            try
            {
                var generatedShipmentId = "";
                foreach (var shipment in shipmentLogDetails.ShipmentLog)
                {
                    if (generatedShipmentId != shipment.generatedShipmentId)
                    {
                        var shipmentLog = new ShipmentLogs();
                        var shipmentDetail = shipmentLogDetails.ShipmentSubjectDetail.Where(sd => sd.shipmentId == shipment.id).ToList();

                        shipmentLog.id = shipment.id;
                        shipmentLog.generatedShipmentId = shipment.generatedShipmentId;
                        shipmentLog.sentinelHospitalName = shipment.sentinelHospitalName;
                        shipmentLog.receivingMolecularLab = shipment.receivingMolecularLab;
                        shipmentLog.shipmentDateTime = shipment.shipmentDateTime;
                        shipmentLog.logisticsProvider = shipment.logisticsProvider;
                        shipmentLog.contactNo = shipment.contactNo;
                        shipmentLog.samplesDetail = shipment.samplesDetail;
                        generatedShipmentId = shipment.generatedShipmentId;
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
