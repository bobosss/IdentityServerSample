using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auditor.Common
{
    /// <summary>
    /// Helper class to provide Identity Server Constants.
    /// </summary>
    public static class Constants
    {
        public static string BaseAddress = ConfigurationManager.AppSettings["IdentityServerBaseAddress"];
        public static string AuthorizeEndpoint = BaseAddress + "/connect/authorize";
        public static string LogoutEndpoint = BaseAddress + "/connect/endsession";
        public static string TokenEndpoint = BaseAddress + "/connect/token";
        public static string UserInfoEndpoint = BaseAddress + "/connect/userinfo";
        public static string IdentityTokenValidationEndpoint = BaseAddress + "/connect/identitytokenvalidation";
        public static string TokenRevocationEndpoint = BaseAddress + "/connect/revocation";

        public static string OpenIdConnectRedirectUri =
            ConfigurationManager.AppSettings["OpenIdConnectAuthenticationOptions:RedirectUri"];

        public static string AuditorClientId = ConfigurationManager.AppSettings["auditor_client_id"];
        public static string AuditorClientName = ConfigurationManager.AppSettings["auditor_client_name"];
        public static string AuditorClientSecret = ConfigurationManager.AppSettings["auditor_client_secret"];
        public static string LoginCallback = ConfigurationManager.AppSettings["login_callback"];
    }

    public static class SmtpSettings
    {
        public static string SmtpHost = ConfigurationManager.AppSettings["smtpHost"];
        public static int SmtpPort = Convert.ToInt32(ConfigurationManager.AppSettings["smtpPort"]);
        public static bool EnableSsl = Convert.ToBoolean(ConfigurationManager.AppSettings["enableSsl"]);
        public static string SmtpUser = ConfigurationManager.AppSettings["smtpUser"];
        public static string SmtpPassword = ConfigurationManager.AppSettings["smtpUserPassword"];
        public static string EmailFrom = ConfigurationManager.AppSettings["emailFrom"];
        public static string EmailFromDisplayName = ConfigurationManager.AppSettings["emailFromDisplayName"];
    }

    public static class ApplicationBehaviorSettings
    {
        public static string ForceEmailConfirmation = ConfigurationManager.AppSettings["forceAccountEmailConfirmation"];
        public static string MonitorEmail = "monitor@allweb.gr";
        public static string LogmailEmail = "logmail@allweb.gr";
        public static string HelpDeskEmail = "help_desk@allweb.gr";
        public static string HelpDeskLink = "https://iris.research.org.cy/#/helpdesk";

    }
}
