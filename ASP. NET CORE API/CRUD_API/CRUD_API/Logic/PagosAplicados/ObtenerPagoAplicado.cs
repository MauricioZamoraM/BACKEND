using API_CRUD.Data;
using API_CRUD.Models.PagosAplicados;

namespace API_CRUD.Logic.PagosAplicados
{
    public class ObtenerPagoAplicado
    {
        public ConnectionDB _dbConnector = new ConnectionDB();

        public async Task<object> ObtenerPagoAplicadoRespuesta(ObtenerPagoRequest request)
        {
            ObtenerPagoRespuesta respuesta = new ObtenerPagoRespuesta();

            try
            {
                respuesta = await new ObtenerPagoAplicado().ObtienePagoAplicado(request);

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

        public async Task<ObtenerPagoRespuesta> ObtienePagoAplicado(ObtenerPagoRequest request)
        {
            ObtenerPagoRespuesta _getResponse = _dbConnector.ObtenerPago(request);
            return _getResponse;
        }
    }
}
