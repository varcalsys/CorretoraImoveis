using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CorretoraImoveis.Domain.Entities;

namespace CorretoraImoveis.Domain.Contracts.Repositories
{
    public interface IFotoRepository: IRepositoryBase<Foto>
    {
        IEnumerable<Foto> GetByImagesImovelId(int id);
    }
}
