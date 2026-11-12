using System.Data;
using MySql.Data.MySqlClient;

namespace AgendaMedica_DAL
{
    // Consultas de solo lectura para la ficha completa de un empleado.
    public class FichaPersonalDAL
    {
        private const string SqlPersonal = @"
            SELECT
                p.id_personal,
                p.nombre,
                p.apellido,
                p.identificacion,
                p.telefono,
                p.correo,
                p.especialidad,
                p.rol,
                p.estado,
                COALESCE(d.nombre, 'Sin departamento') AS departamento
            FROM personal p
            LEFT JOIN departamentos d
                ON p.id_departamento = d.id_departamento
            WHERE p.id_personal = @id";

        private const string SqlHorarios = @"
            SELECT
                h.id_horario,
                h.fecha,
                h.observaciones,
                t.nombre AS turno,
                t.hora_inicio,
                t.hora_fin
            FROM horarios h
            LEFT JOIN turnos t
                ON h.id_turno = t.id_turno
            WHERE h.id_personal = @id
            ORDER BY h.fecha";

        private const string SqlRelevos = @"
            SELECT
                r.id_relevo,
                r.fecha_hora,
                r.observaciones,
                CONCAT(p1.nombre, ' ', p1.apellido) AS entrega,
                CONCAT(p2.nombre, ' ', p2.apellido) AS recibe
            FROM relevos r
            LEFT JOIN personal p1
                ON r.id_personal_entrega = p1.id_personal
            LEFT JOIN personal p2
                ON r.id_personal_recibe = p2.id_personal
            WHERE r.id_personal_entrega = @id
               OR r.id_personal_recibe = @id
            ORDER BY r.fecha_hora";

        private const string SqlIntercambios = @"
            SELECT
                i.id_intercambio,
                i.fecha_solicitud,
                i.motivo,
                i.estado,
                CONCAT(p1.nombre, ' ', p1.apellido) AS solicitante,
                CONCAT(p2.nombre, ' ', p2.apellido) AS receptor
            FROM intercambios i
            LEFT JOIN personal p1
                ON i.id_personal_solicitante = p1.id_personal
            LEFT JOIN personal p2
                ON i.id_personal_receptor = p2.id_personal
            WHERE i.id_personal_solicitante = @id
               OR i.id_personal_receptor = @id
            ORDER BY i.fecha_solicitud";

        public DataTable ObtenerDatosPersonales(int id)
        {
            return Consultar(SqlPersonal, id);
        }

        public DataTable ObtenerHorarios(int id)
        {
            return Consultar(SqlHorarios, id);
        }

        public DataTable ObtenerRelevos(int id)
        {
            return Consultar(SqlRelevos, id);
        }

        public DataTable ObtenerIntercambios(int id)
        {
            return Consultar(SqlIntercambios, id);
        }

        private static DataTable Consultar(string sql, int id)
        {
            using (MySqlConnection cn = ConexionBD.ObtenerConexion())
            using (MySqlCommand cmd = new MySqlCommand(sql, cn))
            {
                cmd.Parameters.AddWithValue("@id", id);

                using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                {
                    DataTable tabla = new DataTable();
                    da.Fill(tabla);
                    return tabla;
                }
            }
        }
    }
}