using EduquayAPI.Contracts.V1.Request;
using EduquayAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.DataLayer
{
    public interface IHNINData
    {
        string Add(HNINRequest hData);
        List<HNIN> Retrieve(int code);
        List<HNIN> Retrieve();
    }
    public interface IHNINDataFactory
    {
        IHNINData Create();
    }

    public class HNINDataFactory : IHNINDataFactory
    {
        public IHNINData Create()
        {
            return new HNINData();
        }
    }
}
