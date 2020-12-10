using EduquayAPI.Contracts.V1.Request;
using EduquayAPI.Models;
using EduquayAPI.Models.Masters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.DataLayer
{
    public interface IGovIDTypeData
    {
        AddEditMasters Add(GovIDTypeRequest gtData);
        List<GovIDType> Retrieve(int code);
        List<GovIDType> Retrieve();
    }
    public interface IGovIDTypeDataFactory
    {
        IGovIDTypeData Create();
    }

    public class GovIDTypeDataFactory : IGovIDTypeDataFactory
    {
        public IGovIDTypeData Create()
        {
            return new GovIDTypeData();
        }
    }
}
