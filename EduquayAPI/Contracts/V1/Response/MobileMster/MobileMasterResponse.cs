using EduquayAPI.Models.LoadMasters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Contracts.V1.Response.MobileMster
{
    public class MobileMasterResponse
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public List<LoadDistricts> Districts { get; set; }
        public List<LoadCHCs> CHC { get; set; }
        public List<LoadPHCs> PHC { get; set; }
        public List<LoadSCs> SC { get; set; }
        public List<LoadMobileRI> RI { get; set; }
        public List<LoadReligion> Religion { get; set; }
        public List<LoadCaste> Caste { get; set; }
        public List<LoadCommunity> Community { get; set; }
        public List<LoadGovIDType> GovIdType { get; set; }
        public List<LoadConstantValues> ConstantValues { get; set; }

    }
}
