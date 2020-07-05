using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SentinelAPI.Models.Infant
{
    public class GetMotherDetails
    {
        public List<InfantMother> MotherDetail { get; set; }
        public List<MotherInfant> InfantsDetail { get; set; }
    }
}
