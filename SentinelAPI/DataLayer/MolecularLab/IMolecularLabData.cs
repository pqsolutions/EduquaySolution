using SentinelAPI.Contracts.V1.Request.MolecularLab;
using SentinelAPI.Models.MolecularLab;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SentinelAPI.DataLayer.MolecularLab
{
    public interface IMolecularLabData
    {
        MolecularLabReceipts RetrieveMolecularLabReceipts(int molecularLabId);
        void AddReceivedShipment(AddMolecularReceiptRequest mrData);
        List<SubjectDetailsForTest> RetriveSubjectForMolecularTest(int molecularLabId);
        List<MolecularSubjectsForBloodTestStatus> RetriveSubjectForMolecularBloodTestEdit(int molecularLabId);
        List<MolecularSubjectsForBloodTestStatus> RetriveSubjectForMolecularBloodTestComplete(int molecularLabId);
        string AddMolecularResult(AddMolecularResultRequest mrData);
        List<MolecularResultsDetail> RetriveMolecularTestResultsDetail(int molecularLabId);
        List<MolecularReportsDetail> RetriveMolecularReports(FetchMolecularReportsRequest mrData);
        MolecularMsg AddBloodSamplesTestResult(AddBloodSampleTestRequest rData);
        List<MolecularLabReport> RetrieveMolecularTestResultsReport(int molecularLabId);
    }

    public interface IMolecularLabDataFactory
    {
        IMolecularLabData Create();
    }
    public class MolecularLabDataFactory : IMolecularLabDataFactory
    {
        public IMolecularLabData Create()
        {
            return new MolecularLabData();
        }
    }
}
