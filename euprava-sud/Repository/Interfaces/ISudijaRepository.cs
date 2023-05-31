using eUprava.Court.Model;

namespace euprava_sud.Repository.Interfaces
{
    public interface ISudijaRepository : IGenericRepository<Sudija>
    {

        Task<IEnumerable<Sudija>> GetAllWithSud();
        Task<IEnumerable<Sudija>> GetSudijaForPrekrsaj(string opstinaId);
        Task<IEnumerable<Sudija>> GetAllWithPrekrsajnePrijave();
        Task<Sudija> GetSudijaWithSudAndOpstina(string jmbg);
    }
}
