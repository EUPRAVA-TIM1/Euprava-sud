using eUprava.Court.Model;
using euprava_sud.Data;
using euprava_sud.Repository.Interfaces;

namespace euprava_sud.Repository
{
    public class PredmetRepository : GenericRepository<Predmet>, IPredmetRepository
    {
        private readonly DataContext _context;
        public PredmetRepository(DataContext context) : base(context)
        {
            _context = context;
        }
    }
}
