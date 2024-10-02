namespace API_CRUD.Models.TipoSolicitud
{
    public class AgregarActualizarSolicitudRequest
    {
        public int tso_id { get; set; }
        public string tso_nombre { get; set; }
        public int tso_estado { get; set; }
    }
}
