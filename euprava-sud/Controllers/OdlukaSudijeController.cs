using eUprava.Court.Model.Enumerations;
using euprava_sud.Model;
using euprava_sud.Models.DTO;
using euprava_sud.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SQLitePCL;

namespace euprava_sud.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class OdlukaSudijeController : ControllerBase
    {
        private readonly IOdlukaSudijeService _odlukaSudijeService;
        private readonly ISudijaService _sudijaService;
        private readonly IPredmetService _predmetService;
        private readonly IRocisteService _rocisteService;
        private readonly IPrekrsajnaPrijavaService _prekrsajnaPrijavaService;

        public OdlukaSudijeController (IOdlukaSudijeService odlukaSudijeService, ISudijaService sudijaService, IPredmetService predmetService, IRocisteService rocisteService, IPrekrsajnaPrijavaService prekrsajnaPrijavaService)
        {
            _odlukaSudijeService = odlukaSudijeService;
            _sudijaService = sudijaService;
            _predmetService = predmetService;
            _rocisteService = rocisteService;
            _prekrsajnaPrijavaService = prekrsajnaPrijavaService;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<OdlukaSudije>>> GetAll()
        {
            return Ok(await _odlukaSudijeService.GetAll());
        }
        [HttpPost]
        public async Task<ActionResult<OdlukaSudije>> Post([FromBody] OdlukaSudije odlukaSudije)
        {
            var odluka = await _odlukaSudijeService.Add(odlukaSudije);
            if(odluka != null)
            {
                return Ok(odluka);
            }
            return BadRequest();
        }

        [HttpGet("sudija/{jmbg}")]
        public async Task<IEnumerable<OdlukaSudijeDTO>> GetAllBySudija(string jmbg)
        {
            return await _odlukaSudijeService.GetAllBySudija(jmbg);
        }

        [HttpGet("optuzeni/{jmbg}")]
        [AllowAnonymous]
        public async Task<IEnumerable<OdlukaSudijeDTO>> GetAllByOptuzeni(string jmbg)
        {
            return await _odlukaSudijeService.GetAllByOptuzeni(jmbg);
        }

        [HttpGet("advokat/{jmbg}")]
        [AllowAnonymous]
        public async Task<IEnumerable<OdlukaSudijeDTO>> GetAllByAdvokat(string jmbg)
        {
            return await _odlukaSudijeService.GetAllByAdvokat(jmbg);
        }

        [HttpGet("rociste/{id}")]
        [AllowAnonymous]
        public async Task<OdlukaSudije> GetAllByRociste(string id)
        {
            return await _odlukaSudijeService.GetByRociste(Guid.Parse(id));
        }

        [HttpGet("search/{jmbg}/prekrsaj/{prekrsajId?}")]
        [AllowAnonymous]
        public async Task<IEnumerable<OdlukaSudijeDTO>> GetAllForSudija(string jmbg, int? prekrsajId)
        {
            return await _odlukaSudijeService.GetAllForSudija(jmbg, prekrsajId);
        }
    }
}
