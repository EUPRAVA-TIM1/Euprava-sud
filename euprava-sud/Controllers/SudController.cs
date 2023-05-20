using eUprava.Court.Model;
using euprava_sud.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace euprava_sud.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class SudController : ControllerBase
    {
        private readonly ISudService _sudService;

        public SudController(ISudService sudService)
        {
            _sudService = sudService;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<Sud>>> GetAll()
        {
            return Ok(await _sudService.GetAll());
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<Sud>> GetById(string id)
        {
            var sud = await _sudService.GetById(Guid.Parse(id));
            if (sud != null)
            {
                return Ok(sud);
            }
            return NotFound();
        }
        [HttpGet("sudije/{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<Sud>>> GetAllSudije(string id)
        {
            return Ok(await _sudService.GetSudijeFromSud(Guid.Parse(id)));
        }


        [HttpPost]
        public async Task<ActionResult> Post([FromBody]Sud sud)
        {
            var retVal = await _sudService.Add(sud);
            if(retVal != null)
            {
                return Ok(retVal);
            }
            return BadRequest();
        }

        [HttpPut]
        public async Task<ActionResult> Put ([FromBody]Sud sud)
        {
            var retVal = await _sudService.Update(sud);
            if (retVal != null)
            {
                return Ok(retVal);
            }
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete (string id)
        {
            var sud = await _sudService.Delete(Guid.Parse(id));
            if (sud != null)
            {
                return Ok(sud);
            }
            return NotFound();
        }
    }
}
