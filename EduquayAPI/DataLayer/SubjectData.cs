using EduquayAPI.Contracts.V1.Request;
using EduquayAPI.Models;
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

        public SubjectData()
        {

        }


        public string AddSubject(SubjectRegistrationRequest subRegData)
        {
            try
            {

                SubjectPrimaryDetail subPrimary = subjectPrimary(subRegData.SubjectPrimaryRequest);
                if (subPrimary != null)
                {
                    if (subPrimary.ID > 0)
                    {
                        var subID = subPrimary.ID;
                        var uniqueSubID = subPrimary.UniqueSubjectID;
                        SubjectAddress(subRegData.SubjectAddressRequest, subID);
                        SubjectPregnancy(subRegData.SubjectPregnancyRequest, subID);
                        SubjectParent(subRegData.SubjectParentRequest, subID);
                        return "Unique SubjectID generated successfully. The Unique ID is: " + uniqueSubID;
                    }
                    else
                    {
                        return $"Failed to add subject registration for {subRegData.SubjectPrimaryRequest.FirstName + " " + subRegData.SubjectPrimaryRequest.LastName}";
                    }
                }
                else
                {
                    return $"Unable to Register subject for {subRegData.SubjectPrimaryRequest.FirstName + " " + subRegData.SubjectPrimaryRequest.LastName}";
                }

            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public SubjectPrimaryDetail subjectPrimary(SubjectPrimaryDetailRequest sprData)
        {

            try
            {
                string stProc = AddSubjectPrimaryDetail;

                var pList = new List<SqlParameter>
                {
                    new SqlParameter("@SubjectTypeID", sprData.SubjectTypeID),
                    new SqlParameter("@ChildSubjectTypeID", sprData.ChildSubjectTypeID),
                    new SqlParameter("@UniqueSubjectID", sprData.UniqueSubjectID ?? sprData.UniqueSubjectID),
                    new SqlParameter("@DistrictID", sprData.DistrictID),
                    new SqlParameter("@CHCID", sprData.CHCID),
                    new SqlParameter("@PHCID", sprData.PHCID),
                    new SqlParameter("@SCID", sprData.SCID),
                    new SqlParameter("@RIID", sprData.RIID),
                    new SqlParameter("@SubjectTitle", sprData.SubjectTitle ?? sprData.SubjectTitle),
                    new SqlParameter("@FirstName", sprData.FirstName ?? sprData.FirstName),
                    new SqlParameter("@MiddleName", sprData.MiddleName ?? sprData.MiddleName),
                    new SqlParameter("@LastName", sprData.LastName ?? sprData.LastName),
                    new SqlParameter("@DOB", sprData.DOB ?? sprData.DOB),
                    new SqlParameter("@Age", sprData.Age),
                    new SqlParameter("@Gender", sprData.Gender ?? sprData.Gender),
                    new SqlParameter("@MaritalStatus", sprData.MaritalStatus ?? sprData.MaritalStatus),
                    new SqlParameter("@MobileNo", sprData.MobileNo ?? sprData.MobileNo),
                    new SqlParameter("@EmailId", sprData.EmailId ?? sprData.EmailId),
                    new SqlParameter("@GovIdType_ID", sprData.GovIdType_ID),
                    new SqlParameter("@GovIdDetail", sprData.GovIdDetail ?? sprData.GovIdDetail),
                    new SqlParameter("@SpouseSubjectID", sprData.SpouseSubjectID ?? sprData.SpouseSubjectID),
                    new SqlParameter("@Spouse_FirstName", sprData.Spouse_FirstName ?? sprData.Spouse_FirstName),
                    new SqlParameter("@Spouse_MiddleName", sprData.Spouse_MiddleName ?? sprData.Spouse_MiddleName),
                    new SqlParameter("@Spouse_LastName", sprData.Spouse_LastName ?? sprData.Spouse_LastName),
                    new SqlParameter("@Spouse_ContactNo", sprData.Spouse_ContactNo ?? sprData.Spouse_ContactNo),
                    new SqlParameter("@Spouse_GovIdType_ID", sprData.Spouse_GovIdType_ID),
                    new SqlParameter("@Spouse_GovIdDetail", sprData.Spouse_GovIdDetail ?? sprData.Spouse_GovIdDetail),
                    new SqlParameter("@AssignANM_ID", sprData.AssignANM_ID),
                    new SqlParameter("@DateofRegister", sprData.DateofRegister),
                    new SqlParameter("@RegisteredFrom", sprData.RegisteredFrom),
                    new SqlParameter("@Isactive", sprData.IsActive ?? sprData.IsActive),
                    new SqlParameter("@Createdby", sprData.CreatedBy),
                    new SqlParameter("@Updatedby", sprData.UpdatedBy),
                    new SqlParameter("@Source", sprData.Source),
                };
                var subPrimary = UtilityDL.FillEntity<SubjectPrimaryDetail>(stProc, pList);
                return subPrimary;

            }
            catch (Exception e)
            {
                throw e;
            }
        }


        public void SubjectAddress(SubjectAddressDetailRequest saData, int subID)
        {

            try
            {
                var stProc = AddSubjectAddressDetail;
                var retVal = new SqlParameter("@SCOPE_OUTPUT", 1) { Direction = ParameterDirection.Output };
                var pList = new List<SqlParameter>()
                {
                    new SqlParameter("@SubjectID", subID),
                    new SqlParameter("@Religion_Id", saData.Religion_Id),
                    new SqlParameter("@Caste_Id", saData.Caste_Id),
                    new SqlParameter("@Community_Id", saData.Community_Id),
                    new SqlParameter("@Address1", saData.Address1 ?? saData.Address1),
                    new SqlParameter("@Address2", saData.Address2 ?? saData.Address2),
                    new SqlParameter("@Address3", saData.Address3 ?? saData.Address3),
                    new SqlParameter("@Pincode", saData.Pincode ?? saData.Pincode),
                    new SqlParameter("@StateName", saData.StateName ?? saData.StateName),
                    new SqlParameter("@UpdatedBy", saData.UpdatedBy),
                    retVal
                };
                UtilityDL.ExecuteNonQuery(stProc, pList);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void SubjectPregnancy(SubjectPregnancyDetailRequest spData, int subID)
        {

            try
            {
                var stProc = AddSubjectPregnancyDetail;
                var retVal = new SqlParameter("@SCOPE_OUTPUT", 1) { Direction = ParameterDirection.Output };
                var pList = new List<SqlParameter>()
                {
                    new SqlParameter("@SubjectID", subID),
                    new SqlParameter("@RCHID", spData.RCHID ?? spData.RCHID),
                    new SqlParameter("@ECNumber", spData.ECNumber ?? spData.ECNumber),
                    new SqlParameter("@LMP_Date", spData.LMP_Date),
                    new SqlParameter("@Gestational_period", spData.Gestational_period),
                    new SqlParameter("@G", spData.G),
                    new SqlParameter("@P", spData.P),
                    new SqlParameter("@L", spData.L),
                    new SqlParameter("@A", spData.A),
                    new SqlParameter("@UpdatedBy", spData.UpdatedBy),
                    retVal
                };
                UtilityDL.ExecuteNonQuery(stProc, pList);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void SubjectParent(SubjectParentDetailRequest spaData, int subID)
        {

            try
            {
                var stProc = AddSubjectParentDetail;
                var retVal = new SqlParameter("@SCOPE_OUTPUT", 1) { Direction = ParameterDirection.Output };
                var pList = new List<SqlParameter>()
                {
                    new SqlParameter("@SubjectID", subID),
                    new SqlParameter("@Mother_FirstName", spaData.Mother_FirstName ?? spaData.Mother_FirstName),
                    new SqlParameter("@Mother_MiddleName", spaData.Mother_MiddleName ?? spaData.Mother_MiddleName),
                    new SqlParameter("@Mother_LastName", spaData.Mother_LastName ?? spaData.Mother_LastName),
                    new SqlParameter("@Mother_GovIdType_ID", spaData.Mother_GovIdType_ID ),
                    new SqlParameter("@Mother_GovIdDetail", spaData.Mother_GovIdDetail ?? spaData.Mother_GovIdDetail),
                    new SqlParameter("@Mother_ContactNo", spaData.Mother_ContactNo ?? spaData.Mother_ContactNo),
                    new SqlParameter("@Father_FirstName", spaData.Father_FirstName ?? spaData.Father_FirstName),
                    new SqlParameter("@Father_MiddleName", spaData.Father_MiddleName ?? spaData.Father_MiddleName),
                    new SqlParameter("@Father_LastName", spaData.Father_LastName ?? spaData.Father_LastName),
                    new SqlParameter("@Father_GovIdType_ID", spaData.Father_GovIdType_ID ),
                    new SqlParameter("@Father_GovIdDetail", spaData.Father_GovIdDetail ?? spaData.Father_GovIdDetail),
                    new SqlParameter("@Father_ContactNo", spaData.Father_ContactNo ?? spaData.Father_ContactNo),
                    new SqlParameter("@Gaurdian_FirstName", spaData.Gaurdian_FirstName ?? spaData.Gaurdian_FirstName),
                    new SqlParameter("@Gaurdian_MiddleName", spaData.Gaurdian_MiddleName ?? spaData.Gaurdian_MiddleName),
                    new SqlParameter("@Gaurdian_LastName", spaData.Gaurdian_LastName ?? spaData.Gaurdian_LastName),
                    new SqlParameter("@Gaurdian_GovIdType_ID", spaData.Gaurdian_GovIdType_ID ),
                    new SqlParameter("@Gaurdian_GovIdDetail", spaData.Gaurdian_GovIdDetail ?? spaData.Gaurdian_GovIdDetail),
                    new SqlParameter("@Gaurdian_ContactNo", spaData.Gaurdian_ContactNo ?? spaData.Gaurdian_ContactNo),
                    new SqlParameter("@RBSKId", spaData.RBSKId ?? spaData.RBSKId),
                    new SqlParameter("@SchoolName", spaData.SchoolName ?? spaData.SchoolName),
                    new SqlParameter("@SchoolAddress1", spaData.SchoolAddress1 ?? spaData.SchoolAddress1),
                    new SqlParameter("@SchoolAddress2", spaData.SchoolAddress2 ?? spaData.SchoolAddress2),
                    new SqlParameter("@SchoolAddress3", spaData.SchoolAddress3 ?? spaData.SchoolAddress3),
                    new SqlParameter("@SchoolPincode", spaData.SchoolPincode ?? spaData.SchoolPincode),
                    new SqlParameter("@SchoolCity", spaData.SchoolCity ?? spaData.SchoolCity),
                    new SqlParameter("@SchoolState", spaData.SchoolState ?? spaData.SchoolState),
                    new SqlParameter("@Standard", spaData.Standard  ?? spaData.Standard),
                    new SqlParameter("@Section", spaData.Section ?? spaData.Section),
                    new SqlParameter("@RollNo", spaData.RollNo ?? spaData.RollNo),
                    new SqlParameter("@UpdatedBy", spaData.UpdatedBy),
                    retVal
                };
                UtilityDL.ExecuteNonQuery(stProc, pList);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<SubjectPrimaryDetail> RetrievePrimaryDetail(string uniqueSubjectId)
        {
            string stProc = FetchSubjectDetail;
            var pList = new List<SqlParameter>() { new SqlParameter("@UniqueSubjectID", uniqueSubjectId) };
            var allData = UtilityDL.FillData<SubjectPrimaryDetail>(stProc, pList);
            return allData;
        }

        public List<SubjectAddresDetail> RetrieveAddressDetail(string uniqueSubjectId)
        {
            string stProc = FetchSubjectDetail;
            var pList = new List<SqlParameter>() { new SqlParameter("@UniqueSubjectID", uniqueSubjectId) };
            var allData = UtilityDL.FillData<SubjectAddresDetail>(stProc, pList);
            return allData;
        }

        public List<SubjectPregnancyDetail> RetrievePregnancyDetail(string uniqueSubjectId)
        {
            string stProc = FetchSubjectDetail;
            var pList = new List<SqlParameter>() { new SqlParameter("@UniqueSubjectID", uniqueSubjectId) };
            var allData = UtilityDL.FillData<SubjectPregnancyDetail>(stProc, pList);
            return allData;
        }

        public List<SubjectParentDetail> RetrieveParentDetail(string uniqueSubjectId)
        {
            string stProc = FetchSubjectDetail;
            var pList = new List<SqlParameter>() { new SqlParameter("@UniqueSubjectID", uniqueSubjectId) };
            var allData = UtilityDL.FillData<SubjectParentDetail>(stProc, pList);
            return allData;
        }
    }
}
