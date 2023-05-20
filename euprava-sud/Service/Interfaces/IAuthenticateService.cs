using eUprava.Court.Model;
using System.Security.Claims;

namespace euprava_sud.Service.Interfaces
{
    public interface IAuthenticateService
    {
        Task<Sudija> Authenticate(string jmbg);
        Task<string> GenerateToken(string jmbg);
        Task<string> GetCurrentUser(IEnumerable<Claim> claims);
    }
}
