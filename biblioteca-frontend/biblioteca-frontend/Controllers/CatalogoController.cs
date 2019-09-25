using biblioteca_frontend.Models;
using biblioteca_frontend.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace biblioteca_frontend.Controllers
{
    public class CatalogoController : Controller
    {
        private CatalogoRepository catalogoService;

        public CatalogoController()
        {
            catalogoService = new CatalogoRepository();
        }

        public ActionResult Details(int id)
        {
            Catalogo catalogo = catalogoService.GetSigle(id);
            return View(catalogo);
        }

    }
}