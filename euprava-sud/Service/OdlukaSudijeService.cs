using AutoMapper;
using eUprava.Court.Model.Enumerations;
using euprava_sud.Model;
using euprava_sud.Repository.Interfaces;
using euprava_sud.Service.Interfaces;
using System;

namespace euprava_sud.Service
{
    public class OdlukaSudijeService : IOdlukaSudijeService
    {
        private readonly IOdlukaSudijeRepository _odlukaSudijeRepository;
        private readonly ISudijaService _sudijaService;
        private readonly IPredmetService _predmetService;
        private readonly IRocisteService _rocisteService;
        private readonly IPrekrsajnaPrijavaService _prekrsajnaPrijavaService;
        private readonly IMapper _mapper;

        public OdlukaSudijeService(IOdlukaSudijeRepository odlukaSudijeRepository, IMapper mapper, ISudijaService sudijaService, IPredmetService predmetService, IRocisteService rocisteService, IPrekrsajnaPrijavaService prekrsajnaPrijavaService)
        {
            _odlukaSudijeRepository = odlukaSudijeRepository;
            _mapper = mapper;
            _sudijaService = sudijaService;
            _predmetService = predmetService;
            _rocisteService = rocisteService;
            _prekrsajnaPrijavaService = prekrsajnaPrijavaService;
        }
        public async Task<OdlukaSudije> Add(OdlukaSudije entity)
        {
            var exist = await _odlukaSudijeRepository.GetAllBy(o => o.RocisteId == entity.RocisteId);
            if (exist.Any())
            {
                return null;
            }
            

            var rociste = await _rocisteService.GetById(entity.RocisteId);
            var sudija = await _sudijaService.GetById(rociste.SudijaJmbg);
            var predmet = await _predmetService.GetWithPrekrsajnaPrijava(rociste.PredmetId);            

            entity.Rociste = rociste;
            entity.Sudija = sudija;
            entity.SudijaJmbg = sudija.Jmbg;
            entity.AdvokatJmbg = rociste.AdvokatJmbg;
            entity.OptuzeniJmbg = rociste.OptuzeniJmbg;
            entity.Predmet = predmet;
            entity.PredmetId = predmet.PredmetId;

            var result = await _odlukaSudijeRepository.Insert(entity);
            if(result != null)
            {
                rociste.IshodRocista = IshodRocista.ZAVRSENO;
                await _rocisteService.Update(rociste);

                predmet.Status = StatusPredmeta.ZATVOREN;
                predmet.PrekrsajnaPrijava.StatusPrekrsajnePrijave = result.Status;
                predmet.PrekrsajnaPrijava.SudijaJmbg = result.SudijaJmbg;
                await _predmetService.Update(predmet);

                return result;
            }
            return null;
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

        public async Task<IEnumerable<OdlukaSudije>> GetAllByAdvokat(string advokatJmbg)
        {
            return await _odlukaSudijeRepository.GetAllBy(o => o.AdvokatJmbg == advokatJmbg);
        }

        public async Task<IEnumerable<OdlukaSudije>> GetAllByOptuzeni(string optuzeniJmbg)
        {
            return await _odlukaSudijeRepository.GetAllBy(o => o.OptuzeniJmbg == optuzeniJmbg);
        }

        public async Task<IEnumerable<OdlukaSudije>> GetAllBySudija(string sudijaJmbg)
        {
            return await _odlukaSudijeRepository.GetAllBy(o => o.SudijaJmbg == sudijaJmbg);
        }

        public async Task<IEnumerable<OdlukaSudije>> GetAllForSudija(string sudijaJmbg, int? prekrsajnaPrijava)
        {
            if (prekrsajnaPrijava != null)
                return await _odlukaSudijeRepository.GetAllForSudija(sudijaJmbg, prekrsajnaPrijava);
            else
                return await _odlukaSudijeRepository.GetAllBy(o => o.SudijaJmbg == sudijaJmbg);

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
                entity.OdlukaSudijeId = odluka.OdlukaSudijeId;
                _mapper.Map(entity, odluka);
                await _odlukaSudijeRepository.Update(odluka);
                return odluka;
            }
            return null;
        }
    }
}
