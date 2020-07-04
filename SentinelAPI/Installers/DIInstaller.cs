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

            services.AddScoped<ILoadMasterDataFactory, LoadMasterDataFactory>();
            services.AddScoped<ILoadMasterService, LoadMasterService>();

        }
    }
}
