using EduquayAPI.Contracts.V1.Request;
using EduquayAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.DataLayer
{
    public interface ISCData
    {
        string Add(SCRequest sdata);
        List<SC> Retreive(int code);
        List<SC> Retreive();
    }
    public interface ISCDataFactory
    {
        ISCData Create();
    }

    public class SCDataFactory : ISCDataFactory
    {
        public ISCData Create()
        {
            return new SCData();
        }
    }
}


