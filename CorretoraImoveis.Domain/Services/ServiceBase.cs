using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CorretoraImoveis.Domain.Contracts.Repositories;
using CorretoraImoveis.Domain.Contracts.Services;

namespace CorretoraImoveis.Domain.Services
{
    public class ServiceBase<T>: IServiceBase<T> where T: class
    {
        private readonly IRepositoryBase<T> _repositoryBase;

        public ServiceBase(IRepositoryBase<T> repositoryBase)
        {
            _repositoryBase = repositoryBase;
        }

        public void Add(T entity)
        {
            _repositoryBase.Add(entity);
        }

        public void Update(T entity)
        {
            _repositoryBase.Update(entity);
        }

        public void Delete(T entity)
        {
            _repositoryBase.Delete(entity);
        }

        public T GetById(int id)
        {
            return _repositoryBase.GetById(id);
        }

        public IQueryable<T> GetAll()
        {
            return _repositoryBase.GetAll();
        }

        public void Commit()
        {
            _repositoryBase.Commit();
        }
    }
}
