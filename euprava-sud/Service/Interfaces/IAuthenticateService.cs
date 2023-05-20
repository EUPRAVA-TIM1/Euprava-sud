using eUprava.Court.Model;
using System.Security.Claims;

namespace euprava_sud.Service.Interfaces
{
    public interface IAuthenticateService
    {
        Task<Sudija> Authenticate(string jmbg, string password);
        Task<string> GenerateToken(Sudija sudija);
        Task<string> GetCurrentUser(IEnumerable<Claim> claims);
    }
}
