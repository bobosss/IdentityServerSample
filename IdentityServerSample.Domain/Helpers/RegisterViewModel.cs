using System.ComponentModel.DataAnnotations;
using Auditor.Business.Models;

namespace Auditor.Business.Models
{
    /// <summary>
    /// Wrapper class for Registering Users
    /// </summary>
    /// <remarks>
    /// Wraps a <see cref="RegistrationInfo">RegistrationInfo</see> class 
    /// and a <see cref="Person">Person</see> class to send to back end for registration process.
    /// </remarks>
    public class RegisterViewModel
    {
        protected RegistrationInfo RegistrationInfo = new RegistrationInfo();
        protected Person Person = new Person();

        public string UserName
        {
            get { return RegistrationInfo.UserName; }
            set { RegistrationInfo.UserName = value; }
        }

        public string Email
        {
            get { return RegistrationInfo.Email; }
            set { RegistrationInfo.Email = value; }
        }

        public string Password
        {
            get { return RegistrationInfo.Password; }
            set { RegistrationInfo.Password = value; }
        }

        public string ConfirmPassword { get; set; }

        public int Id { get; set; }

        public string FirstName
        {
            get { return Person.FirstName; }
            set { Person.FirstName = value; }
        }

        public string LastName
        {
            get { return Person.LastName; }
            set { Person.LastName = value; }
        }

        public string MiddleName
        {
            get { return Person.MiddleName; }
            set { Person.MiddleName = value; }
        }

        public string Gender
        {
            get { return Person.Gender; }
            set { Person.Gender = value; }
        }
        public string IdentityCardNumber
        {
            get { return Person.IdentityCardNumber; }
            set { Person.IdentityCardNumber = value; }
        }

        /*public string TaxCode
        {
            get { return Person.TaxCode; }
            set { Person.TaxCode = value; }
        }*/

        public string Title
        {
            get { return Person.Title; }
            set { Person.Title = value; }
        }

        public string Nationality
        {
            get { return Person.Nationality; }
            set { Person.Nationality = value; }
        }

        public bool? DontAddUserRole
        {
            get { return RegistrationInfo.DontAddUserRole; }
            set { RegistrationInfo.DontAddUserRole = value; }
        }
        public string RoleToAdd
        {
            get { return RegistrationInfo.RoleToAdd; }
            set { RegistrationInfo.RoleToAdd = value; }
        }

        public string WhereYouFindUs
        {
            get { return RegistrationInfo.WhereYouFindUs; }
            set { RegistrationInfo.WhereYouFindUs = value; }
        }

        public string WhereYouFindUsFreeText
        {
            get { return RegistrationInfo.WhereYouFindUsFreeText; }
            set { RegistrationInfo.WhereYouFindUsFreeText = value; }
        }

        public bool? OnlyMail
        {
            get { return RegistrationInfo.OnlyMail; }
            set { RegistrationInfo.OnlyMail = value; }
        }

        public bool? ChangeEmail
        {
            get { return RegistrationInfo.ChangeEmail; }
            set { RegistrationInfo.ChangeEmail = value; }
        }


        public string RPFstaffName
        {
            get { return RegistrationInfo.RPFstaffName; }
            set { RegistrationInfo.RPFstaffName = value; }
        }

        public string RPFstaffmail
        {
            get { return RegistrationInfo.RPFstaffmail; }
            set { RegistrationInfo.RPFstaffmail = value; }
        }

        public string ExtraSection
        {
            get { return RegistrationInfo.ExtraSection; }
            set { RegistrationInfo.ExtraSection = value; }
        }
    }
}
