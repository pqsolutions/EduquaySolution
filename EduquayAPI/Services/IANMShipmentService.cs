using EduquayAPI.Contracts.V1.Request;
using EduquayAPI.Contracts.V1.Request.ANMShipment;
using EduquayAPI.Models;
using EduquayAPI.Models.ANMShipment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Services
{
    public interface IANMShipmentService
    {
        string AddANMShipment(AddANMShipmentRequest asData);
        List<ANMPickandPackSamples> Retrieve(int anmCode);
        List<ANMShipmentLog> RetrieveShipmentLog(int anmCode);
        List<ANMShipments> Retrieve(string shipmentId);
        List<ANMShipmentID> GenerateANMShipmentID(GenerateShipmentIdRequest sgData);
    }
}
