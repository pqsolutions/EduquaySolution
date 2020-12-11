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
    public class ClinicalDiagnosisService : IClinicalDiagnosisService
    {
        private readonly IClinicalDiagnosisData _clinicalDiagnosisData;

        public ClinicalDiagnosisService(IClinicalDiagnosisDataFactory clinicalDiagnosisDataFactory)
        {
            _clinicalDiagnosisData = new ClinicalDiagnosisDataFactory().Create();
        }

        public async Task<AddEditResponse> Add(ClinicalDiagnosisRequest cdData)
        {
            var response = new AddEditResponse();
            try
            {
                if (cdData.isActive.ToLower() != "true")
                {
                    cdData.isActive = "false";
                }
                if (string.IsNullOrEmpty(cdData.diagnosisName))
                {
                    response.Status = "false";
                    response.Message = "Please enter diagnosis name";
                }
                else
                {
                    var addEditResponse = _clinicalDiagnosisData.Add(cdData);
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

        public List<ClinicalDiagnosis> Retrieve(int code)
        {
            var clinicalDiagnosis = _clinicalDiagnosisData.Retrieve(code);
            return clinicalDiagnosis;
        }

        public List<ClinicalDiagnosis> Retrieve()
        {
            var clinicalDiagnosis = _clinicalDiagnosisData.Retrieve();
            return clinicalDiagnosis;
        }
    }
}
