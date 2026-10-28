using System;
using AgendaMedica_DAL;

namespace AgendaMedica_BL
{
    public static class ConexionBL
    {
        public static bool Probar(out string mensaje)
        {
            return ConexionBD.ProbarConexion(out mensaje);
        }
    }
}