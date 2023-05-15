using eUprava.Court.Model;
using euprava_sud.Data;
using euprava_sud.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace euprava_sud.Repository
{
    public class PredmetRepository : GenericRepository<Predmet>, IPredmetRepository
    {
        private readonly DataContext _context;
        public PredmetRepository(DataContext context) : base(context)
        {
            _context = context;
        }
        
        public async Task<Predmet> GetWithPrekrsajnaPrijava(Guid id)
        {
            var retVal = _context.Predmeti.Include(p => p.PrekrsajnaPrijava).FirstOrDefault(p => p.PredmetId == id);
            return retVal;
        }
    }
}
