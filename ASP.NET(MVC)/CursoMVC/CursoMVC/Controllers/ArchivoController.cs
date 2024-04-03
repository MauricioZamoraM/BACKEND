//Importa los espacios de nombres necesarios para utilizar las clases y métodos en el controlador.
using CursoMVC.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.Mvc;
using System.Web;
using static System.Net.WebRequestMethods;
using System.Security.Policy;
using System.Security.Cryptography;


namespace CursoMVC.Controllers
{
    public class ArchivoController : Controller
    {
        public ActionResult Index()
        {
            // Se verifica si existe un mensaje en la propiedad TempData["Message"] y, en caso afirmativo, se asigna ese mensaje a la propiedad ViewBag.Message.Luego, se devuelve la vista correspondiente.
            if (TempData["Message"] != null)
                ViewBag.Message = TempData["Message"].ToString();

            return View();
        }
        //Significa que solo se activará cuando se realice una solicitud HTTP POST a la URL correspondiente
        [HttpPost]
        //Esta acción toma un parámetro de tipo ArchivoViewModel, que representan los datos enviados desde el formulario usando las propiedades en la vista.
        public ActionResult Save(ArchivoViewModel model)
        {
            //Se obtiene la ruta del directorio raíz del sitio utilizando el método Server.MapPath
            string RutaSitio = Server.MapPath("~/");
            //A continuación, se construyen los caminos de archivo para los archivos de destino "archivo1.png" y "archivo2.png" utilizando el método Path.Combine.
            string PathArchivo1 = Path.Combine(RutaSitio + "/Files/archivo1.png");
            string PathArchivo2 = Path.Combine(RutaSitio + "/Files/archivo2.png");
            //Se realiza una validación del modelo utilizando la propiedad ModelState. Si el modelo no es válido, se devuelve la vista "Index" junto con el modelo actual para mostrar los mensajes de validación.
            if (!ModelState.IsValid)
            {
                return View("Index", model);
            }
            //Si el modelo es válido, se guarda el archivo1 y archivo2 utilizando los métodos SaveAs de los objetos Archivo1 y Archivo2 del modelo. Estos métodos guardan los archivos seleccionados en las rutas de archivo especificadas.
            model.Archivo1.SaveAs(PathArchivo1);
            model.Archivo2.SaveAs(PathArchivo2);
            //Se establece un mensaje de éxito en TempData["Message"] y se redirige a la acción "Index" utilizando el método RedirectToAction.
            @TempData["Message"] = "Se cargaron los archivos";
            return RedirectToAction("Index");

        }
    }
}