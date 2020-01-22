using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using BlazorProjekt.Service.DataTransferObjects;
using BlazorProjekt.Service.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BlazorProjekt.Web
{

    [AllowAnonymous]
    public class LoginModel : PageModel
    {
        private readonly ICredentialService _credentialService;
        public string ReturnUrl { get; set; }

        public LoginModel(ICredentialService credentialService)
        {
            _credentialService = credentialService;
        }
        public async Task<IActionResult> OnGetAsync(string paramUsername, string paramPassword)
        {
            string returnUrl = Url.Content("~/");
            try
            {
                // Clear the existing external cookie
                await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            }
            catch { }

            OwnerDTO owner = await _credentialService.Login(paramUsername, paramPassword);

            if (owner == null)
            {
                return LocalRedirect("~/Account/Login");
            }
            List<Claim> claims = new List<Claim>() {
                new Claim(ClaimTypes.Name, paramUsername),
                new Claim(ClaimTypes.GivenName,  owner.Name),
                new Claim(ClaimTypes.PrimarySid, owner.OwnerId.ToString())
            };

            if (owner.Admin)
            {
                claims.Add(new Claim(ClaimTypes.Role, "Administrator"));
            }


            ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            AuthenticationProperties authProperties = new AuthenticationProperties
            {
                IsPersistent = true,
                RedirectUri = Request.Host.Value
            };

            try
            {
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProperties);
            }
            catch (Exception ex)
            {
                string error = ex.Message;
            }
            return LocalRedirect(returnUrl == "~/Account/Login" ? "~/Index" : returnUrl);

        }
    }
}