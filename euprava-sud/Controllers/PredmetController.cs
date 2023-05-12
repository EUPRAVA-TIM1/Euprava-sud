using eUprava.Court.Model;
using euprava_sud.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace euprava_sud.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PredmetController : ControllerBase
    {
        private readonly IPredmetService _predmetService;
        private readonly IPrekrsajnaPrijavaService _prekrsajnaPrijavaService;
        private readonly ISudijaService _sudijaService;
        private readonly IGradjaninService _gradjaninService;

        public PredmetController(IPredmetService predmetService, IPrekrsajnaPrijavaService prekrsajnaPrijavaService, ISudijaService sudijaService, IGradjaninService gradjaninService)
        {
            _predmetService = predmetService;
            _prekrsajnaPrijavaService = prekrsajnaPrijavaService;
            _sudijaService = sudijaService;
            _gradjaninService = gradjaninService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Predmet>>> GetAll()
        {
            return Ok(await _predmetService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Predmet>> GetById(string id)
        {
            var predmet = await _predmetService.GetById(Guid.Parse(id));
            if (predmet != null)
            {
                return Ok(predmet);
            }
            return BadRequest();
        }

        [HttpGet("sudija/{jmbg}")]
        public async Task<ActionResult<Predmet>> GetBySudija(string jmbg)
        {
            var predmet = await _predmetService.GetAllBySudija(jmbg);
            if (predmet != null)
            {
                return Ok(predmet);
            }
            return BadRequest();
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Predmet predmet)
        {
            var prekrsajnaPrijava = await _prekrsajnaPrijavaService.GetById(predmet.PrekrsajnaPrijavaId);
            var sudija = await _sudijaService.GetById(prekrsajnaPrijava.SudijaJmbg);

            predmet.Sudija = sudija;
            predmet.SudijaJmbg = prekrsajnaPrijava.SudijaJmbg;
            predmet.OptuzeniJmbg = prekrsajnaPrijava.OptuzeniJmbg;
            predmet.PrekrsajnaPrijava = prekrsajnaPrijava;
            predmet.PrekrsajnaPrijavaId = prekrsajnaPrijava.PrekrsajnaPrijavaId;

            var retVal = await _predmetService.Add(predmet);
            if(retVal != null)
            {
                return Ok(retVal);
            }
            return BadRequest();

        }

        [HttpPut]
        public async Task<ActionResult> Put([FromBody] Predmet predmet)
        {
            var retVal = await _predmetService.Update(predmet);
            if(retVal != null)
            {
                return Ok(retVal);
            }
            return BadRequest();
        }
    }
}
