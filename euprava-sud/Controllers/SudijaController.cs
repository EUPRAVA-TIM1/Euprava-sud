using eUprava.Court.Model;
using euprava_sud.Service;
using euprava_sud.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace euprava_sud.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SudijaController : ControllerBase
    {

        private readonly ISudijaService _sudijaService;
        public SudijaController(ISudijaService sudijaService)
        {
            _sudijaService = sudijaService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Sudija>>> GetAll()
        {
            return Ok(await _sudijaService.GetAll());
        }

        [HttpGet("{jmbg}")]
        public async Task<ActionResult<Sudija>> GetByJmbg(string jmbg)
        {
            var sudija = await _sudijaService.GetById(jmbg);
            if(sudija != null)
            {
                return Ok(sudija);
            }
            return NotFound();
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
