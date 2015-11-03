using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net.Configuration;
using System.Web;
using System.Web.Mvc;
using CorretoraImoveis.App.Contracts;
using CorretoraImoveis.Domain.Entities;
using CorretoraImoveis.Domain.Services;
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


                var fotos = Load(model.Images);
                imovel.Image = fotos[0].Nome;

                imovel.Fotos = fotos;

               _imovelApp.Register(imovel);              

              _imovelApp.Commit();

                return RedirectToAction("Registrar");
            }
            catch (Exception)
            {
                return View(model);
            }
        }

        public List<Foto> Load(HttpPostedFileBase[] files)
        {

            var fotos = new List<Foto>();

            foreach (HttpPostedFileBase file in files)
            {
                var foto = new Foto();
                byte[] arraybytes = null;
                foto.Nome = DateTime.Now.ToString("yyyy-MM-dd") + DateTime.Now.Millisecond + ".jpg";
                long numeroBytes = file.InputStream.Length;
                BinaryReader br = new BinaryReader(file.InputStream);
                arraybytes = br.ReadBytes((int)numeroBytes);
                var ms = new MemoryStream(arraybytes);
                Image image = Image.FromStream(ms);

                var _bmp = new Bitmap(image, new Size(800, 480));
                foto.UrlFoto = Path.Combine(Server.MapPath("~/images/imoveis"), Path.GetFileName(foto.Nome));
                _bmp.Save(foto.UrlFoto, ImageFormat.Jpeg);

                var thumb = new Bitmap(image, new Size(400, 240));
                foto.UrlThumb = Path.Combine(Server.MapPath("~/images/imoveis/thumb"), Path.GetFileName(foto.Nome));
                thumb.Save(foto.UrlThumb, ImageFormat.Jpeg);

                fotos.Add(foto);
            }

            return fotos;
        }
    }
}