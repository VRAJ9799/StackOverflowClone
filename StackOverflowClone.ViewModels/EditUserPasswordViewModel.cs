using System.ComponentModel.DataAnnotations;

namespace StackOverflowClone.ViewModels
{
    public class EditUserPasswordViewModel
    {
        [Required]

        public int UserID { get; set; }
        [Required]
        [EmailAddress(ErrorMessage = "Invalid Email")]

        public string Email { get; set; }
        [Required]

        public string Password { get; set; }
        [Required]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
    }
}
