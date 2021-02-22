using EduquayAPI.Models.Hematologist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.DataLayer.Hematologist
{
    public interface IHematologistData
    {
        CompletedMolTestDetail RetrieveCompletedMolecularDetail(int molecularLabId);
    }
    public interface IHematologistDataFactory
    {
        IHematologistData Create();
    }
    public class HematologistDataFactory : IHematologistDataFactory
    {
        public IHematologistData Create()
        {
            return new HematologistData();
        }
    }
}
