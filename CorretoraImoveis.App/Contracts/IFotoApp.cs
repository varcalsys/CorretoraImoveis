using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CorretoraImoveis.Domain.Entities;

namespace CorretoraImoveis.App.Contracts
{
    public interface IFotoApp: IAppBase<Foto>
    {
        void Register(Foto entity);

        IEnumerable<Foto> GetByImagesImovelId(int id);

    }
}
