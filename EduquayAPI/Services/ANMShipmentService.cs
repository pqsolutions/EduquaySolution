using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EduquayAPI.Contracts.V1.Request;
using EduquayAPI.Contracts.V1.Request.ANMShipment;
using EduquayAPI.DataLayer;
using EduquayAPI.Models;
using EduquayAPI.Models.ANMShipment;

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
                if(asData.subjectId <=0)
                {
                    return "Invalid Subject Id";
                }
                if (string.IsNullOrEmpty(asData.uniqueSubjectId))
                {
                    return "Invalid UniqueSubjectId";
                }
                if (asData.sampleCollectionId <= 0)
                {
                    return "Invalid sample Id";
                }
                if (string.IsNullOrEmpty(asData.shipmentId))
                {
                    return "Invalid Shipment Id";
                }
                if (asData.anmId <= 0)
                {
                    return "Invalid ANM Id";
                }
                if (asData.testingCHCId <= 0)
                {
                    return "Invalid Tenting Center  Id";
                }
                if (asData.riId <= 0)
                {
                    return "Invalid RI  Id";
                }
                if (asData.ilrId <= 0)
                {
                    return "Invalid ILR  Id";
                }
                if (asData.avdId <= 0)
                {
                    return "Invalid AVD  Id";
                }
                if (string.IsNullOrEmpty(asData.contactNo))
                {
                    return "Invalid Contact No";
                }
                if (string.IsNullOrEmpty(asData.dateOfShipment))
                {
                    return "Invalid Shipment Date";
                }
                if (string.IsNullOrEmpty(asData.timeOfShipment))
                {
                    return "Invalid Shipment Time";
                }

                var result = _anmShipmentData.AddANMShipment(asData);
                return string.IsNullOrEmpty(result) ? $"Unable to add ANM shipment data" : result;
            }
            catch (Exception e)
            {
                return $"Unable to add ANM shipment data - {e.Message}";
            }
        }

        public List<ANMShipmentID> GenerateANMShipmentID(GenerateShipmentIdRequest sgData)
        {
            var ANMShipmentID = _anmShipmentData.GenerateANMShipmentID(sgData);
            return ANMShipmentID;
        }

        public List<ANMPickandPackSamples> Retrieve(int anmCode)
        {
            var shipmentSamples = _anmShipmentData.Retrieve(anmCode);
            return shipmentSamples;
        }

        public List<ANMShipments> Retrieve(string shipmentId)
        {
            var shipmentDetail = _anmShipmentData.Retrieve(shipmentId);
            return shipmentDetail;
        }

        public List<ANMShipmentLog> RetrieveShipmentLog(int anmCode)
        {
            var shipment = _anmShipmentData.RetrieveShipmentLog(anmCode);
            return shipment;
        }
    }
}
