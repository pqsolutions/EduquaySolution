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
                else if (aData.clinicalDiagnosisId == "")
                {
                    sResponse.Status = "false";
                    sResponse.Message = "Lab diagnosis id is missing";
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

        public async Task<HPLCDiagnosisDetailResponse> EditHPLCDiagnosisDetail(int centralLabId)
        {
            var hplcResultResponse = new HPLCDiagnosisDetailResponse();
            try
            {
                var hplcData = _pathologistData.EditHPLCDiagnosisDetail(centralLabId);
                var hplcAllTestDetail = new List<HPLCDiagnosisDetail>();
                foreach (var hplc in hplcData)
                {
                    var hplcDet = new HPLCDiagnosisDetail();
                    hplcDet.uniqueSubjectId = hplc.uniqueSubjectId;
                    hplcDet.subjectName = hplc.subjectName;
                    hplcDet.barcodeNo = hplc.barcodeNo;
                    hplcDet.rchId = hplc.rchId;
                    hplcDet.ga = hplc.ga;
                    hplcDet.dateOfTest = hplc.dateOfTest;
                    hplcDet.district = hplc.district;
                    hplcDet.testingCHC = hplc.testingCHC;
                    hplcDet.riPoint = hplc.riPoint;
                    hplcDet.age = hplc.age;
                    hplcDet.contactNo = hplc.contactNo;
                    hplcDet.address = hplc.address;
                    hplcDet.spouseName = hplc.spouseName;
                    hplcDet.spouseContact = hplc.spouseContact;
                    hplcDet.lmpDate = hplc.lmpDate;
                    hplcDet.obstetricsScore = hplc.obstetricsScore;
                    hplcDet.sstResult = hplc.sstResult;
                    hplcDet.cbcResult = hplc.cbcResult;
                    hplcDet.mcv = hplc.mcv;
                    hplcDet.rdw = hplc.rdw;
                    hplcDet.rbc = hplc.rbc;
                    hplcDet.hbF = hplc.hbF;
                    hplcDet.hbA0 = hplc.hbA0;
                    hplcDet.hbA2 = hplc.hbA2;
                    hplcDet.hbC = hplc.hbC;
                    hplcDet.hbD = hplc.hbD;
                    hplcDet.hbS = hplc.hbS;
                    hplcDet.isNormal = hplc.isNormal;
                    hplcDet.hplcTestResultId = hplc.hplcTestResultId;
                    DateTime myDate1 = DateTime.Now;
                    DateTime myDate2 = Convert.ToDateTime(hplc.dateOfTest);
                    TimeSpan difference = myDate1.Subtract(myDate2);
                    double totalDays = Math.Round(difference.TotalDays);
                    hplcDet.agingOfTest = Convert.ToString(totalDays);
                    hplcDet.clinicalDiagnosisId = hplc.clinicalDiagnosisId;
                    hplcDet.isConsultSeniorPathologist = hplc.isConsultSeniorPathologist;
                    hplcDet.seniorPathologistName = hplc.seniorPathologistName;
                    hplcDet.seniorPathologistRemarks = hplc.seniorPathologistRemarks;
                    hplcDet.hplcResultMasterId = hplc.hplcResultMasterId;
                    hplcDet.othersResult = hplc.othersResult;
                    hplcDet.diagnosisSummary = hplc.diagnosisSummary;
                    hplcDet.graphFileName = hplc.graphFileName;
                    hplcAllTestDetail.Add(hplcDet);
                }

                hplcResultResponse.Status = "true";
                hplcResultResponse.Message = "";
                hplcResultResponse.SubjectDetails = hplcAllTestDetail;
            }
            catch (Exception e)
            {
                hplcResultResponse.Status = "true";
                hplcResultResponse.Message = e.Message;
            }
            return hplcResultResponse;
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
                _pathologistData.AutomaticHPLCDiagnosisUpdate(centralLabId);

                var hplcData = _pathologistData.HPLCResultDetail(centralLabId);

                var hplcAllTestDetail = new List<HPLCallTestDetail>();
                foreach (var hplc in hplcData)
                {
                    var hplcDet = new HPLCallTestDetail();
                    hplcDet.uniqueSubjectId = hplc.uniqueSubjectId;
                    hplcDet.subjectName = hplc.subjectName;
                    hplcDet.barcodeNo = hplc.barcodeNo;
                    hplcDet.rchId = hplc.rchId;
                    hplcDet.ga = hplc.ga;
                    hplcDet.dateOfTest = hplc.dateOfTest;
                    hplcDet.district = hplc.district;
                    hplcDet.testingCHC = hplc.testingCHC;
                    hplcDet.riPoint = hplc.riPoint;
                    hplcDet.age = hplc.age;
                    hplcDet.contactNo = hplc.contactNo;
                    hplcDet.address = hplc.address;
                    hplcDet.spouseName = hplc.spouseName;
                    hplcDet.spouseContact = hplc.spouseContact;
                    hplcDet.lmpDate = hplc.lmpDate;
                    hplcDet.obstetricsScore = hplc.obstetricsScore;
                    hplcDet.sstResult = hplc.sstResult;
                    hplcDet.cbcResult = hplc.cbcResult;
                    hplcDet.mcv = hplc.mcv;
                    hplcDet.rdw = hplc.rdw;
                    hplcDet.rbc = hplc.rbc;
                    hplcDet.hbF = hplc.hbF;
                    hplcDet.hbA0 = hplc.hbA0;
                    hplcDet.hbA2 = hplc.hbA2;
                    hplcDet.hbC = hplc.hbC;
                    hplcDet.hbD = hplc.hbD;
                    hplcDet.hbS = hplc.hbS;
                    hplcDet.isNormal = hplc.isNormal;
                    hplcDet.hplcTestResultId = hplc.hplcTestResultId;
                    DateTime myDate1 = DateTime.Now;
                    DateTime myDate2 = Convert.ToDateTime(hplc.dateOfTest);
                    TimeSpan difference = myDate1.Subtract(myDate2);
                    double totalDays = Math.Round(difference.TotalDays);
                    hplcDet.agingOfTest = Convert.ToString(totalDays);
                    hplcDet.graphFileName = hplc.graphFileName;
                    hplcAllTestDetail.Add(hplcDet);
                }
                hplcResultResponse.Status = "true";
                hplcResultResponse.Message = "";
                hplcResultResponse.SubjectDetails = hplcAllTestDetail;
            }
            catch (Exception e)
            {
                hplcResultResponse.Status = "true";
                hplcResultResponse.Message = e.Message;
            }
            return hplcResultResponse;
        }

        public List<PathologistSampleStatus> RetrieveSampleStatus()
        {
            var allSampleStatus = _pathologistData.RetrieveSampleStatus();
            return allSampleStatus;
        }

        public List<PathoReports> RetrivePathologistReports(PathoReportsRequest prData)
        {
            var allSubject = _pathologistData.RetrivePathologistReports(prData);
            return allSubject;
        }
    }
}
