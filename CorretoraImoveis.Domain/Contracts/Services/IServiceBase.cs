using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorretoraImoveis.Domain.Contracts.Services
{
    public interface IServiceBase<T> where T: class 
    {
        void Save(T entity);
        void Delete(T entity);
        T GetById(int id);
        IEnumerable<T> GetAll();
        void Commit();
    }
}
