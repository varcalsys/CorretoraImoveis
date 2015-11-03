using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorretoraImoveis.App.Contracts
{
    public interface IAppBase<T> where T: class
    {
        T GetById(int id);
        IEnumerable<T> GetAll();
        void Commit();
       
    }
}
