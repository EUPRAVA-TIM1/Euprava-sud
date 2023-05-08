using eUprava.Court.Model;
using euprava_sud.Model;

namespace euprava_sud.Service.Interfaces
{
    public interface IOdlukaSudijeService
    {
        Task<IEnumerable<OdlukaSudije>> GetAll();
        Task<OdlukaSudije> GetById(Guid guid);
        Task<OdlukaSudije> Add(OdlukaSudije entity);
        Task<OdlukaSudije> Update(OdlukaSudije entity);
        Task<OdlukaSudije> Delete(Guid guid);
    }
}
