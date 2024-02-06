using System.Data;
using API_CRUD.Models.ListarPagos;
using System.Data.SqlClient;

namespace API_CRUD.Data
{
    public class ConnectionDB
    {

        public string ActiveEnvironment()
        {
            string env = Utils.Get_Configuration_Key("Environment:active");
            return env;
        }

        public ModelListarPagosAplicadosRespuesta ObtenerPagosAplicados()
        {
            ModelListarPagosAplicadosRespuesta results = new ModelListarPagosAplicadosRespuesta();
            string connectionString = Utils.Get_Connection_String(ActiveEnvironment());

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sqlcommand = "EXEC SP_PAGOS_APLICADOS_LISTAR";

                    using (SqlCommand command = new SqlCommand(sqlcommand, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var respuesta = new ModelListarPagosRespuesta
                                {
                                    id = (int)reader["id"],
                                    identificacionCliente = (string)reader["identificacionCliente"],
                                    nombreCliente = (string)reader["nombreCliente"],
                                    monto = (decimal)reader["monto"],
                                    fecha = (DateTime)reader["fecha"]
                                };

                                results.listPagos.Add(respuesta);
                            }
                        }
                    }
                }

                return results;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

    }
}
