using System.ComponentModel.DataAnnotations;

namespace Auditor.Bussness.Models
{
    public class ForgotPasswordViewModel
    {
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }


        [Display(Name = "User Name")]
        public string UserName { get; set; }
    }
}