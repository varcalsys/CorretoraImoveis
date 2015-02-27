using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CorretoraImoveis.App.Contracts;
using CorretoraImoveis.Domain.Entities;
using CorretoraImoveis.Web.Models;

namespace CorretoraImoveis.Web.Controllers
{
    public class ImovelController : Controller
    {
        private readonly IImovelApp _imovelApp;

        public ImovelController(IImovelApp imovelApp)
        {
            _imovelApp = imovelApp;
        }

        // GET: Imovel
        public ActionResult Index()
        {
            var imoveis = _imovelApp.GetAll();
            if (imoveis.Any())
                return View(imoveis);

            return View("Index", imoveis);
        }

        // GET: Imovel/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Imovel/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Imovel/Create
        [HttpPost]
        public ActionResult Create(ImovelViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }

                var imovel = new Imovel
                {
                    Descricao = model.Descricao,
                    Valor = model.Valor,
                    UrlFoto = "teste"
                };

                _imovelApp.Register(imovel);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewData["Erro"] = ex.Message;
                return RedirectToAction("Index");
            }
           
        }

        // GET: Imovel/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Imovel/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Imovel/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Imovel/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
