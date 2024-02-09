namespace API_CRUD.Models.ListarPagos
{
    public class ListarPagosRespuesta
    {
        public List<ListarPagos> listPagos { get; set; }

        public ListarPagosRespuesta()
        {
            listPagos = new List<ListarPagos>();
        }
    }

    public class ListarPagos
    {
        public int id { get; set; }
        public string identificacionCliente { get; set; }
        public string nombreCliente { get; set; }
        public decimal monto { get; set; }
        public DateTime fecha { get; set; }
        public int estado { get; set; }
    }
}