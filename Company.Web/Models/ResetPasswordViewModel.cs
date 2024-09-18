using System.ComponentModel.DataAnnotations;

namespace Company.Web.Models
{
    public class ResetPasswordViewModel
    {
        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "password Is Required")]
        [RegularExpression(@"^(?=.*[A-Z])(?=.*[a-z])(?=.*\d)(?=.*[\W_])(?=([\S\s]*.){2,}).{8,}$",
     ErrorMessage = "Password must have at least 8 characters, including 1 uppercase letter, 1 lowercase letter, 1 digit, 1 special character, and at least 2 unique characters.")]

        public string Password { get; set; }
        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "Confirm Password Is Required")]
        [Compare(nameof(Password), ErrorMessage = "confirm password doesnt match")]
        public string ConfirmPassword { get; set; }

        public string Email {  get; set; }
        public string Token {  get; set; }
    }
}
