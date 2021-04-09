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
    }
}
