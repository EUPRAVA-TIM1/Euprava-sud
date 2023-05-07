using eUprava.Court.Model;
using euprava_sud.Data;
using euprava_sud.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace euprava_sud.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OpstinaController : ControllerBase
    {
        private readonly IOpstinaService _opstinaService;
        public OpstinaController(IOpstinaService opstinaService)
        {
            _opstinaService = opstinaService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Opstina>>> GetOpstine()
        {
            return Ok(_opstinaService.GetAll());
        }
        [HttpGet("ptt/{ptt}")]
        public async Task<ActionResult<Opstina>> GetByPTT(int ptt)
        {
            
            var opstina = await _opstinaService.GetByPTT(ptt);
            
            if (opstina == null)
                return NotFound();
            return Ok(opstina);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Opstina>> GetById(string id)
        {

            var opstina = await _opstinaService.GetById(Guid.Parse(id));

            if (opstina == null)
                return NotFound();
            return Ok(opstina);
        }
        [HttpPost]
        public async Task<ActionResult> Create(Opstina opstina)
        {
            var retVal = await _opstinaService.Add(opstina);
            if (retVal == null)
                return BadRequest();
            return Ok(retVal);
        }

        [HttpPut]
        public async Task<ActionResult> Update (Opstina opstina)
        {
            var retVal = await _opstinaService.Update(opstina);
            if (retVal == null)
                return BadRequest();
            return Ok(retVal);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(string id)
        {
            var opstina = await _opstinaService.Delete(Guid.Parse(id));
            if (opstina == null)
            {
                return BadRequest();
            }
            return Ok(opstina);
        }
    }
}
