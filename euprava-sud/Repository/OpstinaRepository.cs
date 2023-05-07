using eUprava.Court.Model;
using euprava_sud.Data;

namespace euprava_sud.Repository
{
    public class OpstinaRepository : GenericRepository<Opstina>
    {
        private readonly DataContext _context;
        public OpstinaRepository(DataContext context) : base(context)
        {
            _context = context;
        }
    }
}
