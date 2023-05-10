using AutoMapper;
using eUprava.Court.Model;
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

        public async Task<Predmet> GetById(Guid guid)
        {
            return await _predmetRepository.GetById(guid);
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
