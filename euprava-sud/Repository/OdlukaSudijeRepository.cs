using eUprava.Court.Model.Enumerations;
using euprava_sud.Data;
using euprava_sud.Model;
using euprava_sud.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace euprava_sud.Repository
{
    public class OdlukaSudijeRepository : GenericRepository<OdlukaSudije>, IOdlukaSudijeRepository
    {
        private readonly DataContext _context;
        public OdlukaSudijeRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<OdlukaSudije>> GetAllForSudija(string sudijaJmbg, int? prekrsaj)
        {
            return _context.OdlukeSudija.Include(o => o.Predmet.PrekrsajnaPrijava).Where(o => o.SudijaJmbg == sudijaJmbg && (int)o.Predmet.PrekrsajnaPrijava.Prekrsaj == prekrsaj).OrderBy(o => o.Datum).ToList();
        }
    }
}
