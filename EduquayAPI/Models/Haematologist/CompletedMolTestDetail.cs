using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Models.Haematologist
{
    public class CompletedMolTestDetail
    {
        public List<CompletedMolTestANWDetails> anwDetail { get; set; }
        public List<CompletedFoetusMolTestDetail> foetusDetail { get; set; }
    }
}
