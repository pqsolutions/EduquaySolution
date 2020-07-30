using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Contracts.V1.Request.CentralLab
{
    public class AddCentralShipmentRequest
    {
		public string shipmentId { get; set; }
		public string receivedDate { get; set; }
		public string proceesingDateTime { get; set; }
		public bool sampleDamaged { get; set; }
		public bool sampleTimeout { get; set; }
		public bool barcodeDamaged { get; set; }
		public bool isAccept { get; set; }
		public string barcodeNo { get; set; }
		public int updatedBy { get; set; }
	}
}
