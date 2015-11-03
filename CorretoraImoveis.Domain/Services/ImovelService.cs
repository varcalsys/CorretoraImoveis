using System;
using System.Collections.Generic;
using CorretoraImoveis.Domain.Contracts.Repositories;
using CorretoraImoveis.Domain.Contracts.Services;
using CorretoraImoveis.Domain.Entities;

namespace CorretoraImoveis.Domain.Services
{
    public class ImovelService: ServiceBase<Imovel>, IImovelService
    {
        private readonly IImovelRepository _imovelRepository;

        public ImovelService(IImovelRepository imovelRepository)
            :base(imovelRepository)
        {
            _imovelRepository = imovelRepository;
        }


       
    }
}
