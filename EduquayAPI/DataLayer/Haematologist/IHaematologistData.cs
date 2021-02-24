using EduquayAPI.Contracts.V1.Request.Haematologist;
using EduquayAPI.Models.Haematologist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.DataLayer.Haematologist
{
    public interface IHaematologistData
    {
        CompletedMolTestDetail RetrieveCompletedMolecularDetail(int molecularLabId);
        CVSSampleRefIdDetail AddDecision(PregnancyDecisionRequest pdData);
    }
    public interface IHaematologistDataFactory
    {
        IHaematologistData Create();
    }
    public class HaematologistDataFactory : IHaematologistDataFactory
    {
        public IHaematologistData Create()
        {
            return new HaematologistData();
        }
    }
}
