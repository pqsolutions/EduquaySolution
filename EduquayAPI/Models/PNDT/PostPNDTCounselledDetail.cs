using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Models.PNDT
{
    public class PostPNDTCounselledDetail
    {
        public List<PostPNDTCounselled> anwDetail { get; set; }
        public List<PNDTFoetusDetail> foetusDetail { get; set; }
    }
}
