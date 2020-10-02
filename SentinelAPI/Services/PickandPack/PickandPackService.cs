using SentinelAPI.Contracts.V1.Request.PickandPack;
using SentinelAPI.Contracts.V1.Response.PickandPack;
using SentinelAPI.DataLayer.PickandPack;
using SentinelAPI.Models.PickandPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SentinelAPI.Services.PickandPack
{
    public class PickandPackService : IPickandPackService
    {
        private readonly IPickandPackData _pickandPackData;

        public PickandPackService(IPickandPackDataFactory pickandPackDataFactory)
        {
            _pickandPackData = new PickandPackDataFactory().Create();
        }

        public string checkshipmentValidation(AddPickandPackRequest asData)
        {
            var message = "";
            if (asData.barcodeNo == "")
            {
                message = "Barcode is missing";
            }
            else if (asData.hospitalId <= 0)
            {
                message = "Invalid hospital id";
            }
            else if (asData.molecularLabId <= 0)
            {
                message = "Invalid molecular lab id";
            }
            else if (string.IsNullOrEmpty(asData.senderName))
            {
                message = " Sender name is missing";
            }
            else if (string.IsNullOrEmpty(asData.contactNo))
            {
                message = " Contactno is missing";
            }
            else if (string.IsNullOrEmpty(asData.dateOfShipment))
            {
                message = " Shipment date is missing";
            }
            else if(string.IsNullOrEmpty(asData.dateOfShipment))
            {
                message = " Shipment time is missing";
            }
            return message;
        }

        public async Task<AddShipmentResponse> AddShipment(AddPickandPackRequest asData)
        {
            var shipmentResponse = new AddShipmentResponse();
            try
            {
                var msg = checkshipmentValidation(asData);
                if (msg == "")
                {
                    var shipmentDetails = _pickandPackData.AddShipment(asData);
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

        public List<PickandPackDetails> RetrivePickandPackSamples(int hospitalId)
        {
            var pickandPackSamples = _pickandPackData.RetrivePickandPackSamples(hospitalId);
            return pickandPackSamples;
        }
    }
}
