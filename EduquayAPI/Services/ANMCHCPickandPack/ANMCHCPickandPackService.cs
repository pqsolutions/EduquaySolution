using EduquayAPI.Contracts.V1.Request.ANMCHCPickandPack;
using EduquayAPI.DataLayer.ANMCHCPickandPack;
using EduquayAPI.Models.ANMCHCPickandPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Services.ANMCHCPickandPack
{
    public class ANMCHCPickandPackService : IANMCHCPickandPackService
    {
        private readonly IANMCHCPickandPackData _anmchcPickandPackData;
        public ANMCHCPickandPackService(IANMCHCPickandPackDataFactory anmchcPickandPackDataFactory)
        {
            _anmchcPickandPackData = new ANMCHCPickandPackDataFactory().Create();
        }
        public List<ANMCHCPickandPackSamples> Retrieve(ANMCHCPickandPackRequest acppData)
        {
            var pickandPackSamples = _anmchcPickandPackData.Retrieve(acppData);
            return pickandPackSamples;
        }
    }
}
