using euprava_sud.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;

namespace euprava_sud.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/authorise")]
    public class AuthorizeController : ControllerBase
    {
        private readonly IAuthenticateService _authenticateService;

        public AuthorizeController(IAuthenticateService authenticateService)
        {
            _authenticateService = authenticateService;
        }

        [HttpGet("{jwt}")]
        [AllowAnonymous]
        public IActionResult Authorize(string jwt)
        {
            var userJmbg = ValidateAndExtractUserJmbg(jwt);

            if (userJmbg != null)
            {
                // Generate a new JWT based on the user JMBG
                var newJwt = _authenticateService.GenerateToken(userJmbg).Result;

                // Return the new JWT as a response
                return Ok(newJwt);
            }

            // If the JWT is invalid or the user JMBG cannot be extracted, return an error response
            return BadRequest("Invalid JWT");
        }

        private string ValidateAndExtractUserJmbg(string jwt)
        {
            // Your validation and extraction logic here
            // This method should validate the JWT, check the necessary claims, and extract the user JMBG

            // Example: Assuming the JWT contains the user JMBG as the subject claim
            var jwtHandler = new JwtSecurityTokenHandler();
            var jwtToken = jwtHandler.ReadJwtToken(jwt);

            var userJmbg = jwtToken.Subject;

            return userJmbg;
        }
    }
}
