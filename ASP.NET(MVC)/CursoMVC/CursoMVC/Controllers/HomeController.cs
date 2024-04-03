using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CursoMVC.Controllers
{
    public class HomeController : Controller // Es una clase que hereda de controllers y tiene 3 metodos
    {
        public ActionResult Index() //Un action result puede ser un string, un entero pero en este caso es una vista
        {
            return View();
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