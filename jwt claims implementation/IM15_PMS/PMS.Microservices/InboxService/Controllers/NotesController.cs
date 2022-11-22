using InboxService.Models;
using InboxService.ViewModel;
using LoginService.EFCoreSetUp;
using LoginService.Models;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace InboxService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotesController : ControllerBase
    {
        private readonly INotesRepo _notesRepo;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly LoginContext loginContext;

        public NotesController(INotesRepo notesRepo, IHttpContextAccessor httpContextAccessor,UserManager<ApplicationUser> userManager, LoginContext loginContext)
        {
            _notesRepo = notesRepo;
            _httpContextAccessor = httpContextAccessor;
            this.userManager = userManager;
            this.loginContext = loginContext;
            // string token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1laWRlbnRpZmllciI6IjExIiwiaHR0cDovL3NjaGVtYXMueG1sc29hcC5vcmcvd3MvMjAwNS8wNS9pZGVudGl0eS9jbGFpbXMvZW1haWxhZGRyZXNzIjoiYXJ0QGFiYy5jb20iLCJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9naXZlbm5hbWUiOiJBcnRodXIiLCJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9zdXJuYW1lIjoiSmVmZnJ5IiwiaHR0cDovL3NjaGVtYXMubWljcm9zb2Z0LmNvbS93cy8yMDA4LzA2L2lkZW50aXR5L2NsYWltcy9yb2xlIjoiRG9jdG9yIiwiZXhwIjoxNjY4NjI5MzU3LCJpc3MiOiJodHRwczovL2xvY2FsaG9zdDo0NDM3MC8ifQ.qsLTexFtjBVXkavu2Z5f9BzJUYtjqBo0Qo1NnI9pbIc";
            //var claims = GetPrincipal(token);
        }

        [HttpGet("GetAllSentNotes/{userId}")]
        public async Task<object> GetAllsentNotes(int userId)
        {
            var result = await _notesRepo.GetSentNotes(userId);
            if (result != null)
            {
                return await Task.FromResult(new ResponseModel(ResponseCode.OK, "", result));
            }
            return await Task.FromResult(new ResponseModel(ResponseCode.Error, "notes not found", result));
        }

        [HttpGet("GetAllReceivedNotes/{userId}")]
        public async Task<object> GetAllReceivedNotes(int userId)
        {
            var result = await _notesRepo.GetReceivedNotes(userId);
            if (result != null)
            {
                return await Task.FromResult(new ResponseModel(ResponseCode.OK, "", result));
            }
            return await Task.FromResult(new ResponseModel(ResponseCode.Error, "notes not found", result));
        }

        [HttpPost("AddNote")]
        public async Task<object> AddNotes([FromBody] Notes notes)
        {
            Request.Headers.TryGetValue("Authorization", out var headerValue);
            var tokenvalue = headerValue.ToString().Replace("Bearer ","");
            int id = GetUserID(tokenvalue);

            var result = await _notesRepo.AddNotes(notes);
            if (result > 0)
            {
                return await Task.FromResult(new ResponseModel(ResponseCode.OK, "Notes Sent Successfully", null));
            }
            return await Task.FromResult(new ResponseModel(ResponseCode.Error, "Error in sending notes", result));
        }

        [HttpDelete("DeleteNote/{noteId}")]
        public async Task<object> DeleteNotes(int noteId)
        {
            var result = await _notesRepo.DeleteNotes(noteId);
            if (result > 0)
            {
                return await Task.FromResult(new ResponseModel(ResponseCode.OK, "Notes deleted successfully", null));
            }
            return await Task.FromResult(new ResponseModel(ResponseCode.Error, "Error in deleting notes", result));
        }

        [Route("GetUsers/{id}")]
        [HttpGet]
        public async Task<object> GetUsersList(int id)
        {
            var result = await _notesRepo.GetUsersList(id);
            if (result != null)
            {
                return await Task.FromResult(new ResponseModel(ResponseCode.Error, "", result));
            }
            return await Task.FromResult(new ResponseModel(ResponseCode.OK, "No Users", null));
        }


        public static ClaimsPrincipal GetPrincipal(string token)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var jwtToken = tokenHandler.ReadToken(token) as JwtSecurityToken;

                if (jwtToken == null)
                    return null;

                var symmetricKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("1234567890976543224"));
                ;

                var validationParameters = new TokenValidationParameters()
                {
                    RequireExpirationTime = true,
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    IssuerSigningKey = symmetricKey
                };

                SecurityToken securityToken;
                var principal = tokenHandler.ValidateToken(token, validationParameters, out securityToken);

                return principal;
            }
            catch (Exception ex)
            {
                //should write log
                return null;
            }
        }

        public int GetUserID(string token)
        {
            var claimsPrincipal = GetPrincipal(token);
            int id = Convert.ToInt32(claimsPrincipal.FindFirstValue(ClaimTypes.NameIdentifier));

         return id;
        }

        public string GetRoleName(string token)
        {
            var claimsPrincipal = GetPrincipal(token);
            string role =claimsPrincipal.FindFirstValue(ClaimTypes.Role);
            return role;
        }
    }
}

