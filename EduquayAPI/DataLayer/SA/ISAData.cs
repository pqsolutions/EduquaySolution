using EduquayAPI.Contracts.V1.Request.AdminSupport;
using EduquayAPI.Models.AdminiSupport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.DataLayer.SA
{
    public interface ISAData
    {
        #region State Master
        AddUpdateMaster AddStateDetail(AddStateRequest sData);
        AddUpdateMaster UpdateStatedetail(UpdateStateRequest sData);
        List<StateDetails> RetrieveStateById(int id);
        List<StateDetails> RetrieveAllStates();
        #endregion

        #region District Master
        AddUpdateMaster AddDistrictDetail(AddDistrictRequest data);
        AddUpdateMaster UpdateDistrictDetail(UpdateDistrictRequest data);
        List<DistrictDetail> RetrieveDistrictById(int id);
        List<DistrictDetail> RetrieveAllDistricts();
        #endregion

        #region Block Master
        AddUpdateMaster AddBlockDetail(AddBlockRequest data);
        AddUpdateMaster UpdateBlockDetail(UpdateBlockRequest data);
        List<BlockDetail> RetrieveBlockById(int id);
        List<BlockDetail> RetrieveAllBlocks();
        #endregion

        #region CHC Master
        AddUpdateMaster AddCHCDetail(AddCHCRequest data);
        AddUpdateMaster UpdateCHCDetail(UpdateCHCRequest data);
        List<CHCDetail> RetrieveCHCById(int id);
        List<CHCDetail> RetrieveAllCHCs();
        #endregion

        #region PHC Master
        AddUpdateMaster AddPHCDetail(AddPHCRequest data);
        AddUpdateMaster UpdatePHCDetail(UpdatePHCRequest data);
        List<PHCDetail> RetrievePHCById(int id);
        List<PHCDetail> RetrieveAllPHCs();
        #endregion

        #region SC Master
        AddUpdateMaster AddSCDetail(AddSCRequest data);
        AddUpdateMaster UpdateSCDetail(UpdateSCRequest data);
        List<SCDetail> RetrieveSCById(int id);
        List<SCDetail> RetrieveAllSCs();
        #endregion

    }
    public interface ISADataFactory
    {
        ISAData Create();
    }

    public class SADataFactory : ISADataFactory
    {
        public ISAData Create()
        {
            return new SAData();
        }
    }
}
