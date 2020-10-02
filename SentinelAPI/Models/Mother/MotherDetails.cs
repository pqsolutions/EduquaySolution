using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SentinelAPI.Models.Mother
{
    public class MotherDetails
    {
        public List<MotherDetail> motherDetail { get; set; }
        public List<MothersBabyDetail> babyDetail { get; set; }
    }
}
