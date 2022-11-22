using LoginService.EFCoreSetUp;
using LoginService.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace LoginService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {

        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly LoginContext loginContext;
        private IConfiguration _config;

        public LoginController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IConfiguration config)
        {
            this.signInManager = signInManager;
            this.loginContext = new LoginContext();
            this.userManager = userManager;
            this._config = config;

        }


        private static readonly string[] Summaries = new[]
       {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };


        [HttpGet]
        public IEnumerable<Login> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new Login
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }


        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] UserLogin objUsers)
        {
            try
            {

                Response response;
                //Checking User Login Details
                var userManagerResult = await userManager.FindByEmailAsync(objUsers.Email);
                if (await userManager.CheckPasswordAsync(userManagerResult, objUsers.Password) == false)
                {
                    response = new Response
                    {
                        ResponseCode = Codes.InvalidCredentials,
                        ResponseInfo = userManagerResult.AccessFailedCount
                    };
                    return Ok(response);
                }

                var signInManagerResult = await signInManager.PasswordSignInAsync(objUsers.Email, objUsers.Password, objUsers.RememberMe, lockoutOnFailure: true);
                if (signInManagerResult.Succeeded)
                {
                    var roleName = this.loginContext.Roles.FirstOrDefault(r => r.Id == userManagerResult.RoleID).Name;

                    var res = await userManager.AddClaimAsync(userManagerResult, new Claim("UserRole", roleName));

                    var token = GenerateToken(userManagerResult);
                    var loginresponse = new LoginResponse()
                    {
                        RoleID = (int)userManagerResult.RoleID,
                        Token = token,
                        UserID = userManagerResult.Id,
                        Name = userManagerResult.FirstName + ' ' + userManagerResult.LastName

                    };


                    if (userManagerResult.IsPasswordChanged == false)
                    {

                        response = new Response
                        {

                            ResponseCode = Codes.PromptChangePassword,
                            ResponseInfo = loginresponse
                        };
                        return Ok(response);
                    }



                    response = new Response
                    {
                        ResponseCode = Codes.LoginSuccess,
                        ResponseInfo = loginresponse
                    };
                    return Ok(response);
                }
                if (signInManagerResult.IsLockedOut)
                {
                    response = new Response
                    {
                        ResponseCode = Codes.AccountLockout,
                        ResponseInfo = ""
                    };
                    return Ok(response);
                }

                return StatusCode(StatusCodes.Status200OK);
            }


            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }

        }



        public string GenerateToken(ApplicationUser applicationUser)
        {

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var roleName = this.loginContext.Roles.FirstOrDefault(r => r.Id == applicationUser.RoleID).Name;
            var claimsDetail = new[]
            {
                new Claim(ClaimTypes.NameIdentifier,applicationUser.Id.ToString()),
                new Claim(ClaimTypes.Email,applicationUser.Email),
                new Claim(ClaimTypes.GivenName,applicationUser.FirstName),
                new Claim(ClaimTypes.Surname,applicationUser.LastName),
                new Claim(ClaimTypes.Role,roleName)
            };

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
                _config["Jwt:Audience"],
                claimsDetail,
                expires: System.DateTime.Now.AddMinutes(15),
                signingCredentials: credentials
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
