 
namespace PatientRecords.BLLayer.BLUtilities.SystemConstants
{
    public class SystemConstatnts
    {

        public class ConnectionString
        {
            public const string PatientRecord = "PatientRecordConnectionString";
        }


        public class ValidationMessage
        {
            public const string EmailNotValid = "This email not valid.";
            public const string UserNameAlreadyExist = "This UserName already exist.";
            public const string EmailAlreadyExist = "This email already exist.";
            public const string OfficialIdAlreadyExist = "This official id already exist.";
            public const string AccountLockout = "This accout is Lockout";
        }

        public class AppSettings
        {
            public const string JwtSettings = "JwtSettings";
            public const string SecurityKey = "SecurityKey";
            public const string ExpiryInMinutes = "ExpiryInMinutes";
        }

        public class SwaggerProperites
        {
            public const string SwaggerRoute = "/api/swagger/v1/swagger.json";
            public const string SwaggerTitle = "PatientRecord.Web";
            public const string SwaggesrName = "PatientRecord.Web v1";
            public const string SwaggerVersion = "v1";
            public const string SwaggerRouteTemplate = "api/swagger/{documentname}/swagger.json";
            public const string SwaggerPath = "api/swagger";


        }

    }
}
