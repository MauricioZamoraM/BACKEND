using API_CRUD.Models.ListarPagos;
using API_CRUD.Data;
namespace API_CRUD.Logic.ListarPagosAplicados
{
    public class ListarPagosAplicados
    {
        public ConnectionDB _dbConnector = new ConnectionDB();


        public async Task<object> ListarPagosAplicadosRespuesta()
        {
            ModelListarPagosAplicadosRespuesta respuesta = new ModelListarPagosAplicadosRespuesta();

            try
            {
                respuesta = await new ListarPagosAplicados().ObtenerPagosAplicadosRespuesta();

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

        public async Task<ModelListarPagosAplicadosRespuesta> ObtenerPagosAplicadosRespuesta()
          {
              ModelListarPagosAplicadosRespuesta  _getResponse = _dbConnector.ObtenerPagosAplicados();
              return _getResponse;
          }

    }
}
