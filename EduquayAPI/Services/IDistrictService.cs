using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EduquayAPI.Contracts.V1.Request;
using EduquayAPI.Contracts.V1.Response.Masters;
using EduquayAPI.Models;

namespace EduquayAPI.Services
{
    public interface IDistrictService
    {
        Task<AddEditResponse> AddDistrict(DistrictRequest dData);
        List<District> Retrieve(int code);
        List<District> Retrieve();
    }
}
