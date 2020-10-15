using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SentinelAPI.Models.MolecularLab
{
    public class AddMolecularResultRequest
    {
		public string babySubjectId { get; set; }
		public string barcodeNo { get; set; }
		public int diagnosisId { get; set; }
		public int resultId { get; set; }
		public int userId { get; set; }
		public bool processSample { get; set; }
		public string remarks { get; set; }
	}
}
