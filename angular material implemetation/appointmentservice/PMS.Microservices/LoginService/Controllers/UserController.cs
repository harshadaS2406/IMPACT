using LoginService.EFCoreSetUp;
using LoginService.Models;
using LoginService.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        public UserController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IEmailService emailService, LoginContext _loginContext)
        {
            this.signInManager = signInManager;
            this.emailService = emailService;
            this.userManager = userManager;
            this.loginContext = _loginContext;
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
                        DOB = request.DOB,
                        StatusID = 1, // bydefault active for new users
                        RoleID = request.RoleId == null ? 4 : request.RoleId,  //bydefault 4 if roleID is null-->patient registering outside app
                        IsPasswordChanged = request.RoleId == null ? true : false,


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
      //  [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [Route("ChangePassword")]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePassword changePassword)
        {
            Response response;
            var user = await userManager.FindByIdAsync(changePassword.userid); //User property derived from claims
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
            string temppassword = "Password123@";
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
        [Route("GetHospitalUsers")]
        public async Task<IActionResult> GetHospUsers()

        {
            try
            {

                List<HospitalUser> hospitalUserList = new List<HospitalUser>();
                var users = await userManager.Users.Where(r => r.RoleID != 4).ToListAsync();
                foreach (var user in users)
                {
                    HospitalUser hospitalUser = new HospitalUser
                    {
                        EmployeeID = user.EmployeeID,
                        EmployeeName = user.FirstName + ' ' + user.LastName,
                        DOJ = user.DOJ,
                        Status = this.loginContext.Status.FirstOrDefault(r => r.StatusID == user.StatusID).StatusName,
                        Title = user.Title,
                        FirstName = user.FirstName,
                        LastName = user.LastName,
                        Email = user.Email,
                        PhoneNumber = user.PhoneNumber,
                        GenderID = user.GenderID,
                        DOB = user.DOB,
                        //this.loginContext.Gender.FirstOrDefault(r => r.GenderID == user.StatusID).StatusName,
                        UserId = user.Id,
                        RoleId = user.RoleID
                        //this.loginContext.Roles.FirstOrDefault(r => r.Id == user.RoleID).Name,
                    };

                    hospitalUserList.Add(hospitalUser);

                }



                return Ok(hospitalUserList);
            }
            catch (Exception ex)
            {
                return Ok(StatusCodes.Status500InternalServerError);
            }
        }


        [HttpGet]
        [Route("GetPatientUsers")]
        public async Task<IActionResult> GetPatientUsers()

        {
            try
            {

                List<PatientUser> patientUserslist = new List<PatientUser>();
                var users = await userManager.Users.Where(r => r.RoleID == 4).ToListAsync();
                foreach (var user in users)
                {
                    PatientUser patientUser = new PatientUser
                    {
                        PatientName = user.FirstName + ' ' + user.LastName,
                        DOR = user.DOJ,
                        Status = this.loginContext.Status.FirstOrDefault(r => r.StatusID == user.StatusID).StatusName,
                        Title = user.Title,
                        FirstName = user.FirstName,
                        LastName = user.LastName,
                        Email = user.Email,
                        PhoneNumber = user.PhoneNumber,
                        GenderID = user.GenderID,
                        DOB = user.DOB,
                        //this.loginContext.Gender.FirstOrDefault(r => r.GenderID == user.StatusID).StatusName,
                        UserId = user.Id,
                        RoleId = user.RoleID
                        //this.loginContext.Roles.FirstOrDefault(r => r.Id == user.RoleID).Name,
                    };

                    patientUserslist.Add(patientUser);

                }



                return Ok(patientUserslist);
            }
            catch (Exception ex)
            {
                return Ok(StatusCodes.Status500InternalServerError);
            }
        }



        [HttpPost]
        [Route("UpdateUserStatus")]
        public async Task<IActionResult> UpdateUserStatus([FromBody] HospitalUser hospitalUser)
        {
            try
            {
                var user = await userManager.FindByIdAsync(hospitalUser.UserId.ToString());
                user.StatusID = hospitalUser.StatusId;
                await userManager.UpdateAsync(user);
                UserEmail email = new UserEmail
                {
                    ToEmail = new List<string>() { "test@gmail.com" }
                };

                if (hospitalUser.StatusId == 1)
                {
                    await emailService.SendTestEmail(email, null, EmailCodes.ActivateUser);

                }
                else if(hospitalUser.StatusId==3)
                {

                    await emailService.SendTestEmail(email, null, EmailCodes.BlockedUser);

                }
                return Ok(1);

            }
            catch (Exception ex)
            {

                throw;
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