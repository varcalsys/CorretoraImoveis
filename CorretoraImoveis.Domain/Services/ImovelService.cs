using System;
using System.Collections.Generic;
using CorretoraImoveis.Domain.Contracts.Repositories;
using CorretoraImoveis.Domain.Contracts.Services;
using CorretoraImoveis.Domain.Entities;

namespace CorretoraImoveis.Domain.Services
{
    public class ImovelService: IImovelService
    {
        private readonly IImovelRepository _imovelRepository;

        public ImovelService(IImovelRepository imovelRepository)
        {
            _imovelRepository = imovelRepository;
        }

        public void Save(Imovel entity)
        {
            try
            {
                _imovelRepository.Save(entity);
            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
            
        }

        public void Delete(Imovel entity)
        {
            _imovelRepository.Delete(entity);
        }

        public Imovel GetById(int id)
        {
            return _imovelRepository.GetById(id);
        }

        public IEnumerable<Imovel> GetAll()
        {
            return _imovelRepository.GetAll();
        }

        public void Commit()
        {
            _imovelRepository.Commit();
        }
    }
}
