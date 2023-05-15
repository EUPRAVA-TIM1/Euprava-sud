using eUprava.Court.Model;

namespace euprava_sud.Service.Interfaces
{
    public interface IPredmetService
    {
        Task<IEnumerable<Predmet>> GetAll();
        Task<IEnumerable<Predmet>> GetAllBySudija(string sudijaJmbg);
        Task<Predmet> GetById(Guid guid);
        Task<Predmet> GetWithPrekrsajnaPrijava(Guid guid);
        Task<Predmet> Add(Predmet entity);
        Task<Predmet> Update(Predmet entity);
        Task<Predmet> Delete(Guid guid);
    }
}
