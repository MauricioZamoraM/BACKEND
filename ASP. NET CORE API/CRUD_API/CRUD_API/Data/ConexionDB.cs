using System.Data;
using API_CRUD.Models.PagosAplicados;
using System.Data.SqlClient;
using API_CRUD.Models.ListarPagos;
using API_CRUD.Models.TipoSolicitud;

namespace API_CRUD.Data
{
    public class ConnectionDB
    {

        public string ActiveEnvironment()
        {
            string env = Utils.Get_Configuration_Key("Environment:active");
            return env;
        }

        public ListarPagosRespuesta ListarPagos()
        {
            ListarPagosRespuesta results = new ListarPagosRespuesta();
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
                                var respuesta = new ListarPagos
                                {
                                    id = (int)reader["id"],
                                    identificacionCliente = (string)reader["identificacionCliente"],
                                    nombreCliente = (string)reader["nombreCliente"],
                                    monto = (decimal)reader["monto"],
                                    fecha = (DateTime)reader["fecha"],
                                    estado = Convert.ToInt32(reader["estado"])
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

        public ObtenerPagoRespuesta ObtenerPago(ObtenerPagoRequest request)
        {
            ObtenerPagoRespuesta results = new ObtenerPagoRespuesta();
            string connectionString = Utils.Get_Connection_String(ActiveEnvironment());

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sqlcommand = "EXEC SP_OBTENER_PAGO_APLICADO @id";

                    using (SqlCommand command = new SqlCommand(sqlcommand, connection))
                    {
                        command.Parameters.AddWithValue("@id", request.id);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var respuesta = new ObtenerPagoRespuesta
                                {
                                    tso_id = (int)reader["tso_id"],
                                    tso_nombre = (string)reader["tso_nombre"],
                                    tso_estado = Convert.ToInt32(reader["tso_estado"])

                                };

                                results = respuesta;
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

        public ListarSolicitudResponse ListarSolicitud()
        {
            ListarSolicitudResponse results = new ListarSolicitudResponse();
            string connectionString = Utils.Get_Connection_String(ActiveEnvironment());

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sqlcommand = "EXEC SP_OBTENER_TIPO_SOLICITUD_LISTAR";

                    using (SqlCommand command = new SqlCommand(sqlcommand, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var respuesta = new ListarSolicitud
                                {
                                    tso_id = (int)reader["tso_id"],
                                    tso_nombre = (string)reader["tso_nombre"],
                                    tso_estado = Convert.ToInt32(reader["tso_estado"])
                                };

                                results.listTipoSolicitud.Add(respuesta);
                                results.respuesta_tipo = "success";

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

        public ObtenerSolicitudResponse ObtenerSolicitud(string tiposolicitud_id)
        {
            ObtenerSolicitudResponse results = new ObtenerSolicitudResponse();
            string connectionString = Utils.Get_Connection_String(ActiveEnvironment());

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sqlcommand = "EXEC SP_OBTENER_TIPO_SOLICITUD @id";

                    using (SqlCommand command = new SqlCommand(sqlcommand, connection))
                    {
                        command.Parameters.AddWithValue("@id", Convert.ToInt32(tiposolicitud_id));

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var respuesta = new ObtenerSolicitud
                                {
                                    tso_id = (int)reader["tso_id"],
                                    tso_nombre = (string)reader["tso_nombre"],
                                    tso_estado = Convert.ToInt32(reader["tso_estado"])

                                };

                                results.listTipoSolicitud.Add(respuesta);
                                results.respuesta_tipo = "success";
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

        public AgregarSolicitudResponse AgregarSolicitud(AgregarSolicitudRequest request)
        {
            AgregarSolicitudResponse results = new AgregarSolicitudResponse();
            string connectionString = Utils.Get_Connection_String(ActiveEnvironment());

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sqlcommand = "EXEC SP_AGREGA_TIPO_SOLICITUD @tso_nombre, @tso_estado";

                    using (SqlCommand command = new SqlCommand(sqlcommand, connection))
                    {
                        command.Parameters.AddWithValue("@tso_nombre", request.tso_nombre);
                        command.Parameters.AddWithValue("@tso_estado", Convert.ToInt32(request.tso_estado));

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var respuesta = new ListaSolicitudesAgregar
                                {
                                    tso_nombre = (string)reader["tso_nombre"],
                                    tso_estado = Convert.ToInt32(reader["tso_estado"])

                                };

                                results.solicitudes.Add(respuesta);
                            }
                        }

                        results.respuesta_tipo = "success";
                        results.mensaje = "";
                    }
                }

            }
            catch (Exception ex)
            {
                results.respuesta_tipo = "failed";
                results.mensaje = "Error en la inserción: " + ex.Message;
                throw;
            }
            return results;
        }

        public ActualizarSolicitudResponse ActualizarSolicitud(ActualizarSolicitudRequest request)
        {
            ActualizarSolicitudResponse results = new ActualizarSolicitudResponse();

            string connectionString = Utils.Get_Connection_String(ActiveEnvironment());

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sqlcommand = "EXEC SP_ACTUALIZA_TIPO_SOLICITUD @tso_id, @tso_nombre, @tso_estado";

                    using (SqlCommand command = new SqlCommand(sqlcommand, connection))
                    {
                        command.Parameters.AddWithValue("@tso_id", request.tso_id);
                        command.Parameters.AddWithValue("@tso_nombre", request.tso_nombre);
                        command.Parameters.AddWithValue("@tso_estado", Convert.ToInt32(request.tso_estado));

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var respuesta = new ListaSolicitudesActualizar
                                {
                                    tso_id = (int)reader["tso_id"],
                                    tso_nombre = (string)reader["tso_nombre"],
                                    tso_estado = Convert.ToInt32(reader["tso_estado"])

                                };

                                results.solicitudes.Add(respuesta);
                            }
                        }

                        results.respuesta_tipo = "success";
                        results.mensaje = "";
                    }
                }

            }
            catch (Exception ex)
            {
                results.respuesta_tipo = "failed";
                results.mensaje = "Error en la inserción: " + ex.Message;
                throw;
            }
            return results;
        }

        public AgregarActualizarSolicitudResponse AgregarActualizarSolicitud(AgregarActualizarSolicitudRequest request)
        {
            AgregarActualizarSolicitudResponse results = new AgregarActualizarSolicitudResponse();

            string connectionString = Utils.Get_Connection_String(ActiveEnvironment());

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sqlcommand = "EXEC SP_AGREGA_ACTUALIZA_TIPO_SOLICITUD @tso_id, @tso_nombre, @tso_estado";

                    using (SqlCommand command = new SqlCommand(sqlcommand, connection))
                    {
                        command.Parameters.AddWithValue("@tso_id", request.tso_id);
                        command.Parameters.AddWithValue("@tso_nombre", request.tso_nombre);
                        command.Parameters.AddWithValue("@tso_estado", Convert.ToInt32(request.tso_estado));

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var respuesta = new ListaSolicitudesAgregarActualizar
                                {
                                    tso_id = (int)reader["tso_id"],
                                    tso_nombre = (string)reader["tso_nombre"],
                                    tso_estado = Convert.ToInt32(reader["tso_estado"])

                                };

                                results.solicitudes.Add(respuesta);
                            }
                        }

                        results.respuesta_tipo = "success";
                        results.mensaje = "";
                    }
                }

            }
            catch (Exception ex)
            {
                results.respuesta_tipo = "failed";
                results.mensaje = "Error en la inserción: " + ex.Message;
                throw;
            }
            return results;
        }
    }
}
