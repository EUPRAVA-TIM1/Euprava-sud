using eUprava.Court.Model;

namespace euprava_sud.Service.Interfaces
{
    public interface IOpstinaService
    {
        Task<IEnumerable<Opstina>> GetAll();
        Task<Opstina> GetById(Guid guid);
        Task<Opstina> GetByPTT(int ptt);
        Task<Opstina> Add(Opstina entity);
        Task<Opstina> Update(Opstina entity);
        Task<Opstina> Delete(Guid guid);
    }
}
