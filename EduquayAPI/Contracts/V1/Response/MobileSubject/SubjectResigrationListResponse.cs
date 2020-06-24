using EduquayAPI.Models.MobileSubject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Contracts.V1.Response.MobileSubject
{
    public class SubjectResigrationListResponse
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public List<SubjectResigration> SubjectResigrations { get; set; }
    }

    public class SubjectResigration
    {
        public SubjectPrimary SubjectPrimary { get; set; }
        public SubjectAddress SubjectAddress { get; set; }
        public SubjectPregnancy SubjectPregnancy { get; set; }
        public SubjectParent SubjectParent { get; set; }

    }

}
