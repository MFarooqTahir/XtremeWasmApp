using System.ComponentModel.DataAnnotations;

namespace XtremeWasmApp.Models
{
    public class RegisterModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email"), RegularExpression(".+@(g|G)mail.com", ErrorMessage = "Enter a gmail ID")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Phone Number is required"), DataType(DataType.PhoneNumber, ErrorMessage = "Not a valid phone number")]
        public string Phone { get; set; }

        [Required, RegularExpression(@"\w{6}", ErrorMessage = "Password must be atleast 6 characters long")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }
}