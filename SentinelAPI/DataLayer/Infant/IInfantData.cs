using SentinelAPI.Contracts.V1.Request.Infant;
using SentinelAPI.Models.Infant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SentinelAPI.DataLayer.Infant
{
    public interface IInfantData
    {
        List<InfantRegistration> AddInfantDetail(AddInfantRequest irData);
        GetMotherDetails RetrieveMother(GetMotherRequest mData);
    }

    public interface IInfantDataFactory
    {
        IInfantData Create();
    }

    public class InfantDataFactory : IInfantDataFactory
    {
        public IInfantData Create()
        {
            return new InfantData();
        }
    }
}
