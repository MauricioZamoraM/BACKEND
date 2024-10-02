using API_CRUD.Data;
using API_CRUD.Models.TipoSolicitud;

namespace API_CRUD.Logic.TipoSolicitud
{
    public class ActualizarTipoSolicitud
    {
        public ConnectionDB _dbConnector = new ConnectionDB();

        public async Task<object> ActualizarTipoSolicitudRespuesta(ActualizarSolicitudRequest request)
        {
            ActualizarSolicitudResponse respuesta = new ActualizarSolicitudResponse();

            try
            {
                respuesta = await new ActualizarTipoSolicitud().ActualizaTipoSolicitud(request);

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

        public async Task<ActualizarSolicitudResponse> ActualizaTipoSolicitud(ActualizarSolicitudRequest resquest)
        {
            ActualizarSolicitudResponse _getResponse = _dbConnector.ActualizarSolicitud(resquest);
            return _getResponse;
        }
    }
}
