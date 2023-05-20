using euprava_sud.Service.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace euprava_sud.Configurations
{
    public class SSOJwtMiddleware : IMiddleware
    {
        private readonly IAuthenticateService _authenticateService;

        public SSOJwtMiddleware(IAuthenticateService authenticateService)
        {
            _authenticateService = authenticateService;
        }
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            if (!context.Request.Headers.ContainsKey("Authorization"))
            {
                string path = context.Request.Path.Value;
                if (path.StartsWith("/api/authorise/"))
                {
                    string token = path.Substring("/api/authorise/".Length);

                    if (!string.IsNullOrEmpty(token))
                    {
                        var jwtHandler = new JwtSecurityTokenHandler();
                        var jwtToken = jwtHandler.ReadJwtToken(token);

                        var userJmbg = jwtToken.Subject;

                        var newJwt = await _authenticateService.GenerateToken(userJmbg);

                        /*context.User.AddIdentity(new ClaimsIdentity(new[] { new Claim("jmbg", userJmbg) }));*/
                        context.Response.Headers.Add("Authorization", $"Bearer {newJwt}");
                    }
                }
            }
            
            await next(context);
        }
    }
}
