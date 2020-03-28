using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EduquayAPI.Contracts.V1.Request;
using EduquayAPI.Models;


namespace EduquayAPI.Services
{
    public interface IStateService
    {
        string AddState(StateRequest sData);
        List<State> Retrieve(int code);
        List<State> Retrieve();
    }
}
