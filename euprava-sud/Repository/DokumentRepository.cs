using eUprava.Court.Model;
using euprava_sud.Data;
using euprava_sud.Repository.Interfaces;

namespace euprava_sud.Repository
{
    public class DokumentRepository : GenericRepository<Dokument>, IDokumentRepository
    {
        private readonly DataContext _context;
        public DokumentRepository(DataContext context) : base(context)
        {
            _context = context;
        }
    }
}
