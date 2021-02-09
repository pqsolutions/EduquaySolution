using EduquayAPI.Contracts.V1.Request.Obstetrician;
using EduquayAPI.Models.PNDTObstetrician;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.DataLayer.PNDTObstetrician
{
    public interface IPNDTObstetricianData
    {
        List<PNDTPending> GetPNDTPending(ObstetricianRequest oData);
        PNDTMsg AddPNDTest(AddPNDTestRequest aData);
        List<PNDTNotCompleted> GetPNDTNotCompleted(ObstetricianRequest oData);
        //List<PNDTCompletedSummary> GetPNDTCompletedSummary(PNDTCompletedSummaryRequest oData);
        List<PNDTCompletedSummary> GetPNDTCompletedSummary();
        public PNDTMsg AddPNDTestNew(AddPNDTRequest aData);
    }
    public interface IPNDTObstetricianDataFactory
    {
        IPNDTObstetricianData Create();
    }
    public class PNDTObstetricianDataFactory : IPNDTObstetricianDataFactory
    {
        public IPNDTObstetricianData Create()
        {
            return new PNDTObstetricianData();
        }
    }
}
