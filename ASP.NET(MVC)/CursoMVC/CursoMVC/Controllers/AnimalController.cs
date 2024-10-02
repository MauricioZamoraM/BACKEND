using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CursoMVC.Controllers
{
    //Esta clase es el controlador que se encarga de manejar las interacciones del usuario con la aplicación, las rutas se relacionan con el nombre de controlador
    public class AnimalController : Controller
    {
        // GET: Animal
        //Este método es una acción del controlador que se ejecuta cuando se realiza una solicitud GET a la ruta "/Animal". Se crea una lista de objetos SelectListItem y se llena con información de la base de datos utilizando Entity Framework y LINQ
        public ActionResult Index()
        {
            List<SelectListItem> lst = new List<SelectListItem>();

            using (Models.cursomvcEntities db = new Models.cursomvcEntities())
            {
                lst = (from d in db.animal_class
                       select new SelectListItem
                                              {
                            Value = d.id.ToString(),
                            Text = d.name
                         }).ToList();
            
            }

                return View(lst);
        }
        //Este método es una acción del controlador que se ejecuta cuando se realiza una solicitud GET a la ruta "/Animal/Animal". Recibe un parámetro IdAnimalClass y devuelve un objeto JSON que contiene una lista de animales que pertenecen a la clase especificada
        [HttpGet]
        public JsonResult Animal(int IdAnimalClass)
        {
            //Se declara una nueva lista llamada "lst" que contendrá elementos del tipo ElementJsonIntKey. Esta lista se utiliza para almacenar los resultados de la consulta a la base de datos.
            List<ElementJsonIntKey> lst = new List<ElementJsonIntKey>();
            using (Models.cursomvcEntities db = new Models.cursomvcEntities()) 
            {
                lst = (from d in db.animals
                       where d.idAnimalClass == IdAnimalClass
                       select new ElementJsonIntKey
                       {
                           Value = d.id,
                           Text = d.name
                       }
                       //El método .ToList() se utiliza para convertir una secuencia (como una consulta LINQ) en una lista concreta en memoria. En el contexto del código que has proporcionado, el método .ToList() se aplica al final de la consulta LINQ para obtener una lista de resultados.
                       ).ToList();
            }
            return Json(lst, JsonRequestBehavior.AllowGet);// Se utiliza para permitir explícitamente las solicitudes HTTP GET al usar el método Json() y devolver JSON como resultado.
            // las acciones que modifican los datos (como crear, actualizar o eliminar) generalmente no están permitidas para las solicitudes GET, por razones de seguridad y para seguir las convenciones del protocolo HTTP. Sin embargo, las solicitudes GET son comunes para obtener datos o realizar operaciones de solo lectura.
            //Por defecto, el método Json() en ASP.NET MVC no permite las solicitudes GET, por lo que si se intenta devolver JSON en una acción GET sin especificar el parámetro JsonRequestBehavior.AllowGet, se producirá una excepción de seguridad.
        }
        //Esta clase es un modelo simple que contiene dos propiedades: Value (un entero) y Text (una cadena). Se utiliza para crear objetos JSON en el método Animal 
        public class ElementJsonIntKey { 
           public int Value { get; set; }
           public string Text { get; set; }


        }
    }
}