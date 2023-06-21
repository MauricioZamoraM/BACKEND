using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CursoMVC.Models; // Importamos el namespace con los modelos
using CursoMVC.Models.TableViewModels;
using CursoMVC.Models.ViewModels;

namespace CursoMVC.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            // Va a ir a la base de datos a traer los datos y los va a llenar en el objeto List<UserTableViewModel>;
            List<UserTableViewModel> lst = null;
            using (cursomvcEntities db = new cursomvcEntities())
            {
                lst = (from d in db.usuarios
                      where d.idState == 1
                      orderby d.email
                      select new UserTableViewModel
                      {
                          Email = d.email,
                          Id = d.id
                      }).ToList();
            }

            return View(lst);
        }

        [HttpGet]
        public ActionResult Add()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Add(UserViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            using (var db = new cursomvcEntities())
            {
                usuarios oUser = new usuarios();
                oUser.idState = 1;
                oUser.email = model.Email;
                oUser.password = model.Password;

                db.usuarios.Add(oUser);
                db.SaveChanges();

            }

            return Redirect(Url.Content("~/User"));


        }


        public ActionResult Edit(int Id)
        {
            EditUserViewModel model = new EditUserViewModel();
            using (var db = new cursomvcEntities())
            {
                var oUser = db.usuarios.Find(Id);
                model.Email = oUser.email;
                model.Id = oUser.id;
            }

                return View(model);
        }

        [HttpPost]
        public ActionResult Edit(EditUserViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            using (var db = new cursomvcEntities())
            {
                var oUser = db.usuarios.Find(model.Id);
                oUser.email = model.Email;

                if (model.Password != null && model.Password.Trim() !="") {
                    oUser.password = model.Password;
                }
                db.Entry(oUser).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }

            return Redirect(Url.Content("~/User"));
        }

        [HttpPost]
        public ActionResult Delete(int Id)
        {

            using (var db = new cursomvcEntities())
            {
                var oUser = db.usuarios.Find(Id);
                oUser.idState = 3;
                db.Entry(oUser).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }

            return Content("1");
        }

    }
}