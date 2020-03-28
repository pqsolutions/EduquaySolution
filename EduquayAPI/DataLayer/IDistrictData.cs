using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using EduquayAPI.Contracts.V1.Request;
using EduquayAPI.Models;

namespace EduquayAPI.DataLayer
{
    public interface IDistrictData
    {
        string Add(DistrictRequest ddata);
        List<District> Retreive(int code);
        List<District> Retreive();
    }
    public interface IDistrictDataFactory
    {
        IDistrictData Create();
    }

    public class DistrictDataFactory : IDistrictDataFactory
    {
        public IDistrictData Create()
        {
            return new DistrictData();
        }
    }
}
