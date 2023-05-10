using AutoMapper;
using eUprava.Court.Model;
using euprava_sud.Repository.Interfaces;
using euprava_sud.Service.Interfaces;

namespace euprava_sud.Service
{
    public class PrekrsajnaPrijavaService : IPrekrsajnaPrijavaService
    {
        private readonly IPrekrsajnaPrijavaRepository _prekrsajnaPrijavaRepository;
        private readonly IMapper _mapper;

        public PrekrsajnaPrijavaService(IPrekrsajnaPrijavaRepository prekrsajnaPrijavaRepository, IMapper mapper)
        {
            _prekrsajnaPrijavaRepository = prekrsajnaPrijavaRepository;
            _mapper = mapper;
        }

        public async Task<PrekrsajnaPrijava> Add(PrekrsajnaPrijava entity)
        {
            return await _prekrsajnaPrijavaRepository.Insert(entity);
        }

        public async Task<PrekrsajnaPrijava> Delete(Guid guid)
        {
            var prijava = await _prekrsajnaPrijavaRepository.GetById(guid);
            if (prijava != null)
            {
                await _prekrsajnaPrijavaRepository.Delete(prijava);
                return prijava;
            }
            return null;
        }

        public async Task<IEnumerable<PrekrsajnaPrijava>> GetAll()
        {
            return await _prekrsajnaPrijavaRepository.GetAll();
        }

        public async Task<IEnumerable<PrekrsajnaPrijava>> GetAllDoc()
        {
            return await _prekrsajnaPrijavaRepository.GetAllDoc();
        }

        public async Task<PrekrsajnaPrijava> GetById(Guid guid)
        {
            return await _prekrsajnaPrijavaRepository.GetById(guid);
        }

        public async Task<PrekrsajnaPrijava> Update(PrekrsajnaPrijava entity)
        {
            var prijava = await _prekrsajnaPrijavaRepository.GetById(entity.PrekrsajnaPrijavaId);
            if(prijava != null)
            {
                entity.PrekrsajnaPrijavaId = prijava.PrekrsajnaPrijavaId;
                _mapper.Map(entity, prijava);
                await _prekrsajnaPrijavaRepository.Update(prijava);
                return prijava; 
            }
            return null;
        }
    }
}
