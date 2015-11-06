﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorretoraImoveis.Domain.Contracts.Services
{
    public interface IServiceBase<T> where T: class 
    {
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        T GetById(int id);
        IQueryable<T> GetAll();
        void Commit();
        
    }
}
