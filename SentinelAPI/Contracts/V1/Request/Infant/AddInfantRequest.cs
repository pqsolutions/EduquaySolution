using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SentinelAPI.Contracts.V1.Request.Infant
{
    public class AddInfantRequest
    {
        public int mothersId { get; set; }
        public int districtId { get; set; }
        public int hospitalId { get; set; }
        public string uniqueSubjectId { get; set; }
        public int typeofInfant { get; set; }
        public string subTitle { get; set; }
        public string firstName { get; set; }
        public string middleName { get; set; }
        public string lastName { get; set; }
        public string gender { get; set; }
        public string infantRCHId { get; set; }
        public string dateOfDelivery { get; set; }
        public string timeOfDelivery { get; set; }
        public int statusOfBirth { get; set; }
        public string dateOfRegister { get; set; }
        public int createdBy { get; set; }
        public string comments { get; set; }

    }
}
