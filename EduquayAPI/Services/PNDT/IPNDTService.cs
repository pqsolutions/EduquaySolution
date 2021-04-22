using EduquayAPI.Contracts.V1.Request.PNDTC;
using EduquayAPI.Contracts.V1.Response.PNDT;
using EduquayAPI.Models.PNDT;
using Microsoft.AspNetCore.Http;
using Nancy;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Services.PNDT
{
    public interface IPNDTService
    {
        List<PrePNDTScheduling> GetPositiveSubjectsScheduling(PNDTSchedulingRequest psData);
        List<PrePNDTScheduled> GetSubjectsScheduled(PNDTSchedulingRequest psData);
        Task<AddSchedulingResponse> AddScheduling(AddSchedulingRequest asData);
        List<PrePNDTCounselling> GetScheduledForCounselling(PNDTSchedulingRequest psData);
        Task<AddCounsellingResponse> AddCounselling(AddPrePNDTCounsellingRequest acData);
        List<PrePNDTCounselled> GetSubjectsCounselledYes(PNDTSchedulingRequest pcData);
        List<PrePNDTCounselled> GetSubjectsCounselledNo(PNDTSchedulingRequest pcData);
        List<PrePNDTCounselled> GetSubjectsCounselledPending(PNDTSchedulingRequest pcData);
        List<PostPNDTScheduling> GetPostPNDTScheduling(PNDTSchedulingRequest psData);
        Task<AddSchedulingResponse> AddPostPNDTScheduling(AddSchedulingRequest asData);
        List<PostPNDTScheduled> GetSubjectsPostPNDTScheduled(PNDTSchedulingRequest psData);
        Task<PostPNDTCounsellingResponse> GetScheduledForPostPNDTCounselling(PNDTSchedulingRequest psData);
        Task<AddPostCounsellingResponse> AddPostPNDTCounselling(AddPostPNDTCounsellingRequest acData);
        Task<PostPNDTCounselledResponse> GetSubjectsPostPNDTCounselledYes(PNDTSchedulingRequest pcData);
        Task<PostPNDTCounselledResponse> GetSubjectsPostPNDTCounselledNo(PNDTSchedulingRequest pcData);
        Task<PostPNDTCounselledResponse> GetSubjectsPostPNDTCounselledPending(PNDTSchedulingRequest pcData);
        Task<FileResponse> GetPrePNDTFileDetails(IFormFile formData);
        Task<FileResponse> GetPostPNDTFileDetails(IFormFile formData);
        //Task<DownloadFileResponse> GetPrePNDTDownloadFileDetails(string fileName);
        //Task<DownloadFileResponse> GetPostPNDTDownloadFileDetails(string fileName);
        List<PNDTPickAndPack> RetrievePickAndPack(int pndtLocationId);
        Task<AddPNDTShipmentResponse> AddPNDTShipment(AddPNDTShipmentRequest sData);
        Task<PNDTShipmentLogsResponse> RetrieveShipmentLogs(int pndtLocationId);
    }
}
