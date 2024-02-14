namespace API_CRUD.Models.TipoSolicitud
{
    public class ActualizarSolicitudResponse
    {
        public string respuesta_tipo { get; set; }
        public string mensaje { get; set; }
        public List<ListaSolicitudesActualizar> solicitudes { get; set; }
        public ActualizarSolicitudResponse()
        {
            solicitudes = new List<ListaSolicitudesActualizar>();
        }
    }

    public class ListaSolicitudesActualizar
    {
        public int tso_id { get; set; }
        public string tso_nombre { get; set; }
        public int tso_estado { get; set; }
    }

}
