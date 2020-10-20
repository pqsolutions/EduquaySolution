using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SentinelAPI.Models.Profile
{
    public class ProfileMotherDetails
    {
        public List<MotherProfile> motherDetail { get; set; }
        public List<MotherBabiesDetail> babyDetail { get; set; }
    }
}
