using EduquayAPI.Contracts.V1.Request.MolecularLab;
using EduquayAPI.Contracts.V1.Response;
using EduquayAPI.Contracts.V1.Response.MolecularLab;
using EduquayAPI.DataLayer.MolLabResultProcess;
using EduquayAPI.Models.MolecularLab;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Services.MolLabResultProcess
{
    public class MLResultProcessService : IMLResultProcessService
    {

        private readonly IMLResultProcessData _mlResultProcessData;

        public MLResultProcessService(IMLResultProcessDataFactory mlReultProcessDataFactory)
        {
            _mlResultProcessData = new MLResultProcessDataFactory().Create();
        }

        public List<MLabSpecimenForTestStatus> RetriveSpecimenForMolecularEditTest(int molecularLabId)
        {
            var allSubject = _mlResultProcessData.RetriveSpecimenForMolecularEditTest(molecularLabId);
            return allSubject;
        }

        public List<MLabSpecimenForTestStatus> RetriveSpecimenForMolecularTestComplete(int molecularLabId)
        {
            var allSubject = _mlResultProcessData.RetriveSpecimenForMolecularTestComplete(molecularLabId);
            return allSubject;
        }

        public List<MLabSpecimenForTest> RetriveSpecimenSubjectForMolecularTest(int molecularLabId)
        {
            var allSubject = _mlResultProcessData.RetriveSpecimenSubjectForMolecularTest(molecularLabId);
            return allSubject;
        }

        public List<MolecularSubjectsForBloodTestStatus> RetriveSubjectForMolecularBloodTestComplete(int molecularLabId)
        {
            var allSubject = _mlResultProcessData.RetriveSubjectForMolecularBloodTestComplete(molecularLabId);
            return allSubject;
        }

        public List<MolecularSubjectsForBloodTestStatus> RetriveSubjectForMolecularBloodTestEdit(int molecularLabId)
        {
            var allSubject = _mlResultProcessData.RetriveSubjectForMolecularBloodTestEdit(molecularLabId);
            return allSubject;
        }

        public List<MolecularSubjectsForTest> RetriveSubjectForMolecularBloodTest(int molecularLabId)
        {
            var allSubject = _mlResultProcessData.RetriveSubjectForMolecularBloodTest(molecularLabId);
            return allSubject;
        }

        public async Task<ServiceResponse> AddMolecularBloodResult(AddBloodSampleTestRequest mrData)
        {
            var sResponse = new ServiceResponse();
            string message = CheckVal(mrData);
            try
            {
                if (message == "")
                {
                    var result = _mlResultProcessData.AddBloodSamplesTestResult(mrData);
                    if (string.IsNullOrEmpty(result.message))
                    {
                        sResponse.Status = "false";
                        sResponse.Message = $"Unable to update the molecular blood result for this uniquesubjectid - {mrData.uniqueSubjectId}";
                        return sResponse;
                    }
                    else
                    {
                        sResponse.Status = "true";
                        sResponse.Message = result.message;
                        return sResponse;
                    }
                }
                else
                {
                    sResponse.Status = "false";
                    sResponse.Message = message;
                    return sResponse;
                }
            }
            catch (Exception e)
            {
                sResponse.Status = "false";
                sResponse.Message = $"Unable to update the molecular blood result - {e.Message}";
                return sResponse;
            }
        }

        public string CheckVal(AddBloodSampleTestRequest mrData)
        {
            string msg = "";
            if (string.IsNullOrEmpty(mrData.uniqueSubjectId))
            {
                msg = "Uniquesubjectid is missing";
            }
            else if (string.IsNullOrEmpty(mrData.barcodeNo))
            {
                msg = "Barcode is missing";
            }
            else if (mrData.sampleProcessed == true)
            {
                if (mrData.zygosityId <= 0)
                {
                    msg = "Invalid zygosity Id";
                }
                else if (mrData.testResult == "")
                {
                    msg = "Test result is missing";
                }
            }
            else if (mrData.sampleProcessed == false)
            {
                if (string.IsNullOrEmpty(mrData.reasonForClose))
                {
                    msg = "Reason for close is missing";
                }
            }
            if (mrData.userId <= 0)
            {
                msg = "Invalid user Id";
            }
            return msg;
        }

        public string CheckSpecimenVal(AddSpecimenSampleTestRequest mrData)
        {
            string msg = "";
            if (string.IsNullOrEmpty(mrData.uniqueSubjectId))
            {
                msg = "Uniquesubjectid is missing";
            }
            else if (mrData.pndtFoetusId <= 0)
            {
                msg = "Invalid pndt foetus id";
            }
            else if (mrData.sampleProcessed == true)
            {
                if (mrData.zygosityId <= 0)
                {
                    msg = "Invalid zygosity Id";
                }
                else if (mrData.testResult == "")
                {
                    msg = "Test result is missing";
                }
            }
            else if (mrData.sampleProcessed == false)
            {
                if (string.IsNullOrEmpty(mrData.reasonForClose))
                {
                    msg = "Reason for close is missing";
                }
            }
            if (mrData.userId <= 0)
            {
                msg = "Invalid user Id";
            }
            return msg;

        }

        public async Task<ServiceResponse> AddSpecimenSamplesTestResult(AddSpecimenSampleTestRequest mrData)
        {
            var sResponse = new ServiceResponse();
            string message = CheckSpecimenVal(mrData);
            try
            {
                if (message == "")
                {
                    var result = _mlResultProcessData.AddSpecimenSamplesTestResult(mrData);
                    if (string.IsNullOrEmpty(result.message))
                    {
                        sResponse.Status = "false";
                        sResponse.Message = $"Unable to update the molecular specimen result for this uniquesubjectid - {mrData.uniqueSubjectId}";
                        return sResponse;
                    }
                    else
                    {
                        sResponse.Status = "true";
                        sResponse.Message = result.message;
                        return sResponse;
                    }
                }
                else
                {
                    sResponse.Status = "false";
                    sResponse.Message = message;
                    return sResponse;
                }
            }
            catch (Exception e)
            {
                sResponse.Status = "false";
                sResponse.Message = $"Unable to update the molecular specimen result - {e.Message}";
                return sResponse;
            }
        }

        public List<MolecularLabBloodReport> RetriveSubjectForMolecularBloodTestReports(MolecularLabReportRequest rData)
        {
            var allSubject = _mlResultProcessData.RetriveSubjectForMolecularBloodTestReports(rData);
            return allSubject;
        }

        public async Task<SpecimenReportResponse> RetriveSubjectForMolecularSpecimenTestReports(MolecularLabReportRequest rData)
        {
            var specimenReport = _mlResultProcessData.RetriveSubjectForMolecularSpecimenTestReports(rData);
            var specimenResponse = new SpecimenReportResponse();
            var anwDetails = new List<MolecularLabSpecimenReports>();
            try
            {
                int pndTestId = 0;
                foreach (var testDetil in specimenReport.anwDetail)
                {

                    if (pndTestId != testDetil.pndTestId)
                    {
                        var testANWDetail = new MolecularLabSpecimenReports();
                        var foetusDetail = specimenReport.foetusDetail.Where(sd => sd.pndTestId == testDetil.pndTestId).ToList();
                        testANWDetail.uniqueSubjectId = testDetil.uniqueSubjectId;
                        testANWDetail.subjectName = testDetil.subjectName;
                        testANWDetail.subjectType = testDetil.subjectType;
                        testANWDetail.spouseSubjectId = testDetil.spouseSubjectId;
                        testANWDetail.spouseName = testDetil.spouseName;
                        testANWDetail.rchId = testDetil.rchId;
                        testANWDetail.contactNo = testDetil.contactNo;
                        testANWDetail.age = testDetil.age;
                        testANWDetail.dob = testDetil.dob;
                        testANWDetail.gender = testDetil.gender;
                        testANWDetail.ecNumber = testDetil.ecNumber;
                        testANWDetail.ga = testDetil.ga;
                        testANWDetail.obstetricScore = testDetil.obstetricScore;
                        testANWDetail.lmpDate = testDetil.lmpDate;
                        testANWDetail.address = testDetil.address;
                        testANWDetail.barcodeNo = testDetil.barcodeNo;
                        testANWDetail.district = testDetil.district;
                        testANWDetail.block = testDetil.block;
                        testANWDetail.chc = testDetil.chc;
                        testANWDetail.phc = testDetil.phc;
                        testANWDetail.sc = testDetil.sc;
                        testANWDetail.ri = testDetil.ri;
                        testANWDetail.anmName = testDetil.anmName;
                        testANWDetail.registrationDate = testDetil.registrationDate;
                        testANWDetail.sampleCollectionDate = testDetil.sampleCollectionDate;
                        testANWDetail.molecularTestResult = testDetil.molecularTestResult;
                        testANWDetail.testDate = testDetil.testDate;
                        testANWDetail.spouseMolecularTestResult = testDetil.spouseMolecularTestResult;
                        testANWDetail.molecularLabName = testDetil.molecularLabName;
                        testANWDetail.orderingPhysician = testDetil.orderingPhysician;
                        testANWDetail.molecularResultEnteredBy = testDetil.molecularResultEnteredBy;
                        testANWDetail.pndTestId = testDetil.pndTestId;
                        testANWDetail.labTechnician = testDetil.labTechnician;
                        testANWDetail.foetusDetail = foetusDetail;
                        pndTestId = testDetil.pndTestId;
                        anwDetails.Add(testANWDetail);
                    }
                }
                specimenResponse.data = anwDetails;
                specimenResponse.Status = "true";
                specimenResponse.Message = string.Empty;
                return specimenResponse;
            }

            catch (Exception e)
            {
                specimenResponse.Status = "false";
                specimenResponse.Message = e.Message;
                return specimenResponse;
            }
        }

        public List<MolecularLabBloodReport> RetriveIndividualSubjectForBloodTestReports(MolLabReportIndividualRequest rData)
        {
            var allSubject = _mlResultProcessData.RetriveIndividualSubjectForBloodTestReports(rData);
            return allSubject;
        }

        public async Task<SpecimenReportResponse> RetriveIndividualSubjectForSpecimenTestReports(MolLabReportIndividualRequest rData)
        {
            var specimenReport = _mlResultProcessData.RetriveIndividualSubjectForSpecimenTestReports(rData);
            var specimenResponse = new SpecimenReportResponse();
            var anwDetails = new List<MolecularLabSpecimenReports>();
            try
            {
                int pndTestId = 0;
                foreach (var testDetil in specimenReport.anwDetail)
                {

                    if (pndTestId != testDetil.pndTestId)
                    {
                        var testANWDetail = new MolecularLabSpecimenReports();
                        var foetusDetail = specimenReport.foetusDetail.Where(sd => sd.pndTestId == testDetil.pndTestId).ToList();
                        testANWDetail.uniqueSubjectId = testDetil.uniqueSubjectId;
                        testANWDetail.subjectName = testDetil.subjectName;
                        testANWDetail.subjectType = testDetil.subjectType;
                        testANWDetail.spouseSubjectId = testDetil.spouseSubjectId;
                        testANWDetail.spouseName = testDetil.spouseName;
                        testANWDetail.rchId = testDetil.rchId;
                        testANWDetail.contactNo = testDetil.contactNo;
                        testANWDetail.age = testDetil.age;
                        testANWDetail.dob = testDetil.dob;
                        testANWDetail.gender = testDetil.gender;
                        testANWDetail.ecNumber = testDetil.ecNumber;
                        testANWDetail.ga = testDetil.ga;
                        testANWDetail.obstetricScore = testDetil.obstetricScore;
                        testANWDetail.lmpDate = testDetil.lmpDate;
                        testANWDetail.address = testDetil.address;
                        testANWDetail.barcodeNo = testDetil.barcodeNo;
                        testANWDetail.district = testDetil.district;
                        testANWDetail.block = testDetil.block;
                        testANWDetail.chc = testDetil.chc;
                        testANWDetail.phc = testDetil.phc;
                        testANWDetail.sc = testDetil.sc;
                        testANWDetail.ri = testDetil.ri;
                        testANWDetail.anmName = testDetil.anmName;
                        testANWDetail.registrationDate = testDetil.registrationDate;
                        testANWDetail.sampleCollectionDate = testDetil.sampleCollectionDate;
                        testANWDetail.molecularTestResult = testDetil.molecularTestResult;
                        testANWDetail.testDate = testDetil.testDate;
                        testANWDetail.spouseMolecularTestResult = testDetil.spouseMolecularTestResult;
                        testANWDetail.molecularLabName = testDetil.molecularLabName;
                        testANWDetail.orderingPhysician = testDetil.orderingPhysician;
                        testANWDetail.molecularResultEnteredBy = testDetil.molecularResultEnteredBy;
                        testANWDetail.pndTestId = testDetil.pndTestId;
                        testANWDetail.labTechnician = testDetil.labTechnician;
                        testANWDetail.foetusDetail = foetusDetail;
                        pndTestId = testDetil.pndTestId;
                        anwDetails.Add(testANWDetail);
                    }
                }
                specimenResponse.data = anwDetails;
                specimenResponse.Status = "true";
                specimenResponse.Message = string.Empty;
                return specimenResponse;
            }

            catch (Exception e)
            {
                specimenResponse.Status = "false";
                specimenResponse.Message = e.Message;
                return specimenResponse;
            }
        }
    }
}
