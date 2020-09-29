using SentinelAPI.Contracts.V1.Request.Mother;
using SentinelAPI.Models.Mother;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SentinelAPI.DataLayer.Mother
{
    public interface IMotherData
    {
        MotherRegistration AddMotherDetail(AddMotherRequest mrData);
        MotherDetail RetrieveMother(FetchMotherRequest fmData);
    }

    public interface IMotherDataFactory
    {
        IMotherData Create();
    }

    public class MotherDataFactory : IMotherDataFactory
    {
        public IMotherData Create()
        {
            return new MotherData();
        }
    }
}
