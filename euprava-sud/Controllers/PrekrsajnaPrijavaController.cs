using eUprava.Court.Model;
using euprava_sud.Service;
using euprava_sud.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace euprava_sud.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrekrsajnaPrijavaController : ControllerBase
    {
        private readonly IPrekrsajnaPrijavaService _prekrsajnaPrijavaService;
        public PrekrsajnaPrijavaController(IPrekrsajnaPrijavaService prekrsajnaPrijavaService)
        {
            _prekrsajnaPrijavaService = prekrsajnaPrijavaService;
        }

        [HttpGet]
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

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] PrekrsajnaPrijava prekrsajnaPrijava)
        {
            var retVal = await _prekrsajnaPrijavaService.Add(prekrsajnaPrijava);
            if (retVal == null)
                return BadRequest();
            return Ok(retVal);
        }

        [HttpPut]
        public async Task<ActionResult> Update([FromBody] PrekrsajnaPrijava prekrsajnaPrijava)
        {
            Console.WriteLine("Update", prekrsajnaPrijava);
            var retVal = await _prekrsajnaPrijavaService.Update(prekrsajnaPrijava);
            Console.WriteLine("Update done", prekrsajnaPrijava.ToString());
            
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
