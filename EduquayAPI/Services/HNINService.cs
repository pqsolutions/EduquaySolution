using EduquayAPI.Models;
using EduquayAPI.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EduquayAPI.Contracts.V1.Request;

namespace EduquayAPI.Services
{
    public class HNINService : IHNINService
    {
        private readonly IHNINData _hninData;

        public HNINService(IHNINDataFactory hninDataFactory)
        {
            _hninData = new HNINDataFactory().Create();
        }
        public string Add(HNINRequest hdata)
        {
            var result = _hninData.Add(hdata);
            return result;
        }

        public List<HNIN> Retreive(int code)
        {
            var hnin = _hninData.Retreive(code);
            return hnin;
        }

        public List<HNIN> Retreive()
        {
            var allHNIN = _hninData.Retreive();
            return allHNIN;
        }
    }
}
