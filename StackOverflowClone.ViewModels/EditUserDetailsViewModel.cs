using System.ComponentModel.DataAnnotations;

namespace StackOverflowClone.ViewModels
{
    public class EditUserDetailsViewModel

    {
        public int UserID { get; set; }
        [Required]
        [EmailAddress(ErrorMessage = "Invalid Email")]
        public string Email { get; set; }
        [Required]
        [RegularExpression(@"/^[a-zA-Z]*$/")]

        public string Name { get; set; }
        [Required]

        public string Mobile { get; set; }
    }
}
