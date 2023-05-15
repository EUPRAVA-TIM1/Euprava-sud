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

        public async Task<IEnumerable<Rociste>> GetAllByGradjanin(string jmbg)
        {
            return _context.Rocista.Where(r => r.OptuzeniJmbg == jmbg).OrderBy(r => r.DatumRocista);
        }

        public async Task<IEnumerable<Rociste>> GetAllByAdvokat(string jmbg)
        {
            return _context.Rocista.Where(r => r.AdvokatJmbg == jmbg).OrderBy(r => r.DatumRocista);
        }

        public async Task<IEnumerable<Rociste>> GetAllBySudija(string jmbg)
        {
            return _context.Rocista.Where(r => r.SudijaJmbg == jmbg && r.IshodRocista != eUprava.Court.Model.Enumerations.IshodRocista.ARHIVA).OrderBy(r => r.DatumRocista);
        }
    }
}
