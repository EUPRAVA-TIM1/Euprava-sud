using eUprava.Court.Model;

namespace euprava_sud.Repository.Interfaces
{
    public interface ISudRepository : IGenericRepository<Sud>
    {
        Task<IEnumerable<Sudija>> GetAllSudijeFromSud(Guid id);
    }
}
