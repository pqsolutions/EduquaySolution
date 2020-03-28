using EduquayAPI.Contracts.V1.Request;
using EduquayAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Services
{
    public interface IHNINService
    {
        string Add(HNINRequest hData);
        List<HNIN> Retrieve(int code);
        List<HNIN> Retrieve();
    }
}
