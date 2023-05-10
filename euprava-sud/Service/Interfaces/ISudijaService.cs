using eUprava.Court.Model;

namespace euprava_sud.Service.Interfaces
{
    public interface ISudijaService
    {
        Task<IEnumerable<Sudija>> GetAll();
        Task<IEnumerable<Sudija>> GetAllWithSud();
        Task<IEnumerable<Sudija>> GetAllWithPrijave();
        Task<IEnumerable<Sudija>> GetSudijaForPrekrsaj(string opstinaId);
        Task<Sudija> GetSudijaWithPrijave(string jmbg);
        Task<Sudija> GetById(string jmbg);
        Task<Sudija> Add(Sudija entity);
        Task<Sudija> Update(Sudija entity);
        Task<Sudija> Delete(string jmbg);
    }
}
