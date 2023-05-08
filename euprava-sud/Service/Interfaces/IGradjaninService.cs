using eUprava.Court.Model;

namespace euprava_sud.Service.Interfaces
{
    public interface IGradjaninService
    {
        Task<IEnumerable<Gradjanin>> GetAll();
        Task<Gradjanin> GetById(string jmbg);
        Task<Gradjanin> Add(Gradjanin entity);
        Task<Gradjanin> Update(Gradjanin entity);
        Task<Gradjanin> Delete(string jmbg);
    }
}
