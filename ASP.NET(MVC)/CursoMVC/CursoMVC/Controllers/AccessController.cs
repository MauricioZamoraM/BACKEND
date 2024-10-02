using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using Antlr.Runtime.Misc;
using CursoMVC.Models; // Usamos los modelos
using static System.Net.WebRequestMethods;
namespace CursoMVC.Controllers
{
    public class AccessController : Controller
    {
        // GET: Access
        //La acción Index() se declara con el atributo[HttpGet], lo que indica que responderá a las solicitudes HTTP GET en la ruta "/Access/Index". En el código que has compartido, esta acción simplemente devuelve la vista correspondiente.Sin embargo, no se utiliza en la vista anterior.
        public ActionResult Index()
        {
            return View();
        }

        //La acción Enter(string user, string password) se declara sin un atributo de verbo HTTP específico, lo que indica que responderá a las solicitudes HTTP GET y POST en la ruta "/Access/Enter". Esta acción es la que maneja el envío del formulario de la vista anterior.
        public ActionResult Enter(string user, string password)
        {
            try
            {
                //Se crea una instancia de la clase cursomvcEntities para interactuar con la base de datos utilizando el modelo de datos generado automáticamente.
                using (cursomvcEntities db = new cursomvcEntities())
                {
                    //Se realiza una consulta LINQ en la tabla "usuarios" de la base de datos para buscar un usuario que cumpla con las siguientes condiciones:
                    var lst = from d in db.usuarios
                    where d.email == user && d.password == password && d.idState ==1
                    select d;
                    //Si se encuentra al menos un usuario válido(lst.Count() > 0), se toma el primer usuario de la lista(oUser = lst.First()) y se almacena en la sesión utilizando Session["User"] = oUser;. Esto podría indicar que el usuario ha iniciado sesión correctamente.
                    if (lst.Count() > 0)
                    {
                        usuarios oUser = lst.First();
                        Session["User"] = oUser;
                    }
                    else 
                    {
                        return Content("Usuario Invalido");
                    }
                }

                    return Content("1");
            }
            catch (Exception e)
            {
                return Content("Ocurrio un error: "+e.Message);
            }
        }


    }
}