using EduquayAPI.Contracts.V1.Request;
using EduquayAPI.Contracts.V1.Response.Masters;
using EduquayAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Services
{
    public interface IPHCService
    {
        Task<AddEditResponse> Add(PHCRequest pData);
        List<PHC> Retrieve(int code);
        List<PHC> Retrieve();
    }
}
