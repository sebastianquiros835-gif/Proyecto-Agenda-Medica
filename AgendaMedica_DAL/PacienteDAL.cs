using System;
using System.Data;
using MySql.Data.MySqlClient;

namespace AgendaMedica_DAL
{
    public class PacienteDAL
    {
        public DataTable ObtenerTodos()
        {
            using (MySqlConnection cn = ConexionBD.ObtenerConexion())
            using (MySqlDataAdapter da = new MySqlDataAdapter(
                @"SELECT id_paciente, identificacion, nombre, apellido,
                         telefono, correo, fecha_nacimiento, estado
                  FROM pacientes ORDER BY id_paciente", cn))
            {
                DataTable tabla = new DataTable();
                da.Fill(tabla);
                return tabla;
            }
        }

        public bool ExisteIdentificacion(string identificacion, int idExcluir)
        {
            using (MySqlConnection cn = ConexionBD.ObtenerConexion())
            using (MySqlCommand cmd = new MySqlCommand(
                @"SELECT COUNT(*) FROM pacientes
                  WHERE identificacion = @identificacion
                  AND id_paciente <> @id", cn))
            {
                cmd.Parameters.AddWithValue("@identificacion", identificacion);
                cmd.Parameters.AddWithValue("@id", idExcluir);
                cn.Open();
                return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
            }
        }

        public int Insertar(string identificacion, string nombre, string apellido,
            string telefono, string correo, DateTime? fechaNac, string estado)
        {
            using (MySqlConnection cn = ConexionBD.ObtenerConexion())
            using (MySqlCommand cmd = new MySqlCommand(
                @"INSERT INTO pacientes
                    (identificacion, nombre, apellido, telefono, correo, fecha_nacimiento, estado)
                  VALUES
                    (@identificacion, @nombre, @apellido, @telefono, @correo, @fecha, @estado)", cn))
            {
                AsignarParametros(cmd, identificacion, nombre, apellido,
                    telefono, correo, fechaNac, estado);
                cn.Open();
                return cmd.ExecuteNonQuery();
            }
        }

        public int Actualizar(int id, string identificacion, string nombre, string apellido,
            string telefono, string correo, DateTime? fechaNac, string estado)
        {
            using (MySqlConnection cn = ConexionBD.ObtenerConexion())
            using (MySqlCommand cmd = new MySqlCommand(
                @"UPDATE pacientes SET
                    identificacion = @identificacion, nombre = @nombre,
                    apellido = @apellido, telefono = @telefono, correo = @correo,
                    fecha_nacimiento = @fecha, estado = @estado
                  WHERE id_paciente = @id", cn))
            {
                AsignarParametros(cmd, identificacion, nombre, apellido,
                    telefono, correo, fechaNac, estado);
                cmd.Parameters.AddWithValue("@id", id);
                cn.Open();
                return cmd.ExecuteNonQuery();
            }
        }

        // Desactivación lógica: no se borra el paciente, así no se rompen sus citas futuras.
        public int Desactivar(int id)
        {
            using (MySqlConnection cn = ConexionBD.ObtenerConexion())
            using (MySqlCommand cmd = new MySqlCommand(
                "UPDATE pacientes SET estado = 'Inactivo' WHERE id_paciente = @id", cn))
            {
                cmd.Parameters.AddWithValue("@id", id);
                cn.Open();
                return cmd.ExecuteNonQuery();
            }
        }

        private static void AsignarParametros(MySqlCommand cmd, string identificacion,
            string nombre, string apellido, string telefono, string correo,
            DateTime? fechaNac, string estado)
        {
            cmd.Parameters.AddWithValue("@identificacion", identificacion);
            cmd.Parameters.AddWithValue("@nombre", nombre);
            cmd.Parameters.AddWithValue("@apellido", apellido);
            cmd.Parameters.AddWithValue("@telefono",
                string.IsNullOrWhiteSpace(telefono) ? (object)DBNull.Value : telefono);
            cmd.Parameters.AddWithValue("@correo",
                string.IsNullOrWhiteSpace(correo) ? (object)DBNull.Value : correo);
            cmd.Parameters.AddWithValue("@fecha",
                fechaNac.HasValue ? (object)fechaNac.Value : DBNull.Value);
            cmd.Parameters.AddWithValue("@estado", estado);
        }
    }
}