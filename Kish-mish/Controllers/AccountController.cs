﻿
using Domain.Entities;
using Kish_mish.Helpers;
using Kish_mish.ViewModels.Account;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MimeKit;
using MimeKit.Text;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Kish_mish.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        //private readonly RoleManager<IdentityRole> _roleManager;
        private readonly AppSettings _appSettings;

        public AccountController(UserManager<AppUser> userManager,
                                SignInManager<AppUser> signInManager,
        //RoleManager<IdentityRole> roleManager,
        IOptions<AppSettings> appSettings)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            //_roleManager = roleManager;
            _appSettings = appSettings.Value;
        }


        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterVM request)
        {
            if (!ModelState.IsValid) return View(request);

            AppUser newUser = new()
            {
                FullName = request.FullName,
                UserName = request.UserName,
                Email = request.Email,
            };

            var result = await _userManager.CreateAsync(newUser, request.Password);

            if (!result.Succeeded)
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, item.Description);
                }
                return View(request);
            }

            //await _userManager.AddToRoleAsync(newUser, nameof(Roles.Member));


            string token = await _userManager.GenerateEmailConfirmationTokenAsync(newUser);
            string url = Url.Action(nameof(ConfirmEmail), "Account", new { userId = newUser.Id, token }, Request.Scheme, Request.Host.ToString());

            string html = string.Empty;

            using (StreamReader reader = new("wwwroot/assets/templates/emailconfirmation.html"))
            {
                html = await reader.ReadToEndAsync();
            }

            html = html.Replace("{link}", url);
            html = html.Replace("{Username}", newUser.FullName);

            string subject = "Email confirmation";

            SendEmail(newUser.Email, subject, html);

            return RedirectToAction(nameof(VerifyEmail));
        }

    
        [HttpGet]
        public IActionResult VerifyEmail()
        {
            return View();
        }



        [HttpGet]
        public async Task<IActionResult> ConfirmEmail(string userId, string token)
        {
            var user = await _userManager.FindByIdAsync(userId);
            await _userManager.ConfirmEmailAsync(user, token);
            return RedirectToAction(nameof(SignIn));
        }


        public void SendEmail(string to, string subject, string html, string from = null)
        {
            // create message
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse(from ?? _appSettings.From));
            email.To.Add(MailboxAddress.Parse(to));
            email.Subject = subject;
            email.Body = new TextPart(TextFormat.Html) { Text = html };
            // send email
            using var smtp = new SmtpClient();
            smtp.Connect(_appSettings.Server, _appSettings.Port, SecureSocketOptions.StartTls);
            smtp.Authenticate(_appSettings.Username, _appSettings.Password);
            smtp.Send(email);
            smtp.Disconnect(true);

        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginVM request)
        {
            if (!ModelState.IsValid) return View();

            AppUser existUser = await _userManager.FindByEmailAsync(request.EmailOrUsername);

            if (existUser is null)
            {
                existUser = await _userManager.FindByNameAsync(request.EmailOrUsername);
            }

            if (existUser is null)
            {
                ModelState.AddModelError(string.Empty, "Email or password is wrong!");
                return View();
            }

            var result = await _signInManager.PasswordSignInAsync(existUser, request.Password, false, false);

            if (!result.Succeeded)
            {
                ModelState.AddModelError(string.Empty, "Login failed");
                return View(request);
            }

            //await _signInManager.SignInAsync(existUser, false);

            return RedirectToAction("Index", "Home");

        }

      

            [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        //    [HttpGet]
        //    public async Task<IActionResult> CreateRoles()
        //    {
        //        foreach (var role in Enum.GetValues(typeof(Roles)))
        //        {
        //            if (!await _roleManager.RoleExistsAsync(nameof(role)))
        //            {
        //                await _roleManager.CreateAsync(new IdentityRole { Name = role.ToString() });
        //            }
        //        }
        //        return Ok();
        //    }
        //}
    }
}
