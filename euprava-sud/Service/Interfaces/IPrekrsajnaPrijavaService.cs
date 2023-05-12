using eUprava.Court.Model;

namespace euprava_sud.Service.Interfaces
{
    public interface IPrekrsajnaPrijavaService
    {
        Task<IEnumerable<PrekrsajnaPrijava>> GetAll();
        Task<IEnumerable<PrekrsajnaPrijava>> GetAllDoc();
        Task<IEnumerable<PrekrsajnaPrijava>> GetAllBySudija(string jmbg);
        Task<PrekrsajnaPrijava> GetById(Guid guid);
        Task<PrekrsajnaPrijava> Add(PrekrsajnaPrijava entity);
        Task<PrekrsajnaPrijava> Update(PrekrsajnaPrijava entity);
        Task<PrekrsajnaPrijava> Delete(Guid guid);
    }
}
