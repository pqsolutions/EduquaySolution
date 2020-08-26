using SentinelAPI.DataLayer.PickandPack;
using SentinelAPI.Models.PickandPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SentinelAPI.Services.PickandPack
{
    public class PickandPackService : IPickandPackService
    {
        private readonly IPickandPackData _pickandPackData;

        public PickandPackService(IPickandPackDataFactory pickandPackDataFactory)
        {
            _pickandPackData = new PickandPackDataFactory().Create();
        }
        public List<PickandPackDetails> RetrivePickandPackSamples(int hospitalId)
        {
            var pickandPackSamples = _pickandPackData.RetrivePickandPackSamples(hospitalId);
            return pickandPackSamples;
        }
    }
}
