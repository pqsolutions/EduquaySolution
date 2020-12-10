using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EduquayAPI.Contracts.V1.Request;
using EduquayAPI.Models;
using EduquayAPI.Models.Masters;

namespace EduquayAPI.DataLayer
{
    public interface IReligionData
    {
        AddEditMasters Add(ReligionRequest rData);
        List<Religion> Retrieve(int code);
        List<Religion> Retrieve();
    }

    public interface IReligionDataFactory
    {
        IReligionData Create();
    }

    public class ReligionDataFactory : IReligionDataFactory
    {
        public IReligionData Create()
        {
            return new ReligionData();
        }
    }

}
