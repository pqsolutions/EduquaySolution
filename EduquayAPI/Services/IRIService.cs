using EduquayAPI.Contracts.V1.Request;
using EduquayAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Services
{
    public interface IRIService
    {
        string Add(RIRequest rdata);
        List<RI> Retreive(int code);
        List<RI> Retreive();
    }
}
