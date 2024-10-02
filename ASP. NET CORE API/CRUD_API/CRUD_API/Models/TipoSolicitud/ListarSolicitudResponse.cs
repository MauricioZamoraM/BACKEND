namespace API_CRUD.Models.TipoSolicitud
{
    public class ListarSolicitudResponse
    {
        public List<ListarSolicitud> listTipoSolicitud { get; set; }
        public string respuesta_tipo { get; set; }

        public ListarSolicitudResponse()
        {
            listTipoSolicitud = new List<ListarSolicitud>();
        }
    }

    public class ListarSolicitud
    {
        public int tso_id {get; set;}
        public string tso_nombre { get; set;}
        public int tso_estado { get; set;}
    }
}
