using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Contracts.V1.Request.MolecularLab
{
    public class AddMolecularReceiptRequest
    {
		public string shipmentId { get; set; }
		public string receivedDate { get; set; }
		public bool sampleDamaged { get; set; }
		public bool barcodeDamaged { get; set; }
		public bool isAccept { get; set; }
		public string barcodeNo { get; set; }
		public int userId { get; set; }
	}
}
