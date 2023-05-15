using euprava_sud.Model;

namespace euprava_sud.Repository.Interfaces
{
    public interface IOdlukaSudijeRepository : IGenericRepository<OdlukaSudije>
    {
        Task<IEnumerable<OdlukaSudije>> GetAllForSudija(string sudijaJmbg, int? prekrsaj);
    }
}
