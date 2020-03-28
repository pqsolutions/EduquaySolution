using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EduquayAPI.Contracts.V1.Request;
using EduquayAPI.Models;

namespace EduquayAPI.Services
{
    public interface IDistrictService
    {
        string AddDistrict(DistrictRequest sData);
        List<District> Retrieve(int code);
        List<District> Retrieve();
    }
}
