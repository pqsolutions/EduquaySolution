using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using EduquayAPI.Contracts.V1.Request;
using EduquayAPI.Models;

namespace EduquayAPI.DataLayer
{
    public interface ICHCData
    {
        string Add(CHCRequest cData);
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

