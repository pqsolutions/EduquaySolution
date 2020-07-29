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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Services.MobileSubject
{
    public class MobileSubjectService : IMobileSubjectService
    {
        private readonly IMobileSubjectData _mobileSubjectData;

        public MobileSubjectService(IMobileSubjectDataFactory mobileSubjectDataFactory)
        {
            _mobileSubjectData = new MobileSubjectDataFactory().Create();
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
            }
            catch (Exception e)
            {
                slResponse.Valid = true;
                slResponse.Status = "false";
                slResponse.Message = "Partially " + shipmentIds.Count + " shipment generated successfully, From this (" + shipmentIds + ") onwards shipment not generated. " + e.Message;
                slResponse.ShipmentIds = shipmentIds;
            }
            return slResponse;

        }

        public async Task<TimeoutResponse> AddMoveTimeout(AddTimeoutExpireMobileRequest eData)
        {
            var tResponse =  new TimeoutResponse();
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

                        subjectRegistration.PrimaryDetail = primarySubject;
                        subjectRegistration.AddressDetail = address;
                        subjectRegistration.PregnancyDetail = pregnancy;
                        subjectRegistration.ParentDetail = parent;
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
                    total = damagedSamples.Count + timeoutSamples.Count +hplcPositiveSubjects.Count;
                    nlResponse.Status = "true";
                    nlResponse.Valid = true;
                    nlResponse.Message = string.Empty;
                    nlResponse.totalNotifications = total;
                    nlResponse.DamagedSamples = damagedSamples;
                    nlResponse.TimeoutExpirySamples = timeoutSamples;
                    nlResponse.PositiveSubjects = hplcPositiveSubjects;
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
    }
}

