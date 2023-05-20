using eUprava.Court.Model;
using euprava_sud.Models.DTO;
using euprava_sud.Service;
using euprava_sud.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace euprava_sud.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class SudijaController : ControllerBase
    {

        private readonly ISudijaService _sudijaService;
        private readonly IAuthenticateService _authenticateService;
        public SudijaController(ISudijaService sudijaService, IAuthenticateService authenticateService)
        {
            _sudijaService = sudijaService;
            _authenticateService = authenticateService;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<Sudija>>> GetAll()
        {
            return Ok(await _sudijaService.GetAll());
        }

        [HttpGet("{jmbg}")]
        [AllowAnonymous]
        public async Task<ActionResult<Sudija>> GetByJmbg(string jmbg)
        {            
            var sudija = await _sudijaService.GetSudijaWithPrijave(jmbg);
            if (sudija != null)
            {
                return Ok(sudija);
            }
            return NotFound();
        }

        [HttpGet("prijave")]
        public async Task<ActionResult<Sudija>> GetAllWithPrijave()
        {
            return Ok(await _sudijaService.GetAllWithPrijave());

        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<ActionResult> Login([FromBody] UserLogin userLogin)
        {
            var user = await _authenticateService.Authenticate(userLogin.Jmbg, userLogin.Password);
            if(user != null)
            {
                var token = await _authenticateService.GenerateToken(user);
                var result = new { token = token, ime = user.Ime, jmbg = user.Jmbg };
                return Ok(result);
            }
            return NotFound("User not found");
        }

        [HttpGet("sortirani/{id}")]
        public async Task<ActionResult<Sudija>> GetAllForPrekrsaj(string id)
        {
            return Ok(await _sudijaService.GetSudijaForPrekrsaj(id));

        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Sudija sudija)
        {
            var retVal = await _sudijaService.Add(sudija);
            if(retVal != null)
            {
                return Ok(retVal);
            }
            return BadRequest();
        }
       
        [HttpPut]
        public async Task<ActionResult> Put([FromBody] Sudija sudija)
        {
            var retVal = await _sudijaService.Update(sudija);
            if (retVal != null)
                return Ok(retVal);
            return BadRequest();
        }

        [HttpDelete("{jmbg}")]
        public async Task<ActionResult> Delete(string jmbg)
        {
            var sudija = await _sudijaService.Delete(jmbg);
            if (sudija != null)
            {
                return Ok(sudija);
            }
            return BadRequest();
        }
    }
}
