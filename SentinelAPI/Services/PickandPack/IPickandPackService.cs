using SentinelAPI.Contracts.V1.Request.PickandPack;
using SentinelAPI.Contracts.V1.Response.PickandPack;
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
        Task<AddShipmentResponse> AddShipment(AddPickandPackRequest asData);

    }
}
