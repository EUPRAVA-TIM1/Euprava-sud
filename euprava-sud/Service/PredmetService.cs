using AutoMapper;
using eUprava.Court.Model;
using eUprava.Court.Model.Enumerations;
using euprava_sud.Models.DTO;
using euprava_sud.Repository.Interfaces;
using euprava_sud.Service.Interfaces;

namespace euprava_sud.Service
{
    public class PredmetService : IPredmetService
    {
        private readonly IPredmetRepository _predmetRepository;
        private readonly IMapper _mapper;
        public PredmetService (IPredmetRepository predmetRepository, IMapper mapper)
        {
            _predmetRepository = predmetRepository;
            _mapper = mapper;
        }
        public async Task<Predmet> Add(Predmet entity)
        {
            var isValid = await _predmetRepository.GetAllBy(p => p.PrekrsajnaPrijavaId == entity.PrekrsajnaPrijavaId && p.Status == StatusPredmeta.OTVOREN);
            if (isValid.Any())
                return null;
            return await _predmetRepository.Insert(entity);
        }

        public async Task<Predmet> Delete(Guid guid)
        {
            var predmet = await _predmetRepository.GetById(guid);
            if(predmet != null)
            {
                await _predmetRepository.Delete(predmet);
                return predmet;
            }
            return null;
        }

        public async Task<IEnumerable<Predmet>> GetAll()
        {
            return await _predmetRepository.GetAll();
        }

        public async Task<IEnumerable<PredmetZaProveruDTO>> GetAllByGradjanin(string gradjaninJmbg)
        {
            var retVal = await _predmetRepository.GetAllBy(p => p.OptuzeniJmbg == gradjaninJmbg);
            return _mapper.Map<IEnumerable<PredmetZaProveruDTO>>(retVal);
        }

        public async Task<IEnumerable<Predmet>> GetAllBySudija(string sudijaJmbg)
        {
            return await _predmetRepository.GetAllBy(p => p.SudijaJmbg == sudijaJmbg);
        }

        public async Task<Predmet> GetById(Guid guid)
        {
            return await _predmetRepository.GetById(guid);
        }

        public async Task<Predmet> GetByPrekrsajnaPrijava(Guid prijavaId)
        {
            var res = await _predmetRepository.GetAllBy(p => p.PrekrsajnaPrijavaId == prijavaId);
            return res.FirstOrDefault();
        }

        public async Task<Predmet> GetWithPrekrsajnaPrijava(Guid guid)
        {
            return await _predmetRepository.GetWithPrekrsajnaPrijava(guid);
        }

        public async Task<Predmet> Update(Predmet entity)
        {
            var predmet = await _predmetRepository.GetById(entity.PredmetId);
            if (predmet != null)
            {
                entity.PredmetId = predmet.PredmetId;
                _mapper.Map(entity, predmet);
                _predmetRepository.Update(predmet);
                return predmet;
            }
            return null;
        }
    }
}
