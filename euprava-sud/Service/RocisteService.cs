using eUprava.Court.Model;
using euprava_sud.Repository.Interfaces;
using euprava_sud.Service.Interfaces;

namespace euprava_sud.Service
{
    public class RocisteService : IRocisteService
    {
        private readonly IRocisteRepository _rocisteRepository;
        public RocisteService(IRocisteRepository rocisteRepository)
        {
            _rocisteRepository = rocisteRepository;
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

        public async Task<Rociste> GetById(Guid guid)
        {
            return await _rocisteRepository.GetById(guid);
        }

        public async Task<Rociste> Update(Rociste entity)
        {
            var rociste = await _rocisteRepository.GetById(entity.RocisteId);
            if (rociste != null && rociste.DatumRocista > DateTime.UtcNow.AddDays(-7)) //check days parameter
            {
                await _rocisteRepository.Update(entity);
                return entity;
            }
            return null;
        }
    }
}
