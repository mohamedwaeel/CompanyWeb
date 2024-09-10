using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;

namespace Company.Web.Models
{
    public class SignUpViewModel
    {
        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "First Name Is Required")]
        public string FirstName {  get; set; }
        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "last Name Is Required")]
        public string LastName { get; set; }
        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "email Is Required")]
        [EmailAddress(ErrorMessage = "Invalid email")]
        public string Email { get; set; }
        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "password Is Required")]
        [RegularExpression(@"^(?=.*[A-Z])(?=.*[a-z])(?=.*\d)(?=.*[\W_])(?=([\S\s]*.){2,}).{8,}$",
        ErrorMessage = "Password must have at least 8 characters, including 1 uppercase letter, 1 lowercase letter, 1 digit, 1 special character, and at least 2 unique characters.")]

        public string Password { get; set; }
        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "Confirm Password Is Required")]
        [Compare(nameof(Password),ErrorMessage ="confirm password doesnt match")]
        public string ConfirmPassword {  get; set; }
        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "Required to agree")]

        public bool IsAgree { get; set; }   
    }
}
