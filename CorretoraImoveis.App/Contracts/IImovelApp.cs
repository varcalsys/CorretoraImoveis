using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CorretoraImoveis.Domain.Entities;

namespace CorretoraImoveis.App.Contracts
{
    public interface IImovelApp: IAppBase<Imovel>
    {

        void Register(Imovel imovel);
        void UpDate(Imovel imovel);
        void Delete(Imovel imovel);


    }
}
