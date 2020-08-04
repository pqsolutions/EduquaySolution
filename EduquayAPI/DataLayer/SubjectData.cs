using EduquayAPI.Contracts.V1.Request;
using EduquayAPI.Contracts.V1.Response;
using EduquayAPI.Models;
using EduquayAPI.Models.ANMSubjectRegistration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.DataLayer
{
    public class SubjectData : ISubjectData
    {
        private const string AddSubjectPrimaryDetail = "SPC_AddSubjectPrimaryDetail";
        private const string AddSubjectAddressDetail = "SPC_AddSubjectAddressDetail";
        private const string AddSubjectPregnancyDetail = "SPC_AddSubjectPregnancyDetail";
        private const string AddSubjectParentDetail = "SPC_AddSubjectParentDetail";
        private const string FetchSubjectDetail = "SPC_FetchSubjectDetail";
        private const string FetchANWSubjectDetail = "SPC_FetchANMANWSubjectDetail";
        private const string FetchCHCANWSubjectDetail = "SPC_FetchCHCANWPositiveSubjectDetail";

        public SubjectData()
        {

        }


        public UniqueIdDetail AddSubject(SubjectRegistrationRequest subRegData)
        {
            var uniqueSubjectId = new UniqueIdDetail();
            try
            {
                SubjectPrimaryDetail subPrimary = subjectPrimary(subRegData.subjectPrimaryRequest);
                if (subPrimary != null)
                {
                    if (subPrimary.id > 0)
                    {
                        var subID = subPrimary.id;
                        var uniqueSubId = subPrimary.uniqueSubjectId;
                        SubjectAddress(subRegData.subjectAddressRequest, uniqueSubId);
                        SubjectPregnancy(subRegData.subjectPregnancyRequest, uniqueSubId);
                        SubjectParent(subRegData.subjectParentRequest, uniqueSubId);
                        uniqueSubjectId.uniqueSubjectId = uniqueSubId;
                        uniqueSubjectId.message = "Unique Id Successfully generated";
                        uniqueSubjectId.status = true;
                    }
                    else
                    {
                        uniqueSubjectId.uniqueSubjectId = "";
                        uniqueSubjectId.status = false;
                        uniqueSubjectId.message = $"Failed to add subject registration for {subRegData.subjectPrimaryRequest.firstName + " " + subRegData.subjectPrimaryRequest.lastName}";
                    }
                }
                else
                {
                    uniqueSubjectId.uniqueSubjectId = "";
                    uniqueSubjectId.status = false;
                    uniqueSubjectId.message = $"Failed to add subject registration for {subRegData.subjectPrimaryRequest.firstName + " " + subRegData.subjectPrimaryRequest.lastName}";
                }

            }
            catch (Exception e)
            {
                uniqueSubjectId.uniqueSubjectId = "";
                uniqueSubjectId.status = false;
                uniqueSubjectId.message = $"Failed to add subject registration for {subRegData.subjectPrimaryRequest.firstName + " " + subRegData.subjectPrimaryRequest.lastName}";
            }
            return uniqueSubjectId;

        }

        public SubjectPrimaryDetail subjectPrimary(SubjectPrimaryDetailRequest sprData)
        {

            try
            {
                string stProc = AddSubjectPrimaryDetail;

                var pList = new List<SqlParameter>
                {
                    new SqlParameter("@SubjectTypeID", Convert.ToInt32(sprData.subjectTypeId)),
                    new SqlParameter("@ChildSubjectTypeID", Convert.ToInt32(sprData.childSubjectTypeId)),
                    new SqlParameter("@UniqueSubjectID", sprData.uniqueSubjectId.ToCheckNull()),
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
                    new SqlParameter("@EmailId", sprData.emailId .ToCheckNull()),
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
                    new SqlParameter("@Createdby", Convert.ToInt32(sprData.createdBy)),
                    new SqlParameter("@Source", sprData.source),
                };
                var subPrimary = UtilityDL.FillEntity<SubjectPrimaryDetail>(stProc, pList);
                return subPrimary;

            }
            catch (Exception e)
            {
                throw e;
            }
        }


        public void SubjectAddress(SubjectAddressDetailRequest saData, string uniqueSubId)
        {

            try
            {
                var stProc = AddSubjectAddressDetail;
                var retVal = new SqlParameter("@SCOPE_OUTPUT", 1) { Direction = ParameterDirection.Output };
                var pList = new List<SqlParameter>()
                {
                    new SqlParameter("@UniqueSubjectID", uniqueSubId),
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

        public void SubjectPregnancy(SubjectPregnancyDetailRequest spData, string uniqueSubID)
        {

            try
            {
                var stProc = AddSubjectPregnancyDetail;
                var retVal = new SqlParameter("@SCOPE_OUTPUT", 1) { Direction = ParameterDirection.Output };
                var pList = new List<SqlParameter>()
                {
                    new SqlParameter("@UniqueSubjectID",uniqueSubID ),
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

        public void SubjectParent(SubjectParentDetailRequest spaData, string uniqueSubID)
        {

            try
            {
                var stProc = AddSubjectParentDetail;
                var retVal = new SqlParameter("@SCOPE_OUTPUT", 1) { Direction = ParameterDirection.Output };
                var pList = new List<SqlParameter>()
                {
                    new SqlParameter("@UniqueSubjectID", uniqueSubID),
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

        public List<SubjectPrimaryDetail> RetrievePrimaryDetail(SubjectRequest sData)
        {
            string stProc = FetchSubjectDetail;
            var pList = new List<SqlParameter>() { new SqlParameter("@UniqueSubjectID", sData.subjectId) };
            var allData = UtilityDL.FillData<SubjectPrimaryDetail>(stProc, pList);
            return allData;
        }

        public List<SubjectAddresDetail> RetrieveAddressDetail(SubjectRequest sData)
        {
            string stProc = FetchSubjectDetail;
            var pList = new List<SqlParameter>() { new SqlParameter("@UniqueSubjectID", sData.subjectId) };
            var allData = UtilityDL.FillData<SubjectAddresDetail>(stProc, pList);
            return allData;
        }

        public List<SubjectPregnancyDetail> RetrievePregnancyDetail(SubjectRequest sData)
        {
            string stProc = FetchSubjectDetail;
            var pList = new List<SqlParameter>() { new SqlParameter("@UniqueSubjectID", sData.subjectId) };
            var allData = UtilityDL.FillData<SubjectPregnancyDetail>(stProc, pList);
            return allData;
        }

        public List<SubjectParentDetail> RetrieveParentDetail(SubjectRequest sData)
        {
            string stProc = FetchSubjectDetail;
            var pList = new List<SqlParameter>() { new SqlParameter("@UniqueSubjectID", sData.subjectId) };
            var allData = UtilityDL.FillData<SubjectParentDetail>(stProc, pList);
            return allData;
        }

        public List<ANWSubjectDetail> RetrieveANWDetail(ANWSubjectRequest asData)
        {
            string stProc = FetchANWSubjectDetail;
            var pList = new List<SqlParameter>()
            { 
                new SqlParameter("@ANMID", asData.anmId),
                new SqlParameter("@FromDate", asData.fromDate ?? asData.fromDate),
                new SqlParameter("@ToDate", asData.toDate ?? asData.toDate),
            };
            var allData = UtilityDL.FillData<ANWSubjectDetail>(stProc, pList);
            return allData;
        }

        public List<CHCANWSubjectDetail> RetrieveCHCANWDetail(CHCANWSubjectRequest casData)
        {
            string stProc = FetchCHCANWSubjectDetail;
            var pList = new List<SqlParameter>()
            {
                new SqlParameter("@CHCId", casData.chcId),
                new SqlParameter("@FromDate", casData.fromDate ?? casData.fromDate),
                new SqlParameter("@ToDate", casData.toDate ?? casData.toDate),
                new SqlParameter("@RegisteredFrom", casData.registeredFrom),
            };
            var allData = UtilityDL.FillData<CHCANWSubjectDetail>(stProc, pList);
            return allData;
        }
    }
}
