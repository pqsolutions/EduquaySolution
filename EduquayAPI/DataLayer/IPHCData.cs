using EduquayAPI.Contracts.V1.Request;
using EduquayAPI.Models;
using EduquayAPI.Models.Masters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.DataLayer
{
    public interface IPHCData
    {
        AddEditMasters Add(PHCRequest pData);
        List<PHC> Retrieve(int code);
        List<PHC> Retrieve();
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


