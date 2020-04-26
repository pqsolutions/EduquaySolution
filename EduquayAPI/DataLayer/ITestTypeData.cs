using EduquayAPI.Contracts.V1.Request;
using EduquayAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.DataLayer
{
    public interface ITestTypeData
    {
        string Add(TestTypeRequest ttData);
        List<TestType> Retrieve(int code);
        List<TestType> Retrieve();
    }
    public interface ITestTypeDataFactory
    {
        ITestTypeData Create();
    }

    public class TestTypeDataFactory : ITestTypeDataFactory
    {
        public ITestTypeData Create()
        {
            return new TestTypeData();
        }
    }
}
