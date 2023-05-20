using eUprava.Court.Model;
using euprava_sud.Model;

namespace euprava_sud.Service.Interfaces
{
    public interface IOdlukaSudijeService
    {
        Task<IEnumerable<OdlukaSudije>> GetAll();
        Task<IEnumerable<OdlukaSudije>> GetAllBySudija(string sudijaJmbg);
        Task<IEnumerable<OdlukaSudije>> GetAllByAdvokat(string advokatJmbg);
        Task<IEnumerable<OdlukaSudije>> GetAllByOptuzeni(string optuzeniJmbg);
        Task<IEnumerable<OdlukaSudije>> GetAllForSudija(string sudijaJmbg, int? prekrsajnaPrijava);
        Task<OdlukaSudije> GetById(Guid guid);
        Task<OdlukaSudije> Add(OdlukaSudije entity);
        Task<OdlukaSudije> Update(OdlukaSudije entity);
        Task<OdlukaSudije> Delete(Guid guid);
    }
}
