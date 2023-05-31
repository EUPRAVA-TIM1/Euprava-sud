using eUprava.Court.Model;
using euprava_sud.Data;
using euprava_sud.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace euprava_sud.Repository
{
    public class SudRepository : GenericRepository<Sud>, ISudRepository
    {
        private readonly DataContext _context;
        public SudRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Sudija>> GetAllSudijeFromSud(Guid id)
        {
            var retVal = _context.Sudije.Where(s => s.SudId == id).ToList();
            if(retVal!= null)
            {
                return retVal;
            }
            return null;
        }

        public async Task<IEnumerable<Sud>> GetAllWithOpstina()
        {
            return _context.Sudovi.Include(s => s.Opstina).ToList();
        }

        public async Task<Sud> GetSudByIdWithOpstina(Guid id)
        {
            return _context.Sudovi.Include(s => s.Opstina).FirstOrDefault(s => s.SudId == id);
        }
    }
}
