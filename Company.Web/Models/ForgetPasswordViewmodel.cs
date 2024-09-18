using System.ComponentModel.DataAnnotations;

namespace Company.Web.Models
{
    public class ForgetPasswordViewmodel
    {

        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "email Is Required")]
        [EmailAddress(ErrorMessage = "Invalid email")]
        public string Email { get; set; }
    }
}
