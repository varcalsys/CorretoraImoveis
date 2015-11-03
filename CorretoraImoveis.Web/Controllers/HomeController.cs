using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using CorretoraImoveis.App.Contracts;
using CorretoraImoveis.Domain.Entities;
using CorretoraImoveis.Web.Models;

namespace CorretoraImoveis.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IImovelApp _imovelApp;

        public HomeController(IImovelApp imovelApp)
        {
            _imovelApp = imovelApp;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string bedrooms, string minPrice, string maxPrice)
        {
            var imoveis = Filtrar(bedrooms, minPrice, maxPrice);

            TempData["Imoveis"] = imoveis;

            return RedirectToAction("Pesquisar", "Imoveis", imoveis);
        }

        public ActionResult SignOut()
        {
            return View();
        }

        private IEnumerable<Imovel> Filtrar(string bedrooms, string minPrice, string maxPrice)
            {
            var imoveis = _imovelApp.GetAll();

            if (bedrooms == "" && minPrice == "" && maxPrice == "")
            {
                return imoveis;
            }
            if (bedrooms != "" && minPrice == "" && maxPrice == "")
            {
                imoveis = imoveis.Where(x => x.Bedrooms == int.Parse(bedrooms));
            }
            if (bedrooms == "" && minPrice != "" && maxPrice == "")
            {
                imoveis = imoveis.Where(x => x.Price >= decimal.Parse(minPrice));
            }
            if (bedrooms == "" && minPrice == "" && maxPrice != "")
            {
                imoveis = imoveis.Where(x => x.Price <= decimal.Parse(maxPrice));
            }
            if (bedrooms == "" && minPrice != "" && maxPrice != "")
            {
                imoveis = imoveis.Where(x=>x.Price>=decimal.Parse(minPrice) && x.Price <= decimal.Parse(maxPrice));
            }
            if (bedrooms != "" && minPrice != "" && maxPrice != "")
            {
                imoveis =
                    imoveis.Where(x => x.Bedrooms == int.Parse(bedrooms) && (x.Price >= decimal.Parse(minPrice) && x.Price <= decimal.Parse(maxPrice)));
            }

            return imoveis;
        }
    }
}
