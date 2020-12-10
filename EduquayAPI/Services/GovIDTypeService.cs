using EduquayAPI.Contracts.V1.Request;
using EduquayAPI.Contracts.V1.Response.Masters;
using EduquayAPI.DataLayer;
using EduquayAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Services
{
    public class GovIDTypeService : IGovIDTypeService
    {
        private readonly IGovIDTypeData _govidTypeData;

        public GovIDTypeService(IFacilityTypeDataFactory govidtypeDataFactory)
        {
            _govidTypeData = new GovIDTypeDataFactory().Create();
        }
        public async Task<AddEditResponse> Add(GovIDTypeRequest gtData)
        {
            var response = new AddEditResponse();
            try
            {
                if (gtData.isActive.ToLower() != "true")
                {
                    gtData.isActive = "false";
                }
                if (string.IsNullOrEmpty(gtData.govIdTypeName))
                {
                    response.Status = "false";
                    response.Message = "Please enter gov id type";
                }
                else
                {
                    var addEditResponse = _govidTypeData.Add(gtData);
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

        public List<GovIDType> Retrieve(int code)
        {
            var govidType = _govidTypeData.Retrieve(code);
            return govidType;
        }

        public List<GovIDType> Retrieve()
        {
            var allGovIDTypes = _govidTypeData.Retrieve();
            return allGovIDTypes;
        }
    }
}
