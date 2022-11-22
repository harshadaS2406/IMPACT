using LoginService.EFCoreSetUp;
using LoginService.Models;
using LoginService.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoginService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly IEmailService emailService;
        private LoginContext loginContext;

        public UserController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IEmailService emailService)
        {
            this.signInManager = signInManager;
            this.emailService = emailService;
            this.userManager = userManager;
            loginContext = new LoginContext();

        }

        [HttpPost, AllowAnonymous]
        [Route("Register")]
        public async Task<IActionResult> Register(UserRegistration request)
        {
            try
            {
                var emailCheck = await userManager.FindByEmailAsync(request.Email);
                if (emailCheck == null)
                {
                    var user = new ApplicationUser
                    {
                        Title = request.Title,
                        FirstName = request.FirstName,
                        LastName = request.LastName,
                        UserName = request.Email,
                        NormalizedUserName = request.Email,
                        Email = request.Email,
                        PhoneNumber = request.PhoneNumber,
                        EmailConfirmed = false,
                        Address = request.Address,
                        GenderID = request.GenderID,
                        DOB = DateTime.Parse(request.DOB),
                        StatusID = 1, // bydefault active for new users
                        RoleID = request.RoleId == null ? 4 : request.RoleId,  //bydefault 4 if roleID is null-->patient registering outside app
                        IsPasswordChanged = request.RoleId == null ? true : false

                    };

                    var result = await userManager.CreateAsync(user, request.Password);
                    if (result.Succeeded)
                    {
                        UserEmail email = new UserEmail
                        {
                            ToEmail = new List<string>() { "test@gmail.com" }
                        };

                        if (user.RoleID == 4)
                        {
                            await emailService.SendTestEmail(email, 4, EmailCodes.WelcomeEmail);
                        }
                        else
                        {

                            await emailService.SendTestEmail(email, null, EmailCodes.WelcomeEmailCP);
                        }
                        return Ok("User Created Successfully");
                    }
                    else
                    {
                        if (result.Errors.Count() > 0)
                        {
                            foreach (var error in result.Errors)
                            {
                                return Ok("Error: " + error.Description);
                            }
                        }

                        return Ok("User Created Successfully");
                    }
                }
                else
                {
                    return Ok("User Already Exists");
                }

            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError);
            }


        }

        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [Route("ChangePassword")]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePassword changePassword)
        {
            Response response;
            var user = await userManager.GetUserAsync(User); //User property derived from claims
            if (user == null)
            {
                return Ok("Back to Login");
            }
            var result = await userManager.ChangePasswordAsync(user, changePassword.currentpassword, changePassword.newpassword);
            if (result.Succeeded)
            {
                user.IsPasswordChanged = true;
                await userManager.UpdateAsync(user);

                await signInManager.RefreshSignInAsync(user);

                response = new Response
                {
                    ResponseCode = Codes.PasswordChangedSuccess,
                    ResponseInfo = ""
                };


                return Ok(response);
            }
            else if (result.Errors.Count() > 0)
            {
                List<string> errors = new List<string>();
                foreach (var r in result.Errors)
                {
                    errors.Add(r.Code);

                }
                return Ok(errors[0]);
            }
            return Ok();
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("ForgotPassword")]
        public async Task<IActionResult> ForgotPassword([FromBody] ForgotPassword forgotPassword)
        {
            string temppassword = "It$TheYear2022";
            Response response;

            var user = await userManager.FindByEmailAsync(forgotPassword.EmailId);
            if (user == null)
            {
                response = new Response
                {
                    ResponseCode = Codes.EmailIDNotFound,
                    ResponseInfo = ""
                };
                return Ok(response);
            }
            else
            {
                var token = await userManager.GeneratePasswordResetTokenAsync(user);
                user.IsPasswordChanged = false;
                await userManager.UpdateAsync(user);


                await userManager.ResetPasswordAsync(user, token, temppassword);

                UserEmail email = new UserEmail
                {
                    ToEmail = new List<string>() { "test@gmail.com" }
                };
                await emailService.SendTestEmail(email, null, EmailCodes.ResetPassword);

                response = new Response
                {
                    ResponseCode = Codes.EmailSentResetPassword,
                    ResponseInfo = ""
                };
                return Ok(response);
            }
        }




        [HttpGet]
        [Authorize]
        [Route("Dashboard")]
        public IActionResult AdminDashboard()
        {
            return Ok("Admin Dashboard");
        }
    }
}