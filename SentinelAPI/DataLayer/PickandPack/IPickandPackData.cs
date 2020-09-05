using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SentinelAPI.Contracts.V1.Request.PickandPack;
using SentinelAPI.Models.PickandPack;

namespace SentinelAPI.DataLayer.PickandPack
{
    public interface IPickandPackData
    {
        List<PickandPackDetails> RetrivePickandPackSamples(int hospitalId);
        List<ShipmentsId> AddShipment(AddPickandPackRequest asData);
    }
    public interface IPickandPackDataFactory
    {
        IPickandPackData Create();
    }

    public class PickandPackDataFactory : IPickandPackDataFactory
    {
        public IPickandPackData Create()
        {
            return new PickandPackData();
        }
    }
}
