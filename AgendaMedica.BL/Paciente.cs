using System;

namespace AgendaMedica_BL
{
    public class Paciente
    {
        public int IdPaciente { get; set; }
        public string Identificacion { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public string Estado { get; set; }
    }
}