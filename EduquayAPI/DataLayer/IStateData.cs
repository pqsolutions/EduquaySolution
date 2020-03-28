using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using EduquayAPI.Contracts.V1.Request;
using EduquayAPI.Models;

namespace EduquayAPI.DataLayer
{
    public interface IStateData
    {
        string Add(StateRequest sdata);
        List<State> Retreive(int code);
        List<State> Retreive();
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
