using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Models.MolecularLab
{
    public class AddSpecimenSampleTestRequest
    {
        public string uniqueSubjectId { get; set; }
        public string pndtFoetusId { get; set; }
        public int zygosityId { get; set; }
        public int mutation1Id { get; set; }
        public int mutation2Id { get; set; }
        public string mutation3 { get; set; }
        public string testResult { get; set; }
        public bool sampleDamaged { get; set; }
        public bool sampleProcessed { get; set; }
        public bool completeStatus { get; set; }
        public string reasonForClose { get; set; }
        public string testDate { get; set; }
        public int userId { get; set; }
    }
}
