using eUprava.Court.Model;
using euprava_sud.Data;
using euprava_sud.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;

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
            return _context.Rocista.Include(r => r.Predmet).Include(r => r.Sud).Include(p => p.Sudija).Where(r => r.OptuzeniJmbg == jmbg).OrderBy(r => r.DatumRocista);
        }

        public async Task<IEnumerable<Rociste>> GetAllByAdvokat(string jmbg)
        {
            return _context.Rocista.Include(r => r.Predmet).Include(r => r.Sud).Include(p => p.Sudija).Where(r => r.AdvokatJmbg == jmbg).OrderBy(r => r.DatumRocista);
        }

        public async Task<IEnumerable<Rociste>> GetAllBySudija(string jmbg)
        {
            return _context.Rocista.Include(r => r.Predmet).Include(r => r.Sud).Include(p => p.Sudija).Where(r => r.SudijaJmbg == jmbg && r.IshodRocista != eUprava.Court.Model.Enumerations.IshodRocista.ARHIVA).OrderBy(r => r.DatumRocista);
        }

        public async Task<Rociste> GetByIdFullInformation(Guid rocisteId)
        {
            return _context.Rocista.Include(r => r.Predmet).Include(r => r.Sud).Include(p => p.Sudija).FirstOrDefault(r => r.RocisteId == rocisteId);
        }

      
    }
}
