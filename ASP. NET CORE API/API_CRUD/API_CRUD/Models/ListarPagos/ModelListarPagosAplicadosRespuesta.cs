namespace API_CRUD.Models.ListarPagos
{
    public class ModelListarPagosAplicadosRespuesta
    {
        public List<ModelListarPagosRespuesta> listPagos { get; set; }

        public ModelListarPagosAplicadosRespuesta()
        {
            listPagos = new List<ModelListarPagosRespuesta>();
        }
    }


    public class ModelListarPagosRespuesta
    {
        public int id { get; set; }
        public string identificacionCliente { get; set; }
        public string nombreCliente { get; set; }
        public decimal monto { get; set; }
        public DateTime fecha { get; set; }
        public int numTelefonoDestino { get; set; }
    }

}
