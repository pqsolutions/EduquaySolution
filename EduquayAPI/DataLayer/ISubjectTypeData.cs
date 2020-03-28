using EduquayAPI.Contracts.V1.Request;
using EduquayAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.DataLayer
{
    public interface ISubjectTypeData
    {
        string Add(SubjectTypeRequest stData);
        List<SubjectType> Retrieve(int code);
        List<SubjectType> Retrieve();
    }
    public interface ISubjectTypeDataFactory
    {
        ISubjectTypeData Create();
    }

    public class SubjectTypeDataFactory : ISubjectTypeDataFactory
    {
        public ISubjectTypeData Create()
        {
            return new SubjectTypeData();
        }
    }
}
