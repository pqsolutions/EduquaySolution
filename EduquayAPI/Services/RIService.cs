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
    public class RIService : IRIService
    {

        private readonly IRIData _riData;

        public RIService(IRIDataFactory riDataFactory)
        {
            _riData = new RIDataFactory().Create();
        }
        public async Task<AddEditResponse> Add(RIRequest rData)
        {
            var response = new AddEditResponse();
            try
            {
                if (rData.isActive.ToLower() != "true")
                {
                    rData.isActive = "false";
                }
                if (string.IsNullOrEmpty(rData.riGovCode))
                {
                    response.Status = "false";
                    response.Message = "Please enter ri gov code";
                }
                else if (rData.phcId <= 0)
                {
                    response.Status = "false";
                    response.Message = "Invalid PHC id";
                }
                else if (rData.scId <= 0)
                {
                    response.Status = "false";
                    response.Message = "Invalid SC id";
                }
                else if (rData.ilrId <= 0)
                {
                    response.Status = "false";
                    response.Message = "Invalid ILR id";
                }
                else
                {
                    var addEditResponse = _riData.Add(rData);
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

        public List<RI> Retrieve(int code)
        {
            var ri = _riData.Retrieve(code);
            return ri;
        }

        public List<RI> Retrieve()
        {
            var allRIs = _riData.Retrieve();
            return allRIs;
        }
    }
}
