using MySqlConnector;
using MySqlConnector;
using System;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Agenda_Médica.AgendaMedica.dal
{

    // conexion a la base de datos mysql
    internal class ConexionRepositorios
    {
        private readonly string cadenaConexion =
            "Server=127.0.0.1;Port=3307;Database=agenda_medica;User ID=root;Password=262905?;";

        public MySqlConnection ObtenerConexion()
        {
            return new MySqlConnection(cadenaConexion);
        }


        // prueba de conexion a la base de datos mysql

        public bool ProbarConexion()
        {
            try
            {
                using (MySqlConnection conexion = ObtenerConexion())
                {
                    conexion.Open();
                    return true;
                }
            }
            catch (MySqlException ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                return false;
            }
        }

                

public DataTable ObtenerPersonal()
        {
            DataTable tabla = new DataTable();

            using (MySqlConnection conexion = ObtenerConexion())
            {
                conexion.Open();

                string consulta = "SELECT * FROM personal";

                using (MySqlCommand comando = new MySqlCommand(consulta, conexion))
                using (MySqlDataAdapter adaptador = new MySqlDataAdapter(comando))
                {
                    adaptador.Fill(tabla);
                }
            }

            return tabla;
        }

    }
        }


