using API_CRUD.Logic.PagosAplicados;
using API_CRUD.Models.PagosAplicados;
using API_CRUD.Logic.ObtenerSolicitud;
using API_CRUD.Models.TipoSolicitud;
using API_CRUD.Logic.TipoSolicitud;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
namespace API_CRUD.Controllers
{
    public class TipoSolicitudesController : Controller
    {
        [HttpGet]
        [Route("api/listarTipoSolicitud")]
        public async Task<object> ListarSolicitud()
        {
            return await new ListarTipoSolicitud().ListarTipoSolicitudRespuesta();
        }

        [HttpPost]
        [Route("api/obtenerTipoSolicitud/{tiposolicitud_id}")]
        public async Task<object> ObtenerSolicitud(string tiposolicitud_id)
        {
            return await new ObtenerTipoSolicitud().ObtenerTipoSolicitudRespuesta(tiposolicitud_id);
        }

        [HttpPost]
        [Route("api/agregarTipoSolicitud")]
        public async Task<object> AgregarSolicitud([FromBody] AgregarSolicitudRequest request)
        {
            return await new AgregarTipoSolicitud().AgregarTipoSolicitudRespuesta(request);
        }
    }
}
