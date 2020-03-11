using System.ComponentModel.DataAnnotations;

namespace Auditor.Business.Models
{
    public class ResetPasswordViewModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        [RegularExpression(
            @"^(?=.*[a-z])(?=.*\d)(?=.*[!@#$%^&*()[\]{}<>,\.;:+-/~`'=_\""\?\|])[a-zA-Z\d!@$%^&*()[\]{}<>,\.;:\+-/~`'=_#\""\?\|]{6,16}$",
            ErrorMessage =
                "This value does not contain a digit or special or lowercase character and must be between 6 and 16 characters"
            )]
        [StringLength(16, MinimumLength = 6, ErrorMessage = "Password must be between 6 and 16 characters.")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage = "The Password and Confirm Password do not match.")]
        public string ConfirmPassword { get; set; }

        public string UserId { get; set; }

        public string Code { get; set; }
    }
}