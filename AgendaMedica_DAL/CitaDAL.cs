using System;
using System.Data;
using MySql.Data.MySqlClient;

namespace AgendaMedica_DAL
{
    // Acceso a datos del módulo de citas. Solo SQL parametrizado, sin reglas de negocio.
    public class CitaDAL
    {
        // ---------- Consultas para pantallas y combos ----------

        public DataTable ObtenerTodas()
        {
            return Consultar(@"
                SELECT c.id_cita, c.id_paciente, c.id_medico,
                       CONCAT(pa.nombre, ' ', pa.apellido) AS paciente,
                       CONCAT(m.nombre, ' ', m.apellido)   AS medico,
                       c.fecha_hora_inicio, c.duracion_min,
                       c.gravedad, c.estado, c.motivo,
                       c.diagnostico, c.observaciones
                FROM citas c
                INNER JOIN pacientes pa ON c.id_paciente = pa.id_paciente
                INNER JOIN personal  m  ON c.id_medico   = m.id_personal
                ORDER BY c.fecha_hora_inicio");
        }

        // La colación de la base (utf8mb4_0900_ai_ci) ignora tildes y mayúsculas:
        // 'Medico', 'médico' y 'Médico' coinciden con rol = 'Médico'.
        // Personal activo cuyo rol está marcado como "atiende citas" en la tabla roles.
        public DataTable ObtenerMedicos()
        {
            return Consultar(@"
        SELECT p.id_personal,
               CONCAT_WS(' - ', CONCAT(p.nombre, ' ', p.apellido), p.rol)
                   AS nombre_completo
        FROM personal p
        INNER JOIN roles r ON r.nombre = p.rol
        WHERE p.estado = 'Activo' AND r.atiende_citas = 1
        ORDER BY p.nombre, p.apellido");
        }

        public DataTable ObtenerPacientesActivos()
        {
            return Consultar(@"
                SELECT id_paciente,
                       CONCAT(nombre, ' ', apellido) AS nombre_completo
                FROM pacientes
                WHERE estado = 'Activo'
                ORDER BY nombre, apellido");
        }

        // ---------- Comprobaciones que usa la BL para las reglas ----------

        public bool PacienteActivo(int idPaciente)
        {
            return Contar(
                "SELECT COUNT(*) FROM pacientes WHERE id_paciente = @id AND estado = 'Activo'",
                new MySqlParameter("@id", idPaciente)) > 0;
        }

        public bool MedicoActivo(int idMedico)
        {
            return Contar(@"
        SELECT COUNT(*)
        FROM personal p
        INNER JOIN roles r ON r.nombre = p.rol
        WHERE p.id_personal = @id AND p.estado = 'Activo' AND r.atiende_citas = 1",
                new MySqlParameter("@id", idMedico)) > 0;
        }

        // Regla de horario: la cita debe caber completa dentro del turno del médico ese día.
        // Si la cita cruza la medianoche no cabe en ningún turno y se rechaza.
        public bool MedicoTieneTurno(int idMedico, DateTime inicio, DateTime fin)
        {
            if (inicio.Date != fin.Date)
                return false;

            return Contar(@"
                SELECT COUNT(*)
                FROM horarios h
                INNER JOIN turnos t ON t.id_turno = h.id_turno
                WHERE h.id_personal = @medico
                  AND h.fecha = @fecha
                  AND @horaInicio >= t.hora_inicio
                  AND @horaFin    <= t.hora_fin",
                new MySqlParameter("@medico", idMedico),
                new MySqlParameter("@fecha", inicio.Date),
                new MySqlParameter("@horaInicio", inicio.TimeOfDay),
                new MySqlParameter("@horaFin", fin.TimeOfDay)) > 0;
        }

        // Regla de solapamiento: solo cuentan citas activas del mismo médico.
        // idExcluir = 0 al crear; el id de la cita al reprogramarla.
        public bool HaySolapamiento(int idMedico, DateTime inicio, DateTime fin, int idExcluir)
        {
            return Contar(@"
                SELECT COUNT(*)
                FROM citas
                WHERE id_medico = @medico
                  AND estado IN ('Programada', 'Confirmada')
                  AND id_cita <> @excluir
                  AND fecha_hora_inicio < @fin
                  AND fecha_hora_fin    > @inicio",
                new MySqlParameter("@medico", idMedico),
                new MySqlParameter("@excluir", idExcluir),
                new MySqlParameter("@inicio", inicio),
                new MySqlParameter("@fin", fin)) > 0;
        }

        // Devuelve null si la cita no existe.
        public string ObtenerEstado(int idCita)
        {
            using (MySqlConnection cn = ConexionBD.ObtenerConexion())
            using (MySqlCommand cmd = new MySqlCommand(
                "SELECT estado FROM citas WHERE id_cita = @id", cn))
            {
                cmd.Parameters.AddWithValue("@id", idCita);
                cn.Open();
                object valor = cmd.ExecuteScalar();
                return (valor == null || valor == DBNull.Value) ? null : valor.ToString();
            }
        }

        // ---------- Escritura ----------

        public int Insertar(int idPaciente, int idMedico, DateTime inicio, int duracionMin,
            string motivo, string gravedad, string observaciones)
        {
            using (MySqlConnection cn = ConexionBD.ObtenerConexion())
            using (MySqlCommand cmd = new MySqlCommand(@"
                INSERT INTO citas
                    (id_paciente, id_medico, fecha_hora_inicio, duracion_min,
                     motivo, gravedad, observaciones)
                VALUES
                    (@paciente, @medico, @inicio, @duracion,
                     @motivo, @gravedad, @observaciones)", cn))
            {
                AsignarParametros(cmd, idPaciente, idMedico, inicio, duracionMin,
                    motivo, gravedad, observaciones);
                cn.Open();
                return cmd.ExecuteNonQuery();
            }
        }

        public int Actualizar(int idCita, int idPaciente, int idMedico, DateTime inicio,
            int duracionMin, string motivo, string gravedad, string observaciones)
        {
            using (MySqlConnection cn = ConexionBD.ObtenerConexion())
            using (MySqlCommand cmd = new MySqlCommand(@"
                UPDATE citas SET
                    id_paciente = @paciente, id_medico = @medico,
                    fecha_hora_inicio = @inicio, duracion_min = @duracion,
                    motivo = @motivo, gravedad = @gravedad,
                    observaciones = @observaciones
                WHERE id_cita = @id", cn))
            {
                AsignarParametros(cmd, idPaciente, idMedico, inicio, duracionMin,
                    motivo, gravedad, observaciones);
                cmd.Parameters.AddWithValue("@id", idCita);
                cn.Open();
                return cmd.ExecuteNonQuery();
            }
        }

        public int CambiarEstado(int idCita, string estado)
        {
            using (MySqlConnection cn = ConexionBD.ObtenerConexion())
            using (MySqlCommand cmd = new MySqlCommand(
                "UPDATE citas SET estado = @estado WHERE id_cita = @id", cn))
            {
                cmd.Parameters.AddWithValue("@estado", estado);
                cmd.Parameters.AddWithValue("@id", idCita);
                cn.Open();
                return cmd.ExecuteNonQuery();
            }
        }

        // Guarda la evaluación del médico y deja la cita como Atendida.
        public int GuardarEvaluacion(int idCita, string diagnostico, string observaciones)
        {
            using (MySqlConnection cn = ConexionBD.ObtenerConexion())
            using (MySqlCommand cmd = new MySqlCommand(@"
                UPDATE citas SET
                    diagnostico = @diagnostico,
                    observaciones = @observaciones,
                    estado = 'Atendida'
                WHERE id_cita = @id", cn))
            {
                cmd.Parameters.AddWithValue("@diagnostico", diagnostico);
                cmd.Parameters.AddWithValue("@observaciones", ValorOpcional(observaciones));
                cmd.Parameters.AddWithValue("@id", idCita);
                cn.Open();
                return cmd.ExecuteNonQuery();
            }
        }

        // ---------- Auxiliares ----------

        private static void AsignarParametros(MySqlCommand cmd, int idPaciente, int idMedico,
            DateTime inicio, int duracionMin, string motivo, string gravedad, string observaciones)
        {
            cmd.Parameters.AddWithValue("@paciente", idPaciente);
            cmd.Parameters.AddWithValue("@medico", idMedico);
            cmd.Parameters.AddWithValue("@inicio", inicio);
            cmd.Parameters.AddWithValue("@duracion", duracionMin);
            cmd.Parameters.AddWithValue("@motivo", motivo);
            cmd.Parameters.AddWithValue("@gravedad", gravedad);
            cmd.Parameters.AddWithValue("@observaciones", ValorOpcional(observaciones));
        }

        private static object ValorOpcional(string valor)
        {
            return string.IsNullOrWhiteSpace(valor) ? (object)DBNull.Value : valor;
        }

        private static DataTable Consultar(string sql)
        {
            using (MySqlConnection cn = ConexionBD.ObtenerConexion())
            using (MySqlDataAdapter da = new MySqlDataAdapter(sql, cn))
            {
                DataTable tabla = new DataTable();
                da.Fill(tabla);
                return tabla;
            }
        }

        private static int Contar(string sql, params MySqlParameter[] parametros)
        {
            using (MySqlConnection cn = ConexionBD.ObtenerConexion())
            using (MySqlCommand cmd = new MySqlCommand(sql, cn))
            {
                cmd.Parameters.AddRange(parametros);
                cn.Open();
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }
    }
}