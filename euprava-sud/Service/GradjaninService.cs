﻿using AutoMapper;
using eUprava.Court.Model;
using euprava_sud.Repository.Interfaces;
using euprava_sud.Service.Interfaces;

namespace euprava_sud.Service
{
    public class GradjaninService : IGradjaninService
    {
        private readonly IGradjaninRepository _gradjaninRepository;
        private readonly IMapper _mapper;

        public GradjaninService(IGradjaninRepository gradjaninRepository, IMapper mapper)
        {
            _gradjaninRepository = gradjaninRepository;
            _mapper = mapper;
        }

        public async Task<Gradjanin> Add(Gradjanin entity)
        {
            var exist = await _gradjaninRepository.GetAllBy(g => g.Jmbg == entity.Jmbg);
            if (!exist.Any())
            {
                var result = await _gradjaninRepository.Insert(entity);
                return result;
            }
            return null;
        }

        public async Task<Gradjanin> Delete(string jmbg)
        {
            var gradjanin = await _gradjaninRepository.GetAllBy(g => g.Jmbg == jmbg);
            if (gradjanin.FirstOrDefault() != null)
            {
                await _gradjaninRepository.Delete(gradjanin.First());
                return gradjanin.First();
            }
            return null;
        }

        public async Task<IEnumerable<Gradjanin>> GetAll()
        {
            return await _gradjaninRepository.GetAll();
        }

        public async Task<Gradjanin> GetById(string jmbg)
        {
            var gradjanin = await _gradjaninRepository.GetAllBy(g => g.Jmbg == jmbg);
            return gradjanin.FirstOrDefault();
        }

        public async Task<Gradjanin> Update(Gradjanin entity)
        {
            var gradjanin = await _gradjaninRepository.GetAllBy(g => g.Jmbg == entity.Jmbg);
            if (gradjanin.FirstOrDefault() != null)
            {
                entity.Jmbg = gradjanin.First().Jmbg;
                _mapper.Map(entity, gradjanin.First());
                await _gradjaninRepository.Update(gradjanin.First());
                return gradjanin.First();
            }
            return null;
        }
    }
}
