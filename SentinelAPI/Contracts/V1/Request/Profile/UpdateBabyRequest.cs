using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SentinelAPI.Contracts.V1.Request.Profile
{
    public class UpdateBabyRequest
    {
        public string babySubjectId { get; set; }
        public string hospitalNo { get; set; }
        public string babyFirstName { get; set; }
        public string babyLastName { get; set; }
        public string gender { get; set; }
        public string birthWeight { get; set; }
        public string deliveryDateTime { get; set; }
        public int statusOfBirth { get; set; }
        public int userId { get; set; }
    }
}
