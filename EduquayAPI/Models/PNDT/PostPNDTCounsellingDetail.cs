using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Models.PNDT
{
    public class PostPNDTCounsellingDetail
    {
        public List<PostPNDTCounselling> anwDetail { get; set; }
        public List<PNDTFoetusDetail> foetusDetail { get; set; }
    }
}
