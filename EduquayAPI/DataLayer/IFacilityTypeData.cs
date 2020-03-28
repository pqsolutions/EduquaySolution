using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EduquayAPI.Contracts.V1.Request;
using EduquayAPI.Models;

namespace EduquayAPI.DataLayer
{
    public interface IFacilityTypeData
    {
        string Add(FacilityTypeRequest ftdata);
        List<FacilityType> Retreive(int code);
        List<FacilityType> Retreive();
    }
    public interface IFacilityTypeDataFactory
    {
        IFacilityTypeData Create();
    }

    public class FacilityTypeDataFactory : IFacilityTypeDataFactory
    {
        public IFacilityTypeData Create()
        {
            return new FacilityTypeData();
        }
    }
}
