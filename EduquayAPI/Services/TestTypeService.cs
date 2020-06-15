using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EduquayAPI.Contracts.V1.Request;
using EduquayAPI.DataLayer;
using EduquayAPI.Models;

namespace EduquayAPI.Services
{
    public class TestTypeService : ITestTypeService
    {
        private readonly ITestTypeData _testTypeData;

        public TestTypeService(ITestTypeDataFactory testTypeDataFactory)
        {
            _testTypeData = new TestTypeDataFactory().Create();
        }
        public string Add(TestTypeRequest ttData)
        {
            try
            {
                if (ttData.isactive.ToLower() != "true")
                {
                    ttData.isactive = "false";
                }              

                var result = _testTypeData.Add(ttData);
                return string.IsNullOrEmpty(result) ? $"Unable to add test type data" : result;
            }
            catch (Exception e)
            {
                return $"Unable to add test type data - {e.Message}";
            }
        }

        public List<TestType> Retrieve(int code)
        {
            var testType = _testTypeData.Retrieve(code);
            return testType;
        }

        public List<TestType> Retrieve()
        {
            var testType = _testTypeData.Retrieve();
            return testType;
        }
    }
}
