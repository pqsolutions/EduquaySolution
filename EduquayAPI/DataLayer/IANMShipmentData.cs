using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using EduquayAPI.Contracts.V1.Request;
using EduquayAPI.Contracts.V1.Request.ANMShipment;
using EduquayAPI.Models;
using EduquayAPI.Models.ANMShipment;

namespace EduquayAPI.DataLayer
{
    public interface IANMShipmentData
    {
        string AddANMShipment(AddANMShipmentRequest asData);
        List<ANMPickandPackSamples> Retrieve(int anmCode);
        List<ANMShipmentLog> RetrieveShipmentLog(int anmCode);
        List<ANMShipments> Retrieve(string shipmentId);
        List<ANMShipmentID> GenerateANMShipmentID(GenerateShipmentIdRequest sgData);
    }
    public interface IANMShipmentDataFactory
    {
        IANMShipmentData Create();
    }
    public class ANMShipmentDataFactory : IANMShipmentDataFactory
    {
        public IANMShipmentData Create()
        {
            return new ANMShipmentData();
        }
    }
}
