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
    }
}
