using API_CRUD.Data;
using API_CRUD.Models.TipoSolicitud;

namespace API_CRUD.Logic.TipoSolicitud
{
    public class AgregarActualizarTipoSolicitud
    {
        public ConnectionDB _dbConnector = new ConnectionDB();

        public async Task<object> AgregarActualizarTipoSolicitudRespuesta(AgregarActualizarSolicitudRequest request)
        {
            AgregarActualizarSolicitudResponse respuesta = new AgregarActualizarSolicitudResponse();

            try
            {
                respuesta = await new AgregarActualizarTipoSolicitud().AgregaActualizaTipoSolicitud(request);

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

        public async Task<AgregarActualizarSolicitudResponse> AgregaActualizaTipoSolicitud(AgregarActualizarSolicitudRequest resquest)
        {
            AgregarActualizarSolicitudResponse _getResponse = _dbConnector.AgregarActualizarSolicitud(resquest);
            return _getResponse;
        }
    }
}
