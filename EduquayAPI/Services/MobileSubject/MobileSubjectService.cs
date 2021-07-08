using EduquayAPI.Contracts.V1.Request.Mobile;
using EduquayAPI.Contracts.V1.Request.MobileAppSampleCollection;
using EduquayAPI.Contracts.V1.Request.MobileAppShipment;
using EduquayAPI.Contracts.V1.Request.MobileAppSubjectRegistration;
using EduquayAPI.Contracts.V1.Response;
using EduquayAPI.Contracts.V1.Response.ANMSubjectRegistration;
using EduquayAPI.Contracts.V1.Response.MobileSubject;
using EduquayAPI.DataLayer.MobileSubject;
using EduquayAPI.Models.ANMSubjectRegistration;
using EduquayAPI.Models.MobileSubject;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Net.Mail;
using System.Threading.Tasks;
using EduquayAPI.DataLayer;

namespace EduquayAPI.Services.MobileSubject
{
    public class MobileSubjectService : IMobileSubjectService
    {
        private readonly IMobileSubjectData _mobileSubjectData;
        private readonly ISampleCollectionData _sampleCollectionData;
        private readonly IConfiguration _config;

        public MobileSubjectService(IMobileSubjectDataFactory mobileSubjectDataFactory, ISampleCollectionDataFactory sampleCollectionDataFactory, IConfiguration config)
        {
            _mobileSubjectData = new MobileSubjectDataFactory().Create();
            _sampleCollectionData = new SampleCollectionDataFactory().Create();
            _config = config;
        }

        public async Task<ShipmentListResponse> AddANMShipment(MobileShipmentsRequest msData)
        {
            List<ShipmentIdDetail> shipmentIds = new List<ShipmentIdDetail>();
            ShipmentListResponse slResponse = new ShipmentListResponse();
            var shipmentId = "";
            try
            {
                var checkdevice = _mobileSubjectData.CheckDevice(msData.data.ShipmentsRequest[0].shipment.anmId, msData.deviceId);
                if (checkdevice.valid == false)
                {
                    slResponse.Valid = false;
                    slResponse.Status = "false";
                    slResponse.Message = checkdevice.msg;
                }
                else
                {
                    foreach (var shipments in msData.data.ShipmentsRequest)
                    {
                        var slist = new ShipmentIdDetail();
                        shipmentId = shipments.shipment.shipmentId;
                        _mobileSubjectData.AddShipment(shipments.shipment);
                        slist.ShipmentId = shipments.shipment.shipmentId;
                        shipmentIds.Add(slist);
                    }
                    slResponse.Valid = true;
                    slResponse.Status = "true";
                    slResponse.Message = shipmentIds.Count + " Shipment generated successfully";
                    slResponse.ShipmentIds = shipmentIds;
                }
                return slResponse;
            }
            catch (Exception e)
            {
                slResponse.Valid = true;
                slResponse.Status = "false";
                slResponse.Message = "Partially " + shipmentIds.Count + " shipment generated successfully, From this (" + shipmentIds + ") onwards shipment not generated. " + e.Message;
                slResponse.ShipmentIds = shipmentIds;
                return slResponse;
            }
        }

        public async Task<TimeoutResponse> AddMoveTimeout(AddTimeoutExpireMobileRequest eData)
        {
            var tResponse = new TimeoutResponse();
            var barcodes = new List<BarcodeSampleDetail>();
            var barcodeNo = "";
            try
            {
                var checkdevice = _mobileSubjectData.CheckDevice(eData.data.MoveTimeoutRequest[0].samples.userId, eData.deviceId);
                if (checkdevice.valid == false)
                {
                    tResponse.Valid = false;
                    tResponse.Status = "false";
                    tResponse.Message = checkdevice.msg;
                }
                else
                {
                    foreach (var sample in eData.data.MoveTimeoutRequest)
                    {
                        var slist = new BarcodeSampleDetail();
                        barcodeNo = sample.samples.barcodeNo;
                        _mobileSubjectData.AddTimeoutExpiry(sample.samples);
                        var smsSampleDetails = _sampleCollectionData.FetchSMSSamplesByBarcode(barcodeNo);
                        var subjectMobileNo = smsSampleDetails.subjectMobileNo;
                        var subjectName = smsSampleDetails.subjectName;
                        var anmName = smsSampleDetails.anmName;
                        var anmMobileNo = smsSampleDetails.anmMobileNo;

                        var smsToANMURL = _config.GetSection("RegistrationSamplingOdiyaSMStoSubject").GetSection("SMStoANMSampleTimeoutDamaged").Value;
                        var smsURLANMLink = smsToANMURL.Replace("#MobileNo", subjectMobileNo).Replace("#SubjectName", subjectName).Replace("#BarcodeNo", barcodeNo).Replace("#ANMName", anmName).Replace("#ANMMobile", anmMobileNo);
                        GetResponse(smsURLANMLink);

                        var smsToSubjectURL = _config.GetSection("RegistrationSamplingOdiyaSMStoSubject").GetSection("SMStoSubjectSampleTimeoutDamaged").Value;
                        var smsURLSubjectLink = smsToSubjectURL.Replace("#MobileNo", subjectMobileNo).Replace("#SubjectName", subjectName).Replace("#BarcodeNo", barcodeNo).Replace("#ANMName", anmName).Replace("#ANMMobile", anmMobileNo);
                        GetResponse(smsURLSubjectLink);

                        slist.barcodeNo = sample.samples.barcodeNo;
                        barcodes.Add(slist);
                    }
                    tResponse.Valid = true;
                    tResponse.Status = "true";
                    tResponse.Message = barcodes.Count + " Samples successfully  moved to expiry";
                    tResponse.Barcodes = barcodes;
                }
            }
            catch (Exception e)
            {
                tResponse.Valid = true;
                tResponse.Status = "false";
                tResponse.Message = e.Message;
                tResponse.Barcodes = barcodes;
            }
            return tResponse;
        }

        public async Task<UpdateStatusResponse> UpdatatePositiveStatus(AddUpdateStatusRequest usData)
        {
            var uResponse = new UpdateStatusResponse();
            var barcodes = new List<BarcodeSampleDetail>();
            var barcodeNo = "";
            try
            {
                var checkdevice = _mobileSubjectData.CheckDevice(usData.data.UpdateStatusRequest[0].Samples.userId, usData.deviceId);
                if (checkdevice.valid == false)
                {
                    uResponse.Valid = false;
                    uResponse.Status = "false";
                    uResponse.Message = checkdevice.msg;
                }
                else
                {
                    foreach (var sample in usData.data.UpdateStatusRequest)
                    {
                        var slist = new BarcodeSampleDetail();
                        barcodeNo = sample.Samples.barcodeNo;
                        _mobileSubjectData.UpdatePositiveSubjectStatus(sample.Samples);
                        slist.barcodeNo = sample.Samples.barcodeNo;
                        barcodes.Add(slist);
                    }
                    uResponse.Valid = true;
                    uResponse.Status = "true";
                    uResponse.Message = barcodes.Count + " Samples status successfully updated";
                    uResponse.Barcodes = barcodes;
                }
            }
            catch (Exception e)
            {
                uResponse.Valid = true;
                uResponse.Status = "false";
                uResponse.Message = e.Message;
                uResponse.Barcodes = barcodes;
            }
            return uResponse;
        }

        public async Task<UpdateStatusResponse> UpdateNotificationStatus(AddUpdateStatusRequest usData)
        {
            var uResponse = new UpdateStatusResponse();
            var barcodes = new List<BarcodeSampleDetail>();
            var barcodeNo = "";
            try
            {
                var checkdevice = _mobileSubjectData.CheckDevice(usData.data.UpdateStatusRequest[0].Samples.userId, usData.deviceId);
                if (checkdevice.valid == false)
                {
                    uResponse.Valid = false;
                    uResponse.Status = "false";
                    uResponse.Message = checkdevice.msg;
                }
                else
                {
                    foreach (var sample in usData.data.UpdateStatusRequest)
                    {
                        var slist = new BarcodeSampleDetail();
                        barcodeNo = sample.Samples.barcodeNo;
                        _mobileSubjectData.UpdateNotificationStatus(sample.Samples);
                        slist.barcodeNo = sample.Samples.barcodeNo;
                        barcodes.Add(slist);
                    }
                    uResponse.Valid = true;
                    uResponse.Status = "true";
                    uResponse.Message = barcodes.Count + " Samples status successfully updated";
                    uResponse.Barcodes = barcodes;
                }
            }
            catch (Exception e)
            {
                uResponse.Valid = true;
                uResponse.Status = "false";
                uResponse.Message = e.Message;
                uResponse.Barcodes = barcodes;
            }
            return uResponse;
        }
        public async Task<SampleCollectionListResponse> AddSampleCollection(SampleCollectRequest ssData)
        {
            List<BarcodeSampleDetail> barcodes = new List<BarcodeSampleDetail>();
            SampleCollectionListResponse slResponse = new SampleCollectionListResponse();
            var barcodeNo = "";
            try
            {
                var checkdevice = _mobileSubjectData.CheckDevice(ssData.data.SampleCollectionsRequest[0].samples.collectedBy, ssData.deviceId);
                if (checkdevice.valid == false)
                {
                    slResponse.Valid = false;
                    slResponse.Status = "false";
                    slResponse.Message = checkdevice.msg;
                }
                else
                {
                    foreach (var sample in ssData.data.SampleCollectionsRequest)
                    {
                        var slist = new BarcodeSampleDetail();
                        barcodeNo = sample.samples.barcodeNo;
                        _mobileSubjectData.SampleColection(sample.samples);
                        slist.barcodeNo = sample.samples.barcodeNo;
                        barcodes.Add(slist);
                    }
                    slResponse.Status = "true";
                    slResponse.Valid = true;
                    slResponse.Message = barcodes.Count + " Samples collected successfully";
                    slResponse.Barcodes = barcodes;
                }
            }
            catch (Exception e)
            {
                slResponse.Valid = true;
                slResponse.Status = "false";
                slResponse.Message = "Partially " + barcodes.Count + " samples collected successfully, From this (" + barcodeNo + ") onwards not collected. " + e.Message;
                slResponse.Barcodes = barcodes;
            }
            return slResponse;
        }

        public async Task<SubRegSuccessResponse> AddSubjectRegistration(AddSubjectRequest subRegData)
        {
            List<UniqueSubjectIdDetail> uniqSubjectIdDetail = new List<UniqueSubjectIdDetail>();
            SubRegSuccessResponse subRegSuccess = new SubRegSuccessResponse();
            var subId = "";
            try
            {
                var checkdevice = _mobileSubjectData.CheckDevice(subRegData.data.subjectsRequest[0].subjectPrimaryRequest.assignANMId, subRegData.deviceId);
                if (checkdevice.valid == false)
                {
                    subRegSuccess.Valid = false;
                    subRegSuccess.Status = "false";
                    subRegSuccess.Message = checkdevice.msg;
                }
                else
                {
                    foreach (var subject in subRegData.data.subjectsRequest)
                    {
                        var slist = new UniqueSubjectIdDetail();
                        subId = subject.subjectPrimaryRequest.uniqueSubjectId;
                        _mobileSubjectData.subjectPrimary(subject.subjectPrimaryRequest);
                        _mobileSubjectData.SubjectAddress(subject.subjectAddressRequest);
                        _mobileSubjectData.SubjectPregnancy(subject.subjectPregnancyRequest);
                        _mobileSubjectData.SubjectParent(subject.subjectParentRequest);

                        slist.uniqueSubjectId = subject.subjectParentRequest.uniqueSubjectId;
                        uniqSubjectIdDetail.Add(slist);
                    }

                    subRegSuccess.Status = "true";
                    subRegSuccess.Valid = true;
                    subRegSuccess.Message = uniqSubjectIdDetail.Count + " Subjects registered successfully";
                    subRegSuccess.SuccessIds = uniqSubjectIdDetail;
                }
            }
            catch (Exception e)
            {
                subRegSuccess.Status = "false";
                subRegSuccess.Valid = true;
                subRegSuccess.Message = "Partially " + uniqSubjectIdDetail.Count + " subjects registered successfully, From this (" + subId + ") onwards not registered. " + e.Message;
                subRegSuccess.SuccessIds = uniqSubjectIdDetail;
            }
            return subRegSuccess;
        }

        public async Task<SubjectResigrationListResponse> RetrieveDetail(MobileRetrieveRequest mrData)
        {
            var checkdevice = _mobileSubjectData.CheckDevice(mrData.userId, mrData.deviceId);
            var subjectRegistrationResponse = new SubjectResigrationListResponse();
            var subjectRegistrations = new List<SubjectResigration>();
            var shipmentLogs = new List<ShipmentLogs>();
            try
            {
                if (checkdevice.valid == false)
                {
                    subjectRegistrationResponse.Valid = false;
                    subjectRegistrationResponse.Status = "false";
                    subjectRegistrationResponse.Message = checkdevice.msg;
                }
                else
                {
                    var LastIds = _mobileSubjectData.FindLastId(mrData.userId);
                    var subjectDetails = _mobileSubjectData.MobileSubjectRegDetail(mrData.userId);
                    var sampleDetails = _mobileSubjectData.MobileSampleDetail(mrData.userId);
                    var shipmentDetails = _mobileSubjectData.MobileANMShipmentDetail(mrData.userId);

                    subjectRegistrationResponse.Valid = true;
                    subjectRegistrationResponse.LastUniqueSubjectId = LastIds.LastUniqueSubjectId;
                    subjectRegistrationResponse.LastShipmentId = LastIds.LastShipmentId;

                    foreach (var primarySubject in subjectDetails.PrimarySubjectList)
                    {
                        var subjectRegistration = new SubjectResigration();
                        var address = subjectDetails.AddressSubjectList.FirstOrDefault(ad => ad.uniqueSubjectId == primarySubject.uniqueSubjectId);
                        var pregnancy = subjectDetails.PregnancySubjectList.FirstOrDefault(pr => pr.uniqueSubjectId == primarySubject.uniqueSubjectId);
                        var parent = subjectDetails.ParentSubjectList.FirstOrDefault(pa => pa.uniqueSubjectId == primarySubject.uniqueSubjectId);
                        var results = subjectDetails.Results.FirstOrDefault(r => r.uniqueSubjectId == primarySubject.uniqueSubjectId);
                        var prePndtCounselling = subjectDetails.prePndtCounselling.FirstOrDefault(prp => prp.uniqueSubjectId == primarySubject.uniqueSubjectId);
                        var pndtTesting = subjectDetails.pndtTesting.FirstOrDefault(pn => pn.uniqueSubjectId == primarySubject.uniqueSubjectId);
                        var postPndtCounselling = subjectDetails.postPndtCounselling.FirstOrDefault(pop => pop.uniqueSubjectId == primarySubject.uniqueSubjectId);
                        var mtpService = subjectDetails.mtpService.FirstOrDefault(ms => ms.uniqueSubjectId == primarySubject.uniqueSubjectId);

                        subjectRegistration.PrimaryDetail = primarySubject;
                        subjectRegistration.AddressDetail = address;
                        subjectRegistration.PregnancyDetail = pregnancy;
                        subjectRegistration.ParentDetail = parent;
                        subjectRegistration.Results = results;
                        subjectRegistration.prePndtCounselling = prePndtCounselling;
                        subjectRegistration.pndtTesting = pndtTesting;
                        subjectRegistration.postPndtCounselling = postPndtCounselling;
                        subjectRegistration.mtpService = mtpService;

                        subjectRegistrations.Add(subjectRegistration);
                    }
                    var shipmentId = "";
                    foreach (var shipment in shipmentDetails.ShipmentLog)
                    {
                        var shipmentLog = new ShipmentLogs();
                        if (shipmentId != shipment.shipmentId)
                        {
                            var shipmentDetail = shipmentDetails.ShipmentSubjectDetail.Where(sd => sd.shipmentId == shipment.shipmentId).ToList();
                            shipmentLog.shipmentId = shipment.shipmentId;
                            shipmentLog.anmId = shipment.anmId;
                            shipmentLog.anmName = shipment.anmName;
                            shipmentLog.testingCHCId = shipment.testingCHCId;
                            shipmentLog.testingCHC = shipment.testingCHC;
                            shipmentLog.avdId = shipment.avdId;
                            shipmentLog.avdName = shipment.avdName;
                            shipmentLog.avdContactNo = shipment.avdContactNo;
                            shipmentLog.alternateAVD = shipment.alternateAVD;
                            shipmentLog.alternateAVDContactNo = shipment.alternateAVDContactNo;
                            shipmentLog.ilrId = shipment.ilrId;
                            shipmentLog.ilrPoint = shipment.ilrPoint;
                            shipmentLog.riId = shipment.riId;
                            shipmentLog.riPoint = shipment.riPoint;
                            shipmentLog.dateOfShipment = shipment.dateOfShipment;
                            shipmentLog.timeOfShipment = shipment.timeOfShipment;
                            shipmentLog.createdBy = shipment.createdBy;
                            shipmentLog.source = shipment.source;
                            shipmentLog.SamplesDetail = shipmentDetail;
                            shipmentId = shipment.shipmentId;
                            shipmentLogs.Add(shipmentLog);
                        }
                    }

                    subjectRegistrationResponse.SubjectResigrations = subjectRegistrations;
                    subjectRegistrationResponse.SampleCollections = sampleDetails;
                    subjectRegistrationResponse.ShipmentLogDetail = shipmentLogs;
                    subjectRegistrationResponse.Status = "true";
                    subjectRegistrationResponse.Message = string.Empty;
                }
            }
            catch (Exception ex)
            {
                subjectRegistrationResponse.Valid = true;
                subjectRegistrationResponse.Status = "false";
                subjectRegistrationResponse.Message = ex.Message;
            }

            return subjectRegistrationResponse;
        }

        public async Task<NotificationListResponse> RetrieveNotifications(MobileRetrieveRequest mrData)
        {
            var nlResponse = new NotificationListResponse();
            var chcSubjectRegistrations = new List<CHCSubjectResigration>();
            var mobilePNDTReferral = new List<MobilePNDTReferral>();
            var mobileMTPReferral = new List<MobileMTPReferral>();
            var mobileMTPFollowups = new List<ANMMobileMTPFollowups>();
            var menu = new List<MobileMenus>();
            var total = 0;
            try
            {

                var checkdevice = _mobileSubjectData.CheckDevice(mrData.userId, mrData.deviceId);
                if (checkdevice.valid == false)
                {
                    nlResponse.Valid = false;
                    nlResponse.Status = "false";
                    nlResponse.Message = checkdevice.msg;
                }
                else
                {
                    var damagedSamples = _mobileSubjectData.DamagedSamples(mrData.userId);
                    var timeoutSamples = _mobileSubjectData.SampleTimeout(mrData.userId);
                    var hplcPositiveSubjects = _mobileSubjectData.PositiveSubjects(mrData.userId);
                    var subjectDetails = _mobileSubjectData.MobileCHCSubjectRegDetail(mrData.userId);
                    var sampleDetails = _mobileSubjectData.MobileCHCSampleDetail(mrData.userId);

                    var prePNDTCounsellingNotification = _mobileSubjectData.FetchPrePNDTCounsellingNotification(mrData.userId);
                    var pndTestingNotification = _mobileSubjectData.FetchPNDTestingNotification(mrData.userId);

                    var postPNDTCounsellingNotification = _mobileSubjectData.FetchPostPNDTCounsellingNotification(mrData.userId);
                    var mtpServiceNotification = _mobileSubjectData.FetchMTPServiceNotification(mrData.userId);


                    foreach (var primarySubject in subjectDetails.PrimarySubjectList)
                    {
                        var chcSubjectRegistration = new CHCSubjectResigration();
                        var address = subjectDetails.AddressSubjectList.FirstOrDefault(ad => ad.uniqueSubjectId == primarySubject.uniqueSubjectId);
                        var pregnancy = subjectDetails.PregnancySubjectList.FirstOrDefault(pr => pr.uniqueSubjectId == primarySubject.uniqueSubjectId);
                        var parent = subjectDetails.ParentSubjectList.FirstOrDefault(pa => pa.uniqueSubjectId == primarySubject.uniqueSubjectId);
                        var results = subjectDetails.Results.FirstOrDefault(r => r.uniqueSubjectId == primarySubject.uniqueSubjectId);

                        chcSubjectRegistration.PrimaryDetail = primarySubject;
                        chcSubjectRegistration.AddressDetail = address;
                        chcSubjectRegistration.PregnancyDetail = pregnancy;
                        chcSubjectRegistration.ParentDetail = parent;
                        chcSubjectRegistration.Results = results;
                        chcSubjectRegistrations.Add(chcSubjectRegistration);
                    }

                    var testResults = _mobileSubjectData.GetTestResults(mrData.userId);

                    var pndtDetail = _mobileSubjectData.GetPNDTReferral(mrData.userId);
                    foreach (var sub in pndtDetail.subject)
                    {
                        var pndtReferral = new MobilePNDTReferral();
                        var spouse = pndtDetail.spouse.FirstOrDefault(sp => sp.spouseSubjectId == sub.uniqueSubjectId);
                        var prePNDTCounselling = pndtDetail.prePndtCounselling.FirstOrDefault(pr => pr.uniqueSubjectId == sub.uniqueSubjectId);
                        var pndtTest = pndtDetail.pndtTesting.FirstOrDefault(pt => pt.uniqueSubjectId == sub.uniqueSubjectId);

                        pndtReferral.subject = sub;
                        pndtReferral.spouse = spouse;
                        pndtReferral.prePndtCounselling = prePNDTCounselling;
                        pndtReferral.pndtTesting = pndtTest;
                        mobilePNDTReferral.Add(pndtReferral);
                    }

                    var mtpDetail = _mobileSubjectData.GetMTPReferral(mrData.userId);
                    foreach (var sub in mtpDetail.subject)
                    {
                        var mtpReferral = new MobileMTPReferral();
                        var spouse = mtpDetail.spouse.FirstOrDefault(sp => sp.spouseSubjectId == sub.uniqueSubjectId);
                        var postPNDTCounselling = mtpDetail.postPndtCounselling.FirstOrDefault(pr => pr.uniqueSubjectId == sub.uniqueSubjectId);
                        var mtpService = mtpDetail.mtpService.FirstOrDefault(pt => pt.uniqueSubjectId == sub.uniqueSubjectId);

                        mtpReferral.subject = sub;
                        mtpReferral.spouse = spouse;
                        mtpReferral.postPndtCounselling = postPNDTCounselling;
                        mtpReferral.mtpService = mtpService;
                        mobileMTPReferral.Add(mtpReferral);
                    }

                    var mtpfollowUpDetail = _mobileSubjectData.MobileMTPFollowUp(mrData.userId);

                    var subjId = "";
                    foreach (var postMTP in mtpfollowUpDetail.postMtpFollowUp)
                    {
                        var mtpFollowup = new ANMMobileMTPFollowups();
                        if (subjId != postMTP.uniqueSubjectId)
                        {
                            var firstFollowup1 = mtpfollowUpDetail.firstFollowUp.Where(ff => ff.uniqueSubjectId == postMTP.uniqueSubjectId).ToList();
                            var secondFollowup1 = mtpfollowUpDetail.secondFollowUp.Where(sf => sf.uniqueSubjectId == postMTP.uniqueSubjectId).ToList();
                            var thirdFollowup1 = mtpfollowUpDetail.thirdFollowUp.Where(tf => tf.uniqueSubjectId == postMTP.uniqueSubjectId).ToList();

                            var firstFollowup = firstFollowup1[0];
                            var secondFollowup = secondFollowup1[0];
                            var thirdFollowup = thirdFollowup1[0];
                            mtpFollowup.uniqueSubjectId = postMTP.uniqueSubjectId;
                            mtpFollowup.subjectName = postMTP.subjectName;
                            mtpFollowup.rchId = postMTP.rchId;
                            mtpFollowup.contactNo = postMTP.contactNo;
                            mtpFollowup.mtpDateTime = postMTP.mtpDateTime;
                            mtpFollowup.obstetricianName = postMTP.obstetricianName;

                            mtpFollowup.firstFollowUp = firstFollowup;
                            mtpFollowup.secondFollowUp = secondFollowup;
                            mtpFollowup.thirdFollowUp = thirdFollowup;
                            subjId = postMTP.uniqueSubjectId;
                            mobileMTPFollowups.Add(mtpFollowup);
                        }
                    }

                    var menus = _mobileSubjectData.RetrieveMobileMenu();
                    foreach (var leftMenu in menus)
                    {
                        var lMenu = new MobileMenus();
                        lMenu.name = leftMenu.name;
                        lMenu.link = leftMenu.link;
                        if (leftMenu.name == "Home")
                        {
                            lMenu.odiyaName = "ମୂଳପୃଷ୍ଠା |";
                        }
                        else if (leftMenu.name == "Help")
                        {
                            lMenu.odiyaName = "ସହାୟତା";
                        }
                        else if (leftMenu.name == "Circular")
                        {
                            lMenu.odiyaName = "ବୃତ୍ତାକାର/ ନିର୍ଦେଶନାମା";
                        }
                        menu.Add(lMenu);
                    }

                    var alertMsg = _mobileSubjectData.RetrieveAlert();


                    total = damagedSamples.Count + timeoutSamples.Count + hplcPositiveSubjects.Count + subjectDetails.PrimarySubjectList.Count +
                                pndtDetail.subject.Count + mtpDetail.subject.Count + mtpfollowUpDetail.postMtpFollowUp.Count;
                    nlResponse.Status = "true";
                    nlResponse.Valid = true;
                    nlResponse.Message = string.Empty;
                    nlResponse.totalNotifications = total;
                    nlResponse.damagedSamples = damagedSamples;
                    nlResponse.timeoutExpirySamples = timeoutSamples;
                    nlResponse.positiveSubjects = hplcPositiveSubjects;
                    nlResponse.chcSubjectResigrations = chcSubjectRegistrations;
                    nlResponse.chcSampleCollections = sampleDetails;
                    nlResponse.results = testResults;
                    nlResponse.pndtReferral = mobilePNDTReferral;
                    nlResponse.mtpReferral = mobileMTPReferral;
                    nlResponse.prePndtCounselling = prePNDTCounsellingNotification;
                    nlResponse.pndtTesting = pndTestingNotification;
                    nlResponse.postPndtCounselling = postPNDTCounsellingNotification;
                    nlResponse.mtpService = mtpServiceNotification;
                    nlResponse.postMtpFollowUp = mobileMTPFollowups;
                    nlResponse.leftSideMenus = menu;
                    nlResponse.alert = alertMsg;
                }
            }
            catch (Exception ex)
            {
                nlResponse.Valid = true;
                nlResponse.Status = "false";
                nlResponse.Message = ex.Message;

            }
            return nlResponse;
        }

        public async Task<AcknowledgementResponse> AddCHCSubjectAcknowledgement(AcnowledgementRequest aData)
        {
            var uResponse = new AcknowledgementResponse();
            var ackCount = 0;
            try
            {
                var checkdevice = _mobileSubjectData.CheckDevice(aData.data.AcknowledgementRequest[0].userId, aData.deviceId);
                if (checkdevice.valid == false)
                {
                    uResponse.Valid = false;
                    uResponse.Status = "false";
                    uResponse.Message = checkdevice.msg;
                }
                else
                {
                    foreach (var sample in aData.data.AcknowledgementRequest)
                    {
                        _mobileSubjectData.AddCHCSubAcknowledgement(sample.uniqueSubjectId);
                        ackCount = ackCount + 1;
                    }
                    uResponse.Valid = true;
                    uResponse.Status = "true";
                    uResponse.Message = ackCount + " Acknowledgement successfully received";
                }
            }
            catch (Exception e)
            {
                uResponse.Valid = true;
                uResponse.Status = "false";
                uResponse.Message = e.Message;
            }
            return uResponse;
        }

        public async Task<AcknowledgementResponse> AddCHCSampleAcknowledgement(AcknowledgementBarocdeRequest aData)
        {
            var uResponse = new AcknowledgementResponse();
            var ackCount = 0;
            try
            {
                var checkdevice = _mobileSubjectData.CheckDevice(aData.data.AcknowledgementRequest[0].userId, aData.deviceId);
                if (checkdevice.valid == false)
                {
                    uResponse.Valid = false;
                    uResponse.Status = "false";
                    uResponse.Message = checkdevice.msg;
                }
                else
                {
                    foreach (var sample in aData.data.AcknowledgementRequest)
                    {
                        _mobileSubjectData.AddCHCSamplesAcknowledgement(sample.barcodeNo);
                        ackCount = ackCount + 1;
                    }
                    uResponse.Valid = true;
                    uResponse.Status = "true";
                    uResponse.Message = ackCount + " Acknowledgement successfully received";
                }
            }
            catch (Exception e)
            {
                uResponse.Valid = true;
                uResponse.Status = "false";
                uResponse.Message = e.Message;
            }
            return uResponse;
        }

        public async Task<AcknowledgementResponse> AddAcknowledgement(AcnowledgementRequest aData)
        {
            var uResponse = new AcknowledgementResponse();
            var ackCount = 0;
            try
            {
                var checkdevice = _mobileSubjectData.CheckDevice(aData.data.AcknowledgementRequest[0].userId, aData.deviceId);
                if (checkdevice.valid == false)
                {
                    uResponse.Valid = false;
                    uResponse.Status = "false";
                    uResponse.Message = checkdevice.msg;
                }
                else
                {
                    foreach (var sample in aData.data.AcknowledgementRequest)
                    {
                        _mobileSubjectData.AddResultAcknowledgement(sample.uniqueSubjectId);
                        ackCount = ackCount + 1;
                    }
                    uResponse.Valid = true;
                    uResponse.Status = "true";
                    uResponse.Message = ackCount + " Acknowledgement successfully received";
                }
            }
            catch (Exception e)
            {
                uResponse.Valid = true;
                uResponse.Status = "false";
                uResponse.Message = e.Message;
            }
            return uResponse;
        }

        public async Task<UpdateReferalStatusResponse> UpdatePNDTReferalStatus(AddReferalStatusRequest rData)
        {

            var uResponse = new UpdateReferalStatusResponse();
            var subjectIds = new List<SubjectIdList>();
            var subjectId = "";
            try
            {
                var checkdevice = _mobileSubjectData.CheckDevice(rData.data[0].userId, rData.deviceId);
                if (checkdevice.valid == false)
                {
                    uResponse.Valid = false;
                    uResponse.Status = "false";
                    uResponse.Message = checkdevice.msg;
                }
                else
                {
                    foreach (var sub in rData.data)
                    {
                        var slist = new SubjectIdList();
                        subjectId = sub.uniqueSubjectId;
                        _mobileSubjectData.UpdatePNDTReferalStatus(sub);
                        slist.uniqueSubjectId = sub.uniqueSubjectId;
                        subjectIds.Add(slist);
                    }
                    uResponse.Valid = true;
                    uResponse.Status = "true";
                    uResponse.Message = subjectIds.Count + " subjects pndt referal status successfully updated";
                    uResponse.SubjectIds = subjectIds;
                }
            }
            catch (Exception e)
            {
                uResponse.Valid = true;
                uResponse.Status = "false";
                uResponse.Message = e.Message;
                uResponse.SubjectIds = subjectIds;
            }
            return uResponse;
        }

        public async Task<UpdateReferalStatusResponse> UpdateMTPReferalStatus(AddReferalStatusRequest rData)
        {
            var uResponse = new UpdateReferalStatusResponse();
            var subjectIds = new List<SubjectIdList>();
            var subjectId = "";
            try
            {
                var checkdevice = _mobileSubjectData.CheckDevice(rData.data[0].userId, rData.deviceId);
                if (checkdevice.valid == false)
                {
                    uResponse.Valid = false;
                    uResponse.Status = "false";
                    uResponse.Message = checkdevice.msg;
                }
                else
                {
                    foreach (var sub in rData.data)
                    {
                        var slist = new SubjectIdList();
                        subjectId = sub.uniqueSubjectId;
                        _mobileSubjectData.UpdateMTPReferalStatus(sub);
                        slist.uniqueSubjectId = sub.uniqueSubjectId;
                        subjectIds.Add(slist);
                    }
                    uResponse.Valid = true;
                    uResponse.Status = "true";
                    uResponse.Message = subjectIds.Count + " subjects mtp referal status successfully updated";
                    uResponse.SubjectIds = subjectIds;
                }
            }
            catch (Exception e)
            {
                uResponse.Valid = true;
                uResponse.Status = "false";
                uResponse.Message = e.Message;
                uResponse.SubjectIds = subjectIds;
            }
            return uResponse;
        }

        public async Task<AcknowledgementResponse> UpdatePrePostPNDTMTPAcknowledgement(AddPrePostStatusRequest aData)
        {
            var uResponse = new AcknowledgementResponse();
            var ackCount = 0;
            try
            {
                var checkdevice = _mobileSubjectData.CheckDevice(aData.data[0].userId, aData.deviceId);
                if (checkdevice.valid == false)
                {
                    uResponse.Valid = false;
                    uResponse.Status = "false";
                    uResponse.Message = checkdevice.msg;
                }
                else
                {
                    foreach (var sample in aData.data)
                    {
                        _mobileSubjectData.UpdatePrePostPNDTMTPAcknowledgement(sample);
                        ackCount = ackCount + 1;
                    }
                    uResponse.Valid = true;
                    uResponse.Status = "true";
                    uResponse.Message = ackCount + " Acknowledgement successfully received";
                }
            }
            catch (Exception e)
            {
                uResponse.Valid = true;
                uResponse.Status = "false";
                uResponse.Message = e.Message;
            }
            return uResponse;
        }

        public async Task<UpdateFollowupStatusResponse> UpdatePostMTPFollowupStatus(AddFollowUpRequest fData)
        {
            var uResponse = new UpdateFollowupStatusResponse();
            var subList = new List<SubjectIdsList>();
            var subjectId = "";
            try
            {
                var checkdevice = _mobileSubjectData.CheckDevice(fData.data[0].userId, fData.deviceId);
                if (checkdevice.valid == false)
                {
                    uResponse.Valid = false;
                    uResponse.Status = "false";
                    uResponse.Message = checkdevice.msg;
                }
                else
                {
                    foreach (var subject in fData.data)
                    {
                        var slist = new SubjectIdsList();
                        subjectId = subject.uniqueSubjectId;
                        _mobileSubjectData.UpdatePostMTPFollowupStatus(subject);
                        slist.uniqueSubjectId = subject.uniqueSubjectId;
                        subList.Add(slist);
                    }
                    uResponse.Valid = true;
                    uResponse.Status = "true";
                    uResponse.Message = subList.Count + " Subjects status successfully updated";
                    uResponse.SubjectIds = subList;
                }
            }
            catch (Exception e)
            {
                uResponse.Valid = true;
                uResponse.Status = "false";
                uResponse.Message = e.Message;
                uResponse.SubjectIds = subList;

            }
            return uResponse;
        }

        public async Task<RetriveTrackingResponse> RetrieveTrackingSubjects(MobileRetrieveRequest mrData)
        {
            var tResponse = new RetriveTrackingResponse();
            try
            {
                var checkdevice = _mobileSubjectData.CheckDevice(mrData.userId, mrData.deviceId);
                if (checkdevice.valid == false)
                {
                    tResponse.Valid = false;
                    tResponse.Status = "false";
                    tResponse.Message = checkdevice.msg;
                }
                else
                {
                    var subjects = _mobileSubjectData.RetrieveTrackingSubjects(mrData.userId);
                    tResponse.Valid = true;
                    tResponse.Status = "true";
                    tResponse.Subjects = subjects;
                    tResponse.Message = string.Empty;
                }
            }
            catch (Exception e)
            {
                tResponse.Valid = true;
                tResponse.Status = "false";
                tResponse.Message = e.Message;

            }
            return tResponse;
        }

        public async Task<DashboardAndChartsResponse> RetrieveDashboardandCharts(MobileRetrieveRequest mrData)
        {

            var dcResponse = new DashboardAndChartsResponse();
            try
            {
                var checkdevice = _mobileSubjectData.CheckDevice(mrData.userId, mrData.deviceId);
                if (checkdevice.valid == false)
                {
                    dcResponse.Valid = false;
                    dcResponse.Status = "false";
                    dcResponse.Message = checkdevice.msg;
                }
                else
                {
                    var chart = _mobileSubjectData.FetchMobileChartDetail(mrData.userId);
                    var summary = _mobileSubjectData.FetchMobileMetricsDetail(mrData.userId);
                    var responseMessage = _mobileSubjectData.RetrieveResponseMsg();
                    dcResponse.Valid = true;
                    dcResponse.Status = "true";
                    dcResponse.lastSyncDate = DateTime.Now.ToString("dd/MM/yyyy");
                    dcResponse.chart = chart;
                    dcResponse.summary = summary;
                    dcResponse.Message = responseMessage.responseMsg + dcResponse.lastSyncDate;
                }
            }
            catch (Exception e)
            {
                dcResponse.Valid = true;
                dcResponse.Status = "false";
                dcResponse.Message = e.Message;
            }
            return dcResponse;
        }

        public async Task<SampleCollectionListResponse> AddSampleCollectionNew(SampleCollectRequest ssData)
        {
            List<BarcodeSampleDetail> barcodes = new List<BarcodeSampleDetail>();
            SampleCollectionListResponse slResponse = new SampleCollectionListResponse();
            var barcodeNo = "";
            try
            {
                var checkdevice = _mobileSubjectData.CheckDevice(ssData.data.SampleCollectionsRequest[0].samples.collectedBy, ssData.deviceId);
                if (checkdevice.valid == false)
                {
                    slResponse.Valid = false;
                    slResponse.Status = "false";
                    slResponse.Message = checkdevice.msg;
                }
                else
                {
                    foreach (var sample in ssData.data.SampleCollectionsRequest)
                    {
                        var slist = new BarcodeSampleDetail();
                        barcodeNo = sample.samples.barcodeNo;
                        var getId = _mobileSubjectData.NewSampleCollection(sample.samples);
                        if (getId[0].getId != 0)
                        {
                            SMSTrigger(getId[0].getId);
                        }

                        var reason = sample.samples.reason;
                        var smsSampleDetails = _sampleCollectionData.FetchSMSSamples(sample.samples.barcodeNo, sample.samples.uniqueSubjectId);
                        var barcode = smsSampleDetails.barcodeNo;
                        var subjectMobileNo = smsSampleDetails.subjectMobileNo;
                        var subjectName = smsSampleDetails.subjectName;
                        var anmName = smsSampleDetails.anmName;
                        var anmMobileNo = smsSampleDetails.anmMobileNo;

                        if (reason.ToUpper() == "FIRST TIME COLLECTION")
                        {
                            var smsURL = _config.GetSection("RegistrationSamplingOdiyaSMStoSubject").GetSection("SMSNewSampleAPILink").Value;
                            var smsURLLink = smsURL.Replace("#MobileNo", subjectMobileNo).Replace("#SubjectName", subjectName).Replace("#SubjectId", sample.samples.uniqueSubjectId).Replace("#BarcodeNo", sample.samples.barcodeNo).Replace("#ANMName", anmName).Replace("#ANMMobile", anmMobileNo);
                            GetResponse(smsURLLink);
                        }
                        else
                        {
                            var smsURL = _config.GetSection("RegistrationSamplingOdiyaSMStoSubject").GetSection("SMSNewSampleRecollectionAPILink").Value;
                            var smsURLLink = smsURL.Replace("#MobileNo", subjectMobileNo).Replace("#SubjectName", subjectName).Replace("#SubjectId", sample.samples.uniqueSubjectId).Replace("#BarcodeNo", sample.samples.barcodeNo).Replace("#ANMName", anmName).Replace("#ANMMobile", anmMobileNo);
                            GetResponse(smsURLLink);
                        }


                        slist.barcodeNo = sample.samples.barcodeNo;
                        barcodes.Add(slist);
                    }
                    slResponse.Status = "true";
                    slResponse.Valid = true;
                    slResponse.Message = barcodes.Count + " Samples collected successfully";
                    slResponse.Barcodes = barcodes;
                }
            }
            catch (Exception e)
            {
                slResponse.Valid = true;
                slResponse.Status = "false";
                slResponse.Message = "Partially " + barcodes.Count + " samples collected successfully, From this (" + barcodeNo + ") onwards not collected. " + e.Message;
                slResponse.Barcodes = barcodes;
            }
            return slResponse;
        }

        public void SMSTrigger(int id)
        {
            var errorSMSDetail = _mobileSubjectData.ErrorSMSTrigger(id);
            var barcode = errorSMSDetail.barcode;
            var uniqueSubjectId = errorSMSDetail.uniqueSubjectId;
            var subjectName = errorSMSDetail.subjectName;
            var subjectMobileNo = errorSMSDetail.subjectMobileNo;
            var sampleCollectionDate = errorSMSDetail.sampleCollectionDate;
            var anmName = errorSMSDetail.anmName;
            var anmMobileNo = errorSMSDetail.anmMobileNo;
            var anmSCName = errorSMSDetail.anmSCName;
            var existUniqueSubjectId = errorSMSDetail.existUniqueSubjectId;
            var existSubjectName = errorSMSDetail.existSubjectName;
            var existSubjectMobileNo = errorSMSDetail.existSubjectMobileNo;
            var existSampleCollectionDate = errorSMSDetail.existSampleCollectionDate;
            var existANMName = errorSMSDetail.existANMName;
            var existANMMobileNo = errorSMSDetail.existANMMobileNo;
            var existANMSCName = errorSMSDetail.existANMSCName;
            var anmId = errorSMSDetail.anmId;
            var existANMId = errorSMSDetail.existANMId;
            var scdcDetail = _mobileSubjectData.FetchDCSPCDetails(anmId, existANMId);
            var scName = scdcDetail.scName;
            var scContactNo = scdcDetail.scContactNo;
            var scEmail = scdcDetail.scEmail;
            var dcName = scdcDetail.dcName;
            var dcContactNo = scdcDetail.dcContactNo;
            var dcEmail = scdcDetail.dcEmail;
            var existDCName = scdcDetail.existDCName;
            var existDCContactNo = scdcDetail.existDCContactNo;
            var existDCEmail = scdcDetail.existDCEmail;

            var chcName = errorSMSDetail.chcName;
            var phcName = errorSMSDetail.phcName;
            var regDate = errorSMSDetail.regDate;

            var existCHCName = errorSMSDetail.existCHCName;
            var existPHCName = errorSMSDetail.existPHCName;
            var existRegDate = errorSMSDetail.existRegDate;

            //var smsANMURL = _config.GetSection("ErrorBarcodeSMSEmail").GetSection("ErrorBarcodeToANM").Value;
            //var smsExistANMURL = _config.GetSection("ErrorBarcodeSMSEmail").GetSection("ErrorBarcodeToExistANM").Value;
            //var smsSPCDCURL = _config.GetSection("ErrorBarcodeSMSEmail").GetSection("ErrorBarcodeToDCSPC").Value;

            //var smsANMURLLink = smsANMURL.Replace("#Barcode", barcode).Replace("#ANMName", anmName).Replace("#ANMMobileNo", anmMobileNo)
            //    .Replace("#ExistANMName", existANMName).Replace("#ExistANMSCName", existANMSCName).Replace("#SubjectName", subjectName)
            //    .Replace("#SubjectId", uniqueSubjectId);

            //var smsExistANMURLLink = smsExistANMURL.Replace("#Barcode", barcode).Replace("#ANMName", anmName).Replace("#ExistANMMobileNo", existANMMobileNo)
            //   .Replace("#ExistANMName", existANMName).Replace("#ANMSCName", anmSCName).Replace("#ExistSubjectName", existSubjectName)
            //   .Replace("#ExistSubjectId", existUniqueSubjectId);

            //var dcURLLink = smsSPCDCURL.Replace("#MobileNo", dcContactNo).Replace("#SPCDCName", dcName).Replace("#Barcode", barcode)
            //    .Replace("#ANMName", anmName).Replace("#SubjectName", subjectName).Replace("#SubjectId", uniqueSubjectId)
            //    .Replace("#ExistANMName", existANMName).Replace("#ExistSubjectName", existSubjectName).Replace("#ExistSubjectId", existUniqueSubjectId);

            //var existDCURLLink = smsSPCDCURL.Replace("#MobileNo", existDCContactNo).Replace("#SPCDCName", existDCName).Replace("#Barcode", barcode)
            //    .Replace("#ANMName", anmName).Replace("#SubjectName", subjectName).Replace("#SubjectId", uniqueSubjectId)
            //    .Replace("#ExistANMName", existANMName).Replace("#ExistSubjectName", existSubjectName).Replace("#ExistSubjectId", existUniqueSubjectId);

            //var spcURLLink = smsSPCDCURL.Replace("#MobileNo", scContactNo).Replace("#SPCDCName", scName).Replace("#Barcode", barcode)
            //    .Replace("#ANMName", anmName).Replace("#SubjectName", subjectName).Replace("#SubjectId", uniqueSubjectId)
            //    .Replace("#ExistANMName", existANMName).Replace("#ExistSubjectName", existSubjectName).Replace("#ExistSubjectId", existUniqueSubjectId);

            //GetResponse(smsANMURLLink);
            //GetResponse(smsExistANMURLLink);
            //GetResponse(dcURLLink);
            //GetResponse(existDCURLLink);
            //GetResponse(spcURLLink);

            var host = _config.GetSection("SMTPDetails").GetSection("host").Value;
            var port = _config.GetSection("SMTPDetails").GetSection("port").Value;
            var uName = _config.GetSection("SMTPDetails").GetSection("username").Value;
            string pwd = _config.GetSection("SMTPDetails").GetSection("pwd").Value;
            string from = _config.GetSection("SMTPDetails").GetSection("from").Value;
            string cc = _config.GetSection("ErrorBarcodeSMSEmail").GetSection("recipients").Value;

            string recipients = dcEmail + ", " + existDCEmail + ", " + scEmail;
            string subject = _config.GetSection("ErrorBarcodeSMSEmail").GetSection("MailSubject").Value;
            string mailTemplateBody = _config.GetSection("ErrorBarcodeSMSEmail").GetSection("Body").Value;
            string mailBody = "";
            string mailSubject = subject.Replace("#Barcode", barcode);
            mailBody = mailBody + mailTemplateBody.Replace("#Barcode", barcode)
                .Replace("#ExistSubjectName", existSubjectName).Replace("#ExistSubjectId", existUniqueSubjectId).Replace("#ExistRegDate", existRegDate)
                .Replace("#ExistSampleCollectionDate", existSampleCollectionDate).Replace("#ExistANMName", existANMName).Replace("#ExistANMMobileNo", existANMMobileNo)
                .Replace("#ExistCHC", existCHCName).Replace("#ExistPHC", existPHCName).Replace("#ExistDCName", existDCName).Replace("#ExistDCContactNo", existDCContactNo)
                .Replace("#SubjectName", subjectName).Replace("#SubjectId", uniqueSubjectId).Replace("#RegDate", regDate)
                .Replace("#SampleCollectionDate", sampleCollectionDate).Replace("#ANMName", anmName).Replace("#ANMMobileNo", anmMobileNo)
                .Replace("#CHC", chcName).Replace("#PHC", phcName).Replace("#DCName", dcName).Replace("#DCContactNo", dcContactNo);
            var mailMessage = new MailMessage(from, recipients, mailSubject, mailBody);
            mailMessage.CC.Add(cc);
            mailMessage.IsBodyHtml = true;
            var client = new SmtpClient(host, int.Parse(port))
            {
                Credentials = new NetworkCredential(uName, pwd),
                EnableSsl = true
            };
            client.Send(mailMessage);

        }
        public static string GetResponse(string sURL)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(sURL);
            request.MaximumAutomaticRedirections = 4;
            request.Credentials = CredentialCache.DefaultCredentials;
            try
            {
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream receiveStream = response.GetResponseStream();
                StreamReader readStream = new StreamReader(receiveStream, Encoding.UTF8);
                string sResponse = readStream.ReadToEnd();
                response.Close();
                readStream.Close();
                return sResponse;
            }
            catch
            {
                return "";
            }
        }

    }
}

