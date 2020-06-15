using EduquayAPI.Contracts.V1.Request.ANMCHCPickandPack;
using EduquayAPI.Models.ANMCHCPickandPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.DataLayer.ANMCHCPickandPack
{
    public interface IANMCHCPickandPackData
    {
        List<ANMCHCPickandPackSamples> Retrieve(ANMCHCPickandPackRequest acppData);
    }
    public interface IANMCHCPickandPackDataFactory
    {
        IANMCHCPickandPackData Create();
    }
    public class ANMCHCPickandPackDataFactory : IANMCHCPickandPackDataFactory
    {
        public IANMCHCPickandPackData Create()
        {
            return new ANMCHCPickandPackData();
        }
    }
}
