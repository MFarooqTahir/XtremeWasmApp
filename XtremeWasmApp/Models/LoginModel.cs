using System.ComponentModel.DataAnnotations;

namespace XtremeWasmApp.Models
{
    public class LoginModel
    {
        [Required]
        public string Email { get; set; }

        [Required, RegularExpression("[0-9]{6}", ErrorMessage = "Enter a valid 6 digit pin")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}