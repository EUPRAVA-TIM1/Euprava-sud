using eUprava.Court.Model;
using euprava_sud.Repository.Interfaces;
using euprava_sud.Service.Interfaces;
using System;

namespace euprava_sud.Service
{
    public class SudService : ISudService
    {
        private readonly ISudRepository _sudRepository;
        public SudService(ISudRepository sudRepository)
        {
            _sudRepository = sudRepository;
        }

        public async Task<Sud> Add(Sud entity)
        {
            return await _sudRepository.Insert(entity);
        }

        public async Task<Sud> Delete(Guid guid)
        {
            var sud = await _sudRepository.GetById(guid);
            if(sud != null)
            {
                await _sudRepository.Delete(sud);
                return sud;
            }
            return null;
        }

        public async Task<IEnumerable<Sud>> GetAll()
        {
            return await _sudRepository.GetAll();
        }

        public async Task<Sud> GetById(Guid guid)
        {
            return await _sudRepository.GetById(guid);
        }

        public async Task<Sud> Update(Sud entity)
        {
            var sud = await _sudRepository.GetById(entity.SudId);
            if (sud != null)
            {
                await _sudRepository.Update(entity);
                return entity;
            }
            return null;
        }
    }
}
