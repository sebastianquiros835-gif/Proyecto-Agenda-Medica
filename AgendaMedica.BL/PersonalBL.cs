using System;
using System.Data;
using AgendaMedica_DAL;

namespace AgendaMedica_BL
{
    public class PersonalBL
    {
        private readonly PersonalDAL dal = new PersonalDAL();

        // READ: Consultar todo el personal
        public DataTable ObtenerTodos()
        {
            return dal.ObtenerTodos();
        }

        // READ: Obtener departamentos para el ComboBox
        public DataTable ObtenerDepartamentos()
        {
            return dal.ObtenerDepartamentos();
        }

        // CREATE: Registrar personal
        public void Insertar(
            string nombre,
            string apellido,
            string identificacion,
            string telefono,
            string correo,
            string especialidad,
            string rol,
            int idDepartamento)
        {
            ValidarDatos(
                nombre, apellido, identificacion,
                especialidad, rol, idDepartamento);

            ValidarLongitud(telefono, 20, "Teléfono");
            ValidarLongitud(correo, 100, "Correo");

            int resultado = dal.Insertar(
                nombre, apellido, identificacion,
                telefono, correo, especialidad, rol,
                idDepartamento);

            if (resultado != 1)
                throw new Exception("No se pudo registrar el empleado.");
        }

        // UPDATE: Actualizar personal
        public void Actualizar(
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
            if (idPersonal <= 0)
                throw new ArgumentException("Seleccione un empleado válido.");

            ValidarDatos(
                nombre, apellido, identificacion,
                especialidad, rol, idDepartamento);

            ValidarLongitud(telefono, 20, "Teléfono");
            ValidarLongitud(correo, 100, "Correo");

            if (estado != "Activo" && estado != "Inactivo")
                throw new ArgumentException("El estado no es válido.");

            int resultado = dal.Actualizar(
                idPersonal, nombre, apellido,
                identificacion, telefono, correo,
                especialidad, rol, estado, idDepartamento);

            if (resultado != 1)
                throw new Exception("No se pudo actualizar el empleado.");
        }

        // DELETE lógico: Desactivar personal o eliminar 
        public void Desactivar(int idPersonal)
        {
            if (idPersonal <= 0)
                throw new ArgumentException("Seleccione un empleado válido.");

            int resultado = dal.Desactivar(idPersonal);

            if (resultado != 1)
                throw new Exception("No se pudo desactivar el empleado.");
        }

        // Actulizar
        private void ValidarDatos(
            string nombre,
            string apellido,
            string identificacion,
            string especialidad,
            string rol,
            int idDepartamento)
        {
            ValidarRequerido(nombre, 50, "Nombre");
            ValidarRequerido(apellido, 80, "Apellido");
            ValidarRequerido(identificacion, 20, "Identificación");
            ValidarRequerido(especialidad, 80, "Especialidad");
            ValidarRequerido(rol, 80, "Rol");

            if (idDepartamento <= 0)
                throw new ArgumentException(
                    "Seleccione un departamento válido.");
        }

        private void ValidarRequerido(
            string valor, int maximo, string campo)
        {
            if (string.IsNullOrWhiteSpace(valor))
                throw new ArgumentException(
                    "El campo " + campo + " es obligatorio.");

            if (valor.Trim().Length > maximo)
                throw new ArgumentException(
                    "El campo " + campo +
                    " no puede superar " + maximo + " caracteres.");
        }

        private void ValidarLongitud(
            string valor, int maximo, string campo)
        {
            if (!string.IsNullOrWhiteSpace(valor) &&
                valor.Trim().Length > maximo)
            {
                throw new ArgumentException(
                    "El campo " + campo +
                    " no puede superar " + maximo + " caracteres.");
            }
        }
    }
}
