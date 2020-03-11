using System.ComponentModel.DataAnnotations;

namespace Auditor.Business.Models
{
    public class RegistrationInfo
    {
        public string UserName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }
        public bool? DontAddUserRole { get; set; }

        public string RoleToAdd { get; set; }

        public string WhereYouFindUs { get; set; }

        public string WhereYouFindUsFreeText { get; set; }

        public bool? OnlyMail { get; set; }

        public bool? ChangeEmail { get; set; }

        public string RPFProposalId { get; set; }

        public string RPFstaffName { get; set; }

        public string RPFstaffmail { get; set; }

        public string ExtraSection { get; set; }

    }
}
