using SentinelAPI.Models.Shipment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SentinelAPI.DataLayer.Shipments
{
    public interface IShipmentData
    {
        ShipmentsLogs RetrieveShipmentLog(int userId);

    }

    public interface IShipmentDataFactory
    {
        IShipmentData Create();
    }

    public class ShipmentDataFactory : IShipmentDataFactory
    {
        public IShipmentData Create()
        {
            return new ShipmentData();
        }
    }
}
