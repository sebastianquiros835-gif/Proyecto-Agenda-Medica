using System;
using System.Data;
using System.Text.RegularExpressions;
using AgendaMedica_DAL;

namespace AgendaMedica_BL
{
    public class PacienteBL
    {
        private readonly PacienteDAL dal = new PacienteDAL();

        public DataTable ObtenerTodos()
        {
            return dal.ObtenerTodos();
        }

        public void Insertar(Paciente p)
        {
            Normalizar(p);
            Validar(p, 0);

            if (dal.Insertar(p.Identificacion, p.Nombre, p.Apellido, p.Telefono,
                p.Correo, p.FechaNacimiento, p.Estado) != 1)
                throw new Exception("No se pudo registrar el paciente.");
        }

        public void Actualizar(Paciente p)
        {
            if (p.IdPaciente <= 0)
                throw new Exception("Seleccione un paciente de la tabla.");

            Normalizar(p);
            Validar(p, p.IdPaciente);

            if (dal.Actualizar(p.IdPaciente, p.Identificacion, p.Nombre, p.Apellido,
                p.Telefono, p.Correo, p.FechaNacimiento, p.Estado) != 1)
                throw new Exception("No se pudo actualizar el paciente.");
        }

        public void Desactivar(int idPaciente)
        {
            if (idPaciente <= 0)
                throw new Exception("Seleccione un paciente de la tabla.");

            if (dal.Desactivar(idPaciente) != 1)
                throw new Exception("No se pudo desactivar el paciente.");
        }

        private static void Normalizar(Paciente p)
        {
            p.Identificacion = (p.Identificacion ?? "").Trim();
            p.Nombre = (p.Nombre ?? "").Trim();
            p.Apellido = (p.Apellido ?? "").Trim();
            p.Telefono = (p.Telefono ?? "").Trim();
            p.Correo = (p.Correo ?? "").Trim();
            p.Estado = (p.Estado ?? "").Trim();
        }

        private void Validar(Paciente p, int idActual)
        {
            if (p.Identificacion.Length == 0 || p.Identificacion.Length > 20)
                throw new Exception("La identificación es obligatoria (máximo 20 caracteres).");
            if (p.Nombre.Length == 0 || p.Nombre.Length > 60)
                throw new Exception("El nombre es obligatorio (máximo 60 caracteres).");
            if (p.Apellido.Length == 0 || p.Apellido.Length > 80)
                throw new Exception("Los apellidos son obligatorios (máximo 80 caracteres).");

            if (p.Telefono.Length > 0 && !Regex.IsMatch(p.Telefono, @"^\d{8}$"))
                throw new Exception("El teléfono debe tener 8 dígitos, sin guiones ni espacios.");

            if (p.Correo.Length > 0 &&
                (p.Correo.Length > 100 || !Regex.IsMatch(p.Correo, @"^[^@\s]+@[^@\s]+\.[^@\s]+$")))
                throw new Exception("El correo no tiene un formato válido.");

            if (p.FechaNacimiento.HasValue && p.FechaNacimiento.Value.Date > DateTime.Today)
                throw new Exception("La fecha de nacimiento no puede ser futura.");

            if (p.Estado != "Activo" && p.Estado != "Inactivo")
                throw new Exception("El estado debe ser Activo o Inactivo.");

            if (dal.ExisteIdentificacion(p.Identificacion, idActual))
                throw new Exception("Ya existe un paciente con esa identificación.");
        }
    }
}