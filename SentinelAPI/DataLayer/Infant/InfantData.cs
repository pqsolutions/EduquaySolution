using SentinelAPI.Contracts.V1.Request.Infant;
using SentinelAPI.Models;
using SentinelAPI.Models.Infant;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace SentinelAPI.DataLayer.Infant
{
    public class InfantData : IInfantData
    {
        private const string AddInfantsDetail = "SPC_AddInfantDetail";
        private const string FetchMotherDetail = "SPC_FetchMotherInfantDetail";

        public InfantData()
        {

        }
        public string AddInfantDetail(AddInfantRequest irData)
        {
            InfantRegistration infantRegDetails = InfantDetail(irData);
            if (infantRegDetails != null)
            {
                return $"{infantRegDetails.responseMsg} successfully. The Unique ID is: {infantRegDetails.infantSubjectId}";
            }
            else
            {
                return $"Unable to register infant details for {irData.firstName}";
            }
        }

        public InfantRegistration InfantDetail(AddInfantRequest irData)
        {
            try
            {
                string stProc = AddInfantsDetail;
                var pList = new List<SqlParameter>
                {
                    new SqlParameter("@MothersID", irData.mothersId),
                    new SqlParameter("@DistrictId", irData.districtId),
                    new SqlParameter("@HospitalId", irData.hospitalId),
                    new SqlParameter("@UniqueSubjectId", irData.uniqueSubjectId.ToCheckNull()),
                    new SqlParameter("@TypeofInfant", irData.typeofInfant),
                    new SqlParameter("@SubTitle", irData.subTitle.ToCheckNull()),
                    new SqlParameter("@FirstName", irData.firstName ?? irData.firstName),
                    new SqlParameter("@MiddleName", irData.middleName.ToCheckNull()),
                    new SqlParameter("@LastName", irData.lastName.ToCheckNull()),
                    new SqlParameter("@Gender", irData.gender ?? irData.gender),
                    new SqlParameter("@InfantRCHID", irData.infantRCHId.ToCheckNull()),
                    new SqlParameter("@DateofDelivery", irData.dateOfDelivery ?? irData.dateOfDelivery),
                    new SqlParameter("@TimeofDelivery", irData.timeOfDelivery ?? irData.timeOfDelivery),
                    new SqlParameter("@StatusofBirth", irData.statusOfBirth),
                    new SqlParameter("@DateofRegister", irData.dateOfRegister ?? irData.dateOfRegister),
                    new SqlParameter("@CreatedBy", irData.createdBy),
                    new SqlParameter("@Comments", irData.comments.ToCheckNull()),

                };
                var motherDet = UtilityDL.FillEntity<InfantRegistration>(stProc, pList);
                return motherDet;

            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public GetMotherDetails RetrieveMother(GetMotherRequest mData)
        {
            string stProc = FetchMotherDetail;
            var pList = new List<SqlParameter>()
            {
                new SqlParameter("@MothersRchSubHospID", mData.motherUniqueSubjectId ?? mData.motherUniqueSubjectId),
            };
            var motherdetail = UtilityDL.FillData<InfantMother>(stProc, pList);
            var infantDetail = UtilityDL.FillData<MotherInfant>(stProc, pList);
            var mother = new GetMotherDetails();
            mother.MotherDetail = motherdetail;
            mother.InfantsDetail = infantDetail;
            return mother;
        }
    }
}
