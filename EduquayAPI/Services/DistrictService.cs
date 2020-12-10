using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EduquayAPI.Contracts.V1.Request;
using EduquayAPI.Contracts.V1.Response.Masters;
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
        public async Task<AddEditResponse> AddDistrict(DistrictRequest dData)
        {

            var response = new AddEditResponse();
            try
            {
                if (dData.isActive.ToLower() != "true")
                {
                    dData.isActive = "false";
                }
                if (dData.stateId <= 0)
                {
                    response.Status = "false";
                    response.Message = "Invalid state id";
                }
                else
                {
                    var addEditResponse = _districtData.Add(dData);
                    response.Status = "true";
                    response.Message = addEditResponse.message;
                }
                return response;
            }
            catch (Exception e)
            {
                response.Status = "false";
                response.Message = $"Unable to process - {e.Message}";
                return response;
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
