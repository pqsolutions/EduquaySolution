using EduquayAPI.Contracts.V1.Request;
using EduquayAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Services
{
    public interface ISCService
    {
        string Add(SCRequest sdata);
        List<SC> Retreive(int code);
        List<SC> Retreive();
    }
}
