using eUprava.Court.Model;
using euprava_sud.Service.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace euprava_sud.Service
{
    public class AuthenticateService : IAuthenticateService
    {
        private readonly ISudijaService _sudijaService;
        private readonly IConfiguration _configuration;
        public AuthenticateService (ISudijaService sudijaService, IConfiguration configuration)
        {
            _sudijaService = sudijaService;
            _configuration = configuration;
        }
        public Task<Sudija> Authenticate(string jmbg)
        {
            var user = _sudijaService.GetById(jmbg);
            if(user != null)
            {
                return user;
            }
            return null;
        }

        public async Task<string> GenerateToken(string jmbg)
        {
            /*var user = await _sudijaService.GetById(jmbg);*/
            var user = await _sudijaService.GetById(jmbg);
            bool isSudija = false;
            if (user != null)
                isSudija = true;

            /////
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim("Jmbg", jmbg),
                new Claim("isSudija", isSudija.ToString()),
                isSudija ? new Claim("Role", "Sudija") : new Claim("Role", "Gradjanin")
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                _configuration["Jwt:Issuer"],
                _configuration["Jwt:Audience"],
                claims,
                expires: DateTime.UtcNow.AddMinutes(480),
                signingCredentials: signIn);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task<string> GetCurrentUser(IEnumerable<Claim> claims)
        {
            return claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value;
        }
    }
}
