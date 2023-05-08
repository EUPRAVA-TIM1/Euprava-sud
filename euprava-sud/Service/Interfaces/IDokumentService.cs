using eUprava.Court.Model;

namespace euprava_sud.Service.Interfaces
{
    public interface IDokumentService
    {
        Task<IEnumerable<Dokument>> GetAll();
        Task<Dokument> GetById(Guid guid);

        Task<Dokument> Add(Dokument dokument);
        Task<Dokument> Update(Dokument dokument);
        Task<Dokument> Delete(Guid guid);
    }
}
