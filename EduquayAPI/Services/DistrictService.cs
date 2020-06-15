﻿using System;
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
        public string AddDistrict(DistrictRequest dData)
        {
            try
            {
                if (dData.stateId <= 0)
                {
                    return "Invalid State Id";
                }
                if (dData.isActive.ToLower() != "true")
                {
                    dData.isActive = "false";
                }
                var result = _districtData.Add(dData);
                return string.IsNullOrEmpty(result) ? $"Unable to add district data" : result;
            }
            catch (Exception e)
            {
                return $"Unable to add district data - {e.Message}";
            }
        }
        public List<District> Retrieve(int code)
        {
            var district = _districtData.Retrieve(code);
            return district;
        }

        public List<District> Retrieve()
        {
            var allDistricts = _districtData.Retrieve();
            return allDistricts;
        }
    }
}
