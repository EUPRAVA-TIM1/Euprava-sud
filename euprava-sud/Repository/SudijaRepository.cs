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

        public async Task<IEnumerable<Sudija>> GetAllWithSud()
        {
            var retVal = _context.Sudije.Include(p => p.Sud).ToList();
            return retVal;
        }
    }
}
