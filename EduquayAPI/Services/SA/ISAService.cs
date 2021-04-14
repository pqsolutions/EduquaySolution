using EduquayAPI.Contracts.V1.Request.AdminSupport;
using EduquayAPI.Contracts.V1.Response.Masters;
using EduquayAPI.Models.AdminiSupport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Services.SA
{
    public interface ISAService
    {
        #region State Master
        Task<AddEditResponse> AddStateDetail(AddStateRequest sData);
        Task<AddEditResponse> UpdateStatedetail(UpdateStateRequest sData);
        List<StateDetails> RetrieveStateById(int id);
        List<StateDetails> RetrieveAllStates();
        #endregion

        #region District Master
        Task<AddEditResponse> AddDistrictDetail(AddDistrictRequest data);
        Task<AddEditResponse> UpdateDistrictDetail(UpdateDistrictRequest data);
        List<DistrictDetail> RetrieveDistrictById(int id);
        List<DistrictDetail> RetrieveAllDistricts();
        #endregion

        #region Block Master
        Task<AddEditResponse> AddBlockDetail(AddBlockRequest data);
        Task<AddEditResponse> UpdateBlockDetail(UpdateBlockRequest data);
        List<BlockDetail> RetrieveBlockById(int id);
        List<BlockDetail> RetrieveAllBlocks();
        #endregion

        #region CHC Master
        Task<AddEditResponse> AddCHCDetail(AddCHCRequest data);
        Task<AddEditResponse> UpdateCHCDetail(UpdateCHCRequest data);
        List<CHCDetail> RetrieveCHCById(int id);
        List<CHCDetail> RetrieveAllCHCs();
        #endregion

        #region PHC Master
        Task<AddEditResponse> AddPHCDetail(AddPHCRequest data);
        Task<AddEditResponse> UpdatePHCDetail(UpdatePHCRequest data);
        List<PHCDetail> RetrievePHCById(int id);
        List<PHCDetail> RetrieveAllPHCs();
        #endregion

        #region PHC Master
        Task<AddEditResponse> AddSCDetail(AddSCRequest data);
        Task<AddEditResponse> UpdateSCDetail(UpdateSCRequest data);
        List<SCDetail> RetrieveSCById(int id);
        List<SCDetail> RetrieveAllSCs();
        #endregion
    }
}
