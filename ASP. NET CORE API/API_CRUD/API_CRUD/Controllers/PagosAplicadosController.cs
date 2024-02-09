using API_CRUD.Logic.PagosAplicados;
using API_CRUD.Models.PagosAplicados;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace API_CRUD.Controllers
{

    public class ListarPagosController : ControllerBase
    {
        [HttpGet]
        [Route("api/listarPagos")]
        public async Task<object> ListarPagos()
        {
            return await new ListarPagosAplicados().ListarPagosAplicadosRespuesta();
        }

        [HttpPost]
        [Route("api/obtenerPago")]
        public async Task<object> ObtenerPago([FromBody] ObtenerPagoRequest request)
        {
            return await new ObtenerPagoAplicado().ObtenerPagoAplicadoRespuesta(request);
        }

    }
}