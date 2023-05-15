using eUprava.Court.Model;

namespace euprava_sud.Repository.Interfaces
{
    public interface IPredmetRepository : IGenericRepository<Predmet>
    {
        Task<Predmet> GetWithPrekrsajnaPrijava(Guid id);
    }
}
