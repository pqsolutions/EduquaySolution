﻿using EduquayAPI.Contracts.V1.Request;
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

                SubjectPrimaryDetail subPrimary = subjectPrimary(subRegData.subjectPrimaryRequest);
                if (subPrimary != null)
                {
                    if (subPrimary.id > 0)
                    {
                        var subID = subPrimary.id;
                        var uniqueSubID = subPrimary.uniqueSubjectId;
                        SubjectAddress(subRegData.subjectAddressRequest, subID);
                        SubjectPregnancy(subRegData.subjectPregnancyRequest, subID);
                        SubjectParent(subRegData.subjectParentRequest, subID);
                        return "Unique SubjectID generated successfully. The Unique ID is: " + uniqueSubID;
                    }
                    else
                    {
                        return $"Failed to add subject registration for {subRegData.subjectPrimaryRequest.firstName + " " + subRegData.subjectPrimaryRequest.lastName}";
                    }
                }
                else
                {
                    return $"Unable to Register subject for {subRegData.subjectPrimaryRequest.firstName + " " + subRegData.subjectPrimaryRequest.lastName}";
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

        public void SubjectPregnancy(SubjectPregnancyDetailRequest spData, int subID)
        {

            try
            {
                var stProc = AddSubjectPregnancyDetail;
                var retVal = new SqlParameter("@SCOPE_OUTPUT", 1) { Direction = ParameterDirection.Output };
                var pList = new List<SqlParameter>()
                {
                    new SqlParameter("@SubjectID", subID),
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

        public void SubjectParent(SubjectParentDetailRequest spaData, int subID)
        {

            try
            {
                var stProc = AddSubjectParentDetail;
                var retVal = new SqlParameter("@SCOPE_OUTPUT", 1) { Direction = ParameterDirection.Output };
                var pList = new List<SqlParameter>()
                {
                    new SqlParameter("@SubjectID", subID),
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
