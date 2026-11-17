using System;
using System.Data;
using AgendaMedica_DAL;

namespace AgendaMedica_BL
{
    // Reglas de negocio de las citas del hospital privado Medical Dreams.
    public class CitaBL
    {
        private readonly CitaDAL dal = new CitaDAL();

        // RN-04: duraciones permitidas, en minutos.
        public static readonly int[] Duraciones = { 30, 45, 60 };
        public const int DuracionPorDefecto = 30;

        // RN-05: modalidades de cita.
        public static readonly string[] Tipos = { "Presencial", "Virtual", "Urgencia" };
        public const string TipoPorDefecto = "Presencial";

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
                    c.Tipo, c.Motivo, c.Gravedad, c.Observaciones) != 1)
                throw new Exception("No se pudo agendar la cita.");
        }

        // Si cambia el médico, la fecha, la hora o la duración, la cita se reprograma:
        // en una sola transacción la original queda como Reprogramada y se crea una nueva.
        // Si el horario no cambia, solo se corrigen los demás datos de la misma cita.
        // Devuelve true si se creó una cita nueva y false si solo se actualizó la existente.
        public bool Reprogramar(Cita c)
        {
            if (c.IdCita <= 0)
                throw new Exception("Seleccione una cita de la tabla.");

            DataRow actual = dal.ObtenerCita(c.IdCita);
            if (actual == null)
                throw new Exception("La cita seleccionada no existe.");

            string estado = Convert.ToString(actual["estado"]);
            if (estado != "Programada" && estado != "Confirmada")
                throw new Exception("Solo se pueden reprogramar citas Programadas o Confirmadas.");

            Normalizar(c);
            // La cita original se excluye de las comprobaciones: va a dejar de estar activa.
            ValidarCita(c, c.IdCita);

            bool mismoHorario =
                Convert.ToInt32(actual["id_medico"]) == c.IdMedico
                && Convert.ToDateTime(actual["fecha_hora_inicio"]) == c.FechaHoraInicio
                && Convert.ToInt32(actual["duracion_min"]) == c.DuracionMin;

            if (mismoHorario)
            {
                if (dal.Actualizar(c.IdCita, c.IdPaciente, c.IdMedico, c.FechaHoraInicio,
                        c.DuracionMin, c.Tipo, c.Motivo, c.Gravedad, c.Observaciones) != 1)
                    throw new Exception("No se pudo actualizar la cita.");
                return false;
            }

            dal.Reprogramar(c.IdCita, c.IdPaciente, c.IdMedico, c.FechaHoraInicio,
                c.DuracionMin, c.Tipo, c.Motivo, c.Gravedad, c.Observaciones);
            return true;
        }

        public void Confirmar(int idCita)
        {
            CambiarEstado(idCita, "Confirmada");
        }

        public void Cancelar(int idCita)
        {
            CambiarEstado(idCita, "Cancelada");
        }

        // RN-07: el paciente no llegó. Solo se puede marcar cuando la hora de la cita ya pasó.
        public void MarcarNoAsistio(int idCita)
        {
            if (idCita <= 0)
                throw new Exception("Seleccione una cita de la tabla.");

            DataRow actual = dal.ObtenerCita(idCita);
            if (actual == null)
                throw new Exception("La cita seleccionada no existe.");

            string estado = Convert.ToString(actual["estado"]);
            if (!TransicionValida(estado, "No asistió"))
                throw new Exception("No se puede pasar una cita de " + estado + " a No asistió.");

            if (Convert.ToDateTime(actual["fecha_hora_inicio"]) > DateTime.Now)
                throw new Exception("Solo se puede marcar No asistió cuando la hora de la cita ya pasó.");

            if (dal.CambiarEstado(idCita, "No asistió") != 1)
                throw new Exception("No se pudo cambiar el estado de la cita.");
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

        // Estados:
        //   Programada -> Confirmada, Cancelada, No asistió, Reprogramada
        //   Confirmada -> Atendida, Cancelada, No asistió, Reprogramada
        //   Atendida, Cancelada, No asistió y Reprogramada son finales.
        // "Reprogramada" solo se asigna mediante Reprogramar(), nunca con CambiarEstado().
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
                case "Programada":
                    return nuevo == "Confirmada" || nuevo == "Cancelada" || nuevo == "No asistió";
                case "Confirmada":
                    return nuevo == "Atendida" || nuevo == "Cancelada" || nuevo == "No asistió";
                default:
                    return false;
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

            if (Array.IndexOf(Tipos, c.Tipo) < 0)
                throw new Exception("Seleccione el tipo de cita: Presencial, Virtual o Urgencia.");

            if (Array.IndexOf(Duraciones, c.DuracionMin) < 0)
                throw new Exception("La duración debe ser de 30, 45 o 60 minutos.");

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

            // RN-03: un paciente no puede tener dos citas simultáneas, ni siquiera con médicos distintos.
            if (dal.PacienteTieneCitaEnRango(c.IdPaciente, c.FechaHoraInicio, c.FechaHoraFin, idExcluir))
                throw new Exception("El paciente ya tiene otra cita en ese horario.");
        }

        private static void Normalizar(Cita c)
        {
            c.Motivo = (c.Motivo ?? "").Trim();
            c.Gravedad = (c.Gravedad ?? "").Trim();
            c.Tipo = (c.Tipo ?? "").Trim();
            c.Observaciones = (c.Observaciones ?? "").Trim();
            if (c.DuracionMin == 0)
                c.DuracionMin = DuracionPorDefecto;
            if (c.Tipo.Length == 0)
                c.Tipo = TipoPorDefecto;
        }

        public void Actualizar(Cita cita)
        {
            throw new NotImplementedException();
        }
    }
}