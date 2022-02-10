﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EFCoreWebApp.Core.Domain;

namespace EFCoreWebApp.Core.Abstractions.Repositories
{
    public interface IRepository<T> 
        where T : BaseEntity
    {
        Task<IEnumerable<T>> GetAllAsync();

        Task<T> GetByIdAsync(int id);

        Task AddAsync(T entity);

        Task UpdateAsync(T entity);

        Task DeleteAsync(T entity);

    }
}
