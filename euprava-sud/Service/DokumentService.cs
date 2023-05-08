using eUprava.Court.Model;
using euprava_sud.Repository;
using euprava_sud.Repository.Interfaces;
using euprava_sud.Service.Interfaces;

namespace euprava_sud.Service
{
    public class DokumentService : IDokumentService
    {
        private readonly IDokumentRepository _dokumentRepository;

        public DokumentService(IDokumentRepository dokumentRepository)
        {
            _dokumentRepository = dokumentRepository;
        }

        public async Task<Dokument> Add(Dokument dokument)
        {
            var retVal = await _dokumentRepository.Insert(dokument);
            return retVal;
        }

        public async Task<Dokument> Delete(Guid guid)
        {
            var dokumenti = await _dokumentRepository.GetAllBy(d => d.DokumentId == guid);
            if (!dokumenti.Any())
            {
                return null;
            }
            await _dokumentRepository.Delete(dokumenti.First());
            return dokumenti.First();
        }

        public async Task<IEnumerable<Dokument>> GetAll()
        {
            return await _dokumentRepository.GetAll();
        }

        public async Task<Dokument> GetById(Guid guid)
        {
            return await _dokumentRepository.GetById(guid);
        }

        public async Task<Dokument> Update(Dokument dokument)
        {
            var ifExist = await _dokumentRepository.GetById(dokument.DokumentId);
            if (ifExist != null)
            {
                await _dokumentRepository.Update(dokument);
                return dokument;
            }
            return null;
        }
    }
}
