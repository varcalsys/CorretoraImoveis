using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CorretoraImoveis.Data.ContextDb;
using CorretoraImoveis.Domain.Contracts.Repositories;
using CorretoraImoveis.Domain.Entities;

namespace CorretoraImoveis.Data.Repositories
{
    public class FotoRepository : RepositoryBase<Foto>, IFotoRepository
    {

        public IEnumerable<Foto> GetByImagesImovelId(int id)
        {
            return  _context.Fotos.Where(x=>x.ImovelId == id);
        }
    }
}
