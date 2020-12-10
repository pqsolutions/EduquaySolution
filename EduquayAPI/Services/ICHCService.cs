using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EduquayAPI.Contracts.V1.Request;
using EduquayAPI.Contracts.V1.Response.Masters;
using EduquayAPI.Models;

namespace EduquayAPI.Services
{
    public interface ICHCService
    {
        Task<AddEditResponse> Add(CHCRequest cData);
        List<CHC> Retrieve(int code);
        List<CHC> Retrieve();
    }
}
