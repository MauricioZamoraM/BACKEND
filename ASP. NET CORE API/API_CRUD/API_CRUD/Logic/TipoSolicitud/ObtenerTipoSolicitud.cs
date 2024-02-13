using API_CRUD.Data;
using API_CRUD.Logic.PagosAplicados;
using API_CRUD.Models.PagosAplicados;
using API_CRUD.Models.TipoSolicitud;

namespace API_CRUD.Logic.TipoSolicitud
{
    public class ObtenerTipoSolicitud
    {
        public ConnectionDB _dbConnector = new ConnectionDB();

        public async Task<object> ObtenerTipoSolicitudRespuesta(string tiposolicitud_id)
        {
            ObtenerSolicitudResponse respuesta = new ObtenerSolicitudResponse();

            try
            {
                respuesta = await new ObtenerTipoSolicitud().ObtieneTipoSolicitud(tiposolicitud_id);

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

        public async Task<ObtenerSolicitudResponse> ObtieneTipoSolicitud(string tiposolicitud_id)
        {
            ObtenerSolicitudResponse _getResponse = _dbConnector.ObtenerSolicitud(tiposolicitud_id);
            return _getResponse;
        }
    }
}
