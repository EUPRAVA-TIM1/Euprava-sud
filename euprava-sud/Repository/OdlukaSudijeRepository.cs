using eUprava.Court.Model.Enumerations;
using euprava_sud.Data;
using euprava_sud.Model;
using euprava_sud.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using euprava_sud.Model.Enumerations;
using eUprava.Court.Model;

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
            return _context.OdlukeSudija.Include(o => o.Predmet.PrekrsajnaPrijava).Include(r => r.Rociste).Include(p => p.Sudija).Where(o => o.SudijaJmbg == sudijaJmbg && (int)o.Predmet.PrekrsajnaPrijava.Prekrsaj == prekrsaj).OrderBy(o => o.Datum).ToList();
        }

        public async Task<OdlukaSudije> GetByRociste(Guid rocisteId)
        {
            return _context.OdlukeSudija.FirstOrDefault(o => o.RocisteId == rocisteId);
        }

        public async Task<IEnumerable<OdlukaSudije>> GetAllByGradjanin(string jmbg)
        {
            return _context.OdlukeSudija.Include(r => r.Predmet.PrekrsajnaPrijava).Include(r => r.Rociste).Include(p => p.Sudija).Where(r => r.OptuzeniJmbg == jmbg).OrderBy(r => r.Datum);
        }

        public async Task<IEnumerable<OdlukaSudije>> GetAllByAdvokat(string jmbg)
        {
            return _context.OdlukeSudija.Include(r => r.Predmet.PrekrsajnaPrijava).Include(r => r.Rociste).Include(p => p.Sudija).Where(r => r.AdvokatJmbg == jmbg).OrderBy(r => r.Datum);
        }

        public async Task<IEnumerable<OdlukaSudije>> GetAllBySudija(string jmbg)
        {
            return _context.OdlukeSudija.Include(r => r.Predmet.PrekrsajnaPrijava).Include(r => r.Rociste).Include(p => p.Sudija).Where(r => r.SudijaJmbg == jmbg && r.Status != StatusPrekrsajnePrijave.ARHIVA).OrderBy(r => r.Datum);
        }
    }
}
