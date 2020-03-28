using EduquayAPI.Contracts.V1.Request;
using EduquayAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.DataLayer
{
    public interface IPHCData
    {
        string Add(PHCRequest pdata);
        List<PHC> Retreive(int code);
        List<PHC> Retreive();
    }
    public interface IPHCDataFactory
    {
        IPHCData Create();
    }

    public class PHCDataFactory : IPHCDataFactory
    {
        public IPHCData Create()
        {
            return new PHCData();
        }
    }
}


