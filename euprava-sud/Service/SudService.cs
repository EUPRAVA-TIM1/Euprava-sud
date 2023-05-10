using AutoMapper;
using eUprava.Court.Model;
using euprava_sud.Repository.Interfaces;
using euprava_sud.Service.Interfaces;
using System;

namespace euprava_sud.Service
{
    public class SudService : ISudService
    {
        private readonly ISudRepository _sudRepository;
        private readonly IMapper _mapper;
        public SudService(ISudRepository sudRepository, IMapper mapper)
        {
            _sudRepository = sudRepository;
            _mapper = mapper;
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

        public async Task<IEnumerable<Sudija>> GetSudijeFromSud(Guid guid)
        {
            var sudije = await _sudRepository.GetAllSudijeFromSud(guid);
            return sudije;
        }

        public async Task<Sud> Update(Sud entity)
        {
            var sud = await _sudRepository.GetById(entity.SudId);
            if (sud != null)
            {
                entity.SudId = sud.SudId;
                _mapper.Map(entity, sud);
                await _sudRepository.Update(sud);
                return sud;
            }
            return null;
        }
    }
}
