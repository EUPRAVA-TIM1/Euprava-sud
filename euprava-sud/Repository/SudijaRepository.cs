using eUprava.Court.Model;
using euprava_sud.Data;
using euprava_sud.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace euprava_sud.Repository
{
    public class SudijaRepository : GenericRepository<Sudija>, ISudijaRepository
    {
        private readonly DataContext _context;
        public SudijaRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Sudija>> GetAllWithPrekrsajnePrijave()
        {
            return _context.Sudije.Include(s => s.PrekrsajnePrijave).ToList();
        }

        public async Task<IEnumerable<Sudija>> GetAllWithSud()
        {
            var retVal = _context.Sudije.Include(p => p.Sud).ToList();
            return retVal;
        }

        public async Task<IEnumerable<Sudija>> GetSudijaForPrekrsaj(string opstinaId)
        {
            return _context.Sudije.Where(s => s.OpstinaId == Guid.Parse(opstinaId)).OrderBy(s => s.PrekrsajnePrijave.Count).ToList();
        }

        public async Task<Sudija> GetSudijaWithPrijave(string jmbg)
        {
            return _context.Sudije.Where(s => s.Jmbg == jmbg).Include(s => s.PrekrsajnePrijave).FirstOrDefault();
        }
    }
}
