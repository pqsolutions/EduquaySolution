using EduquayAPI.Contracts.V1.Request.ANMCHCPickandPack;
using EduquayAPI.Models.ANMCHCPickandPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Services.ANMCHCPickandPack
{
    public interface IANMCHCPickandPackService
    {
        List<ANMCHCPickandPackSamples> Retrieve(ANMCHCPickandPackRequest acppData);
    }
}
