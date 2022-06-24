using System.ComponentModel.DataAnnotations;

namespace XtremeWasmApp.Models
{
    public class RegisterModel
    {
        private string _email { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email"), RegularExpression(".+@(g|G)mail.com", ErrorMessage = "Enter a gmail ID")]
        public string Email {
            get => _email;
            set => _email = value.ToLowerInvariant();
        }

        [Required(ErrorMessage = "Phone Number is required"), DataType(DataType.PhoneNumber, ErrorMessage = "Not a valid phone number")]
        public string Phone { get; set; }

        [Required, RegularExpression("[0-9]{6}", ErrorMessage = "Password must be 6 digit long")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        public string Code { get; set; }
    }
}