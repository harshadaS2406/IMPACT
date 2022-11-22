using LoginService.Models;
using System.Threading.Tasks;

namespace LoginService.Services
{
    public interface IEmailService
    {
        Task SendTestEmail(UserEmail email, int? roleid, int purpose);
    }
}