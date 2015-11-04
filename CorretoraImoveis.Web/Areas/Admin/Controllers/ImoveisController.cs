using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Web;
using System.Web.Mvc;
using CorretoraImoveis.App.Contracts;
using CorretoraImoveis.Domain.Entities;
using CorretoraImoveis.Util.Common;
using CorretoraImoveis.Web.Areas.Admin.Models;


namespace CorretoraImoveis.Web.Areas.Admin.Controllers
{
    [Authorize]
    public class ImoveisController : Controller
    {

        private readonly IImovelApp _imovelApp;
        private readonly IFotoApp _fotoApp;

        public ImoveisController(IImovelApp imovelApp, IFotoApp fotoApp)
        {
            _imovelApp = imovelApp;
            _fotoApp = fotoApp;
        }

        // GET: Admin/Imoveis
        public ActionResult Index()
        {
            
            return View();
        }

        public ActionResult Registrar()
        {
            ViewBag.Imoveis = _imovelApp.GetAll();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Registrar(ImovelViewModel model)
        {
            var fotos = new List<Foto>();

            try
            {
                if (!ModelState.IsValid)
                {

                    return View(model);
                }


                var imovel = new Imovel
                {
                    Title = model.Title,
                    Description = model.Description,
                    Type = model.Type,
                    Price = model.Price,
                    Address = model.Address,
                    Bathrooms = model.Bathrooms,
                    Bedrooms = model.Bedrooms,
                    Area = model.Area,
                    Lat = model.Lat,
                    Lng = model.Lng,
                    Garage = model.Garage,
                    SecuritySystem = model.SecuritySystem,
                    AirConditioning = model.AirConditioning,
                    Balcony = model.Balcony,
                    OutdoorPool = model.OutdoorPool,
                    Internet = model.Internet,
                    Heating = model.Heating,
                    TvCable = model.TvCable,
                    Garden = model.Garden,
                    Telephone = model.Telephone,
                    FirePlace = model.FirePlace,
                    
                };


                fotos = Helper.LoadFiles(model.Images, Server.MapPath("~/"));

                imovel.Image = fotos[0].Nome;
                imovel.Fotos = fotos;
               _imovelApp.Register(null);              
               _imovelApp.Register(imovel);   
                           
               _imovelApp.Commit();

                return RedirectToAction("Registrar");
            }
            catch (Exception)
            {
                ViewBag.Message = "Erro ao registrar imóvel";
                Helper.DeleteFiles(fotos);
                return RedirectToAction("Registrar");
            }
        }

        public void DeleteImages(IList<Foto> fotos)
        {
            if(fotos.Any())
                foreach (var foto in fotos)
                {
                    System.IO.File.Delete(foto.UrlFoto);
                    System.IO.File.Delete(foto.UrlThumb);
                }
        }
    }
}