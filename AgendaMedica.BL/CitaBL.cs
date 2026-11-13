using System;
using System.Data;
using AgendaMedica_DAL;

namespace AgendaMedica_BL
{
    // Reglas de negocio de las citas del hospital privado Medical Dreams.
    public class CitaBL
    {
        private readonly CitaDAL dal = new CitaDAL();

        public const int DuracionMinima = 10;
        public const int DuracionMaxima = 120;
        public const int DuracionPorDefecto = 30;

        public static readonly string[] Gravedades = { "Muy leve", "Leve", "Moderado", "Urgente" };

        // ---------- Consultas para la interfaz ----------

        public DataTable ObtenerTodas() { return dal.ObtenerTodas(); }
        public DataTable ObtenerMedicos() { return dal.ObtenerMedicos(); }
        public DataTable ObtenerPacientes() { return dal.ObtenerPacientesActivos(); }

        // Médicos que atienden citas y que trabajan durante todo el rango de la cita.
        public DataTable ObtenerMedicosDisponibles(DateTime inicio, int duracionMin)
        {
            return dal.ObtenerMedicosDisponibles(inicio, inicio.AddMinutes(duracionMin));
        }

        // ---------- Operaciones ----------

        public void Agendar(Cita c)
        {
            Normalizar(c);
            c.IdCita = 0;
            ValidarCita(c, 0);

            if (dal.Insertar(c.IdPaciente, c.IdMedico, c.FechaHoraInicio, c.DuracionMin,
                    c.Motivo, c.Gravedad, c.Observaciones) != 1)
                throw new Exception("No se pudo agendar la cita.");
        }

        // Reprogramar o corregir una cita que todavía no se atendió ni se canceló.
        public void Actualizar(Cita c)
        {
            if (c.IdCita <= 0)
                throw new Exception("Seleccione una cita de la tabla.");

            string estado = EstadoActual(c.IdCita);
            if (estado != "Programada" && estado != "Confirmada")
                throw new Exception("Solo se pueden modificar citas Programadas o Confirmadas.");

            Normalizar(c);
            ValidarCita(c, c.IdCita);

            if (dal.Actualizar(c.IdCita, c.IdPaciente, c.IdMedico, c.FechaHoraInicio,
                    c.DuracionMin, c.Motivo, c.Gravedad, c.Observaciones) != 1)
                throw new Exception("No se pudo actualizar la cita.");
        }

        public void Confirmar(int idCita)
        {
            CambiarEstado(idCita, "Confirmada");
        }

        public void Cancelar(int idCita)
        {
            CambiarEstado(idCita, "Cancelada");
        }

        // El médico registra diagnóstico y observaciones; la cita pasa a Atendida.
        public void Evaluar(int idCita, string diagnostico, string observaciones)
        {
            if (idCita <= 0)
                throw new Exception("Seleccione una cita de la tabla.");

            if (EstadoActual(idCita) != "Confirmada")
                throw new Exception("Solo se puede evaluar una cita Confirmada.");

            diagnostico = (diagnostico ?? "").Trim();
            observaciones = (observaciones ?? "").Trim();

            if (diagnostico.Length == 0 || diagnostico.Length > 200)
                throw new Exception("El diagnóstico es obligatorio (máximo 200 caracteres).");
            if (observaciones.Length > 500)
                throw new Exception("Las observaciones no pueden superar 500 caracteres.");

            if (dal.GuardarEvaluacion(idCita, diagnostico, observaciones) != 1)
                throw new Exception("No se pudo guardar la evaluación.");
        }

        // ---------- Reglas ----------

        // Estados: Programada -> Confirmada -> Atendida; Cancelada desde Programada o Confirmada.
        // Atendida y Cancelada son finales.
        private void CambiarEstado(int idCita, string nuevo)
        {
            if (idCita <= 0)
                throw new Exception("Seleccione una cita de la tabla.");

            string actual = EstadoActual(idCita);
            if (!TransicionValida(actual, nuevo))
                throw new Exception("No se puede pasar una cita de " + actual + " a " + nuevo + ".");

            if (dal.CambiarEstado(idCita, nuevo) != 1)
                throw new Exception("No se pudo cambiar el estado de la cita.");
        }

        private static bool TransicionValida(string actual, string nuevo)
        {
            switch (actual)
            {
                case "Programada": return nuevo == "Confirmada" || nuevo == "Cancelada";
                case "Confirmada": return nuevo == "Atendida" || nuevo == "Cancelada";
                default: return false;
            }
        }

        private string EstadoActual(int idCita)
        {
            string estado = dal.ObtenerEstado(idCita);
            if (estado == null)
                throw new Exception("La cita seleccionada no existe.");
            return estado;
        }

        private void ValidarCita(Cita c, int idExcluir)
        {
            if (c.IdPaciente <= 0)
                throw new Exception("Seleccione un paciente.");
            if (c.IdMedico <= 0)
                throw new Exception("Seleccione un médico.");

            if (c.Motivo.Length == 0 || c.Motivo.Length > 200)
                throw new Exception("El motivo de la consulta es obligatorio (máximo 200 caracteres).");
            if (c.Observaciones.Length > 500)
                throw new Exception("Las observaciones no pueden superar 500 caracteres.");

            if (Array.IndexOf(Gravedades, c.Gravedad) < 0)
                throw new Exception("Seleccione una gravedad válida.");

            if (c.DuracionMin < DuracionMinima || c.DuracionMin > DuracionMaxima)
                throw new Exception("La duración debe estar entre " + DuracionMinima +
                    " y " + DuracionMaxima + " minutos.");

            if (c.FechaHoraInicio <= DateTime.Now)
                throw new Exception("La cita debe programarse en una fecha y hora futuras.");

            if (!dal.PacienteActivo(c.IdPaciente))
                throw new Exception("El paciente no existe o está inactivo.");

            if (!dal.MedicoActivo(c.IdMedico))
                throw new Exception("El profesional no existe, está inactivo o su rol no atiende citas.");

            if (!dal.MedicoTieneTurno(c.IdMedico, c.FechaHoraInicio, c.FechaHoraFin))
                throw new Exception("El médico no tiene un turno asignado que cubra ese horario.");

            if (dal.HaySolapamiento(c.IdMedico, c.FechaHoraInicio, c.FechaHoraFin, idExcluir))
                throw new Exception("El médico ya tiene otra cita en ese horario.");
        }

        private static void Normalizar(Cita c)
        {
            c.Motivo = (c.Motivo ?? "").Trim();
            c.Gravedad = (c.Gravedad ?? "").Trim();
            c.Observaciones = (c.Observaciones ?? "").Trim();
            if (c.DuracionMin == 0)
                c.DuracionMin = DuracionPorDefecto;
        }
    }
}