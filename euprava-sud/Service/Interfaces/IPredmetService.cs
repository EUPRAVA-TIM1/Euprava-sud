using eUprava.Court.Model;
using euprava_sud.Models.DTO;

namespace euprava_sud.Service.Interfaces
{
    public interface IPredmetService
    {
        Task<IEnumerable<Predmet>> GetAll();
        Task<IEnumerable<Predmet>> GetAllBySudija(string sudijaJmbg);
        Task<IEnumerable<PredmetZaProveruDTO>> GetAllByGradjanin(string gradjaninJmbg);
        Task<Predmet> GetById(Guid guid);
        Task<Predmet> GetByPrekrsajnaPrijava(Guid prijavaId);
        Task<Predmet> GetWithPrekrsajnaPrijava(Guid guid);
        Task<Predmet> Add(Predmet entity);
        Task<Predmet> Update(Predmet entity);
        Task<Predmet> Delete(Guid guid);
    }
}
