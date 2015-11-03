﻿using System.Diagnostics;
using CorretoraImoveis.Data.ContextDb;
using CorretoraImoveis.Domain.Contracts.Repositories;
using CorretoraImoveis.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace CorretoraImoveis.Data.Repositories
{
    public class ImovelRepository:RepositoryBase<Imovel>, IImovelRepository
    {
        public ICollection<Foto> GetByImagesImovelId(int id)
        {
            var fotos = _context.Fotos.Where(x => x.ImovelId == id);

            return fotos.ToList();
        }
    }
}
