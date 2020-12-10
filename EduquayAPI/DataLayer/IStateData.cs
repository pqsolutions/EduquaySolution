using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using EduquayAPI.Contracts.V1.Request;
using EduquayAPI.Models;
using EduquayAPI.Models.Masters;

namespace EduquayAPI.DataLayer
{
    public interface IStateData
    {
        AddEditMasters Add(StateRequest sData);
        List<State> Retrieve(int code);
        List<State> Retrieve();
    }
    public interface IStateDataFactory
    {
        IStateData Create();
    } 

    public class StateDataFactory : IStateDataFactory
    {
        public IStateData Create()
        {
            return new StateData();
        }
    }
}
