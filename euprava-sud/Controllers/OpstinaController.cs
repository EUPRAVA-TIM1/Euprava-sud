using eUprava.Court.Model;
using euprava_sud.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace euprava_sud.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OpstinaController : ControllerBase
    {
        private readonly DataContext _dbContext;
        public OpstinaController(DataContext dataContext)
        {
            _dbContext = dataContext;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Opstina>> GetOpstine()
        {
            return _dbContext.Opstine;
        }
        [HttpGet("{ptt:int}")]
        public ActionResult<Opstina> GetByPTT(int ptt)
        {
            
            var opstina = _dbContext.Opstine.Where(o => o.PTT == ptt).First();
            
            if (opstina == null)
                return NotFound();
            return Ok(opstina);
        }
        [HttpPost]
        public async Task<ActionResult> Create(Opstina opstina)
        {
            await _dbContext.Opstine.AddAsync(opstina);
            await _dbContext.SaveChangesAsync();
            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> Update (Opstina opstina)
        {
            _dbContext.Opstine.Update(opstina);
            await _dbContext.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{ptt:int}")]
        public async Task<ActionResult> Delete(int ptt)
        {
            var opstina = await _dbContext.Opstine.FindAsync(ptt);
            _dbContext.Opstine.Remove(opstina);
            await _dbContext.SaveChangesAsync();
            return Ok();
        }
    }
}
