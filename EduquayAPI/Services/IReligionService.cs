using EduquayAPI.Contracts.V1.Request;
using EduquayAPI.Contracts.V1.Response.Masters;
using EduquayAPI.Models;
using EduquayAPI.Models.Masters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Services
{
   public interface IReligionService
    {
        Task<AddEditResponse> Add(ReligionRequest rData);
        List<Religion> Retrieve(int code);
        List<Religion> Retrieve();
    }
}
