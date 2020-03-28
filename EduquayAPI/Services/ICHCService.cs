using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EduquayAPI.Contracts.V1.Request;
using EduquayAPI.Models;

namespace EduquayAPI.Services
{
    public interface ICHCService
    {
        string Add(CHCRequest cdata);
        List<CHC> Retreive(int code);
        List<CHC> Retreive();
    }
}
