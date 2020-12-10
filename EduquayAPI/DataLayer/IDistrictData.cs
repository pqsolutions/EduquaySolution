using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using EduquayAPI.Contracts.V1.Request;
using EduquayAPI.Models;
using EduquayAPI.Models.Masters;

namespace EduquayAPI.DataLayer
{
    public interface IDistrictData
    {
        AddEditMasters Add(DistrictRequest dData);
        List<District> Retrieve(int code);
        List<District> Retrieve();
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
