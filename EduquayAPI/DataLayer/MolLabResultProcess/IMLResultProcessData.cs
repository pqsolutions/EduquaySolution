using EduquayAPI.Contracts.V1.Request.MolecularLab;
using EduquayAPI.Models.MolecularLab;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.DataLayer.MolLabResultProcess
{
    public interface IMLResultProcessData
    {
        List<MolecularSubjectsForTest> RetriveSubjectForMolecularBloodTest(int molecularLabId);
        List<MolecularSubjectsForBloodTestStatus> RetriveSubjectForMolecularBloodTestEdit(int molecularLabId);
        List<MolecularSubjectsForBloodTestStatus> RetriveSubjectForMolecularBloodTestComplete(int molecularLabId);
        List<MolecularLabBloodReport> RetriveSubjectForMolecularBloodTestReports(int molecularLabId);
        MolecularMsg AddBloodSamplesTestResult(AddBloodSampleTestRequest rData);

        List<MLabSpecimenForTest> RetriveSpecimenSubjectForMolecularTest(int molecularLabId);
        List<MLabSpecimenForTestStatus> RetriveSpecimenForMolecularEditTest(int molecularLabId);
        List<MLabSpecimenForTestStatus> RetriveSpecimenForMolecularTestComplete(int molecularLabId);
        MolecularMsg AddSpecimenSamplesTestResult(AddSpecimenSampleTestRequest rData);
        SpecimenReport RetriveSubjectForMolecularSpecimenTestReports(int molecularLabId);
    }

    public interface IMLResultProcessDataFactory
    {
        IMLResultProcessData Create();
    }
    public class MLResultProcessDataFactory : IMLResultProcessDataFactory
    {
        public IMLResultProcessData Create()
        {
            return new MLResultProcessData();
        }
    }
}
