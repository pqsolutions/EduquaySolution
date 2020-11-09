using EduquayAPI.Contracts.V1.Request.Mobile;
using EduquayAPI.Contracts.V1.Request.MobileAppSampleCollection;
using EduquayAPI.Contracts.V1.Request.MobileAppShipment;
using EduquayAPI.Contracts.V1.Request.MobileAppSubjectRegistration;
using EduquayAPI.Contracts.V1.Response.ANMSubjectRegistration;
using EduquayAPI.Models;
using EduquayAPI.Models.ANMSubjectRegistration;
using EduquayAPI.Models.MobileSubject;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.DataLayer.MobileSubject
{
    public class MobileSubjectData : IMobileSubjectData
    {

        private const string AddPrimaryDetail = "SPC_AddPrimaryDetail";
        private const string AddSubjectAddressDetail = "SPC_AddSubjectAddressDetail";
        private const string AddSubjectPregnancyDetail = "SPC_AddSubjectPregnancyDetail";
        private const string AddSubjectParentDetail = "SPC_AddSubjectParentDetail";
        private const string FetchMobileSubjectsDetail = "SPC_FetchMobileSubjectDetail";
        private const string AddSampleCollection = "SPC_AddSampleCollection";
        private const string FetchMobileSampleDetailList = "SPC_FetchMobileSampleDetailList";
        private const string AddShipments = "SPC_AddANMMobileShipments";
        private const string FetchShipmentLog = "SPC_FetchMobileANMShipmentLog";
        private const string FetchDamagedSamples = "SPC_FetchMobileNotificationDamaged";
        private const string FetchTimooutExpiry = "SPC_FetchMobileNotificationTimeout";
        private const string FetchLastId = "SPC_FetchLastIds";
        private const string CheckValidDevice = "SPC_CheckValidDevice";
        private const string MoveTimeoutExpiry = "SPC_AddTimeoutExpiryInUnsentSamples";
        private const string HPLCPositive = "SPC_FetchMobilePositiveSubjectDetail";
        private const string UpdateStatusNotifications = "SPC_UpdateStatusANMMobileNotification";
        private const string UpdateStatusPositiveSubjects = "SPC_UpdateStatusANMMobilePositiveSubjects";
        private const string FetchTestResults = "SPC_FetchMobileSubjectResultDetail";
        private const string AddResultAcknowledgements = "SPC_AddResultAcknowledgement";

        private const string FetchMobileCHCSubjectDetail = "SPC_FetchMobileCHCSubjectDetail";
        private const string FetchMobileCHCSampleDetailList = "SPC_FetchMobileCHCSampleDetailList";
        private const string AddCHCSubjectAcknowledgement = "SPC_AddCHCSubjectAcknowledgement";
        private const string AddCHCSampleAcknowledgement = "SPC_AddCHCSampleAcknowledgement";

        private const string FetchANMMobileNotificationPNDTReferal = "SPC_FetchANMMobileNotificationPNDTReferal";
        private const string FetchANMMobileNotificationMTPReferal = "SPC_FetchANMMobileNotificationMTPReferal";
        private const string UpdateStatusANMMobileNotificationPNDTReferal = "SPC_UpdateStatusANMMobileNotificationPNDTReferal";
        private const string UpdateStatusANMMobileNotificationMTPReferal = "SPC_UpdateStatusANMMobileNotificationMTPReferal";

        private const string FetchANMMobilePrePNDTCounselling = "SPC_FetchANMMobilePrePNDTCounselling";
        private const string FetchANMMobilePNDTesting = "SPC_FetchANMMobilePNDTesting";
        private const string FetchANMMobilePostPNDTCounselling = "SPC_FetchANMMobilePostPNDTCounselling";
        private const string FetchANMMobileMTPService = "SPC_FetchANMMobileMTPService";

        private const string FetchANMMobileNotificationPrePC = "SPC_FetchANMMobileNotificationPrePC";
        private const string FetchANMMobileNotificationPNDTesting = "SPC_FetchANMMobileNotificationPNDTesting";
        private const string FetchANMMobileNotificationPostPC = "SPC_FetchANMMobileNotificationPostPC";
        private const string FetchANMMobileNotificationMTPService = "SPC_FetchANMMobileNotificationMTPService";
        private const string AddPrePostPNDTMTPAcknowledgement = "SPC_AddPrePostPNDTMTPAcknowledgement";

        private const string FetchANMNotificationPostMTPFollowUp = "SPC_FetchANMNotificationPostMTPFollowUp";
        private const string UpdateMobilePostMTPFollowUpStatus = "SPC_UpdateMobilePostMTPFollowUpStatus";

        private const string FetchTrackingSubjectReportMobile = "SPC_FetchTrackingSubjectReportMobile";
        public MobileSubjectData()
        {

        }

        public void AddShipment(MobileShipmentRequest msData)
        {
            try
            {
                string stProc = AddShipments;
                var pList = new List<SqlParameter>
                {
                    new SqlParameter("@GeneratedShipmentId", msData.shipmentId ?? msData.shipmentId),
                    new SqlParameter("@BarcodeNo", msData.barcodeNo ?? msData.barcodeNo),
                    new SqlParameter("@ShipmentFrom", msData.shipmentFrom),
                    new SqlParameter("@ANM_ID", msData.anmId),
                    new SqlParameter("@RIID", msData.riId),
                    new SqlParameter("@ILR_ID", msData.ilrId),
                    new SqlParameter("@AVDID", msData.avdId),
                    new SqlParameter("@AVDContactNo", msData.avdContactNo.ToCheckNull()),
                    new SqlParameter("@AlternateAVD", msData.alternateAVD.ToCheckNull()),
                    new SqlParameter("@AlternateAVDContactNo", msData.alternateAVDContactNo.ToCheckNull()),
                    new SqlParameter("@TestingCHCID", msData.testingCHCId),
                    new SqlParameter("@DateofShipment", msData.dateOfShipment ?? msData.dateOfShipment),
                    new SqlParameter("@TimeofShipment", msData.timeOfShipment ?? msData.timeOfShipment),
                    new SqlParameter("@Createdby", msData.createdBy),
                    new SqlParameter("@Source",msData.source ?? msData.source),
                };
                UtilityDL.ExecuteNonQuery(stProc, pList);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void subjectPrimary(PrimaryDetailRequest sprData)
        {

            try
            {
                string stProc = AddPrimaryDetail;

                var pList = new List<SqlParameter>
                {
                    new SqlParameter("@SubjectTypeID", Convert.ToInt32(sprData.subjectTypeId)),
                    new SqlParameter("@ChildSubjectTypeID", Convert.ToInt32(sprData.childSubjectTypeId)),
                    new SqlParameter("@UniqueSubjectID", sprData.uniqueSubjectId ?? sprData.uniqueSubjectId),
                    new SqlParameter("@DistrictID", Convert.ToInt32(sprData.districtId)),
                    new SqlParameter("@CHCID", Convert.ToInt32(sprData.chcId)),
                    new SqlParameter("@PHCID", Convert.ToInt32(sprData.phcId)),
                    new SqlParameter("@SCID", Convert.ToInt32(sprData.scId)),
                    new SqlParameter("@RIID", Convert.ToInt32(sprData.riId)),
                    new SqlParameter("@SubjectTitle", sprData.subjectTitle.ToCheckNull()),
                    new SqlParameter("@FirstName", sprData.firstName ?? sprData.firstName),
                    new SqlParameter("@MiddleName", sprData.middleName.ToCheckNull()),
                    new SqlParameter("@LastName", sprData.lastName.ToCheckNull()),
                    new SqlParameter("@DOB", sprData.dob.ToCheckNull()),
                    new SqlParameter("@Age", Convert.ToInt32(sprData.age)),
                    new SqlParameter("@Gender", sprData.gender.ToCheckNull()),
                    new SqlParameter("@MaritalStatus", sprData.maritalStatus ?? sprData.maritalStatus),
                    new SqlParameter("@MobileNo", sprData.mobileNo.ToCheckNull()),
                    new SqlParameter("@EmailId", sprData.emailId.ToCheckNull()),
                    new SqlParameter("@GovIdType_ID", Convert.ToInt32(sprData.govIdTypeId)),
                    new SqlParameter("@GovIdDetail", sprData.govIdDetail.ToCheckNull()),
                    new SqlParameter("@SpouseSubjectID", sprData.spouseSubjectId.ToCheckNull()),
                    new SqlParameter("@Spouse_FirstName", sprData.spouseFirstName.ToCheckNull()),
                    new SqlParameter("@Spouse_MiddleName", sprData.spouseMiddleName.ToCheckNull()),
                    new SqlParameter("@Spouse_LastName", sprData.spouseLastName.ToCheckNull()),
                    new SqlParameter("@Spouse_ContactNo", sprData.spouseContactNo.ToCheckNull()),
                    new SqlParameter("@Spouse_GovIdType_ID", Convert.ToInt32(sprData.spouseGovIdTypeId)),
                    new SqlParameter("@Spouse_GovIdDetail", sprData.spouseGovIdDetail.ToCheckNull()),
                    new SqlParameter("@AssignANM_ID", Convert.ToInt32(sprData.assignANMId)),
                    new SqlParameter("@DateofRegister", sprData.dateOfRegister.ToCheckNull()),
                    new SqlParameter("@RegisteredFrom", Convert.ToInt32(sprData.registeredFrom)),
                    new SqlParameter("@Isactive", sprData.isActive),
                    new SqlParameter("@Createdby", Convert.ToInt32(sprData.createdBy)),
                    new SqlParameter("@Updatedby", Convert.ToInt32(sprData.updatedBy)),
                    new SqlParameter("@Source", sprData.source),
                };
                UtilityDL.ExecuteNonQuery(stProc, pList);

            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void SubjectPregnancy(PregnancyDetailRequest spData)
        {

            try
            {
                var stProc = AddSubjectPregnancyDetail;
                var retVal = new SqlParameter("@SCOPE_OUTPUT", 1) { Direction = ParameterDirection.Output };
                var pList = new List<SqlParameter>()
                {
                    new SqlParameter("@UniqueSubjectID", spData.uniqueSubjectId ?? spData.uniqueSubjectId),
                    new SqlParameter("@RCHID", spData.rchId.ToCheckNull()),
                    new SqlParameter("@ECNumber", spData.ecNumber.ToCheckNull()),
                    new SqlParameter("@LMP_Date", spData.lmpDate.ToCheckNull()),
                    new SqlParameter("@G", Convert.ToInt32(spData.g)),
                    new SqlParameter("@P", Convert.ToInt32(spData.p)),
                    new SqlParameter("@L", Convert.ToInt32(spData.l)),
                    new SqlParameter("@A", Convert.ToInt32(spData.a)),
                    new SqlParameter("@UpdatedBy", Convert.ToInt32(spData.updatedBy)),
                    retVal
                };
                UtilityDL.ExecuteNonQuery(stProc, pList);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void SubjectParent(ParentDetailRequest spaData)
        {

            try
            {
                var stProc = AddSubjectParentDetail;
                var retVal = new SqlParameter("@SCOPE_OUTPUT", 1) { Direction = ParameterDirection.Output };
                var pList = new List<SqlParameter>()
                {
                    new SqlParameter("@UniqueSubjectID", spaData.uniqueSubjectId ?? spaData.uniqueSubjectId),
                    new SqlParameter("@Mother_FirstName", spaData.motherFirstName.ToCheckNull()),
                    new SqlParameter("@Mother_MiddleName", spaData.motherMiddleName.ToCheckNull()),
                    new SqlParameter("@Mother_LastName", spaData.motherLastName.ToCheckNull()),
                    new SqlParameter("@Mother_GovIdType_ID", Convert.ToInt32(spaData.motherGovIdTypeId)),
                    new SqlParameter("@Mother_GovIdDetail", spaData.motherGovIdDetail.ToCheckNull()),
                    new SqlParameter("@Mother_ContactNo", spaData.motherContactNo.ToCheckNull()),
                    new SqlParameter("@Father_FirstName", spaData.fatherFirstName.ToCheckNull()),
                    new SqlParameter("@Father_MiddleName", spaData.fatherMiddleName.ToCheckNull()),
                    new SqlParameter("@Father_LastName", spaData.fatherLastName.ToCheckNull()),
                    new SqlParameter("@Father_GovIdType_ID", Convert.ToInt32(spaData.fatherGovIdTypeId)),
                    new SqlParameter("@Father_GovIdDetail", spaData.fatherGovIdDetail.ToCheckNull()),
                    new SqlParameter("@Father_ContactNo", spaData.fatherContactNo.ToCheckNull()),
                    new SqlParameter("@Gaurdian_FirstName", spaData.gaurdianFirstName.ToCheckNull()),
                    new SqlParameter("@Gaurdian_MiddleName", spaData.gaurdianMiddleName.ToCheckNull()),
                    new SqlParameter("@Gaurdian_LastName", spaData.gaurdianLastName.ToCheckNull()),
                    new SqlParameter("@Guardian_GovIdType_ID", Convert.ToInt32(spaData.gaurdianGovIdTypeId)),
                    new SqlParameter("@Guardian_GovIdDetail", spaData.gaurdianGovIdDetail.ToCheckNull()),
                    new SqlParameter("@Gaurdian_ContactNo", spaData.gaurdianContactNo.ToCheckNull()),
                    new SqlParameter("@RBSKId", spaData.rbskId.ToCheckNull()),
                    new SqlParameter("@SchoolName", spaData.schoolName.ToCheckNull()),
                    new SqlParameter("@SchoolAddress1", spaData.schoolAddress1.ToCheckNull()),
                    new SqlParameter("@SchoolAddress2", spaData.schoolAddress2.ToCheckNull()),
                    new SqlParameter("@SchoolAddress3", spaData.schoolAddress3.ToCheckNull()),
                    new SqlParameter("@SchoolPincode", spaData.schoolPincode.ToCheckNull()),
                    new SqlParameter("@SchoolCity", spaData.schoolCity.ToCheckNull()),
                    new SqlParameter("@SchoolState", spaData.schoolState.ToCheckNull()),
                    new SqlParameter("@Standard", spaData.standard.ToCheckNull()),
                    new SqlParameter("@Section", spaData.section.ToCheckNull()),
                    new SqlParameter("@RollNo", spaData.rollNo.ToCheckNull()),
                    new SqlParameter("@UpdatedBy", Convert.ToInt32(spaData.updatedBy)),
                    retVal
                };
                UtilityDL.ExecuteNonQuery(stProc, pList);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void SubjectAddress(AddressDetailRequest saData)
        {

            try
            {
                var stProc = AddSubjectAddressDetail;
                var retVal = new SqlParameter("@SCOPE_OUTPUT", 1) { Direction = ParameterDirection.Output };
                var pList = new List<SqlParameter>()
                {
                    new SqlParameter("@UniqueSubjectID", saData.uniqueSubjectId ?? saData.uniqueSubjectId),
                    new SqlParameter("@Religion_Id", Convert.ToInt32(saData.religionId)),
                    new SqlParameter("@Caste_Id", Convert.ToInt32(saData.casteId)),
                    new SqlParameter("@Community_Id", Convert.ToInt32(saData.communityId)),
                    new SqlParameter("@Address1", saData.address1.ToCheckNull()),
                    new SqlParameter("@Address2", saData.address2.ToCheckNull()),
                    new SqlParameter("@Address3", saData.address3.ToCheckNull()),
                    new SqlParameter("@Pincode", saData.pincode.ToCheckNull()),
                    new SqlParameter("@StateName", saData.stateName.ToCheckNull()),
                    new SqlParameter("@UpdatedBy", Convert.ToInt32(saData.updatedBy)),
                    retVal
                };
                UtilityDL.ExecuteNonQuery(stProc, pList);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public void SampleColection(SampleCollectionsRequest ssData)
        {
            try
            {
                var stProc = AddSampleCollection;
                var retVal = new SqlParameter("@SCOPE_OUTPUT", 1) { Direction = ParameterDirection.Output };
                var pList = new List<SqlParameter>()
                {
                    new SqlParameter("@UniqueSubjectID", ssData.uniqueSubjectId ?? ssData.uniqueSubjectId),
                    new SqlParameter("@BarcodeNo", ssData.barcodeNo  ?? ssData.barcodeNo),
                    new SqlParameter("@SampleCollectionDate", ssData.sampleCollectionDate ?? ssData.sampleCollectionDate),
                    new SqlParameter("@SampleCollectionTime", ssData.sampleCollectionTime ?? ssData.sampleCollectionTime),
                    new SqlParameter("@Reason", ssData.reason ?? ssData.reason),
                    new SqlParameter("@CollectionFrom", ssData.collectionFrom),
                    new SqlParameter("@CollectedBy", ssData.collectedBy),
                    retVal
                };
                UtilityDL.ExecuteNonQuery(stProc, pList);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public SubjectRegDetail MobileSubjectRegDetail(int userId)
        {
            string stProc = FetchMobileSubjectsDetail;
            string stProc1 = FetchANMMobilePrePNDTCounselling;
            string stProc2 = FetchANMMobilePNDTesting;
            string stProc3 = FetchANMMobilePostPNDTCounselling;
            string stProc4 = FetchANMMobileMTPService;

            var pList = new List<SqlParameter>() { new SqlParameter("@UserId", userId) };
            var allPrimaryData = UtilityDL.FillData<SubjectPrimary>(stProc, pList);
            var allAddressData = UtilityDL.FillData<SubjectAddress>(stProc, pList);
            var allPregnancyData = UtilityDL.FillData<SubjectPregnancy>(stProc, pList);
            var allParentData = UtilityDL.FillData<SubjectParent>(stProc, pList);
            var allResults = UtilityDL.FillData<TestResult>(stProc, pList);
            var allPrPC = UtilityDL.FillData<MobilePrePNDTCounselling>(stProc1, pList);
            var allPNDTTest = UtilityDL.FillData<MobilePNDTesting>(stProc2, pList);
            var allPoPC = UtilityDL.FillData<MobilePostPNDTCounselling>(stProc3, pList);
            var allMTP = UtilityDL.FillData<MobileMTPService>(stProc4, pList);
            var subDetail = new SubjectRegDetail();
            subDetail.PrimarySubjectList = allPrimaryData;
            subDetail.AddressSubjectList = allAddressData;
            subDetail.PregnancySubjectList = allPregnancyData;
            subDetail.ParentSubjectList = allParentData;
            subDetail.Results = allResults;
            subDetail.prePndtCounselling = allPrPC;
            subDetail.pndtTesting = allPNDTTest;
            subDetail.postPndtCounselling = allPoPC;
            subDetail.mtpService = allMTP;
            return subDetail;
        }

        public List<SampleCollection> MobileSampleDetail(int userId)
        {
            string stProc = FetchMobileSampleDetailList;
            var pList = new List<SqlParameter>() { new SqlParameter("@UserId", userId) };
            var allSampleData = UtilityDL.FillData<SampleCollection>(stProc, pList);
            return allSampleData;
        }

        public ANMMobileShipment MobileANMShipmentDetail(int userId)
        {
            string stProc = FetchShipmentLog;
            var pList = new List<SqlParameter>() { new SqlParameter("@UserID", userId) };
            var shipmentLog= UtilityDL.FillData<MobileShipment>(stProc, pList);
            var shipmentSample = UtilityDL.FillData<MobileShipmentSample>(stProc, pList);
            var shipdetail = new ANMMobileShipment();
            shipdetail.ShipmentLog = shipmentLog;
            shipdetail.ShipmentSubjectDetail = shipmentSample;
            return shipdetail;
        }

        public List<MobileNotificationSamples> DamagedSamples(int userId)
        {
            string stProc = FetchDamagedSamples;
            var pList = new List<SqlParameter>() { new SqlParameter("@ANMID", userId) };
            var allSampleData = UtilityDL.FillData<MobileNotificationSamples>(stProc, pList);
            return allSampleData;
        }

        public List<MobileNotificationSamples> SampleTimeout(int userId)
        {
            string stProc = FetchTimooutExpiry;
            var pList = new List<SqlParameter>() { new SqlParameter("@ANMID", userId) };
            var allSampleData = UtilityDL.FillData<MobileNotificationSamples>(stProc, pList);
            return allSampleData;
        }

        public LastIds FindLastId(int userId)
        {
            string stProc = FetchLastId;
            var pList = new List<SqlParameter>() { new SqlParameter("@ANMId", userId) };
            var allData = UtilityDL.FillEntity<LastIds>(stProc, pList);
            return allData;
        }

        public Device CheckDevice(int userId, string deviceId)
        {
            string stProc = CheckValidDevice;
            var pList = new List<SqlParameter>()
            {
                new SqlParameter("@ANMId", userId ),
                new SqlParameter("@DeviceId", deviceId ),

            };
            var allData = UtilityDL.FillEntity<Device>(stProc, pList);
            return allData;
        }

        public void AddTimeoutExpiry(MobileAddExpiryRequest meData)
        {
            try
            {
                var stProc = MoveTimeoutExpiry;
                var pList = new List<SqlParameter>()
                {
                    new SqlParameter("@BarcodeNo", meData.barcodeNo  ?? meData.barcodeNo),
                    new SqlParameter("@ANMID", meData.userId ),
                };
                UtilityDL.ExecuteNonQuery(stProc, pList);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<MobilePositiveSubjects> PositiveSubjects(int userId)
        {
            string stProc = HPLCPositive;
            var pList = new List<SqlParameter>() { new SqlParameter("@ANMID", userId) };
            var allSampleData = UtilityDL.FillData<MobilePositiveSubjects>(stProc, pList);
            return allSampleData;
        }

        public void UpdateNotificationStatus(UpdateStatusRequest usData)
        {
            try
            {
                var stProc = UpdateStatusNotifications;
                var pList = new List<SqlParameter>()
                {
                    new SqlParameter("@BarcodeNo", usData.barcodeNo  ?? usData.barcodeNo),
                    new SqlParameter("@ANMID", usData.userId ),
                    new SqlParameter("@NotifiedOn", usData.notifiedOn ?? usData.notifiedOn),

                };
                UtilityDL.ExecuteNonQuery(stProc, pList);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void UpdatePositiveSubjectStatus(UpdateStatusRequest usData)
        {
            try
            {
                var stProc = UpdateStatusPositiveSubjects;
                var pList = new List<SqlParameter>()
                {
                    new SqlParameter("@BarcodeNo", usData.barcodeNo  ?? usData.barcodeNo),
                    new SqlParameter("@ANMID", usData.userId ),
                    new SqlParameter("@NotifiedOn", usData.notifiedOn ?? usData.notifiedOn),

                };
                UtilityDL.ExecuteNonQuery(stProc, pList);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<TestResult> GetTestResults(int userId)
        {
            string stProc = FetchTestResults;
            var pList = new List<SqlParameter>() { new SqlParameter("@UserId", userId) };
            var allResultsData = UtilityDL.FillData<TestResult>(stProc, pList);
            return allResultsData;
        }

        public void AddResultAcknowledgement(string uniqueSubjectId)
        {
            try
            {
                var stProc = AddResultAcknowledgements;
                var pList = new List<SqlParameter>()
                {
                    new SqlParameter("@UniqueSubjectId", uniqueSubjectId  ?? uniqueSubjectId),
                };
                UtilityDL.ExecuteNonQuery(stProc, pList);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public void AddCHCSubAcknowledgement(string uniqueSubjectId)
        {
            try
            {
                var stProc = AddCHCSubjectAcknowledgement;
                var pList = new List<SqlParameter>()
                {
                    new SqlParameter("@UniqueSubjectId", uniqueSubjectId  ?? uniqueSubjectId),
                };
                UtilityDL.ExecuteNonQuery(stProc, pList);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void AddCHCSamplesAcknowledgement(string barcodeNo)
        {
            try
            {
                var stProc = AddCHCSampleAcknowledgement;
                var pList = new List<SqlParameter>()
                {
                    new SqlParameter("@BarcodeNo", barcodeNo  ?? barcodeNo),
                };
                UtilityDL.ExecuteNonQuery(stProc, pList);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<SampleCollection> MobileCHCSampleDetail(int userId)
        {
            string stProc = FetchMobileCHCSampleDetailList;
            var pList = new List<SqlParameter>() { new SqlParameter("@UserId", userId) };
            var allSampleData = UtilityDL.FillData<SampleCollection>(stProc, pList);
            return allSampleData;
        }

        public SubjectRegDetail MobileCHCSubjectRegDetail(int userId)
        {
            string stProc = FetchMobileCHCSubjectDetail;
            var pList = new List<SqlParameter>() { new SqlParameter("@UserId", userId) };
            var allPrimaryData = UtilityDL.FillData<SubjectPrimary>(stProc, pList);
            var allAddressData = UtilityDL.FillData<SubjectAddress>(stProc, pList);
            var allPregnancyData = UtilityDL.FillData<SubjectPregnancy>(stProc, pList);
            var allParentData = UtilityDL.FillData<SubjectParent>(stProc, pList);
            var allResults = UtilityDL.FillData<TestResult>(stProc, pList);
            var subDetail = new SubjectRegDetail();
            subDetail.PrimarySubjectList = allPrimaryData;
            subDetail.AddressSubjectList = allAddressData;
            subDetail.PregnancySubjectList = allPregnancyData;
            subDetail.ParentSubjectList = allParentData;
            subDetail.Results = allResults;
            return subDetail;
        }

        public MobilePNDTReferal GetPNDTReferral(int userId)
        {
            string stProc = FetchANMMobileNotificationPNDTReferal;
            var pList = new List<SqlParameter>() { new SqlParameter("@UserId", userId) };
            var allSubjectData = UtilityDL.FillData<MobilePNDTSubject>(stProc, pList);
            var allSpouseData = UtilityDL.FillData<MobilePNDTSpouse>(stProc, pList);
            var allPPCData = UtilityDL.FillData<NotificationPrePNDTCounselling>(stProc, pList);
            var allPNDTTestData = UtilityDL.FillData<NotificationPNDTesting>(stProc, pList);
            var pndtRefferalDetail = new MobilePNDTReferal();
            pndtRefferalDetail.subject = allSubjectData;
            pndtRefferalDetail.spouse = allSpouseData;
            pndtRefferalDetail.prePndtCounselling = allPPCData;
            pndtRefferalDetail.pndtTesting = allPNDTTestData;
            return pndtRefferalDetail;
        }

        public MobileMTPReferal GetMTPReferral(int userId)
        {
            string stProc = FetchANMMobileNotificationMTPReferal;
            var pList = new List<SqlParameter>() { new SqlParameter("@UserId", userId) };
            var allSubjectData = UtilityDL.FillData<MobileMTPSubject>(stProc, pList);
            var allSpouseData = UtilityDL.FillData<MobileMTPSpouse>(stProc, pList);
            var allPPCData = UtilityDL.FillData<NotificationPostPNDTCounselling>(stProc, pList);
            var allMTPService = UtilityDL.FillData<NotificationMTPService>(stProc, pList);
            var mtpRefferalDetail = new MobileMTPReferal();
            mtpRefferalDetail.subject = allSubjectData;
            mtpRefferalDetail.spouse = allSpouseData;
            mtpRefferalDetail.postPndtCounselling = allPPCData;
            mtpRefferalDetail.mtpService = allMTPService;
            return mtpRefferalDetail;
        }

        public void UpdatePNDTReferalStatus(MobileReferalRequest rData)
        {
            try
            {
                var stProc = UpdateStatusANMMobileNotificationPNDTReferal;
                var pList = new List<SqlParameter>()
                {
                    new SqlParameter("@ANWSubjectId", rData.uniqueSubjectId  ?? rData.uniqueSubjectId),
                    new SqlParameter("@ANMID", rData.userId ),
                };
                UtilityDL.ExecuteNonQuery(stProc, pList);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void UpdateMTPReferalStatus(MobileReferalRequest rData)
        {
            try
            {
                var stProc = UpdateStatusANMMobileNotificationMTPReferal;
                var pList = new List<SqlParameter>()
                {
                    new SqlParameter("@ANWSubjectId", rData.uniqueSubjectId  ?? rData.uniqueSubjectId),
                    new SqlParameter("@ANMID", rData.userId ),
                };
                UtilityDL.ExecuteNonQuery(stProc, pList);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<MobilePrePNDTCounselling> FetchPrePNDTCounselling(int userId)
        {
            string stProc = FetchANMMobilePrePNDTCounselling;
            var pList = new List<SqlParameter>() { new SqlParameter("@UserId", userId) };
            var allSampleData = UtilityDL.FillData<MobilePrePNDTCounselling>(stProc, pList);
            return allSampleData;
        }

        public List<MobilePNDTesting> FetchPNDTesting(int userId)
        {
            string stProc = FetchANMMobilePNDTesting;
            var pList = new List<SqlParameter>() { new SqlParameter("@UserId", userId) };
            var allSampleData = UtilityDL.FillData<MobilePNDTesting>(stProc, pList);
            return allSampleData;
        }

        public List<MobilePostPNDTCounselling> FetchPostPNDTCounselling(int userId)
        {
            string stProc = FetchANMMobilePostPNDTCounselling;
            var pList = new List<SqlParameter>() { new SqlParameter("@UserId", userId) };
            var allSampleData = UtilityDL.FillData<MobilePostPNDTCounselling>(stProc, pList);
            return allSampleData;
        }

        public List<MobileMTPService> FetchMTPService(int userId)
        {
            string stProc = FetchANMMobileMTPService;
            var pList = new List<SqlParameter>() { new SqlParameter("@UserId", userId) };
            var allSampleData = UtilityDL.FillData<MobileMTPService>(stProc, pList);
            return allSampleData;
        }

        public List<MobilePrePNDTCounselling> FetchPrePNDTCounsellingNotification(int userId)
        {
            string stProc = FetchANMMobileNotificationPrePC;
            var pList = new List<SqlParameter>() { new SqlParameter("@UserId", userId) };
            var allSampleData = UtilityDL.FillData<MobilePrePNDTCounselling>(stProc, pList);
            return allSampleData;
        }

        public List<MobilePNDTesting> FetchPNDTestingNotification(int userId)
        {
            string stProc = FetchANMMobileNotificationPNDTesting;
            var pList = new List<SqlParameter>() { new SqlParameter("@UserId", userId) };
            var allSampleData = UtilityDL.FillData<MobilePNDTesting>(stProc, pList);
            return allSampleData;
        }

        public List<MobilePostPNDTCounselling> FetchPostPNDTCounsellingNotification(int userId)
        {
            string stProc = FetchANMMobileNotificationPostPC;
            var pList = new List<SqlParameter>() { new SqlParameter("@UserId", userId) };
            var allSampleData = UtilityDL.FillData<MobilePostPNDTCounselling>(stProc, pList);
            return allSampleData;
        }

        public List<MobileMTPService> FetchMTPServiceNotification(int userId)
        {
            string stProc = FetchANMMobileNotificationMTPService;
            var pList = new List<SqlParameter>() { new SqlParameter("@UserId", userId) };
            var allSampleData = UtilityDL.FillData<MobileMTPService>(stProc, pList);
            return allSampleData;
        }

        public void UpdatePrePostPNDTMTPAcknowledgement(AddPNDTMTPAckRequest aData)
        {
            try
            {
                var stProc = AddPrePostPNDTMTPAcknowledgement;
                var pList = new List<SqlParameter>()
                {
                    new SqlParameter("@UniqueSubjectId", aData.uniqueSubjectId  ?? aData.uniqueSubjectId),
                    new SqlParameter("@Request", aData.inputRequest),
                };
                UtilityDL.ExecuteNonQuery(stProc, pList);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ANMMobileMTPFollowUp MobileMTPFollowUp(int userId)
        {
            string stProc = FetchANMNotificationPostMTPFollowUp;
            var pList = new List<SqlParameter>() { new SqlParameter("@UserID", userId) };
            var postMtpFollowUp = UtilityDL.FillData<MTPFollowupDetail>(stProc, pList);
            var firstFollowUp = UtilityDL.FillData<MTPFirstFollowup>(stProc, pList);
            var secondFollowUp = UtilityDL.FillData<MTPSecondFollowup>(stProc, pList);
            var thirdFollowUp = UtilityDL.FillData<MTPThirdFollowup>(stProc, pList);
            var mtpFollowup = new ANMMobileMTPFollowUp();
            mtpFollowup.postMtpFollowUp = postMtpFollowUp;
            mtpFollowup.firstFollowUp = firstFollowUp;
            mtpFollowup.secondFollowUp = secondFollowUp;
            mtpFollowup.thirdFollowUp = thirdFollowUp;
            return mtpFollowup;
        }

        public void UpdatePostMTPFollowupStatus(AddUpdateFollowupStatusRequest fData)
        {
            try
            {
                string stProc = UpdateMobilePostMTPFollowUpStatus;
                var pList = new List<SqlParameter>
                {
                    new SqlParameter("@UniqueSubjectId", fData.uniqueSubjectId),
                    new SqlParameter("@FollowUpNo", fData.followUpNo),
                    new SqlParameter("@FollowUpStatusId", fData.followUpStatusId),
                    new SqlParameter("@FollowUpStatusDetail", fData.followUpStatusDetail.ToCheckNull()),
                    new SqlParameter("@UserId", fData.userId),

                };
                UtilityDL.ExecuteNonQuery(stProc, pList);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<TrackingMobileSubjects> RetrieveTrackingSubjects(int userId)
        {

            string stProc = FetchTrackingSubjectReportMobile;
            var pList = new List<SqlParameter>() { new SqlParameter("@ANMId", userId) };
            var allSampleData = UtilityDL.FillData<TrackingMobileSubjects>(stProc, pList);
            return allSampleData;
        }
    }
}
