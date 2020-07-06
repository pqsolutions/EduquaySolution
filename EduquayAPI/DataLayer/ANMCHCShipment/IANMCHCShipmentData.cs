using EduquayAPI.Contracts.V1.Request.ANMCHCShipment;
using EduquayAPI.Models.ANMCHCShipment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.DataLayer.ANMCHCShipment
{
    public interface IANMCHCShipmentData
    {
        List<ANMCHCShipmentID> AddANMCHCShipment(AddShipmentANMCHCRequest asData);
        List<ANMCHCShipmentID> AddCHCCHCShipment(AddShipmentCHCCHCRequest csData);
        ANMCHCShipments RetrieveShipmentLog(ANMCHCShipmentLogRequest asData);
        CHCCHCShipments RetrieveCHCShipmentLog(ANMCHCShipmentLogRequest asData);

    }
    public interface IANMCHCShipmentDataFactory
    {
        IANMCHCShipmentData Create();
    }
    public class ANMCHCShipmentDataFactory : IANMCHCShipmentDataFactory
    {
        public IANMCHCShipmentData Create()
        {
            return new ANMCHCShipmentData();
        }
    }
}
