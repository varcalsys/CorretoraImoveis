using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CorretoraImoveis.App.Contracts;
using CorretoraImoveis.Domain.Entities;
using CorretoraImoveis.Web.Areas.Admin.Models;
using CorretoraImoveis.Web.Models;

namespace CorretoraImoveis.Web.Controllers
{
    public class ImoveisController : Controller
    {
        private readonly IImovelApp _imovelApp;
        private readonly IFotoApp _fotoApp;

        public ImoveisController(IImovelApp imovelApp, IFotoApp fotoApp)
        {
            _imovelApp = imovelApp;
            _fotoApp = fotoApp;
        }

        // GET: Imoveis
        public ActionResult Index()
        {
            return View();
        }

        

        public ActionResult Pesquisar()
        {
            IEnumerable<Imovel> imoveis = null;

            if (TempData["Imoveis"] == null)
            {
                imoveis = _imovelApp.GetAll();
                return View(imoveis);
            }

            imoveis = TempData["Imoveis"] as IEnumerable<Imovel>;
            return View(imoveis);
        }


        public ActionResult Detalhes(int id)
        {
            var imovel = _imovelApp.GetById(id);

            var fotos = _fotoApp.GetByImagesImovelId(id);
            imovel.Fotos = fotos.ToList();           
            ViewBag.Imoveis = imovel;
            return View(imovel);
        }
    }
}