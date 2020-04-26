using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EduquayAPI.Contracts.V1.Request;
using EduquayAPI.Models;

namespace EduquayAPI.Services
{
    public interface ITestTypeService
    {
        string Add(TestTypeRequest ttData);
        List<TestType> Retrieve(int code);
        List<TestType> Retrieve();
    }
}
