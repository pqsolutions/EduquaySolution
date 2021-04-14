using EduquayAPI.Contracts.V1.Request.AdminSupport;
using EduquayAPI.Contracts.V1.Response.Masters;
using EduquayAPI.DataLayer.SA;
using EduquayAPI.Models.AdminiSupport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Services.SA
{
    public class SAService : ISAService 
    {
        private readonly ISAData _saData;
        public SAService(ISADataFactory saDataFactory)
        {
            _saData = new SADataFactory().Create();
        }

        #region State Master
        public async Task<AddEditResponse> AddStateDetail(AddStateRequest sData)
        {
            var response = new AddEditResponse();
            try
            {
                if (string.IsNullOrEmpty(sData.stateGovCode))
                {
                    response.Status = "false";
                    response.Message = "Please enter state gov code";
                }
                else if (string.IsNullOrEmpty(sData.name))
                {
                    response.Status = "false";
                    response.Message = "Please enter state name";
                }
                else
                {
                    var addEditResponse = _saData.AddStateDetail(sData);
                    response.Status = "true";
                    response.Message = addEditResponse.message;
                }
                return response;
            }
            catch (Exception e)
            {
                response.Status = "false";
                response.Message = $"Unable to process - {e.Message}";
                return response;
            }
        }
        public async Task<AddEditResponse> UpdateStatedetail(UpdateStateRequest sData)
        {
            var response = new AddEditResponse();
            try
            {
                if (string.IsNullOrEmpty(sData.stateGovCode))
                {
                    response.Status = "false";
                    response.Message = "Please enter state gov code";
                }
                else if (string.IsNullOrEmpty(sData.name))
                {
                    response.Status = "false";
                    response.Message = "Please enter state name";
                }
                else
                {
                    var addEditResponse = _saData.UpdateStatedetail(sData);
                    response.Status = "true";
                    response.Message = addEditResponse.message;
                }
                return response;
            }
            catch (Exception e)
            {
                response.Status = "false";
                response.Message = $"Unable to process - {e.Message}";
                return response;
            }
        }
        public List<StateDetails> RetrieveAllStates()
        {
            var data = _saData.RetrieveAllStates();
            return data;
        }
        public List<StateDetails> RetrieveStateById(int id)
        {
            var data = _saData.RetrieveStateById(id);
            return data;
        }
        #endregion

        #region District Master
        public async Task<AddEditResponse> AddDistrictDetail(AddDistrictRequest data)
        {
            var response = new AddEditResponse();
            try
            {
                if (string.IsNullOrEmpty(data.districtGovCode))
                {
                    response.Status = "false";
                    response.Message = "Please enter district gov code";
                }
                else if (string.IsNullOrEmpty(data.name))
                {
                    response.Status = "false";
                    response.Message = "Please enter district name";
                }
                else if (data.stateId <= 0)
                {
                    response.Status = "false";
                    response.Message = "Invalid State";
                }
                else
                {
                    var addEditResponse = _saData.AddDistrictDetail(data);
                    response.Status = "true";
                    response.Message = addEditResponse.message;
                }
                return response;
            }
            catch (Exception e)
            {
                response.Status = "false";
                response.Message = $"Unable to process - {e.Message}";
                return response;
            }
        }
        public async Task<AddEditResponse> UpdateDistrictDetail(UpdateDistrictRequest data)
        {
            var response = new AddEditResponse();
            try
            {
                if (string.IsNullOrEmpty(data.districtGovCode))
                {
                    response.Status = "false";
                    response.Message = "Please enter district gov code";
                }
                else if (string.IsNullOrEmpty(data.name))
                {
                    response.Status = "false";
                    response.Message = "Please enter district name";
                }
                else if (data.stateId <= 0)
                {
                    response.Status = "false";
                    response.Message = "Invalid State";
                }
                else
                {
                    var addEditResponse = _saData.UpdateDistrictDetail(data);
                    response.Status = "true";
                    response.Message = addEditResponse.message;
                }
                return response;
            }
            catch (Exception e)
            {
                response.Status = "false";
                response.Message = $"Unable to process - {e.Message}";
                return response;
            }
        }
        public List<DistrictDetail> RetrieveAllDistricts()
        {
            var data = _saData.RetrieveAllDistricts();
            return data;
        }
        public List<DistrictDetail> RetrieveDistrictById(int id)
        {
            var data = _saData.RetrieveDistrictById(id);
            return data;
        }
        #endregion

        #region Block Master
        public async Task<AddEditResponse> AddBlockDetail(AddBlockRequest data)
        {
            var response = new AddEditResponse();
            try
            {
                if (string.IsNullOrEmpty(data.blockGovCode))
                {
                    response.Status = "false";
                    response.Message = "Please enter block gov code";
                }
                else if (string.IsNullOrEmpty(data.name))
                {
                    response.Status = "false";
                    response.Message = "Please enter block name";
                }
                else if (data.districtId <= 0)
                {
                    response.Status = "false";
                    response.Message = "Invalid district";
                }
                else
                {
                    var addEditResponse = _saData.AddBlockDetail(data);
                    response.Status = "true";
                    response.Message = addEditResponse.message;
                }
                return response;
            }
            catch (Exception e)
            {
                response.Status = "false";
                response.Message = $"Unable to process - {e.Message}";
                return response;
            }
        }
        public async Task<AddEditResponse> UpdateBlockDetail(UpdateBlockRequest data)
        {
            var response = new AddEditResponse();
            try
            {
                if (string.IsNullOrEmpty(data.blockGovCode))
                {
                    response.Status = "false";
                    response.Message = "Please enter block gov code";
                }
                else if (string.IsNullOrEmpty(data.name))
                {
                    response.Status = "false";
                    response.Message = "Please enter block name";
                }
                else if (data.districtId <= 0)
                {
                    response.Status = "false";
                    response.Message = "Invalid district";
                }
                else
                {
                    var addEditResponse = _saData.UpdateBlockDetail(data);
                    response.Status = "true";
                    response.Message = addEditResponse.message;
                }
                return response;
            }
            catch (Exception e)
            {
                response.Status = "false";
                response.Message = $"Unable to process - {e.Message}";
                return response;
            }
        }
        public List<BlockDetail> RetrieveBlockById(int id)
        {
            var data = _saData.RetrieveBlockById(id);
            return data;
        }
        public List<BlockDetail> RetrieveAllBlocks()
        {
            var data = _saData.RetrieveAllBlocks();
            return data;
        }
        #endregion

        #region CHC Master
        public async Task<AddEditResponse> AddCHCDetail(AddCHCRequest data)
        {
            var response = new AddEditResponse();
            try
            {
                if (string.IsNullOrEmpty(data.chcGovCode))
                {
                    response.Status = "false";
                    response.Message = "Please enter chc gov code";
                }
                else if (string.IsNullOrEmpty(data.name))
                {
                    response.Status = "false";
                    response.Message = "Please enter chc name";
                }
                else if (data.districtId <= 0)
                {
                    response.Status = "false";
                    response.Message = "Invalid district";
                }
                else if (data.blockId <= 0)
                {
                    response.Status = "false";
                    response.Message = "Invalid block";
                }
                else
                {
                    var addEditResponse = _saData.AddCHCDetail(data);
                    response.Status = "true";
                    response.Message = addEditResponse.message;
                }
                return response;
            }
            catch (Exception e)
            {
                response.Status = "false";
                response.Message = $"Unable to process - {e.Message}";
                return response;
            }
        }
        public async Task<AddEditResponse> UpdateCHCDetail(UpdateCHCRequest data)
        {
            var response = new AddEditResponse();
            try
            {
                if (string.IsNullOrEmpty(data.chcGovCode))
                {
                    response.Status = "false";
                    response.Message = "Please enter chc gov code";
                }
                else if (string.IsNullOrEmpty(data.name))
                {
                    response.Status = "false";
                    response.Message = "Please enter chc name";
                }
                else if (data.districtId <= 0)
                {
                    response.Status = "false";
                    response.Message = "Invalid district";
                }
                else if (data.blockId <= 0)
                {
                    response.Status = "false";
                    response.Message = "Invalid block";
                }
                else
                {
                    var addEditResponse = _saData.UpdateCHCDetail(data);
                    response.Status = "true";
                    response.Message = addEditResponse.message;
                }
                return response;
            }
            catch (Exception e)
            {
                response.Status = "false";
                response.Message = $"Unable to process - {e.Message}";
                return response;
            }
        }
        public List<CHCDetail> RetrieveCHCById(int id)
        {
            var data = _saData.RetrieveCHCById(id);
            return data;
        }
        public List<CHCDetail> RetrieveAllCHCs()
        {
            var data = _saData.RetrieveAllCHCs();
            return data;
        }
        #endregion

        #region PHC Master
        public async Task<AddEditResponse> AddPHCDetail(AddPHCRequest data)
        {
            var response = new AddEditResponse();
            try
            {
                if (string.IsNullOrEmpty(data.phcGovCode))
                {
                    response.Status = "false";
                    response.Message = "Please enter phc gov code";
                }
                else if (string.IsNullOrEmpty(data.name))
                {
                    response.Status = "false";
                    response.Message = "Please enter phc name";
                }
                else if (data.chcId <= 0)
                {
                    response.Status = "false";
                    response.Message = "Invalid chc";
                }
                else
                {
                    var addEditResponse = _saData.AddPHCDetail(data);
                    response.Status = "true";
                    response.Message = addEditResponse.message;
                }
                return response;
            }
            catch (Exception e)
            {
                response.Status = "false";
                response.Message = $"Unable to process - {e.Message}";
                return response;
            }
        }
        public async Task<AddEditResponse> UpdatePHCDetail(UpdatePHCRequest data)
        {
            var response = new AddEditResponse();
            try
            {
                if (string.IsNullOrEmpty(data.phcGovCode))
                {
                    response.Status = "false";
                    response.Message = "Please enter phc gov code";
                }
                else if (string.IsNullOrEmpty(data.name))
                {
                    response.Status = "false";
                    response.Message = "Please enter phc name";
                }
                else if (data.chcId <= 0)
                {
                    response.Status = "false";
                    response.Message = "Invalid chc";
                }
                else
                {
                    var addEditResponse = _saData.UpdatePHCDetail(data);
                    response.Status = "true";
                    response.Message = addEditResponse.message;
                }
                return response;
            }
            catch (Exception e)
            {
                response.Status = "false";
                response.Message = $"Unable to process - {e.Message}";
                return response;
            }
        }
        public List<PHCDetail> RetrievePHCById(int id)
        {
            var data = _saData.RetrievePHCById(id);
            return data;
        }
        public List<PHCDetail> RetrieveAllPHCs()
        {
            var data = _saData.RetrieveAllPHCs();
            return data;
        }
        #endregion

        #region SC Master
        public async Task<AddEditResponse> AddSCDetail(AddSCRequest data)
        {
            var response = new AddEditResponse();
            try
            {
                if (string.IsNullOrEmpty(data.scGovCode))
                {
                    response.Status = "false";
                    response.Message = "Please enter sc gov code";
                }
                else if (string.IsNullOrEmpty(data.name))
                {
                    response.Status = "false";
                    response.Message = "Please enter sc name";
                }
                else if (data.chcId <= 0)
                {
                    response.Status = "false";
                    response.Message = "Invalid chc";
                }
                else if (data.phcId <= 0)
                {
                    response.Status = "false";
                    response.Message = "Invalid phc";
                }
                else
                {
                    var addEditResponse = _saData.AddSCDetail(data);
                    response.Status = "true";
                    response.Message = addEditResponse.message;
                }
                return response;
            }
            catch (Exception e)
            {
                response.Status = "false";
                response.Message = $"Unable to process - {e.Message}";
                return response;
            }
        }
        public async Task<AddEditResponse> UpdateSCDetail(UpdateSCRequest data)
        {
            var response = new AddEditResponse();
            try
            {
                if (string.IsNullOrEmpty(data.scGovCode))
                {
                    response.Status = "false";
                    response.Message = "Please enter sc gov code";
                }
                else if (string.IsNullOrEmpty(data.name))
                {
                    response.Status = "false";
                    response.Message = "Please enter sc name";
                }
                else if (data.chcId <= 0)
                {
                    response.Status = "false";
                    response.Message = "Invalid chc";
                }
                else if (data.phcId <= 0)
                {
                    response.Status = "false";
                    response.Message = "Invalid phc";
                }
                else
                {
                    var addEditResponse = _saData.UpdateSCDetail(data);
                    response.Status = "true";
                    response.Message = addEditResponse.message;
                }
                return response;
            }
            catch (Exception e)
            {
                response.Status = "false";
                response.Message = $"Unable to process - {e.Message}";
                return response;
            }
        }
        public List<SCDetail> RetrieveSCById(int id)
        {
            var data = _saData.RetrieveSCById(id);
            return data;
        }
        public List<SCDetail> RetrieveAllSCs()
        {
            var data = _saData.RetrieveAllSCs();
            return data;
        }
        #endregion
    }
}
