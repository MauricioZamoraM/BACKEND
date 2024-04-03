namespace API_CRUD.Models.TipoSolicitud
{
    public class ObtenerSolicitudResponse
    {
        public List<ObtenerSolicitud> listTipoSolicitud { get; set; }
        public string respuesta_tipo { get; set; }

        public ObtenerSolicitudResponse()
        {
            listTipoSolicitud = new List<ObtenerSolicitud>();
        }
    }

    public class ObtenerSolicitud
    {
        public int tso_id { get; set; }
        public string tso_nombre { get; set; }
        public int tso_estado { get; set; }
    }
}

