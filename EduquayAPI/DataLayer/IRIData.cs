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
    public interface IRIData
    {
        AddEditMasters Add(RIRequest rData);
        List<RI> Retrieve(int code);
        List<RI> Retrieve();
    }
    public interface IRIDataFactory
    {
        IRIData Create();
    }

    public class RIDataFactory : IRIDataFactory
    {
        public IRIData Create()
        {
            return new RIData();
        }
    }
}


