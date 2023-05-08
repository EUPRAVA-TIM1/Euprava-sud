﻿using eUprava.Court.Model;

namespace euprava_sud.Service.Interfaces
{
    public interface ISudService
    {
        Task<IEnumerable<Sud>> GetAll();
        Task<Sud> GetById(Guid guid);
        Task<Sud> Add(Sud entity);
        Task<Sud> Update(Sud entity);
        Task<Sud> Delete(Guid guid);
    }
}
