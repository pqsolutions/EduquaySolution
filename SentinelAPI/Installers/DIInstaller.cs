using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SentinelAPI.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using SentinelAPI.DataLayer.Master;
using SentinelAPI.Services.Login;
using SentinelAPI.Services.Master.User;
using SentinelAPI.Services.Mother;
using SentinelAPI.DataLayer.Mother;
using SentinelAPI.DataLayer.LoadMaster;
using SentinelAPI.Services.Master.LoadMaster;
using SentinelAPI.DataLayer.SampleCollection;
using SentinelAPI.Services.SampleCollection;
using SentinelAPI.DataLayer.PickandPack;
using SentinelAPI.Services.PickandPack;
using SentinelAPI.DataLayer.Shipments;
using SentinelAPI.Services.Shipments;
using SentinelAPI.DataLayer.Baby;
using SentinelAPI.Services.Baby;

namespace SentinelAPI.Installers
{
    public class DIInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<DbConnect>();

            services.AddScoped<IUserData, UserData>();
            services.AddScoped<ILoginUserService, LoginUserService>();
            services.AddScoped<IUserService, UserService>();

            services.AddScoped<IMotherDataFactory, MotherDataFactory>();
            services.AddScoped<IMotherService, MotherService>();

            services.AddScoped<IBabyDataFactory, BabyDataFactory>();
            services.AddScoped<IBabyService, BabyService>();

            services.AddScoped<ILoadMasterDataFactory, LoadMasterDataFactory>();
            services.AddScoped<ILoadMasterService, LoadMasterService>();

            services.AddScoped<ISampleCollectionDataFactory, SampleCollectionDataFactory>();
            services.AddScoped<ISampleCollectionService, SampleCollectionService>();

            services.AddScoped<IPickandPackDataFactory, PickandPackDataFactory>();
            services.AddScoped<IPickandPackService, PickandPackService>();

            services.AddScoped<IShipmentDataFactory, ShipmentDataFactory>();
            services.AddScoped<IShipmentService, ShipmentService>();

        }
    }
}
