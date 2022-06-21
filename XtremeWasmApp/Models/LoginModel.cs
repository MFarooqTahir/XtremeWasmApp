using System.ComponentModel.DataAnnotations;

namespace XtremeWasmApp.Models
{
    public class LoginModel
    {
        [Required]
        public string Email { get; set; }

        [Required, RegularExpression("[0-9]{6}", ErrorMessage = "Password must be 6 digit long")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}