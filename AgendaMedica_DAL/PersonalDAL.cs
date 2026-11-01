using System;
using System.Data;
using MySql.Data.MySqlClient;

namespace AgendaMedica_DAL
{
    public class PersonalDAL
    {
        // READ: Obtener todos los empleados
        public DataTable ObtenerTodos()
        {
            using (MySqlConnection conexion = ConexionBD.ObtenerConexion())
            {
                string sql = @"
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
                        p.id_departamento,
                        d.nombre AS departamento
                    FROM personal p
                    LEFT JOIN departamentos d
                        ON p.id_departamento = d.id_departamento
                    ORDER BY p.id_personal";

                using (MySqlDataAdapter adaptador =
                    new MySqlDataAdapter(sql, conexion))
                {
                    DataTable tabla = new DataTable();
                    adaptador.Fill(tabla);
                    return tabla;
                }
            }
        }

        // READ: Obtener departamentos
        public DataTable ObtenerDepartamentos()
        {
            using (MySqlConnection conexion = ConexionBD.ObtenerConexion())
            {
                string sql = @"
                    SELECT id_departamento, nombre
                    FROM departamentos
                    ORDER BY nombre";

                using (MySqlDataAdapter adaptador =
                    new MySqlDataAdapter(sql, conexion))
                {
                    DataTable tabla = new DataTable();
                    adaptador.Fill(tabla);
                    return tabla;
                }
            }
        }

        // CREATE: Registrar un empleado
        public int Insertar(
            string nombre,
            string apellido,
            string identificacion,
            string telefono,
            string correo,
            string especialidad,
            string rol,
            int idDepartamento)
        {
            using (MySqlConnection conexion = ConexionBD.ObtenerConexion())
            {
                string sql = @"
                    INSERT INTO personal
                    (nombre, apellido, identificacion, telefono,
                     correo, especialidad, rol, estado, id_departamento)
                    VALUES
                    (@nombre, @apellido, @identificacion, @telefono,
                     @correo, @especialidad, @rol, 'Activo', @idDepartamento)";

                using (MySqlCommand comando = new MySqlCommand(sql, conexion))
                {
                    comando.Parameters.AddWithValue("@nombre", nombre.Trim());
                    comando.Parameters.AddWithValue("@apellido", apellido.Trim());
                    comando.Parameters.AddWithValue("@identificacion", identificacion.Trim());
                    comando.Parameters.AddWithValue("@telefono", ValorOpcional(telefono));
                    comando.Parameters.AddWithValue("@correo", ValorOpcional(correo));
                    comando.Parameters.AddWithValue("@especialidad", ValorOpcional(especialidad));
                    comando.Parameters.AddWithValue("@rol", ValorOpcional(rol));
                    comando.Parameters.AddWithValue("@idDepartamento", idDepartamento);

                    conexion.Open();
                    return comando.ExecuteNonQuery();
                }
            }
        }

        // UPDATE: Modificar un empleado
        public int Actualizar(
            int idPersonal,
            string nombre,
            string apellido,
            string identificacion,
            string telefono,
            string correo,
            string especialidad,
            string rol,
            string estado,
            int idDepartamento)
        {
            using (MySqlConnection conexion = ConexionBD.ObtenerConexion())
            {
                string sql = @"
                    UPDATE personal SET
                        nombre = @nombre,
                        apellido = @apellido,
                        identificacion = @identificacion,
                        telefono = @telefono,
                        correo = @correo,
                        especialidad = @especialidad,
                        rol = @rol,
                        estado = @estado,
                        id_departamento = @idDepartamento
                    WHERE id_personal = @idPersonal";

                using (MySqlCommand comando = new MySqlCommand(sql, conexion))
                {
                    comando.Parameters.AddWithValue("@idPersonal", idPersonal);
                    comando.Parameters.AddWithValue("@nombre", nombre.Trim());
                    comando.Parameters.AddWithValue("@apellido", apellido.Trim());
                    comando.Parameters.AddWithValue("@identificacion", identificacion.Trim());
                    comando.Parameters.AddWithValue("@telefono", ValorOpcional(telefono));
                    comando.Parameters.AddWithValue("@correo", ValorOpcional(correo));
                    comando.Parameters.AddWithValue("@especialidad", ValorOpcional(especialidad));
                    comando.Parameters.AddWithValue("@rol", ValorOpcional(rol));
                    comando.Parameters.AddWithValue("@estado", estado);
                    comando.Parameters.AddWithValue("@idDepartamento", idDepartamento);

                    conexion.Open();
                    return comando.ExecuteNonQuery();
                }
            }
        }

        // DELETE lógico: Desactivar un empleado
        public int Desactivar(int idPersonal)
        {
            using (MySqlConnection conexion = ConexionBD.ObtenerConexion())
            {
                string sql = @"
                    UPDATE personal
                    SET estado = 'Inactivo'
                    WHERE id_personal = @idPersonal";

                using (MySqlCommand comando = new MySqlCommand(sql, conexion))
                {
                    comando.Parameters.AddWithValue("@idPersonal", idPersonal);

                    conexion.Open();
                    return comando.ExecuteNonQuery();
                }
            }
        }

        // Manejar campos opcionales
        private object ValorOpcional(string valor)
        {
            if (string.IsNullOrWhiteSpace(valor))
                return DBNull.Value;

            return valor.Trim();
        }
    }
}

