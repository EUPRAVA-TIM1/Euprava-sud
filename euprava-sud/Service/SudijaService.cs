using AutoMapper;
using eUprava.Court.Model;
using euprava_sud.Repository;
using euprava_sud.Repository.Interfaces;
using euprava_sud.Service.Interfaces;
using MySqlX.XDevAPI.Common;
using Org.BouncyCastle.Crypto.Generators;

namespace euprava_sud.Service
{
    public class SudijaService : ISudijaService
    {
        private readonly ISudijaRepository _sudijaRepository;
        private readonly IOpstinaRepository _opstinaRepository;
        private readonly IMapper _mapper;
        public SudijaService(ISudijaRepository sudijaRepository,IOpstinaRepository opstinaRepository ,IMapper mapper)
        {
            _sudijaRepository = sudijaRepository;
            _opstinaRepository = opstinaRepository; 
            _mapper = mapper;
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

        public async Task<IEnumerable<Sudija>> GetAllWithPrijave()
        {
            return await _sudijaRepository.GetAllWithPrekrsajnePrijave();
        }

        public async Task<IEnumerable<Sudija>> GetAllWithSud()
        {
            return await _sudijaRepository.GetAllWithSud();
        }

        public async Task<Sudija> GetById(string jmbg)
        {
            var sudije = await _sudijaRepository.GetAllBy(s => s.Jmbg == jmbg);
            return sudije.FirstOrDefault();
        }

        public async Task<IEnumerable<Sudija>> GetSudijaForPrekrsaj(int ptt)
        {
            var opstine = await _opstinaRepository.GetAllBy(o => o.PTT == ptt);
            
            if (!opstine.Any())
            {
                opstine = await _opstinaRepository.GetAll();
            }

            var opstina = opstine.FirstOrDefault();

            var sudije = await _sudijaRepository.GetSudijaForPrekrsaj(opstina.OpstinaId.ToString());
            if (sudije.Any())
                return sudije;
            return await _sudijaRepository.GetAll();
        }

        public async Task<Sudija> GetSudijaWIthSudAndOpstina(string jmbg)
        {
            return await _sudijaRepository.GetSudijaWithSudAndOpstina(jmbg);
        }

        public async Task<Sudija> Login(string jmbg, string password)
        {
            var sudija = await _sudijaRepository.GetById(jmbg);
            if(sudija != null)
            {
                var verified = BCrypt.Net.BCrypt.Verify(password, sudija.Password);
                if (verified)
                    return sudija;
                return null;
            }
            return null;
        }

        public async Task<Sudija> Update(Sudija entity)
        {
            var sudije = await _sudijaRepository.GetById(entity.Jmbg);
            if (sudije != null)
            {
                entity.Jmbg = sudije.Jmbg;
                _mapper.Map(entity,sudije);
                await _sudijaRepository.Update(sudije);
                return sudije;
            }
            return null;
        }
    }
}
