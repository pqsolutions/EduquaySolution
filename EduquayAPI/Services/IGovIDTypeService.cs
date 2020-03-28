using EduquayAPI.Contracts.V1.Request;
using EduquayAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Services
{
    public interface IGovIDTypeService
    {
        string Add(GovIDTypeRequest gtData);
        List<GovIDType> Retrieve(int code);
        List<GovIDType> Retrieve();
    }
}
