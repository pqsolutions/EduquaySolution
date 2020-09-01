using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Contracts.V1.Request.Obstetrician
{
    public class ObstetricianRequest
    {
        public int districtId { get; set; }
        public int chcId { get; set; }
        public int phcId { get; set; }
        public int anmId { get; set; }
    }
}
