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
        #endregion
    }
}
