using EduquayAPI.Contracts.V1.Request;
using EduquayAPI.Models;
using EduquayAPI.Models.Masters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.DataLayer
{
    public interface ICommunityData
    {
        AddEditMasters Add(CommunityRequest cData);
        List<Community> Retrieve(int code);
        List<Community> Retrieve();
    }

    public interface ICommunityDataFactory
    {
        ICommunityData Create();
    }

    public class CommunityDataFactory : ICommunityDataFactory
    {
        public ICommunityData Create()
        {
            return new CommunityData();
        }
    }
}
