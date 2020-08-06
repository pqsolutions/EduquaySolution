using EduquayAPI.Contracts.V1.Request.Pathologist;
using EduquayAPI.Contracts.V1.Response;
using EduquayAPI.Contracts.V1.Response.Pathologist;
using EduquayAPI.DataLayer.Pathologist;
using EduquayAPI.Models.Pathologist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace EduquayAPI.Services.Pathologist
{
    public class PathologistService : IPathologistService
    {
        private readonly IPathologistData _pathologistData;

        public PathologistService(IPathologistDataFactory pathologistDataFactory)
        {
            _pathologistData = new PathologistDataFactory().Create();
        }

        public async Task<ServiceResponse> AddHPLCDiagnosisResult(AddHPLCDiagnosisResultRequest aData)
        {
            var sResponse = new ServiceResponse();
            try
            {
                if (string.IsNullOrEmpty(aData.uniqueSubjectId))
                {
                    sResponse.Status = "false";
                    sResponse.Message = "Uniquesubjectid is missing";
                    return sResponse;
                }
                else if (string.IsNullOrEmpty(aData.barcodeNo))
                {
                    sResponse.Status = "false";
                    sResponse.Message = "Barcode no is missing";
                    return sResponse;
                }
                else if (aData.centralLabId <= 0)
                {
                    sResponse.Status = "false";
                    sResponse.Message = "Invalid Central Lab Id";
                    return sResponse;
                }
                else if (aData.hplcTestResultId <= 0)
                {
                    sResponse.Status = "false";
                    sResponse.Message = "Invalid hplc test result Id";
                    return sResponse;
                }
                else if (aData.clinicalDiagnosisId <= 0)
                {
                    sResponse.Status = "false";
                    sResponse.Message = "Invalid clinical diagnosis Id";
                    return sResponse;
                }
                else if (string.IsNullOrEmpty(aData.hplcResultMasterId))
                {
                    sResponse.Status = "false";
                    sResponse.Message = "HPLC result is missing";
                    return sResponse;
                }
                else if (aData.userId <= 0)
                {
                    sResponse.Status = "false";
                    sResponse.Message = "Invalid pathologist";
                    return sResponse;
                }
                else
                {
                    var result = _pathologistData.AddHPLCDiagnosisResult(aData);
                    if (string.IsNullOrEmpty(result))
                    {
                        sResponse.Status = "false";
                        sResponse.Message = $"Unable to  update the hplc diagnosis result  for this uniquesubjectid - {aData.uniqueSubjectId}";
                        return sResponse;
                    }
                    else
                    {
                        sResponse.Status = "true";
                        sResponse.Message = result;
                        return sResponse;
                    }
                }
            }
            catch (Exception e)
            {
                sResponse.Status = "false";
                sResponse.Message = $"Unable to update the hplc diagnosis result  for this uniquesubjectid - {aData.uniqueSubjectId} - {e.Message}";
                return sResponse;
            }
        }

        public List<HPLCResult> HPLCResult()
        {
            var allHPLCResult = _pathologistData.HPLCResult();
            return allHPLCResult;
        }

        public async Task<HPLCTestDetailResponse> HPLCResultDetail(int centralLabId)
        {
            var hplcResultResponse = new HPLCTestDetailResponse();
            try
            {
                var hplcData = _pathologistData.HPLCResultDetail(centralLabId);
                hplcResultResponse.Status = "true";
                hplcResultResponse.Message = "";
                hplcResultResponse.SubjectDetails = hplcData;
            }
            catch (Exception e)
            {
                hplcResultResponse.Status = "true";
                hplcResultResponse.Message = e.Message;
            }
            return hplcResultResponse;
        }
    }
}
