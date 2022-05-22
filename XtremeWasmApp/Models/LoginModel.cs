using System.ComponentModel.DataAnnotations;

namespace XtremeWasmApp.Models
{
    public class LoginModel
    {
        [Required]
        public string Email { get; set; }

        [Required, RegularExpression(".{6,}", ErrorMessage = "Password must be atleast 6 characters long")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}