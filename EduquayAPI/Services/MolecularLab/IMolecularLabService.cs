using EduquayAPI.Contracts.V1.Request.MolecularLab;
using EduquayAPI.Contracts.V1.Response;
using EduquayAPI.Contracts.V1.Response.MolecularLab;
using EduquayAPI.Models.MolecularLab;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Services.MolecularLab
{
    public interface IMolecularLabService
    {
        Task<MolecularLabReceiptResponse> RetrieveMolecularLabReceipts(int MolecularLabId);
        Task<MolecularReceiptResponse> AddReceivedShipment(AddMolecularLabReceiptRequest mlRequest);
        List<MolecularSubjectsForTest> RetriveSubjectForMolecularTest(int molecularLabId);
        Task<ServiceResponse> AddMolecularResult(AddMolecularResultRequest mrData);
        List<MolecularReports> RetriveMolecularReports(MolecularReportRequest mrData);
        List<MolecularSampleStatus> RetrieveSampleStatus();

    }
}
