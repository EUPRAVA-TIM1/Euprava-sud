using eUprava.Court.Model;
using euprava_sud.Data;
using euprava_sud.Repository.Interfaces;

namespace euprava_sud.Repository
{
    public class PrekrsajnaPrijavaRepository : GenericRepository<PrekrsajnaPrijava>, IPrekrsajnaPrijavaRepository
    {
        private readonly DataContext _context;
        public PrekrsajnaPrijavaRepository(DataContext context) : base(context)
        {
            _context = context;
        }
    }
}
