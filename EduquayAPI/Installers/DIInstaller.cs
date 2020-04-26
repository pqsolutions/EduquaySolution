using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EduquayAPI.DataLayer;
using EduquayAPI.Services;
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

            services.AddScoped<IANMShipmentDataFactory, ANMShipmentDataFactory>();
            services.AddScoped<IANMShipmentService , ANMShipmentService>();

            services.AddSingleton<DbConnect>();
        }
    }
}
