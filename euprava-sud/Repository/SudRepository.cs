using eUprava.Court.Model;
using euprava_sud.Data;
using euprava_sud.Repository.Interfaces;

namespace euprava_sud.Repository
{
    public class SudRepository : GenericRepository<Sud>, ISudRepository
    {
        private readonly DataContext _context;
        public SudRepository(DataContext context) : base(context)
        {
            _context = context;
        }
    }
}
