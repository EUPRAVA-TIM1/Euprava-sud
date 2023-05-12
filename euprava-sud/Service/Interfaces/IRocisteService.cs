using eUprava.Court.Model;

namespace euprava_sud.Service.Interfaces
{
    public interface IRocisteService
    {
        Task<IEnumerable<Rociste>> GetAll();
        Task<IEnumerable<Rociste>> GetAllBySudija(string jmbg);
        Task<IEnumerable<Rociste>> GetAllByGradjanin(string jmbg);
        Task<Rociste> GetById(Guid guid);
        Task<Rociste> Add(Rociste entity);
        Task<Rociste> Update(Rociste entity);
        Task<Rociste> Delete(Guid guid);
    }
}
