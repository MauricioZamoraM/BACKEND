using System.Data;
using API_CRUD.Models.PagosAplicados;
using System.Data.SqlClient;
using API_CRUD.Models.ListarPagos;

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

        //public ModelAplicarPagosEnvioPagosOfflineRespuestaDavivienda AplicarPagosEnvioPagosOffline(Credito CreditoActivo, ModelAplicarPagosDavivienda resConsulta, DatosConfiguracionRecaudadora datosConfiguracion, string estado, string TipoNumeroDoc)
        //{
        //    PoolTransaccion transaccion = new PoolTransaccion();
        //    ModelAplicarPagosEnvioPagosOfflineRespuestaDavivienda response = new ModelAplicarPagosEnvioPagosOfflineRespuestaDavivienda();

        //    try
        //    {
        //        string connectionString = Utils.Desencrypt(Utils.Get_Connection_String(ActiveEnvironment()));
        //        using (SqlConnection connection = new SqlConnection(connectionString))
        //        {
        //            connection.Open();

        //            string insertQuery = "EXECUTE [dbo].[DaviviendaInsertarInformacionPagosOff] @codReferencia,@tra_id_factura,@tra_nit,@tra_cuenta, @tra_tipo_doc ,@tra_numero_doc ,@tra_estado ,@tra_fecha_pago ,@tra_contrato ,@tra_agencia ,@tra_enviado ,@tra_periodo ,@tra_id ,@tra_centro ,@tra_codigo_dispersion ,@tra_vencimiento ,@tra_nombre ,@tra_valor ,@tra_cliente ,@tra_banco ,@tra_consecutivo_consulta ,@tra_valor_cuota ,@tra_valor_vencido ,@tra_estado_reversion ,@tra_id_pago ,@estado";
        //            using (SqlCommand command = new SqlCommand(insertQuery, connection))
        //            {

        //                if (CreditoActivo._mensajeRespuesta == "El cliente tiene 1 credito" || (CreditoActivo._tipo_doc + CreditoActivo._numero_doc) == TipoNumeroDoc)
        //                {
        //                    // Establecer parametros para desserializar 
        //                    command.Parameters.AddWithValue("@codReferencia", resConsulta.CodReferencia);
        //                    command.Parameters.AddWithValue("@tra_id_factura", Convert.ToDecimal(resConsulta.CodReferenciaBanco));
        //                    command.Parameters.AddWithValue("@tra_nit", Convert.ToDecimal(CreditoActivo._nit)); //tranit es decimal en informa _nit es string
        //                    command.Parameters.AddWithValue("@tra_cuenta", CreditoActivo._cuenta);//lenght 12
        //                    command.Parameters.AddWithValue("@tra_tipo_doc", CreditoActivo._tipo_doc);
        //                    command.Parameters.AddWithValue("@tra_numero_doc", Convert.ToInt32(CreditoActivo._numero_doc));
        //                    command.Parameters.AddWithValue("@tra_estado", datosConfiguracion.tra_estado); //Por defecto A
        //                    command.Parameters.AddWithValue("@tra_fecha_pago", resConsulta.Fecha);
        //                    command.Parameters.AddWithValue("@tra_contrato", datosConfiguracion.tra_contrato);//Datos de recuadadora 
        //                    command.Parameters.AddWithValue("@tra_agencia", datosConfiguracion.tra_agencia);//Datos de recuadadora 
        //                    command.Parameters.AddWithValue("@tra_enviado", Convert.ToString(datosConfiguracion.tra_enviado));//Debe ser cero
        //                    command.Parameters.AddWithValue("@tra_periodo", resConsulta.Fecha);
        //                    command.Parameters.AddWithValue("@tra_id", datosConfiguracion.tra_id);//Numero de intentos de transaccion
        //                    command.Parameters.AddWithValue("@tra_centro", CreditoActivo._centro);
        //                    command.Parameters.AddWithValue("@tra_codigo_dispersion", datosConfiguracion.tra_codigo_dispersion);//Debe ser 1 por defecto
        //                    command.Parameters.AddWithValue("@tra_vencimiento", CreditoActivo._fech_venci);
        //                    command.Parameters.AddWithValue("@tra_nombre", CreditoActivo._nombre);
        //                    command.Parameters.AddWithValue("@tra_valor", resConsulta.Monto);
        //                    command.Parameters.AddWithValue("@tra_cliente", datosConfiguracion.tra_cliente);//Datos de recuadadora 
        //                    command.Parameters.AddWithValue("@tra_banco", datosConfiguracion.tra_banco);//Datos de recuadadora 
        //                    command.Parameters.AddWithValue("@tra_consecutivo_consulta", transaccion.tra_consecutivo_consulta ?? (object)DBNull.Value);
        //                    command.Parameters.AddWithValue("@tra_valor_cuota", CreditoActivo._valcuota);
        //                    command.Parameters.AddWithValue("@tra_valor_vencido", CreditoActivo._valorvencido);
        //                    command.Parameters.AddWithValue("@tra_estado_reversion", transaccion.tra_estado_reversion ?? (object)DBNull.Value);
        //                    command.Parameters.AddWithValue("@tra_id_pago", transaccion.tra_id_pago/*Convert.ToInt64(resConsulta.CodReferenciaBanco)*/);
        //                    command.Parameters.AddWithValue("@estado", estado ?? (object)DBNull.Value);


        //                }

        //                //int rowsAffected = 
        //                command.ExecuteNonQuery();
        //                response.success = true;
        //                response.mensaje = "Agregado";
        //                /* if (rowsAffected == -1)
        //                {
        //                    return new ModelAplicarPagosEnvioPagosOfflineRespuestaDavivienda
        //                    {
        //                        success = true,
        //                        Mensaje = "Se insertó el registro de forma exitosa",
        //                    };
        //                }
        //                else
        //                {
        //                    return new ModelAplicarPagosEnvioPagosOfflineRespuestaDavivienda
        //                    {
        //                        success = true,
        //                        Mensaje = "No se insertó el registro",
        //                    };
        //                }*/
        //            }
        //        }

        //    }
        //    catch (Exception ex)
        //    {

        //        response.success = false;
        //        response.mensaje = "Error en la inserción: " + ex.Message;

        //    }
        //    return response;
        //}


    }
}
