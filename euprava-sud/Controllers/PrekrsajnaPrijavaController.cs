using eUprava.Court.Model;
using euprava_sud.Service;
using euprava_sud.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace euprava_sud.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PrekrsajnaPrijavaController : ControllerBase
    {
        private readonly IPrekrsajnaPrijavaService _prekrsajnaPrijavaService;
        private readonly ISudijaService _sudijaService;
        public PrekrsajnaPrijavaController(IPrekrsajnaPrijavaService prekrsajnaPrijavaService, ISudijaService sudijaService)
        {
            _prekrsajnaPrijavaService = prekrsajnaPrijavaService;
            _sudijaService = sudijaService;
        }

        
        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<PrekrsajnaPrijava>>> GetAll()
        {
            return Ok(_prekrsajnaPrijavaService.GetAllDoc());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PrekrsajnaPrijava>> GetById(string id)
        {
            var prijava = await _prekrsajnaPrijavaService.GetById(Guid.Parse(id));
            if (prijava != null)
            {
                return Ok(prijava);
            }
            return NotFound();
        }
        [HttpGet("sudija/{jmbg}")]
        public async Task<ActionResult<PrekrsajnaPrijava>> GetBySudija(string jmbg)
        {
            var prijave = await _prekrsajnaPrijavaService.GetAllBySudija(jmbg);
            return Ok(prijave);
            
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> Create([FromBody] PrekrsajnaPrijava prekrsajnaPrijava)
        {
            var sudije = await _sudijaService.GetSudijaForPrekrsaj(prekrsajnaPrijava.OpstinaId.ToString());
            var sudija = sudije.FirstOrDefault();
            if(sudija != null)
            {
                prekrsajnaPrijava.Sudija = sudija;
                prekrsajnaPrijava.SudijaJmbg = sudija.Jmbg.ToString();
                
                var retVal = await _prekrsajnaPrijavaService.Add(prekrsajnaPrijava);
                if (retVal == null)
                {
                    return BadRequest();
                }
                return Ok(retVal);
            }

            return BadRequest();
        }

        [HttpPut]
        public async Task<ActionResult> Update([FromBody] PrekrsajnaPrijava prekrsajnaPrijava)
        {
            var retVal = await _prekrsajnaPrijavaService.Update(prekrsajnaPrijava);
            
            if (retVal == null)
                return BadRequest();
            return Ok(retVal);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(string id)
        {
            var opstina = await _prekrsajnaPrijavaService.Delete(Guid.Parse(id));
            if (opstina == null)
            {
                return BadRequest();
            }
            return Ok(opstina);
        }


    }
}
