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
    public interface ICHCData
    {
        AddEditMasters Add(CHCRequest cData);
        List<CHC> Retrieve(int code);
        List<CHC> Retrieve();
    }
    public interface ICHCDataFactory
    {
        ICHCData Create();
    }

    public class CHCDataFactory : ICHCDataFactory
    {
        public ICHCData Create()
        {
            return new CHCData();
        }
    }
}

