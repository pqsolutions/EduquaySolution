using EduquayAPI.Contracts.V1.Request.MobileAppSubjectRegistration;
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

        public MobileSubjectData()
        {

        }
        public string AddSubject(AddSubjectRequest subRegData)
        {
            try
            {
                int count = 0;
                foreach(var subject in subRegData.subjectsRequest)
                {
                    subjectPrimary(subject.subjectPrimaryRequest);
                    SubjectAddress(subject.subjectAddressRequest);
                    SubjectPregnancy(subject.subjectPregnancyRequest);
                    SubjectParent(subject.subjectParentRequest);
                    count += 1;
                }
                return ""+ count +" subjects registered successfully.";
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
                    new SqlParameter("@SubjectTypeID", sprData.subjectTypeId),
                    new SqlParameter("@ChildSubjectTypeID", sprData.childSubjectTypeId),
                    new SqlParameter("@UniqueSubjectID", sprData.uniqueSubjectId ?? sprData.uniqueSubjectId),
                    new SqlParameter("@DistrictID", sprData.districtId),
                    new SqlParameter("@CHCID", sprData.chcId),
                    new SqlParameter("@PHCID", sprData.phcId),
                    new SqlParameter("@SCID", sprData.scId),
                    new SqlParameter("@RIID", sprData.riId),
                    new SqlParameter("@SubjectTitle", sprData.subjectTitle ?? sprData.subjectTitle),
                    new SqlParameter("@FirstName", sprData.firstName ?? sprData.firstName),
                    new SqlParameter("@MiddleName", sprData.middleName ?? sprData.middleName),
                    new SqlParameter("@LastName", sprData.lastName ?? sprData.lastName),
                    new SqlParameter("@DOB", sprData.dob ?? sprData.dob),
                    new SqlParameter("@Age", sprData.age),
                    new SqlParameter("@Gender", sprData.gender ?? sprData.gender),
                    new SqlParameter("@MaritalStatus", sprData.maritalStatus ?? sprData.maritalStatus),
                    new SqlParameter("@MobileNo", sprData.mobileNo ?? sprData.mobileNo),
                    new SqlParameter("@EmailId", sprData.emailId ?? sprData.emailId),
                    new SqlParameter("@GovIdType_ID", sprData.govIdTypeId),
                    new SqlParameter("@GovIdDetail", sprData.govIdDetail ?? sprData.govIdDetail),
                    new SqlParameter("@SpouseSubjectID", sprData.spouseSubjectId ?? sprData.spouseSubjectId),
                    new SqlParameter("@Spouse_FirstName", sprData.spouseFirstName ?? sprData.spouseFirstName),
                    new SqlParameter("@Spouse_MiddleName", sprData.spouseMiddleName ?? sprData.spouseMiddleName),
                    new SqlParameter("@Spouse_LastName", sprData.spouseLastName ?? sprData.spouseLastName),
                    new SqlParameter("@Spouse_ContactNo", sprData.spouseContactNo ?? sprData.spouseContactNo),
                    new SqlParameter("@Spouse_GovIdType_ID", sprData.spouseGovIdTypeId),
                    new SqlParameter("@Spouse_GovIdDetail", sprData.spouseGovIdDetail ?? sprData.spouseGovIdDetail),
                    new SqlParameter("@AssignANM_ID", sprData.assignANMId),
                    new SqlParameter("@DateofRegister", sprData.dateOfRegister),
                    new SqlParameter("@RegisteredFrom", sprData.registeredFrom),
                    new SqlParameter("@Isactive", sprData.isActive ?? sprData.isActive),
                    new SqlParameter("@Createdby", sprData.createdBy),
                    new SqlParameter("@Updatedby", sprData.updatedBy),
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
                    new SqlParameter("@RCHID", spData.rchId ?? spData.rchId),
                    new SqlParameter("@ECNumber", spData.ecNumber ?? spData.ecNumber),
                    new SqlParameter("@LMP_Date", spData.lmpDate),
                    new SqlParameter("@Gestational_period", spData.gestationalPeriod),
                    new SqlParameter("@G", spData.g),
                    new SqlParameter("@P", spData.p),
                    new SqlParameter("@L", spData.l),
                    new SqlParameter("@A", spData.a),
                    new SqlParameter("@UpdatedBy", spData.updatedBy),
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
                    new SqlParameter("@Mother_FirstName", spaData.motherFirstName ?? spaData.motherFirstName),
                    new SqlParameter("@Mother_MiddleName", spaData.motherMiddleName ?? spaData.motherMiddleName),
                    new SqlParameter("@Mother_LastName", spaData.motherLastName ?? spaData.motherLastName),
                    new SqlParameter("@Mother_GovIdType_ID", spaData.motherGovIdTypeId ),
                    new SqlParameter("@Mother_GovIdDetail", spaData.motherGovIdDetail ?? spaData.motherGovIdDetail),
                    new SqlParameter("@Mother_ContactNo", spaData.motherContactNo ?? spaData.motherContactNo),
                    new SqlParameter("@Father_FirstName", spaData.fatherFirstName ?? spaData.fatherFirstName),
                    new SqlParameter("@Father_MiddleName", spaData.fatherMiddleName ?? spaData.fatherMiddleName),
                    new SqlParameter("@Father_LastName", spaData.fatherLastName ?? spaData.fatherLastName),
                    new SqlParameter("@Father_GovIdType_ID", spaData.fatherGovIdTypeId ),
                    new SqlParameter("@Father_GovIdDetail", spaData.fatherGovIdDetail ?? spaData.fatherGovIdDetail),
                    new SqlParameter("@Father_ContactNo", spaData.fatherContactNo ?? spaData.fatherContactNo),
                    new SqlParameter("@Gaurdian_FirstName", spaData.gaurdianFirstName ?? spaData.gaurdianFirstName),
                    new SqlParameter("@Gaurdian_MiddleName", spaData.gaurdianMiddleName ?? spaData.gaurdianMiddleName),
                    new SqlParameter("@Gaurdian_LastName", spaData.gaurdianLastName ?? spaData.gaurdianLastName),
                    new SqlParameter("@Gaurdian_GovIdType_ID", spaData.gaurdianGovIdTypeId ),
                    new SqlParameter("@Gaurdian_GovIdDetail", spaData.gaurdianGovIdDetail ?? spaData.gaurdianGovIdDetail),
                    new SqlParameter("@Gaurdian_ContactNo", spaData.gaurdianContactNo ?? spaData.gaurdianContactNo),
                    new SqlParameter("@RBSKId", spaData.rbskId ?? spaData.rbskId),
                    new SqlParameter("@SchoolName", spaData.schoolName ?? spaData.schoolName),
                    new SqlParameter("@SchoolAddress1", spaData.schoolAddress1 ?? spaData.schoolAddress1),
                    new SqlParameter("@SchoolAddress2", spaData.schoolAddress2 ?? spaData.schoolAddress2),
                    new SqlParameter("@SchoolAddress3", spaData.schoolAddress3 ?? spaData.schoolAddress3),
                    new SqlParameter("@SchoolPincode", spaData.schoolPincode ?? spaData.schoolPincode),
                    new SqlParameter("@SchoolCity", spaData.schoolCity ?? spaData.schoolCity),
                    new SqlParameter("@SchoolState", spaData.schoolState ?? spaData.schoolState),
                    new SqlParameter("@Standard", spaData.standard  ?? spaData.standard),
                    new SqlParameter("@Section", spaData.section ?? spaData.section),
                    new SqlParameter("@RollNo", spaData.rollNo ?? spaData.rollNo),
                    new SqlParameter("@UpdatedBy", spaData.updatedBy),
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
                    new SqlParameter("@Religion_Id", saData.religionId),
                    new SqlParameter("@Caste_Id", saData.casteId),
                    new SqlParameter("@Community_Id", saData.communityId),
                    new SqlParameter("@Address1", saData.address1 ?? saData.address1),
                    new SqlParameter("@Address2", saData.address2 ?? saData.address2),
                    new SqlParameter("@Address3", saData.address3 ?? saData.address3),
                    new SqlParameter("@Pincode", saData.pincode ?? saData.pincode),
                    new SqlParameter("@StateName", saData.stateName ?? saData.stateName),
                    new SqlParameter("@UpdatedBy", saData.updatedBy),
                    retVal
                };
                UtilityDL.ExecuteNonQuery(stProc, pList);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



    }
}
