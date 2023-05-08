using eUprava.Court.Model;
using euprava_sud.Data;
using euprava_sud.Repository.Interfaces;

namespace euprava_sud.Repository
{
    public class SudijaRepository : GenericRepository<Sudija>, ISudijaRepository
    {
        private readonly DataContext _context;
        public SudijaRepository(DataContext context) : base(context)
        {
            _context = context;
        }
    }
}
