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
    public class ImovelApp: IImovelApp
    {

        private readonly IImovelService _imovelService;

        public ImovelApp(IImovelService imovelService)
        {
            _imovelService = imovelService;
        }

        public void Register(Imovel imovel)
        {
            try
            {
                _imovelService.Save(imovel);
                _imovelService.Commit();
            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
           
        }

        public void UpDate(Imovel imovel)
        {
            _imovelService.Save(imovel);
            _imovelService.Commit();
        }

        public void Delete(Imovel imovel)
        {
            _imovelService.Delete(imovel);
            _imovelService.Commit();
        }

        public Imovel GetById(int id)
        {
            return _imovelService.GetById(id);
        }

        public IEnumerable<Imovel> GetAll()
        {
            return _imovelService.GetAll();
        }
    }
}
