using API_CRUD.Data;
using API_CRUD.Logic.PagosAplicados;
using API_CRUD.Models.ListarPagos;
using API_CRUD.Models.TipoSolicitud;

namespace API_CRUD.Logic.ObtenerSolicitud
{
    public class ListarTipoSolicitud
    {
        public ConnectionDB _dbConnector = new ConnectionDB();


        public async Task<object> ListarTipoSolicitudRespuesta()
        {
            ListarSolicitudResponse respuesta = new ListarSolicitudResponse();

            try
            {
                respuesta = await new ListarTipoSolicitud().ListaTipoSolicitud();

            }
            catch (Exception ex)
            {
                var objResponse = new
                {
                    mensaje = "Error al ejecutar el proceso, favor intentarlo más tarde.",
                    exitoso = false
                };

                return objResponse;

            }

            return respuesta;
        }

        public async Task<ListarSolicitudResponse> ListaTipoSolicitud()
        {
            ListarSolicitudResponse _getResponse = _dbConnector.ListarSolicitud();
            return _getResponse;
        }
    }
}
