using System.ComponentModel.DataAnnotations;
namespace StackOverflowClone.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [EmailAddress(ErrorMessage = "Invalid Email")]
        public string Email { get; set; }
        [Required]

        public string Password { get; set; }
        [Required]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
        [Required]

        public string Name { get; set; }
        [Required]

        public string Mobile { get; set; }

    }
}
