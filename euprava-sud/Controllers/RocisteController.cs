using eUprava.Court.Model;
using euprava_sud.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace euprava_sud.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RocisteController : ControllerBase
    {
        private readonly IRocisteService _rocisteService;
        private readonly IPredmetService _predmetService;
        private readonly ISudijaService _sudijaService;
        private readonly ISudService _sudService;

        public RocisteController (IRocisteService rocisteService, IPredmetService predmetService, ISudijaService sudijaService, ISudService sudService)
        {
            _rocisteService = rocisteService;
            _predmetService = predmetService;
            _sudijaService = sudijaService;
            _sudService = sudService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Rociste>>> GetAll()
        {
            return Ok(await _rocisteService.GetAll());
        }

        [HttpGet("sudija/{jmbg}")]
        public async Task<ActionResult<IEnumerable<Rociste>>> GetAllBySudija(string jmbg)
        {
            return Ok(await _rocisteService.GetAllBySudija(jmbg));
        }

        [HttpGet("gradjanin/{jmbg}")]
        public async Task<ActionResult<IEnumerable<Rociste>>> GetAllByGradjanin(string jmbg)
        {
            return Ok(await _rocisteService.GetAllByGradjanin(jmbg));
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Rociste rociste)
        {
            var predmet = await _predmetService.GetById(rociste.PredmetId);
            var sudija = await _sudijaService.GetById(predmet.SudijaJmbg);
            var sud = await _sudService.GetById(sudija.SudId);

            rociste.Predmet = predmet;
            rociste.OptuzeniJmbg = predmet.OptuzeniJmbg;
            rociste.PredmetId = predmet.PredmetId;
            rociste.Sudija = sudija;
            rociste.SudijaJmbg = sudija.Jmbg;
            rociste.Sud = sud;
            rociste.SudId = sud.SudId;

            var retVal = await _rocisteService.Add(rociste);
            if(retVal != null)
            {
                return Ok(retVal);
            }
            return BadRequest();
        }

        [HttpPut]
        public async Task<ActionResult> Put([FromBody] Rociste rociste)
        {
            /*var predmet = await _predmetService.GetById(rociste.PredmetId);
            var sudija = await _sudijaService.GetById(rociste.SudijaJmbg);
            var sud = await _sudService.GetById(rociste.SudId);*/

            /*rociste.Predmet = predmet;
            rociste.Sudija = sudija;
            rociste.Sud = sud;*/

            var retVal = await _rocisteService.Update(rociste);
            if (retVal != null)
            {
                return Ok(retVal);
            }
            return BadRequest();

        }

    }
}
