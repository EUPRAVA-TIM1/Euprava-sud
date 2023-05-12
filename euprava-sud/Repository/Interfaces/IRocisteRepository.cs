using eUprava.Court.Model;

namespace euprava_sud.Repository.Interfaces
{
    public interface IRocisteRepository : IGenericRepository<Rociste>
    {
        Task<IEnumerable<Rociste>> GetAllByGradjanin(string jmbg);
        Task<IEnumerable<Rociste>> GetAllBySudija(string jmbg);
    }
}
