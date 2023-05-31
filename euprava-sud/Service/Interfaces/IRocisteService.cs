using eUprava.Court.Model;
using euprava_sud.Models.DTO;

namespace euprava_sud.Service.Interfaces
{
    public interface IRocisteService
    {
        Task<IEnumerable<Rociste>> GetAll();
        Task<IEnumerable<RocisteDTO>> GetAllBySudija(string jmbg);
        Task<IEnumerable<RocisteDTO>> GetAllByGradjanin(string jmbg);
        Task<IEnumerable<RocisteDTO>> GetAllByAdvokat(string jmbg);
        Task<IEnumerable<Rociste>> GetAllByPredmet(Guid predmetId);
        Task<Rociste> GetById(Guid guid);
        Task<Rociste> GetByIdFullInformation(Guid guid);
        Task<Rociste> Add(Rociste entity);
        Task<Rociste> Update(Rociste entity);
        Task<Rociste> Delete(Guid guid);
    }
}
