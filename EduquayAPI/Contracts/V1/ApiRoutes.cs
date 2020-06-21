using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Contracts.V1
{
    public static class ApiRoutes
    {
        public const string Root = "api";
        public const string Version = "v1";
        public const string Base = Root + "/" + Version;

        public static class Posts
        {
            public const string AddPatient = "Add";
        }
        public static class Gets
        {
            public const string GetPatient = "Patient{pId}";
            public const string GetPatients = "Patients";
        }

        public static class Identity
        {
            public const string Register = "Register";
            public const string Login = "Login";
            public const string User = "LoggedUser";

        }
     }
}
