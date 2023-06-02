using eUprava.Court.Model;
using euprava_sud.Model;

namespace euprava_sud.Repository.Interfaces
{
    public interface IOdlukaSudijeRepository : IGenericRepository<OdlukaSudije>
    {
        Task<IEnumerable<OdlukaSudije>> GetAllForSudija(string sudijaJmbg, int? prekrsaj);
        Task<OdlukaSudije> GetByRociste(Guid rocisteId);

        Task<IEnumerable<OdlukaSudije>> GetAllByGradjanin(string jmbg);
        Task<IEnumerable<OdlukaSudije>> GetAllBySudija(string jmbg);
        Task<IEnumerable<OdlukaSudije>> GetAllByAdvokat(string jmbg);
    }
}
