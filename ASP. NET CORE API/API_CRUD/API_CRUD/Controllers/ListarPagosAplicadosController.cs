using API_CRUD.Logic.ListarPagosAplicados;
using Microsoft.AspNetCore.Mvc;

namespace API_CRUD.Controllers
{

    public class ListarPagosController : ControllerBase
    {
        [HttpGet]
        [Route("api/listarPagos")]
        public async Task<object> ListarPagosAplicados()
        {
            return await new ListarPagosAplicados().ListarPagosAplicadosRespuesta();
        }
    }
}