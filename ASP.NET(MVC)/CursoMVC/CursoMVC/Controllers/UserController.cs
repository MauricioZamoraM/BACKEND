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
            //Aquí se declara una variable llamada lst que es una lista de objetos UserTableViewModel y se inicializa con el valor null. Esta variable se utilizará para almacenar los resultados de una consulta a la base de datos.
            List<UserTableViewModel> lst = null;
            using (cursomvcEntities db = new cursomvcEntities())//En esta sección se crea y utiliza un objeto de contexto de base de datos llamado db utilizando el contexto cursomvcEntities. El uso del bloque using asegura que el objeto db se elimine correctamente después de su uso para liberar los recursos. Dentro de este bloque se realizará una consulta a la base de datos.
            {
                //En esta sección se realiza una consulta a la tabla usuarios de la base de datos utilizando LINQ (Language Integrated Query). Se seleccionan aquellos registros donde el campo idState es igual a 1 y se ordenan por el campo email. Los resultados de la consulta se asignan a la variable lst después de transformarlos en objetos UserTableViewModel, donde se asigna el valor de email a la propiedad Email y el valor de id a la propiedad Id. Finalmente, se convierte el resultado en una lista utilizando el método ToList().
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
            if (!ModelState.IsValid) // Se valida si es modelo es valido y se retorna la vsita actual
            {
                return View(model);
            }
            using (var db = new cursomvcEntities())
            {
                usuarios oUser = new usuarios();
                oUser.idState = 1;
                oUser.email = model.Email;
                oUser.password = model.Password;
                //El objeto de usuario oUser se agrega a la tabla usuarios en la base de datos utilizando el método Add(). Luego, se guardan los cambios en la base de datos utilizando el método SaveChanges().
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
                db.Entry(oUser).State = System.Data.Entity.EntityState.Modified;//Al establecer db.Entry(usuario).State en Modified, estás informando al contexto que el objeto usuario ha sido modificado y que los cambios deben reflejarse en la base de datos cuando se llame al método SaveChanges() del contexto.
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