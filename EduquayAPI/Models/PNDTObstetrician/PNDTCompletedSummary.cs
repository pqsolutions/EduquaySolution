using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Models.PNDTObstetrician
{
    public class PNDTCompletedSummary
    {
        public List<PNDTCompletedANWDetail> anwDetail { get; set; }
        public List<PNDTCompletedFoetusDetail> foetusDetail { get; set; }
    }
}