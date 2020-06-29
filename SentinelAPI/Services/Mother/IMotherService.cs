using SentinelAPI.Contracts.V1.Request.Mother;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SentinelAPI.Services.Mother
{
    public interface IMotherService
    {
        string AddMotherDetail(AddMotherRequest mrData);
    }
}
