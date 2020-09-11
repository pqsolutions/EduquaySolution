using EduquayAPI.Contracts.V1.Request.Obstetrician;
using EduquayAPI.Models.MTPObstetrician;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.DataLayer.MTPObstetrician
{
    public interface IMTPObstetricianData
    {
        List<MTPPending> GetMTPPending(ObstetricianRequest oData);
        MTPMsg AddMTPService(AddMTPTestRequest aData);
        List<MTPSummary> GetMTPCompleted(ObstetricianRequest oData);
        List<MTPSummary> GetMTPSummary();

    }
    public interface IMTPObstetricianDataFactory
    {
        IMTPObstetricianData Create();
    }
    public class MTPObstetricianDataFactory : IMTPObstetricianDataFactory
    {
        public IMTPObstetricianData Create()
        {
            return new MTPObstetricianData();
        }
    }
}
