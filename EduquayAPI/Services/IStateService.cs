using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EduquayAPI.Contracts.V1.Request;
using EduquayAPI.Contracts.V1.Response.Masters;
using EduquayAPI.Models;


namespace EduquayAPI.Services
{
    public interface IStateService
    {
        Task<AddEditResponse> AddState(StateRequest sData);
        List<State> Retrieve(int code);
        List<State> Retrieve();
    }
}
