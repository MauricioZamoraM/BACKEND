namespace API_CRUD.Models.TipoSolicitud
{
    public class AgregarSolicitudResponse
    {
        public string respuesta_tipo { get; set; }
        public string mensaje { get; set; }
        public List<ListaSolicitudesAgregar> solicitudes { get; set; }
        public AgregarSolicitudResponse()
        {
            solicitudes = new List<ListaSolicitudesAgregar>();
        }
    }

    public class ListaSolicitudesAgregar
    {
        public int tso_id { get; set; }
        public string tso_nombre { get; set; }
        public int tso_estado { get; set; }
    }

}
