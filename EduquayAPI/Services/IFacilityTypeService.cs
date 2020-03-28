using EduquayAPI.Contracts.V1.Request;
using EduquayAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Services
{
    public interface IFacilityTypeService
    {
        string Add(FacilityTypeRequest ftdata);
        List<FacilityType> Retreive(int code);
        List<FacilityType> Retreive();
    }
}
