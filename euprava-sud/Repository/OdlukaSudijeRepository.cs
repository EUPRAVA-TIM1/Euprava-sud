using euprava_sud.Data;
using euprava_sud.Model;
using euprava_sud.Repository.Interfaces;

namespace euprava_sud.Repository
{
    public class OdlukaSudijeRepository : GenericRepository<OdlukaSudije>, IOdlukaSudijeRepository
    {
        private readonly DataContext _context;
        public OdlukaSudijeRepository(DataContext context) : base(context)
        {
            _context = context;
        }
    }
}
