using eUprava.Court.Model;

namespace euprava_sud.Repository.Interfaces
{
    public interface IPrekrsajnaPrijavaRepository : IGenericRepository<PrekrsajnaPrijava>
    {
        Task<IEnumerable<PrekrsajnaPrijava>> GetAllDoc();
    }
}
