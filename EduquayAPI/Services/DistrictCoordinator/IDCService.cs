using EduquayAPI.Contracts.V1.Request.DistrictCoordinator;
using EduquayAPI.Contracts.V1.Response;
using EduquayAPI.Models.DiscrictCoordinator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Services.DistrictCoordinator
{
    public interface IDCService
    {
        List<NotificationSamples> GetDamagedSamples(int districtId);
        List<NotificationSamples> GetTimeoutSamples(int districtId);
        List<NotificationSamples> GetUnsentSamples(int districtId);
        List<DCPositiveSamples> GetPositiveSampeles(int districtId);
        ServiceResponse UpdateSampleStatus(NotificationDCRequest nData);
        ServiceResponse UpdatePositiveSubjectStatus(NotificationDCRequest nData);
        List<PNDTReferal> GetPNDTReferal(int districtId);
        List<MTPReferal> GetMTPReferal(int districtId);

        ServiceResponse UpdatePNDTReferalStatus(ReferalDCRequest rData);
        ServiceResponse UpdateMTPReferalStatus(ReferalDCRequest rData);
        List<DCPostMTPFollowUp> GetMTPFollowUp(int districtId);
        ServiceResponse UpdateMTPFollowUpStatus(AddPostMTPRequest rData);
    }
}
