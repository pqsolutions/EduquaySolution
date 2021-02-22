using EduquayAPI.Contracts.V1.Response.Hematologist;
using EduquayAPI.DataLayer.Hematologist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Services.Hematologist
{
    public class HematologistService : IHematologistService
    {
        private readonly IHematologistData _hematologistData;

        public HematologistService(IHematologistDataFactory hematologistDataFactory)
        {
            _hematologistData = new HematologistDataFactory().Create();
        }
        public async Task<CompletedMolecularTestResponse> RetrieveCompletedMolecularDetail(int molecularLabId)
        {
            var completedMolecularTestDetail = _hematologistData.RetrieveCompletedMolecularDetail(molecularLabId);
            var completedTestResponse = new CompletedMolecularTestResponse();
            var completedMolTestANWDetail = new List<CompletedMolTestANWDetail>();
            try
            {
                int pndTestId = 0;
                foreach (var testDetil in completedMolecularTestDetail.anwDetail)
                {

                    if (pndTestId != testDetil.pndTestId)
                    {
                        var molTestANWDetail = new CompletedMolTestANWDetail();
                        var foetusDetail = completedMolecularTestDetail.foetusDetail.Where(sd => sd.pndTestId == testDetil.pndTestId).ToList();
                        molTestANWDetail.anwSubjectId = testDetil.anwSubjectId;
                        molTestANWDetail.subjectName = testDetil.subjectName;
                        molTestANWDetail.spouseSubjectId = testDetil.spouseSubjectId;
                        molTestANWDetail.spouseName = testDetil.spouseName;
                        molTestANWDetail.rchId = testDetil.rchId;
                        molTestANWDetail.contactNo = testDetil.contactNo;
                        molTestANWDetail.age = testDetil.age;
                        molTestANWDetail.spouseAge = testDetil.spouseAge;
                        molTestANWDetail.ecNumber = testDetil.ecNumber;
                        molTestANWDetail.ga = testDetil.ga;
                        molTestANWDetail.obstetricScore = testDetil.obstetricScore;
                        molTestANWDetail.lmpDate = testDetil.lmpDate;
                        molTestANWDetail.anwSSTestResult = testDetil.anwSSTestResult;
                        molTestANWDetail.anwHPLCTestResult = testDetil.anwHPLCTestResult;
                        molTestANWDetail.anwHPLCDiagnosis = testDetil.anwHPLCDiagnosis;
                        molTestANWDetail.spouseCBCTestResult = testDetil.spouseCBCTestResult;
                        molTestANWDetail.spouseSSTestResult = testDetil.spouseSSTestResult;
                        molTestANWDetail.spouseHPLCTestResult = testDetil.spouseHPLCTestResult;
                        molTestANWDetail.spouseHPLCDiagnosis = testDetil.spouseHPLCDiagnosis;
                        molTestANWDetail.prePNDTCounsellingId = testDetil.prePNDTCounsellingId;
                        molTestANWDetail.schedulingId = testDetil.schedulingId;
                        molTestANWDetail.counsellingDateTime = testDetil.counsellingDateTime;
                        molTestANWDetail.counsellorId = testDetil.counsellorId;
                        molTestANWDetail.counsellorName = testDetil.counsellorName;
                        molTestANWDetail.obstetricianId = testDetil.obstetricianId;
                        molTestANWDetail.obstetricianName = testDetil.obstetricianName;
                        molTestANWDetail.schedulePNDTDate = testDetil.schedulePNDTDate;
                        molTestANWDetail.schedulePNDTTime = testDetil.schedulePNDTTime;
                        molTestANWDetail.counsellingRemarks = testDetil.counsellingRemarks;
                        molTestANWDetail.counsellingStatus = testDetil.counsellingStatus;
                        molTestANWDetail.pndTestId = testDetil.pndTestId;
                        molTestANWDetail.clinicalHistory = testDetil.clinicalHistory;
                        molTestANWDetail.examination = testDetil.examination;
                        molTestANWDetail.procedureofTesting = testDetil.procedureofTesting;
                        molTestANWDetail.pndtComplecations = testDetil.pndtComplecations;
                        molTestANWDetail.motherVoided = testDetil.motherVoided;
                        molTestANWDetail.motherVitalStable = testDetil.motherVitalStable;
                        molTestANWDetail.anwMCV = testDetil.anwMCV;
                        molTestANWDetail.anwRDW = testDetil.anwRDW;
                        molTestANWDetail.anwRBC = testDetil.anwRBC;
                        molTestANWDetail.anwHbA0 = testDetil.anwHbA0;
                        molTestANWDetail.anwHbA2 = testDetil.anwHbA2;
                        molTestANWDetail.anwHbF = testDetil.anwHbF;
                        molTestANWDetail.anwHbS = testDetil.anwHbS;
                        molTestANWDetail.anwHbD = testDetil.anwHbD;
                        molTestANWDetail.spouseMCV = testDetil.spouseMCV;
                        molTestANWDetail.spouseRDW = testDetil.spouseRDW;
                        molTestANWDetail.spouseRBC = testDetil.spouseRBC;
                        molTestANWDetail.spouseHbA0 = testDetil.spouseHbA0;
                        molTestANWDetail.spouseHbA2 = testDetil.spouseHbA2;
                        molTestANWDetail.spouseHbF = testDetil.spouseHbF;
                        molTestANWDetail.spouseHbS = testDetil.spouseHbS;
                        molTestANWDetail.spouseHbD = testDetil.spouseHbD;
                        molTestANWDetail.anwPathoRemarks = testDetil.anwPathoRemarks;
                        molTestANWDetail.spousePathoRemarks = testDetil.spousePathoRemarks;
                        molTestANWDetail.foetusDetail = foetusDetail;
                        pndTestId = testDetil.pndTestId;

                        completedMolTestANWDetail.Add(molTestANWDetail);
                    }

                }
                completedTestResponse.data = completedMolTestANWDetail;
                completedTestResponse.Status = "true";
                completedTestResponse.Message = string.Empty;
            }
            catch (Exception e)
            {
                completedTestResponse.Status = "false";
                completedTestResponse.Message = e.Message;
            }
            return completedTestResponse;
        }
    }
}
