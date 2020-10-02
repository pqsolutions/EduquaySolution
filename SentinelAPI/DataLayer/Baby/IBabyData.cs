using SentinelAPI.Contracts.V1.Request.Baby;
using SentinelAPI.Models.Baby;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SentinelAPI.DataLayer.Baby
{
    public interface IBabyData
    {
        BabyRegistration AddBabyDetail(AddBabyRequest brData);
    }
    public interface IBabyDataFactory
    {
        IBabyData Create();
    }

    public class BabyDataFactory : IBabyDataFactory
    {
        public IBabyData Create()
        {
            return new BabyData();
        }
    }
}
