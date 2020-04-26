using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using EduquayAPI.Contracts.V1.Request;
using EduquayAPI.Models;


namespace EduquayAPI.DataLayer
{
    public interface IANMShipmentData
    {
        string AddANMShipment(AddANMShipmentRequest asData);
        List<ANMPickandPackSamples> Retrieve(int anmCode);
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
