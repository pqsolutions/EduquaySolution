using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EduquayAPI.DataLayer;
using EduquayAPI.DataLayer.ANMCHCPickandPack;
using EduquayAPI.DataLayer.ANMCHCShipment;
using EduquayAPI.DataLayer.ANMNotifications;
using EduquayAPI.DataLayer.CentralLab;
using EduquayAPI.DataLayer.CHCNotifications;
using EduquayAPI.DataLayer.CHCReceipt;
using EduquayAPI.DataLayer.DistrictCoordinator;
using EduquayAPI.DataLayer.MobileMaster;
using EduquayAPI.DataLayer.MobileSubject;
using EduquayAPI.DataLayer.MolecularLab;
using EduquayAPI.DataLayer.MTPObstetrician;
using EduquayAPI.DataLayer.Pathologist;
using EduquayAPI.DataLayer.PNDT;
using EduquayAPI.DataLayer.PNDTandMTPMaster;
using EduquayAPI.DataLayer.PNDTObstetrician;
using EduquayAPI.DataLayer.WebMaster;
using EduquayAPI.Services;
using EduquayAPI.Services.ANMCHCPickandPack;
using EduquayAPI.Services.ANMCHCShipment;
using EduquayAPI.Services.ANMNotifications;
using EduquayAPI.Services.CentralLab;
using EduquayAPI.Services.CHCNotifications;
using EduquayAPI.Services.CHCReceipt;
using EduquayAPI.Services.DistrictCoordinator;
using EduquayAPI.Services.MobileMaster;
using EduquayAPI.Services.MobileSubject;
using EduquayAPI.Services.MolecularLab;
using EduquayAPI.Services.MTPObstetrician;
using EduquayAPI.Services.Pathologist;
using EduquayAPI.Services.PNDT;
using EduquayAPI.Services.PNDTandMTPMaster;
using EduquayAPI.Services.PNDTObstetrician;
using EduquayAPI.Services.WebMaster;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EduquayAPI.Installers
{
    public class DIInstaller: IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IPatientDataFactory, PatientDataFactory>();
            services.AddScoped<IPatientService, PatientService>();
            services.AddScoped<IUserData, UserData>();
            services.AddScoped<IIdentityService, IdentityService>();
            services.AddScoped<IUserService, UserService>();

            services.AddScoped<IUsersData, UsersData>();
            services.AddScoped<IUserIdentityService, UserIdentityService>();
            services.AddScoped<IUsersService, UsersService>();

            services.AddScoped<IStateDataFactory, StateDataFactory>();
            services.AddScoped<IStateService, StateService>();

            services.AddScoped<ISubjectDataFactory, SubjectDataFactory>();
            services.AddScoped<ISubjectService, SubjectService>();

            services.AddScoped<IDistrictDataFactory, DistrictDataFactory>();
            services.AddScoped<IDistrictService, DistrictService>();

            services.AddScoped<IBlockDataFactory, BlockDataFactory>();
            services.AddScoped<IBlockService, BlockService>();

            services.AddScoped<IFacilityTypeDataFactory, FacilityTypeDataFactory>();
            services.AddScoped<IFacilityTypeService, FacilityTypeService>();

            services.AddScoped<IHNINDataFactory, HNINDataFactory>();
            services.AddScoped<IHNINService,HNINService>();

            services.AddScoped<ICHCDataFactory, CHCDataFactory>();
            services.AddScoped<ICHCService, CHCService>();

            services.AddScoped<IPHCDataFactory, PHCDataFactory>();
            services.AddScoped<IPHCService, PHCService>();

            services.AddScoped<ISCDataFactory, SCDataFactory>();
            services.AddScoped<ISCService, SCService>();

            services.AddScoped<IRIDataFactory, RIDataFactory>();
            services.AddScoped<IRIService, RIService>();

            services.AddScoped<IUserRoleDataFactory, UserRoleDataFactory>();
            services.AddScoped<IUserRoleService, UserRoleService>();

            services.AddScoped<IUserTypeDataFactory, UserTypeDataFactory>();
            services.AddScoped<IUserTypeService, UserTypeService>();

            services.AddScoped<IGovIDTypeDataFactory, GovIDTypeDataFactory>();
            services.AddScoped<IGovIDTypeService, GovIDTypeService>();

            services.AddScoped<ISubjectTypeDataFactory, SubjectTypeDataFactory>();
            services.AddScoped<ISubjectTypeService, SubjectTypeService>();

            services.AddScoped<IReligionDataFactory, ReligionDataFactory>();
            services.AddScoped<IReligionService, ReligionService>();

            services.AddScoped<ICasteDataFactory, CasteDataFactory>();
            services.AddScoped<ICasteService, CasteService>();

            services.AddScoped<ICommunityDataFactory, CommunityDataFactory>();
            services.AddScoped<ICommunityService, CommunityService>();

            services.AddScoped<IClinicalDiagnosisDataFactory, ClinicalDiagnosisDataFactory>();
            services.AddScoped<IClinicalDiagnosisService, ClinicalDiagnosisService>();

            services.AddScoped<ITestTypeDataFactory, TestTypeDataFactory>();
            services.AddScoped<ITestTypeService, TestTypeService>();

            services.AddScoped<IThresholdDataFactory, ThresholdDataFactory>();
            services.AddScoped<IThresholdService, ThresholdService>();

            services.AddScoped<ISampleCollectionDataFactory, SampleCollectionDataFactory>();
            services.AddScoped<ISampleCollectionService, SampleCollectionService>();

            services.AddScoped<IANMNotificationsDataFactory, ANMNotificationsDataFactory>();
            services.AddScoped<IANMNotificationsService, ANMNotificationsService>();

            services.AddScoped<IANMCHCPickandPackDataFactory, ANMCHCPickandPackDataFactory>();
            services.AddScoped<IANMCHCPickandPackService, ANMCHCPickandPackService>();

            services.AddScoped<IANMCHCShipmentDataFactory, ANMCHCShipmentDataFactory>();
            services.AddScoped<IANMCHCShipmentService, ANMCHCShipmentService>();

            services.AddScoped<ICHCReceiptDataFactory, CHCReceiptDataFactory>();
            services.AddScoped<ICHCReceiptService, CHCReceiptService>();

            services.AddScoped<ICentralLabDataFactory, CentralLabDataFactory>();
            services.AddScoped<ICentralLabService, CentralLabService>();

            services.AddScoped<IMobileMasterDataFactory, MobileMasterDataFactory>();
            services.AddScoped<IMobileMasterService, MobileMasterService>();

            services.AddScoped<IMobileSubjectDataFactory, MobileSubjectDataFactory>();
            services.AddScoped<IMobileSubjectService, MobileSubjectService>();

            services.AddScoped<IWebMasterDataFactory, WebMasterDataFactory>();
            services.AddScoped<IWebMasterService, WebMasterService>();

            services.AddScoped<ICHCNotificationsDataFactory, CHCNotificationsDataFactory>();
            services.AddScoped<ICHCNotificationsService, CHCNotificationsService>();

            services.AddScoped<IPathologistDataFactory, PathologistDataFactory>();
            services.AddScoped<IPathologistService, PathologistService>();

            services.AddScoped<IMolecularLabDataFactory, MolecularLabDataFactory>();
            services.AddScoped<IMolecularLabService, MolecularLabService>();

            services.AddScoped<IPNDTDataFactory, PNDTDataFactory>();
            services.AddScoped<IPNDTService, PNDTService>();

            services.AddScoped<IPMMasterDataFactory, PMMasterDataFactory>();
            services.AddScoped<IPMMasterService, PMMasterService>();

            services.AddScoped<IPNDTObstetricianDataFactory, PNDTObstetricianDataFactory>();
            services.AddScoped<IPNDTObstetricianService, PNDTObstetricianService>();

            services.AddScoped<IMTPObstetricianDataFactory, MTPObstetricianDataFactory>();
            services.AddScoped<IMTPObstetricianService, MTPObstetricianService>();

            services.AddScoped<IDCDataFactory, DCDataFactory>();
            services.AddScoped<IDCService, DCService>();

            services.AddSingleton<DbConnect>();
        }
    }
}
