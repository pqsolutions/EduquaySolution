using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SentinelAPI.Contracts.V1.Request.Baby
{
    public class AddBabyRequest
    {
        public string mothersSubjectId { get; set; }
        public int typeofBaby { get; set; }
        public string babySubjectId { get; set; }
        public string dateOfRegisteration { get; set; }
        public int hospitalId { get; set; }
        public string hospitalNo { get; set; }
        public string babyName { get; set; }
        public string gender { get; set; }
        public string birthWeight { get; set; }
        public string deliveryDateTime { get; set; }
        public int statusOfBirth { get; set; }
        public int userId { get; set; }
    }
}
