using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CorretoraImoveis.App.Contracts;
using CorretoraImoveis.Domain.Contracts.Services;
using CorretoraImoveis.Domain.Entities;

namespace CorretoraImoveis.App
{
    public class FotoApp: IFotoApp
    {
        private readonly IFotoService _fotoService;

        public FotoApp(IFotoService fotoService)
        {
            _fotoService = fotoService;
        }

        public IEnumerable<Foto> GetByImagesImovelId(int id)
        {
            return _fotoService.GetByImagesImovelId(id);
        }

        public void Register(Foto entity)
        {
            _fotoService.Add(entity);

        }

        public Foto GetById(int id)
        {
            return _fotoService.GetById(id);
        }

        public IQueryable<Foto> GetAll()
        {
           return _fotoService.GetAll();
        }


        public void Commit()
        {
            _fotoService.Commit();
        }

    }
}
