using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CorretoraImoveis.Domain.Contracts.Repositories;
using CorretoraImoveis.Domain.Contracts.Services;
using CorretoraImoveis.Domain.Entities;

namespace CorretoraImoveis.Domain.Services
{
    public class FotoService:ServiceBase<Foto>, IFotoService
    {

        private readonly IFotoRepository _fotoRepository;


        public FotoService(IFotoRepository fotoRepository) :
            base(fotoRepository)
        {
            _fotoRepository = fotoRepository;
        }

        public IEnumerable<Foto> GetByImagesImovelId(int id)
        {
            return _fotoRepository.GetByImagesImovelId(id);
        }
    }
}
