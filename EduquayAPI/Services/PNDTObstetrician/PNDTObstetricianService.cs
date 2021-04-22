using EduquayAPI.Contracts.V1.Request.Obstetrician;
using EduquayAPI.Contracts.V1.Response.Obstetrician;
using EduquayAPI.DataLayer.PNDTObstetrician;
using EduquayAPI.Models.PNDTObstetrician;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Services.PNDTObstetrician
{
    public class PNDTObstetricianService : IPNDTObstetricianService
    {
        private readonly IPNDTObstetricianData _pndtObstetricianData;

        public PNDTObstetricianService(IPNDTObstetricianDataFactory pndtObstetricianData)
        {
            _pndtObstetricianData = new PNDTObstetricianDataFactory().Create();
        }

        public async Task<AddPNDTResponse> AddPNDTest(AddPNDTestRequest aData)
        {
            var sResponse = new AddPNDTResponse();
            try
            {
                if (aData.obstetricianId <= 0)
                {
                    sResponse.Status = "false";
                    sResponse.Message = "Invalid Obstetrician";
                    return sResponse;
                }
                else if (string.IsNullOrEmpty(aData.pndtDateTime))
                {
                    sResponse.Status = "false";
                    sResponse.Message = "PNDT date and time is missing";
                    return sResponse;
                }

                else if (string.IsNullOrEmpty(aData.clinicalHistory))
                {
                    sResponse.Status = "false";
                    sResponse.Message = "Clinical history is missing";
                    return sResponse;
                }
                else if (string.IsNullOrEmpty(aData.examination))
                {
                    sResponse.Status = "false";
                    sResponse.Message = "Examination is missing";
                    return sResponse;
                }
                else if (aData.procedureOfTestingId <= 0)
                {
                    sResponse.Status = "false";
                    sResponse.Message = "Invalid procedure for testing id";
                    return sResponse;
                }
                else if (string.IsNullOrEmpty(aData.pndtComplecationsId))
                {
                    sResponse.Status = "false";
                    sResponse.Message = "Complications are missing";
                    return sResponse;
                }
                else
                {
                    var pndtMsg = _pndtObstetricianData.AddPNDTest(aData);
                    sResponse.Status = "true";
                    sResponse.Message = string.Empty;
                    sResponse.data = pndtMsg;
                    return sResponse;
                }

            }
            catch (Exception e)
            {
                sResponse.Status = "false";
                sResponse.Message = $"Unable to add PND Test - {e.Message}";
                return sResponse;
            }

        }

        public string AddPNDTCheckValidation(AddPNDTRequest aData)
        {
            string msg = "";
            List<string> stringSampleRefIdList = aData.sampleRefId.Split(',').ToList();
            List<string> stringCVSList = aData.cvsSampleRefId.Split(',').ToList();
            List<string> stringFoetusList = aData.foetusName.Split(',').ToList();
            int sr, cv, fn;
            sr = stringSampleRefIdList.Count(); 
            cv = stringCVSList.Count(); 
            fn = stringFoetusList.Count();
            if (aData.obstetricianId <= 0)
            {
                msg = "Invalid Obstetrician";
            }
            else if (string.IsNullOrEmpty(aData.pndtDateTime))
            {
               msg  = "PNDT date and time is missing";
            }
            else if (string.IsNullOrEmpty(aData.clinicalHistory))
            {
                msg = "Clinical history is missing";
            }
            else if (string.IsNullOrEmpty(aData.examination))
            {
               msg= "Examination is missing";
            }
            else if (aData.procedureOfTestingId <= 0)
            {
               msg = "Invalid procedure for testing id";
            }
            else if (string.IsNullOrEmpty(aData.pndtComplecationsId))
            {
                msg = "Complications are missing";
            }
            else if (aData.pregnancyType <= 0)
            {
                msg = "Invalid type of pregnancy";
            }
            else if (string.IsNullOrEmpty(aData.sampleRefId))
            {
                msg = "Sample reference id is missing";
            }
            else if (string.IsNullOrEmpty(aData.foetusName))
            {
                msg = "Foetus name is missing";
            }
            else if (string.IsNullOrEmpty(aData.cvsSampleRefId))
            {
                msg = "CVS sample id is missing";
            }
            else if (string.IsNullOrEmpty(aData.assistedBy))
            {
                msg = "Assisted by is missing";
            }
            if (sr != cv || sr != fn || cv != fn)
            {
                msg = "samplerefid , foetusname , cvssamplerefid counts are not equal.";
            }
            return msg;
        }


        public async Task<AddPNDTResponse> AddPNDTestNew(AddPNDTRequest aData)
        {
            var sResponse = new AddPNDTResponse();
            var msg = AddPNDTCheckValidation(aData);
            try
            {
                if (msg == "")
                {
                    var pndtMsg = _pndtObstetricianData.AddPNDTestNew(aData);
                    sResponse.Status = "true";
                    sResponse.Message = string.Empty;
                    sResponse.data = pndtMsg;
                    return sResponse;
                }
                else
                {
                    sResponse.Status = "false";
                    sResponse.Message = msg;
                    return sResponse;
                }
            }
            catch (Exception e)
            {
                sResponse.Status = "false";
                sResponse.Message = $"Unable to add PND Test - {e.Message}";
                return sResponse;
            }
        }

        //public List<PNDTCompletedSummary> GetPNDTCompletedSummary()
        //{
        //    var completedData = _pndtObstetricianData.GetPNDTCompletedSummary();
        //    return completedData;
        //}

        public List<PNDTNotCompleted> GetPNDTNotCompleted(ObstetricianRequest oData)
        {
            var notCompletedData = _pndtObstetricianData.GetPNDTNotCompleted(oData);
            return notCompletedData;
        }

        public List<PNDTPending> GetPNDTPending(ObstetricianRequest oData)
        {
            var pendingData = _pndtObstetricianData.GetPNDTPending(oData);
            return pendingData;
        }

        public async Task<PNDTCompletedSummaryResponse> GetPNDTCompletedSummary()
        {
            var completedTestDetail = _pndtObstetricianData.GetPNDTCompletedSummary();
            var completedTestResponse = new PNDTCompletedSummaryResponse();
            var completedTestANWDetail = new List<PNDTCompletedDetail>();
            try
            {
                int pndTestId = 0;
                foreach (var testDetil in completedTestDetail.anwDetail)
                {

                    if (pndTestId != testDetil.pndTestId)
                    {
                        var testANWDetail = new PNDTCompletedDetail();
                        var foetusDetail = completedTestDetail.foetusDetail.Where(sd => sd.pndTestId == testDetil.pndTestId).ToList();
                        testANWDetail.anwSubjectId = testDetil.anwSubjectId;
                        testANWDetail.subjectName = testDetil.subjectName;
                        testANWDetail.spouseSubjectId = testDetil.spouseSubjectId;
                        testANWDetail.spouseName = testDetil.spouseName;
                        testANWDetail.rchId = testDetil.rchId;
                        testANWDetail.contactNo = testDetil.contactNo;
                        testANWDetail.age = testDetil.age;
                        testANWDetail.spouseAge = testDetil.spouseAge;
                        testANWDetail.ecNumber = testDetil.ecNumber;
                        testANWDetail.ga = testDetil.ga;
                        testANWDetail.obstetricScore = testDetil.obstetricScore;
                        testANWDetail.lmpDate = testDetil.lmpDate;
                        testANWDetail.anwCBCTestResult = testDetil.anwCBCTestResult;
                        testANWDetail.anwSSTestResult = testDetil.anwSSTestResult;
                        testANWDetail.anwHPLCTestResult = testDetil.anwHPLCTestResult;
                        testANWDetail.anwHPLCDiagnosis = testDetil.anwHPLCDiagnosis;
                        testANWDetail.spouseCBCTestResult = testDetil.spouseCBCTestResult;
                        testANWDetail.spouseSSTestResult = testDetil.spouseSSTestResult;
                        testANWDetail.spouseHPLCTestResult = testDetil.spouseHPLCTestResult;
                        testANWDetail.spouseHPLCDiagnosis = testDetil.spouseHPLCDiagnosis;
                        testANWDetail.prePNDTCounsellingId = testDetil.prePNDTCounsellingId;
                        testANWDetail.schedulingId = testDetil.schedulingId;
                        testANWDetail.counsellingDateTime = testDetil.counsellingDateTime;
                        testANWDetail.counsellorId = testDetil.counsellorId;
                        testANWDetail.counsellorName = testDetil.counsellorName;
                        testANWDetail.obstetricianId = testDetil.obstetricianId;
                        testANWDetail.obstetricianName = testDetil.obstetricianName;
                        testANWDetail.schedulePNDTDate = testDetil.schedulePNDTDate;
                        testANWDetail.schedulePNDTTime = testDetil.schedulePNDTTime;
                        testANWDetail.counsellingRemarks = testDetil.counsellingRemarks;
                        testANWDetail.counsellingStatus = testDetil.counsellingStatus;
                        testANWDetail.pndTestId = testDetil.pndTestId;
                        testANWDetail.clinicalHistory = testDetil.clinicalHistory;
                        testANWDetail.examination = testDetil.examination;
                        testANWDetail.procedureofTesting = testDetil.procedureofTesting;
                        testANWDetail.pndtComplecations = testDetil.pndtComplecations;
                        testANWDetail.motherVoided = testDetil.motherVoided;
                        testANWDetail.motherVitalStable = testDetil.motherVitalStable;
                        testANWDetail.foetalHeartRateDocumentScan = testDetil.foetalHeartRateDocumentScan;
                        testANWDetail.anwMCV = testDetil.anwMCV;
                        testANWDetail.anwRDW = testDetil.anwRDW;
                        testANWDetail.anwRBC = testDetil.anwRBC;
                        testANWDetail.anwHbA0 = testDetil.anwHbA0;
                        testANWDetail.anwHbA2 = testDetil.anwHbA2;
                        testANWDetail.anwHbF = testDetil.anwHbF;
                        testANWDetail.anwHbS = testDetil.anwHbS;
                        testANWDetail.anwHbD = testDetil.anwHbD;
                        testANWDetail.spouseMCV = testDetil.spouseMCV;
                        testANWDetail.spouseRDW = testDetil.spouseRDW;
                        testANWDetail.spouseRBC = testDetil.spouseRBC;
                        testANWDetail.spouseHbA0 = testDetil.spouseHbA0;
                        testANWDetail.spouseHbA2 = testDetil.spouseHbA2;
                        testANWDetail.spouseHbF = testDetil.spouseHbF;
                        testANWDetail.spouseHbS = testDetil.spouseHbS;
                        testANWDetail.spouseHbD = testDetil.spouseHbD;
                        testANWDetail.anwPathoRemarks = testDetil.anwPathoRemarks;
                        testANWDetail.spousePathoRemarks = testDetil.spousePathoRemarks;
                        testANWDetail.foetusDetail = foetusDetail;
                        pndTestId = testDetil.pndTestId;
                        completedTestANWDetail.Add(testANWDetail);
                    }
                }
                completedTestResponse.data = completedTestANWDetail;
                completedTestResponse.Status = "true";
                completedTestResponse.Message = string.Empty;
                return completedTestResponse;
            }
            catch (Exception e)
            {
                completedTestResponse.Status = "false";
                completedTestResponse.Message = e.Message;
                return completedTestResponse;
            }
        }
    }
}
