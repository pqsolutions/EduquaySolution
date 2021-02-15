using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Contracts.V1.Request.MolecularLab
{
    public class AddMolLabSpecimenReceiptRequest
    {
		public string shipmentId { get; set; }
		public string receivedDateTime { get; set; }
		public bool sampleDamaged { get; set; }
		public bool barcodeDamaged { get; set; }
		public bool isAccept { get; set; }
		public int pndtFoetusId { get; set; }
		public string sampleRefId { get; set; }
		public int userId { get; set; }
	}
}
