using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EduquayAPI.Contracts.V1.Request;
using EduquayAPI.DataLayer;
using EduquayAPI.Models;

namespace EduquayAPI.Services
{
    public class ANMShipmentService : IANMShipmentService
    {
        private readonly IANMShipmentData _anmShipmentData;

        public ANMShipmentService(IANMShipmentDataFactory anmShipmentDataFactory)
        {
            _anmShipmentData = new ANMShipmentDataFactory().Create();
        }
        public string AddANMShipment(AddANMShipmentRequest asData)
        {
            try
            {
                var result = _anmShipmentData.AddANMShipment(asData);
                return string.IsNullOrEmpty(result) ? $"Unable to add ANM shipment data" : result;
            }
            catch (Exception e)
            {
                return $"Unable to add ANM shipment data - {e.Message}";
            }
        }

        public List<ANMPickandPackSamples> Retrieve(int anmCode)
        {
            var shipmentSamples = _anmShipmentData.Retrieve(anmCode);
            return shipmentSamples;
        }
    }
}
