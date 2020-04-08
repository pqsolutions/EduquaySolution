using EduquayAPI.Contracts.V1.Request;
using EduquayAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Services
{
   public interface ICasteService
    {

        string Add(CasteRequest cData);
        List<Caste> Retrieve(int code);
        List<Caste> Retrieve();
    }
}
