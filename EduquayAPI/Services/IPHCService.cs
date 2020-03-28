using EduquayAPI.Contracts.V1.Request;
using EduquayAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Services
{
    public interface IPHCService
    {
        string Add(PHCRequest pdata);
        List<PHC> Retreive(int code);
        List<PHC> Retreive();
    }
}
