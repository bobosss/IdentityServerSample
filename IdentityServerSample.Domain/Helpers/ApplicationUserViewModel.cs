using System.Runtime.Serialization;

namespace Auditor.Business.Models
{
    /// <summary>
    /// DTO class for  <see cref="Auditor.Security.Common.Models.ApplicationUser">ApplicationUser</see>
    /// </summary>
    /// <remarks>
    /// DTO class that can be serialized and transfered through wcf channel 
    /// </remarks>

    public class ApplicationUserViewModel
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string Gender { get; set; }
        public string IdentityCardNumber { get; set; }
        public string TaxCode { get; set; }
        public string Title { get; set; }
        public string Nationality { get; set; }
        public int Id { get; set; }
        public bool EmailConfirmed { get; set; }
        public int AccessFailedCount { get; set; }
        public bool? DontAddUserRole { get; set; }
        public string RoleToAdd { get; set; }
        public string WhereYouFindUs { get; set; }
        public string WhereYouFindUsFreeText { get; set; }

    }
}
