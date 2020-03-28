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

        private readonly IFacilityTypeData _facilityTypeData;

        public FacilityTypeService(IFacilityTypeDataFactory facilitytypeDataFactory)
        {
            _facilityTypeData = new FacilityTypeDataFactory().Create();
        }
        public string Add(FacilityTypeRequest ftData)
        {
            try
            {
                if (ftData.IsActive.ToLower() != "true")
                {
                    ftData.IsActive = "false";
                }
                var result = _facilityTypeData.Add(ftData);
                return string.IsNullOrEmpty(result) ? $"Unable to add facility type data" : result;
            }
            catch (Exception e)
            {
                return $"Unable to add facility type data - {e.Message}";
            }
        }

        public List<FacilityType> Retrieve(int code)
        {
            var facilityType = _facilityTypeData.Retrieve(code);
            return facilityType;
        }

        public List<FacilityType> Retrieve()
        {
            var allFacilityTypes = _facilityTypeData.Retrieve();
            return allFacilityTypes;
        }
    }
}
