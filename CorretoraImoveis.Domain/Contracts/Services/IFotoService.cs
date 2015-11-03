using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CorretoraImoveis.Domain.Entities;

namespace CorretoraImoveis.Domain.Contracts.Services
{
    public interface IFotoService: IServiceBase<Foto>
    {
        IEnumerable<Foto> GetByImagesImovelId(int id);
    }
}
