using AutoMapper;
using eUprava.Court.Model;
using euprava_sud.Models.DTO;
using euprava_sud.Repository.Interfaces;
using euprava_sud.Service.Interfaces;

namespace euprava_sud.Service
{
    public class RocisteService : IRocisteService
    {
        private readonly IRocisteRepository _rocisteRepository;
        private readonly IMapper _mapper;
        public RocisteService(IRocisteRepository rocisteRepository, IMapper mapper)
        {
            _rocisteRepository = rocisteRepository;
            _mapper = mapper;
        }

        public async Task<Rociste> Add(Rociste entity)
        {
            var exist = await _rocisteRepository.GetAllBy(r => r.PredmetId == entity.PredmetId && r.IshodRocista == eUprava.Court.Model.Enumerations.IshodRocista.ZAKAZANO);
            if (!exist.Any())
            {
                var retVal = await _rocisteRepository.Insert(entity);
                return retVal;
            }
            return null;
        }

        public async Task<Rociste> Delete(Guid guid)
        {
            var rociste = await _rocisteRepository.GetById(guid);
            if(rociste != null && rociste.DatumRocista > DateTime.UtcNow.AddDays(-7)) //check days parameter
            {
                await _rocisteRepository.Delete(rociste);
                return rociste;
            }
            return null;
        }

        public async Task<IEnumerable<Rociste>> GetAll()
        {
            return await _rocisteRepository.GetAll();
        }

        public async Task<IEnumerable<Rociste>> GetAllByAdvokat(string jmbg)
        {
            return await _rocisteRepository.GetAllByAdvokat(jmbg);
        }

        public async Task<IEnumerable<RocisteDTO>> GetAllByGradjanin(string jmbg)
        {
            var rocista = await _rocisteRepository.GetAllByGradjanin(jmbg);
            return _mapper.Map<IEnumerable<RocisteDTO>>(rocista);
        }

        public async Task<IEnumerable<Rociste>> GetAllByPredmet(Guid predmetId)
        {
            return await _rocisteRepository.GetAllBy(r => r.PredmetId == predmetId);
        }

        public async Task<IEnumerable<Rociste>> GetAllBySudija(string jmbg)
        {
            return await _rocisteRepository.GetAllBySudija(jmbg);
        }

        public async Task<Rociste> GetById(Guid guid)
        {
            return await _rocisteRepository.GetById(guid);
        }

        public async Task<Rociste> GetByIdFullInformation(Guid guid)
        {
            return await _rocisteRepository.GetByIdFullInformation(guid);
        }

        public async Task<Rociste> Update(Rociste entity)
        {
            var rociste = await _rocisteRepository.GetById(entity.RocisteId);
            
            entity.RocisteId = rociste.RocisteId;
            entity.PredmetId = rociste.PredmetId;
            entity.SudijaJmbg = rociste.SudijaJmbg;
            entity.SudId = rociste.SudId;
            _mapper.Map(entity, rociste);
            await _rocisteRepository.Update(rociste);
            return rociste;
            
            return null;
        }
    }
}
