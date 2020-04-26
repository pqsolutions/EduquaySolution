using EduquayAPI.Contracts.V1.Request;
using EduquayAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.DataLayer
{
    public interface IThresholdData
    {
        string Add(ThresholdRequest tData);
        List<Threshold> Retrieve(int code);
        List<Threshold> Retrieve();
    }
    public interface IThresholdDataFactory
    {
        IThresholdData Create();
    }

    public class ThresholdDataFactory : IThresholdDataFactory
    {
        public IThresholdData Create()
        {
            return new ThresholdData();
        }
    }

}
