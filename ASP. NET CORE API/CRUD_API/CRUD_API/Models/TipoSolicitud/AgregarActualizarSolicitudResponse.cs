namespace API_CRUD.Models.TipoSolicitud
{
    public class AgregarActualizarSolicitudResponse
    {
        public string respuesta_tipo { get; set; }
        public string mensaje { get; set; }
        public List<ListaSolicitudesAgregarActualizar> solicitudes { get; set; }
        public AgregarActualizarSolicitudResponse()
        {
            solicitudes = new List<ListaSolicitudesAgregarActualizar>();
        }
    }

    public class ListaSolicitudesAgregarActualizar
    {
        public int tso_id { get; set; }
        public string tso_nombre { get; set; }
        public int tso_estado { get; set; }
    }
}

