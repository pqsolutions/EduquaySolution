using EduquayAPI.Contracts.V1.Request.Mobile;
using EduquayAPI.Contracts.V1.Response.MobileMster;
using EduquayAPI.DataLayer.MobileMaster;
using EduquayAPI.Models.LoadMasters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Services.MobileMaster
{
    public class MobileMasterService : IMobileMasterService
    {
        private readonly IMobileMasterData _mobileMasterData;
        public MobileMasterService(IMobileMasterDataFactory mobileMasterDataFactory)
        {
            _mobileMasterData = new MobileMasterDataFactory().Create();
        }
        public async Task<MobileMasterResponse> RetrieveMasters(MobileRetrieveRequest mrData)
        {
            MobileMasterResponse mmResponse = new MobileMasterResponse();
            try
            {
                var checkdevice = _mobileMasterData.CheckDevice(mrData.userId, mrData.deviceId);
                if (checkdevice.valid == false)
                {
                    mmResponse.Valid = false;
                    mmResponse.Status = "false";
                    mmResponse.Message = checkdevice.msg;
                }
                else
                {
                    var allStates = _mobileMasterData.RetrieveState();
                    var district = _mobileMasterData.RetrieveDistrict(mrData.userId);
                    var chc = _mobileMasterData.RetrieveCHC(mrData.userId);
                    var phc = _mobileMasterData.RetrievePHC(mrData.userId);
                    var sc = _mobileMasterData.RetrieveSC(mrData.userId);
                    var ri = _mobileMasterData.RetrieveRI(mrData.userId);
                    var allGovIDType = _mobileMasterData.RetrieveGovIDType();
                    var allReligion = _mobileMasterData.RetrieveReligion();
                    var allCastes = _mobileMasterData.RetrieveCaste();
                    var allCommunity = _mobileMasterData.RetrieveCommunity();
                    var allConstant = _mobileMasterData.RetrieveConstantValues();
                    var allFollowUp = _mobileMasterData.RetrieveFollowups();
                    mmResponse.Valid = true;
                    mmResponse.Status = "true";
                    mmResponse.Message = string.Empty;
                    mmResponse.States = allStates;
                    mmResponse.Districts = district;
                    mmResponse.CHC = chc;
                    mmResponse.PHC = phc;
                    mmResponse.SC = sc;
                    mmResponse.RI = ri;
                    mmResponse.GovIdType = allGovIDType;
                    mmResponse.Religion = allReligion;
                    mmResponse.Caste = allCastes;
                    mmResponse.Community = allCommunity;
                    mmResponse.ConstantValues = allConstant;
                    mmResponse.FollowUpStatus = allFollowUp;
                }
            }
            catch (Exception e)
            {
                mmResponse.Valid = true;
                mmResponse.Status = "false";
                mmResponse.Message = e.Message;
            }
            return mmResponse;
        }
       
        public List<LoadCommunity> RetrieveCommunity(int id)
        {
            var community = _mobileMasterData.RetrieveCommunity(id);
            return community;
        }
    }
}
