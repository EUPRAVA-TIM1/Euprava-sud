using eUprava.Court.Model;
using euprava_sud.Data;
using euprava_sud.Repository.Interfaces;

namespace euprava_sud.Repository
{
    public class RocisteRepository : GenericRepository<Rociste>, IRocisteRepository
    {
        private readonly DataContext _context;
        public RocisteRepository(DataContext context) : base(context)
        {
            _context = context;
        }
    }
}
