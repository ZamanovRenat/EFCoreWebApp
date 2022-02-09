﻿using System;
using System.Collections.Generic;
using EFCoreWebApp.Core.Domain;

namespace EFCoreWebApp.Core.Abstractions.Repositories
{
    public interface IRepository<T> : IDisposable
        where T : class
    {
        IEnumerable<T> GetAll();
        T Get(int id);
        void Create(T item);
        void Update(T item);
        void Delete(int id);
        void Save();
    }
}
