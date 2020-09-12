﻿using EduquayAPI.Contracts.V1.Request.DistrictCoordinator;
using EduquayAPI.Models.DiscrictCoordinator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.DataLayer.DistrictCoordinator
{
    public interface IDCData
    {
        List<NotificationSamples> GetDamagedSamples(int districtId);
        List<NotificationSamples> GetTimeoutSamples(int districtId);
        List<NotificationSamples> GetUnsentSamples(int districtId);
        string UpdateSampleStatus(NotificationDCRequest nData);
        List<DCPositiveSamples > GetPositiveSampeles(int districtId);
        string UpdatePositiveSubjectStatus(NotificationDCRequest nData);
        List<PNDTReferal> GetPNDTReferal(int districtId);
        List<MTPReferal> GetMTPReferal(int districtId);

    }
    public interface IDCDataFactory
    {
        IDCData Create();
    }
    public class DCDataFactory : IDCDataFactory
    {
        public IDCData Create()
        {
            return new DCData();
        }
    }
}
