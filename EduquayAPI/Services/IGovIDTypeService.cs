using EduquayAPI.Contracts.V1.Request;
using EduquayAPI.Contracts.V1.Response.Masters;
using EduquayAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Services
{
    public interface IGovIDTypeService
    {
        Task<AddEditResponse> Add(GovIDTypeRequest gtData);
        List<GovIDType> Retrieve(int code);
        List<GovIDType> Retrieve();
    }
}
