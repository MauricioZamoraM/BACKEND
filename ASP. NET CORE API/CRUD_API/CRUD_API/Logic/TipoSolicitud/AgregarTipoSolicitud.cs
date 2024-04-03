using API_CRUD.Data;
using API_CRUD.Models.TipoSolicitud;

namespace API_CRUD.Logic.TipoSolicitud
{
    public class AgregarTipoSolicitud
    {
        public ConnectionDB _dbConnector = new ConnectionDB();

        public async Task<object> AgregarTipoSolicitudRespuesta(AgregarSolicitudRequest request)
        {
            AgregarSolicitudResponse respuesta = new AgregarSolicitudResponse();

            try
            {
                respuesta = await new AgregarTipoSolicitud().AgregaTipoSolicitud(request);

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

        public async Task<AgregarSolicitudResponse> AgregaTipoSolicitud(AgregarSolicitudRequest resquest)
        {
            AgregarSolicitudResponse _getResponse = _dbConnector.AgregarSolicitud(resquest);
            return _getResponse;
        }
    }
}
