using SentinelAPI.Models.PickandPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SentinelAPI.Services.PickandPack
{
    public interface IPickandPackService
    {
        List<PickandPackDetails> RetrivePickandPackSamples(int hospitalId);
    }
}
