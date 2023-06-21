using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CursoMVC.Controllers;
using CursoMVC.Models;

namespace CursoMVC.Filters
{
    public class VerifySession : ActionFilterAttribute // Debe de heredar de esta clase para indicar que es un filtro, este filtro es para verificar la sesion,la peticion al servidor pasa primero por el filtro si el usuario es correcto para al controlador sino lo devuelve al login
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext) //Este filtro entra antes del controller
        {
            var oUser = (usuarios)HttpContext.Current.Session["User"]; // Evalua la sesion

            if (oUser == null) // Si es null
            {
                if (filterContext.Controller is AccessController == false) // Evalua si el controller al que iba es diferente al access controller
                {
                    filterContext.HttpContext.Response.Redirect("~/Access/Index"); // Nos redirecciona al login
                }
            }
            else
            {
                if (filterContext.Controller is AccessController == true) // Evalua si el controller al que iba es diferente al access controller
                {
                    filterContext.HttpContext.Response.Redirect("~/Home/Index"); // Nos redirecciona al login
                }
            }
            // Si la segunda condicion no se cumple, significa que el controller al que va es igual al access controller por lo tanto puede continuar con el proceso
            base.OnActionExecuting(filterContext); // Se llama al metodo OnActionExecuting
        }
    }
}