using EduquayAPI.Contracts.V1.Request.ANMNotifications;
using EduquayAPI.Contracts.V1.Request.CHCNotifications;
using EduquayAPI.Models;
using EduquayAPI.Models.CHCNotifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.DataLayer.CHCNotifications
{
    public interface ICHCNotificationsData
    {
        List<CHCNotificationSample> GetCHCNotificationSamples(CHCNotificationSamplesRequest cnData);
        List<CHCUnsentSamples> GetANMUnsentSamples(CHCNotificationSamplesRequest cnData);
        List<BarcodeSample> FetchBarcode(string barcodeNo);
        string AddTimeoutExpiry(CHCNotificationTimeoutRequest cnData);
        string AddSampleRecollection(SampleRecollectionRequest srData);
        List<CHCHPLCPositiveSamples> GetPositiveDetails(CHCPositiveSamplesRequest cpData);


    }
    public interface ICHCNotificationsDataFactory
    {
        ICHCNotificationsData Create();
    }
    public class CHCNotificationsDataFactory : ICHCNotificationsDataFactory
    {
        public ICHCNotificationsData Create()
        {
            return new CHCNotificationsData();
        }
    }
}
