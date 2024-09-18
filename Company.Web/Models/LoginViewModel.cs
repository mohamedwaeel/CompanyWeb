using System.ComponentModel.DataAnnotations;

namespace Company.Web.Models
{
    public class LoginViewModel
    {
        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "email Is Required")]
        [EmailAddress(ErrorMessage = "Invalid email")]
        public string Email { get; set; }
        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "password Is Required")]

        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}
