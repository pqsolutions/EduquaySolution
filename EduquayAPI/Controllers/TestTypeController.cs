using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EduquayAPI.Contracts.V1.Request;
using EduquayAPI.Contracts.V1.Response;
using EduquayAPI.Models;
using EduquayAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;

namespace EduquayAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class TestTypeController : ControllerBase
    {
        private readonly ITestTypeService _testTypeService;
        public TestTypeController(ITestTypeService testTypeService)
        {
            _testTypeService = testTypeService;
        }

        [HttpPost]
        [Route("Add")]
        public ActionResult<string> Add(TestTypeRequest ttData)
        {
            try
            {
                var testType = _testTypeService.Add(ttData);
                return string.IsNullOrEmpty(testType) ? $"Unable to add test type data" : testType;
            }
            catch (Exception e)
            {
                return $"Unable to add  test type data - {e.Message}";
            }
        }

        [HttpGet]
        [Route("Retrieve")]
        public TestTypeResponse GetTestTypes()
        {
            try
            {
                var testTypes = _testTypeService.Retrieve();
                return testTypes.Count == 0 ? new TestTypeResponse { Status = "true", Message = "No test type found", TestTypes = new List<TestType>() } : new TestTypeResponse { Status = "true", Message = string.Empty, TestTypes = testTypes };
            }
            catch (Exception e)
            {
                return new TestTypeResponse { Status = "false", Message = e.Message, TestTypes = null };
            }
        }

        [HttpGet]
        [Route("Retrieve/{code}")]
        public TestTypeResponse GetTestType(int code)
        {
            try
            {
                var testTypes = _testTypeService.Retrieve(code);
                return testTypes.Count == 0 ? new TestTypeResponse { Status = "true", Message = "No test type found", TestTypes = new List<TestType>() } : new TestTypeResponse { Status = "true", Message = string.Empty, TestTypes = testTypes };
            }
            catch (Exception e)
            {
                return new TestTypeResponse { Status = "false", Message = e.Message, TestTypes = null };
            }
        }





    }
}