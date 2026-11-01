using System;
using System.Configuration;
using MySql.Data.MySqlClient;
using System.Data;

namespace AgendaMedica_DAL
{
    /*public static class ConexionBD
    {
        private static readonly string cadena =
            ConfigurationManager.ConnectionStrings["AgendaMedicaDB"].ConnectionString;

        public static MySqlConnection ObtenerConexion()
        {
            return new MySqlConnection(cadena);
        }

        public static bool ProbarConexion(out string mensaje)
        {
            try
            {
                using (MySqlConnection conexion = ObtenerConexion())
                {
                    conexion.Open();
                    mensaje = "Conexión exitosa a MySQL.";
                    return true;
                }
            }
            catch (MySqlException ex)
            {
                mensaje = "Error de MySQL: " + ex.Message;
                return false;
            }
            catch (Exception ex)
            {
                mensaje = "Error inesperado: " + ex.Message;
                return false;
            }
        }
    }*/
    public static class ConexionBD
    {
        public static MySqlConnection ObtenerConexion()
        {
            ConnectionStringSettings config =
                ConfigurationManager.ConnectionStrings["AgendaMedicaDB"];

            if (config == null ||
                string.IsNullOrWhiteSpace(config.ConnectionString))
            {
                throw new Exception(
                    "No se encontró AgendaMedicaDB en App.config.");
            }

            return new MySqlConnection(config.ConnectionString);
        }

        public static bool ProbarConexion(out string mensaje)
        {
            try
            {
                using (MySqlConnection conexion = ObtenerConexion())
                {
                    conexion.Open();
                    mensaje = "Conexión exitosa a MySQL.";
                    return true;
                }
            }
            catch (Exception ex)
            {
                mensaje = "Error: " + ex.Message;
                return false;
            }
        }
    }
}