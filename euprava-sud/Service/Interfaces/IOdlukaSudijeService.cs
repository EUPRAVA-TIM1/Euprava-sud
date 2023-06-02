using eUprava.Court.Model;
using euprava_sud.Model;
using euprava_sud.Models.DTO;

namespace euprava_sud.Service.Interfaces
{
    public interface IOdlukaSudijeService
    {
        Task<IEnumerable<OdlukaSudije>> GetAll();
        Task<IEnumerable<OdlukaSudijeDTO>> GetAllBySudija(string sudijaJmbg);
        Task<IEnumerable<OdlukaSudijeDTO>> GetAllByAdvokat(string advokatJmbg);
        Task<IEnumerable<OdlukaSudijeDTO>> GetAllByOptuzeni(string optuzeniJmbg);
        Task<IEnumerable<OdlukaSudijeDTO>> GetAllForSudija(string sudijaJmbg, int? prekrsajnaPrijava);
        Task<OdlukaSudije> GetById(Guid guid);
        Task<OdlukaSudije> GetByRociste(Guid guid);
        Task<OdlukaSudije> Add(OdlukaSudije entity);
        Task<OdlukaSudije> Update(OdlukaSudije entity);
        Task<OdlukaSudije> Delete(Guid guid);
    }
}
