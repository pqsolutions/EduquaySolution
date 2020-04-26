using EduquayAPI.Contracts.V1.Request;
using EduquayAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Services
{
    public interface IThresholdService
    {
        string Add(ThresholdRequest tData);
        List<Threshold> Retrieve(int code);
        List<Threshold> Retrieve();
    }
}
