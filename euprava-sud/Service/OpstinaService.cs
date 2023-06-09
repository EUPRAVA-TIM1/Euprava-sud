﻿using AutoMapper;
using eUprava.Court.Model;
using euprava_sud.Repository;
using euprava_sud.Repository.Interfaces;
using euprava_sud.Service.Interfaces;
using System;

namespace euprava_sud.Service
{
    public class OpstinaService : IOpstinaService
    {
        private readonly IOpstinaRepository _opstinaRepository;
        private readonly IMapper _mapper;
        public OpstinaService(IOpstinaRepository opstinaRepository, IMapper mapper)
        {
            _opstinaRepository = opstinaRepository;
            _mapper = mapper;
        }

        public async Task<Opstina> Add(Opstina entity)
        {
            var opstine = await _opstinaRepository.GetAllBy(o => o.PTT == entity.PTT);
            if (!opstine.Any())
            {
                var result = await _opstinaRepository.Insert(entity);
                return result;
            }
            return null;
        }

        public async Task<Opstina> Delete(Guid guid)
        {
            var opstine = await _opstinaRepository.GetAllBy(o => o.OpstinaId == guid);
            if (!opstine.Any())
            {
                return null;
            }
            await _opstinaRepository.Delete(opstine.First());
            return opstine.First();
        }

        public async Task<IEnumerable<Opstina>> GetAll()
        {
            return await _opstinaRepository.GetAll();
        }

        public async Task<Opstina> GetById(Guid guid)
        {
            var opstina = await _opstinaRepository.GetById(guid);
            return opstina;
        }

        public async Task<Opstina> GetByPTT(int ptt)
        {
            var opstina = await _opstinaRepository.GetAllBy(o => o.PTT == ptt);
            return opstina.FirstOrDefault();
        }

        public async Task<Opstina> Update(Opstina opstina)
        {
            var ifExist = await _opstinaRepository.GetById(opstina.OpstinaId);
            if (ifExist != null)
            {
                opstina.OpstinaId = ifExist.OpstinaId;
                _mapper.Map(opstina, ifExist);
                await _opstinaRepository.Update(ifExist);
                return ifExist;
            }
            return null;
            
        }
    }
}
