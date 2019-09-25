using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using biblioteca_frontend.Repository;
using biblioteca_frontend.Models;

namespace biblioteca_frontend.Controllers
{
    public class HomeController : Controller
    {

        private CatalogoRepository catalogoService;
        private LectorRepository lectorService;
        public HomeController()
        {
            catalogoService = new CatalogoRepository();
            lectorService = new LectorRepository();
        }

        public ActionResult Index()
        {
            List<Catalogo> catalogos = catalogoService.GetAll().ToList();
            return View(catalogos);
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Login(Login user)
        {
           
            Lector lector = lectorService.Login(user);
            if (lector != null)
            {
                Session["user"] = lector;
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Message = "Email o Contraseña incorrectas.";
                return View();
            }
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(Lector lector)
        {
            try
            {
                Lector response = lectorService.Create(lector);
                return RedirectToAction("Login","Home");
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult Search(string name)
        {
            List<Catalogo> catalogos = catalogoService.Search(name).ToList();
            return PartialView("_Catalogo", catalogos);
        }


        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}