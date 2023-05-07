using eUprava.Court.Model;
using euprava_sud.Data;
using euprava_sud.Repository.Interfaces;

namespace euprava_sud.Repository
{
    public class OpstinaRepository : GenericRepository<Opstina>, IOpstinaRepository
    {
        private readonly DataContext _context;
        public OpstinaRepository(DataContext context) : base(context)
        {
            _context = context;
        }
    }
}
