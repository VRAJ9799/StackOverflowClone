using System.ComponentModel.DataAnnotations;

namespace StackOverflowClone.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        [EmailAddress(ErrorMessage = "Invalid Email")]
        public string Email { get; set; }
        [Required]

        public string Password { get; set; }
    }
}
