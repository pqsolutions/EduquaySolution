using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EduquayAPI.Contracts.V1.Request;
using EduquayAPI.Contracts.V1.Response.Masters;
using EduquayAPI.DataLayer;
using EduquayAPI.Models;

namespace EduquayAPI.Services
{
    public class PHCService : IPHCService
    {
        private readonly IPHCData _phcData;

        public PHCService(IPHCDataFactory phcDataFactory)
        {
            _phcData = new PHCDataFactory().Create();
        }
        public async Task<AddEditResponse> Add(PHCRequest pData)
        {

            var response = new AddEditResponse();
            try
            {
                if (pData.isActive.ToLower() != "true")
                {
                    pData.isActive = "false";
                }
                if (string.IsNullOrEmpty(pData.phcGovCode))
                {
                    response.Status = "false";
                    response.Message = "Please enter phc gov code";
                }
                else if (pData.chcId <= 0)
                {
                    response.Status = "false";
                    response.Message = "Invalid CHC id";
                }
                else
                {
                    var addEditResponse = _phcData.Add(pData);
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

        public List<PHC> Retrieve(int code)
        {
            var phc = _phcData.Retrieve(code);
            return phc;
        }

        public List<PHC> Retrieve()
        {
            var allPHCs = _phcData.Retrieve();
            return allPHCs;
        }
    }
}
