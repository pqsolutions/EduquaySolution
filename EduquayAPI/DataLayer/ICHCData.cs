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
        string Add(CHCRequest cdata);
        List<CHC> Retreive(int code);
        List<CHC> Retreive();
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

