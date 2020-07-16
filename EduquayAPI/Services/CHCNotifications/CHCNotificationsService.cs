using EduquayAPI.Contracts.V1.Request.CHCNotifications;
using EduquayAPI.Contracts.V1.Response.CHCNotifications;
using EduquayAPI.DataLayer.CHCNotifications;
using EduquayAPI.Models.CHCNotifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Services.CHCNotifications
{
    public class CHCNotificationsService : ICHCNotificationsService
    {
        private readonly ICHCNotificationsData _chcNotificationsData;

        public CHCNotificationsService(ICHCNotificationsDataFactory chcNotificationsDataFactory)
        {
            _chcNotificationsData = new CHCNotificationsDataFactory().Create();
        }
        public List<CHCNotificationSample> GetCHCNotificationSamples(CHCNotificationSamplesRequest cnData)
        {
            var notificationSamples = _chcNotificationsData.GetCHCNotificationSamples(cnData);
            return notificationSamples;
        }

        public async Task<CHCUnsentSamplesResponse> RetrieveUnsentSamples(CHCNotificationSamplesRequest cnData)
        {
            var chcUnsentresponse = new CHCUnsentSamplesResponse();
            try
            {
                var unsentSampleDetail = _chcNotificationsData.GetANMUnsentSamples(cnData);

                var chcUnsent = new List<CHCUnsentSample>();

                foreach (var unsent in unsentSampleDetail)
                {
                    var unsentSample = new CHCUnsentSample();
                    unsentSample.barcodeNo = unsent.barcodeNo;
                    unsentSample.contactNo = unsent.contactNo;
                    unsentSample.gestationalAge = unsent.gestationalAge;
                    unsentSample.rchId = unsent.rchId;
                    unsentSample.sampleCollectionId = unsent.sampleCollectionId;
                    unsentSample.subjectName = unsent.subjectName;
                    unsentSample.uniqueSubjectId = unsent.uniqueSubjectId;
                    unsentSample.sampleDateTime = unsent.sampleDateTime;
                    DateTime myDate1 = DateTime.Now;
                    DateTime myDate2 = Convert.ToDateTime(unsent.sampleDateTime);
                    TimeSpan difference = myDate1.Subtract(myDate2);
                    double totalHours = Math.Round(difference.TotalHours);
                    unsentSample.sampleAging = Convert.ToString(totalHours); //+ " Hrs";
                    chcUnsent.Add(unsentSample);
                }
                chcUnsentresponse.UnsentSamplesDetail = chcUnsent;
                chcUnsentresponse.Status = "true";
                chcUnsentresponse.Message = string.Empty;
            }
            catch (Exception e)
            {
                chcUnsentresponse.Status = "false";
                chcUnsentresponse.Message = e.Message;
            }
            return chcUnsentresponse;

        }
    }
}
