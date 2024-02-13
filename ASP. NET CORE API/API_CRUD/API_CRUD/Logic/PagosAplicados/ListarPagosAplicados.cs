using API_CRUD.Models.ListarPagos;
using API_CRUD.Data;
namespace API_CRUD.Logic.PagosAplicados
{
    public class ListarPagosAplicados
    {
        public ConnectionDB _dbConnector = new ConnectionDB();


        public async Task<object> ListarPagosAplicadosRespuesta()
        {
            ListarPagosRespuesta respuesta = new ListarPagosRespuesta();

            try
            {
                respuesta = await new ListarPagosAplicados().ListaPagosAplicados();

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

        public async Task<ListarPagosRespuesta> ListaPagosAplicados()
          {
            ListarPagosRespuesta _getResponse = _dbConnector.ListarPagos();
              return _getResponse;
          }

    }
}
