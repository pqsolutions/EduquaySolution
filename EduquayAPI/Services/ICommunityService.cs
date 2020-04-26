using EduquayAPI.Contracts.V1.Request;
using EduquayAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Services
{
    public interface ICommunityService
    {
        string Add(CommunityRequest cData);
        List<Community> Retrieve(int code);
        List<Community> Retrieve();
    }
}
