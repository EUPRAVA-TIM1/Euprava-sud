using eUprava.Court.Model;

namespace euprava_sud.Repository.Interfaces
{
    public interface ISudijaRepository : IGenericRepository<Sudija>
    {

        Task<IEnumerable<Sudija>> GetAllWithSud();
    }
}
