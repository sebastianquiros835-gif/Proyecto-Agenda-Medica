using System;

namespace AgendaMedica_BL
{
    public class Cita
    {
        public int IdCita { get; set; }
        public int IdPaciente { get; set; }
        public int IdMedico { get; set; }
        public DateTime FechaHoraInicio { get; set; }
        public int DuracionMin { get; set; }
        public string Motivo { get; set; }
        public string Gravedad { get; set; }
        public string Estado { get; set; }
        public string Diagnostico { get; set; }
        public string Observaciones { get; set; }

        // Se calcula igual que la columna fecha_hora_fin de la base de datos.
        public DateTime FechaHoraFin
        {
            get { return FechaHoraInicio.AddMinutes(DuracionMin); }
        }
    }
}