namespace NetCoreYouTube.Models
{
    public class Usuario
    {
        public string idUsuario { get; set; }
        public string usuario { get; set; }
        public string password { get; set; }
        public string rol { get; set; }
        public static List<Usuario> DB()
        {
            var list = new List<Usuario>();

            list.Add(new Usuario
            {
                idUsuario = "1",
                usuario = "Mateo",
                password = "123",
                rol = "empleado"
            });

            list.Add(new Usuario
            {
                idUsuario = "2",
                usuario = "Marcos",
                password = "123",
                rol = "empleado"
            });

            list.Add(new Usuario
            {
                idUsuario = "3",
                usuario = "Lucas",
                password = "123",
                rol = "asesor"
            });

            list.Add(new Usuario
            {
                idUsuario = "4",
                usuario = "Juan",
                password = "123Davivienda",
                rol = "Administrador"
            });

            return list;
        }

    }
}
