using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EduquayAPI.Contracts.V1.Request;
using EduquayAPI.DataLayer;
using EduquayAPI.Models;

namespace EduquayAPI.Services
{
    public class DistrictService : IDistrictService
    {
        private readonly IDistrictData _districtData;
        public DistrictService(IDistrictDataFactory districteDataFactory)
        {
            _districtData = new DistrictDataFactory().Create();
        }
        public string AddDistrict(DistrictRequest ddata)
        {
            var result = _districtData.Add(ddata);
            return result;
        }
        public List<District> Retreive(int code)
        {
            var district = _districtData.Retreive(code);
            return district;
        }

        public List<District> Retreive()
        {
            var allDistricts = _districtData.Retreive();
            return allDistricts;
        }
    }
}
