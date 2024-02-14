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
        [Route("api/ListarTipoSolicitud")]
        public async Task<object> ListarSolicitud()
        {
            return await new ListarTipoSolicitud().ListarTipoSolicitudRespuesta();
        }

        [HttpPost]
        [Route("api/ObtenerTipoSolicitud/{tiposolicitud_id}")]
        public async Task<object> ObtenerSolicitud(string tiposolicitud_id)
        {
            return await new ObtenerTipoSolicitud().ObtenerTipoSolicitudRespuesta(tiposolicitud_id);
        }

        [HttpPost]
        [Route("api/ActualizarTipoSolicitud")]
        public async Task<object> ActualizarSolicitud([FromBody] ActualizarSolicitudRequest request)
        {
            return await new ActualizarTipoSolicitud().ActualizarTipoSolicitudRespuesta(request);
        }

        [HttpPost]
        [Route("api/AgregarTipoSolicitud")]
        public async Task<object> AgregarSolicitud([FromBody] AgregarSolicitudRequest request)
        {
            return await new AgregarTipoSolicitud().AgregarTipoSolicitudRespuesta(request);
        }

        [HttpPost]
        [Route("api/AgregaActualizaTipoSolicitud")]
        public async Task<object> AgregaActualizaSolicitud([FromBody] AgregarActualizarSolicitudRequest request)
        {
            return await new AgregarActualizarTipoSolicitud().AgregarActualizarTipoSolicitudRespuesta(request);
        }
    }
}
