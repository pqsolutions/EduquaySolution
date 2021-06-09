using EduquayAPI.Contracts.V1.Request.MolecularLab;
using EduquayAPI.Contracts.V1.Response;
using EduquayAPI.Contracts.V1.Response.MolecularLab;
using EduquayAPI.Models.MolecularLab;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Services.MolLabResultProcess
{
    public interface IMLResultProcessService
    {
        List<MolecularSubjectsForTest> RetriveSubjectForMolecularBloodTest(int molecularLabId);
        List<MolecularSubjectsForBloodTestStatus> RetriveSubjectForMolecularBloodTestEdit(int molecularLabId);
        List<MolecularSubjectsForBloodTestStatus> RetriveSubjectForMolecularBloodTestComplete(int molecularLabId);
        Task<ServiceResponse> AddMolecularBloodResult(AddBloodSampleTestRequest mrData);
        List<MolecularLabBloodReport> RetriveSubjectForMolecularBloodTestReports(MolecularLabReportRequest rData);
        List<MLabSpecimenForTest> RetriveSpecimenSubjectForMolecularTest(int molecularLabId);
        List<MLabSpecimenForTestStatus> RetriveSpecimenForMolecularEditTest(int molecularLabId);
        List<MLabSpecimenForTestStatus> RetriveSpecimenForMolecularTestComplete(int molecularLabId);
        Task<ServiceResponse> AddSpecimenSamplesTestResult(AddSpecimenSampleTestRequest mrData);
        Task<SpecimenReportResponse> RetriveSubjectForMolecularSpecimenTestReports(MolecularLabReportRequest rData);

        List<MolecularLabBloodReport> RetriveIndividualSubjectForBloodTestReports(MolLabReportIndividualRequest rData);
        Task<SpecimenReportResponse> RetriveIndividualSubjectForSpecimenTestReports(MolLabReportIndividualRequest rData);
    }
}
