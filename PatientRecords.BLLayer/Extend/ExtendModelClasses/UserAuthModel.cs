using System.ComponentModel.DataAnnotations;
 

namespace PatientRecords.BLLayer.Extend.ExtendModelClasses
{
    public class UserAuthModel
    {
        [Required(ErrorMessage = "Email is required.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password is required.")]
        public string Password { get; set; }
    }
}
