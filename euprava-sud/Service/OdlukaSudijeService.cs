using euprava_sud.Model;
using euprava_sud.Repository.Interfaces;
using euprava_sud.Service.Interfaces;
using System;

namespace euprava_sud.Service
{
    public class OdlukaSudijeService : IOdlukaSudijeService
    {
        private readonly IOdlukaSudijeRepository _odlukaSudijeRepository;

        public OdlukaSudijeService(IOdlukaSudijeRepository odlukaSudijeRepository)
        {
            _odlukaSudijeRepository = odlukaSudijeRepository;
        }
        public async Task<OdlukaSudije> Add(OdlukaSudije entity)
        {
            var result = await _odlukaSudijeRepository.Insert(entity);
            return result;
        }

        public async Task<OdlukaSudije> Delete(Guid guid)
        {
            var odluka = await _odlukaSudijeRepository.GetById(guid);
            if (odluka != null)
            {
                await _odlukaSudijeRepository.Delete(odluka);
                return odluka;
            }
            return null;
        }

        public async Task<IEnumerable<OdlukaSudije>> GetAll()
        {
            return await _odlukaSudijeRepository.GetAll();
        }

        public async Task<OdlukaSudije> GetById(Guid guid)
        {
            return await _odlukaSudijeRepository.GetById(guid);
        }

        public async Task<OdlukaSudije> Update(OdlukaSudije entity)
        {
            var odluka = await _odlukaSudijeRepository.GetById(entity.OdlukaSudijeId);
            if (odluka != null)
            {
                await _odlukaSudijeRepository.Update(entity);
                return entity;
            }
            return null;
        }
    }
}
