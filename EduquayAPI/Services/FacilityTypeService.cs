using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EduquayAPI.Contracts.V1.Request;
using EduquayAPI.DataLayer;
using EduquayAPI.Models;

namespace EduquayAPI.Services
{
    public class FacilityTypeService : IFacilityTypeService
    {

        private readonly IFacilityTypeData _facilitytypeData;

        public FacilityTypeService(IFacilityTypeDataFactory facilitytypeDataFactory)
        {
            _facilitytypeData = new FacilityTypeDataFactory().Create();
        }
        public string Add(FacilityTypeRequest ftdata)
        {
            var result = _facilitytypeData.Add(ftdata);
            return result;
        }

        public List<FacilityType> Retreive(int code)
        {
            var facilityType = _facilitytypeData.Retreive(code);
            return facilityType;
        }

        public List<FacilityType> Retreive()
        {
            var allFacilityTypes = _facilitytypeData.Retreive();
            return allFacilityTypes;
        }
    }
}
