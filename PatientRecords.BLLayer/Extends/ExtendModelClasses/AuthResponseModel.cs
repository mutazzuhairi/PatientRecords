using PatientRecords.BLLayer.EntityViews;

namespace PatientRecords.BLLayer.Extends.ExtendModelClasses
{
    public class AuthResponseModel
    {
        public bool IsAuthSuccessful { get; set; }
        public string ErrorMessage { get; set; }
        public string Token { get; set; }
        public UserView LoggedUser { get; set; }
    }
}
