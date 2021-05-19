using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Models.MolecularLab
{
    public class SpecimenReport
    {
        public List<MolecularLabSpecimenReport> anwDetail { get; set; }
        public List<MolecularLabFoetusResult> foetusDetail { get; set; }
    }
}
