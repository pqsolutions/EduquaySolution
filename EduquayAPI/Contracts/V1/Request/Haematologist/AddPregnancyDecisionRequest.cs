using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Contracts.V1.Request.Haematologist
{
    public class AddPregnancyDecisionRequest
    {
        public List<PregnancyDecisionRequest> updateRequest { get; set; }
    }

    public class PregnancyDecisionRequest
    {
        public int pndTestId { get; set; }
        public int pndtFoetusId { get; set; }
        public bool planForPregnencyContinue { get; set; }
        public int userId { get; set; }
    }
}
