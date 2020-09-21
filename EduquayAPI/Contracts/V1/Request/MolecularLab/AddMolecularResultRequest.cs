using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Contracts.V1.Request.MolecularLab
{
    public class AddMolecularResultRequest
    {
		public string uniqueSubjectId { get; set; }
		public string barcodeNo { get; set; }
		public int diagnosisId { get; set; }
		public int resultId { get; set; }
		public int userId { get; set; }
		public bool processSample { get; set; }
		public string remarks { get; set; }
	}
}
