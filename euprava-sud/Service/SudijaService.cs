using eUprava.Court.Model;
using euprava_sud.Repository;
using euprava_sud.Repository.Interfaces;
using euprava_sud.Service.Interfaces;

namespace euprava_sud.Service
{
    public class SudijaService : ISudijaService
    {
        private readonly ISudijaRepository _sudijaRepository;
        public SudijaService(ISudijaRepository sudijaRepository)
        {
            _sudijaRepository = sudijaRepository;
        }

        public async Task<Sudija> Add(Sudija entity)
        {
            var sudija = await _sudijaRepository.GetAllBy(s => s.Jmbg == entity.Jmbg);
            if (!sudija.Any())
            {
                var retVal = await _sudijaRepository.Insert(entity);
                return retVal;
            }
            return null;
        }

        public async Task<Sudija> Delete(string jmbg)
        {
            var sudija = await _sudijaRepository.GetAllBy(s => s.Jmbg == jmbg);
            if (sudija.FirstOrDefault() != null)
            {
                await _sudijaRepository.Delete(sudija.First());
                return sudija.First();
            }
            return null;
        }

        public async Task<IEnumerable<Sudija>> GetAll()
        {
            return await _sudijaRepository.GetAll();
        }

        public async Task<Sudija> GetById(string jmbg)
        {
            var sudije = await _sudijaRepository.GetAllBy(s => s.Jmbg == jmbg);
            return sudije.FirstOrDefault();
        }

        public async Task<Sudija> Update(Sudija entity)
        {
            var sudije = await _sudijaRepository.GetAllBy(s => s.Jmbg == entity.Jmbg);
            if (sudije.FirstOrDefault() != null)
            {
                await _sudijaRepository.Update(entity);
                return entity;
            }
            return null;
        }
    }
}
