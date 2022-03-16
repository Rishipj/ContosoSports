using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.AzureADB2C.UI;
using Microsoft.Extensions.Configuration;

namespace Contoso.Apps.SportsLeague.Web.Controllers
{
    public class AccountController : Controller
    {
        private string _editProfilePolicyId;

        public AccountController(IConfiguration configuration)
        {
            _editProfilePolicyId = configuration.GetValue<string>("AzureADB2C:EditProfilePolicyId");
        }

        public ActionResult SignIn()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return Challenge(new AuthenticationProperties() { RedirectUri = "/" }, AzureADB2CDefaults.AuthenticationScheme);
            }
            return RedirectToAction("Index", "Home");
        }

        public ActionResult SignUp()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return Challenge(new AuthenticationProperties() { RedirectUri = "/" }, AzureADB2CDefaults.AuthenticationScheme);
            }
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Profile()
        {
            if (User.Identity.IsAuthenticated)
            {
                var properties = new AuthenticationProperties() { RedirectUri = "/" };
                properties.Items[AzureADB2CDefaults.PolicyKey] = _editProfilePolicyId;
                return Challenge(
                    properties,
                    AzureADB2CDefaults.AuthenticationScheme);
            }
            return RedirectToAction("Index", "Home");
        }

        public ActionResult SignOut()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            string redirectUri = Url.Action("Index", "Home", null, Request.Scheme);
            var properties = new AuthenticationProperties
            {
                RedirectUri = redirectUri
            };
            return SignOut(properties, AzureADB2CDefaults.CookieScheme, AzureADB2CDefaults.OpenIdScheme);
        }
    }
}
