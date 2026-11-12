using System;
using System.Data;
using AgendaMedica_DAL;

namespace AgendaMedica_BL
{
    // Arma la ficha completa de un empleado a partir de las consultas de la DAL.
    public class FichaPersonalBL
    {
        private readonly FichaPersonalDAL dal = new FichaPersonalDAL();

        public DataTable ObtenerFicha(int id)
        {
            if (id <= 0)
                throw new Exception("Ingrese un ID válido.");

            DataTable personal = dal.ObtenerDatosPersonales(id);
            if (personal.Rows.Count == 0)
                throw new Exception("No se encontró ninguna persona con ese ID.");

            DataTable ficha = new DataTable();
            ficha.Columns.Add("Sección");
            ficha.Columns.Add("Campo");
            ficha.Columns.Add("Información");

            DataRow p = personal.Rows[0];
            Encabezado(ficha, "DATOS PERSONALES");
            Dato(ficha, "ID", p["id_personal"]);
            Dato(ficha, "Nombre", p["nombre"]);
            Dato(ficha, "Apellido", p["apellido"]);
            Dato(ficha, "Identificación", p["identificacion"]);
            Dato(ficha, "Teléfono", p["telefono"]);
            Dato(ficha, "Correo", p["correo"]);
            Dato(ficha, "Especialidad", p["especialidad"]);
            Dato(ficha, "Rol", p["rol"]);
            Dato(ficha, "Estado", p["estado"]);

            Encabezado(ficha, "DEPARTAMENTO");
            Dato(ficha, "Departamento", p["departamento"]);

            Encabezado(ficha, "HORARIOS Y TURNOS");
            int numeroHorario = 0;
            foreach (DataRow h in dal.ObtenerHorarios(id).Rows)
            {
                numeroHorario++;
                Item(ficha, "Horario", numeroHorario, "ID", h["id_horario"]);
                Item(ficha, "Horario", numeroHorario, "Fecha", h["fecha"]);
                Item(ficha, "Horario", numeroHorario, "Turno", h["turno"]);
                Item(ficha, "Horario", numeroHorario, "Inicio", h["hora_inicio"]);
                Item(ficha, "Horario", numeroHorario, "Finalización", h["hora_fin"]);
                Item(ficha, "Horario", numeroHorario, "Observaciones", h["observaciones"]);
            }
            if (numeroHorario == 0)
            {
                Dato(ficha, "Registros", "No tiene horarios registrados.");
            }
            
            Encabezado(ficha, "RELEVOS");
            int numeroRelevo = 0;
            foreach (DataRow r in dal.ObtenerRelevos(id).Rows)
            {
                numeroRelevo++;
                Item(ficha, "Relevo", numeroRelevo, "ID", r["id_relevo"]);
                Item(ficha, "Relevo", numeroRelevo, "Fecha y hora", r["fecha_hora"]);
                Item(ficha, "Relevo", numeroRelevo, "Entrega", r["entrega"]);
                Item(ficha, "Relevo", numeroRelevo, "Recibe", r["recibe"]);
                Item(ficha, "Relevo", numeroRelevo, "Observaciones", r["observaciones"]);
            }
            if (numeroRelevo == 0)
                Dato(ficha, "Registros", "No tiene relevos registrados.");

            Encabezado(ficha, "INTERCAMBIOS");
            int numeroIntercambio = 0;
            foreach (DataRow i in dal.ObtenerIntercambios(id).Rows)
            {
                numeroIntercambio++;
                Item(ficha, "Intercambio", numeroIntercambio, "ID", i["id_intercambio"]);
                Item(ficha, "Intercambio", numeroIntercambio, "Fecha", i["fecha_solicitud"]);
                Item(ficha, "Intercambio", numeroIntercambio, "Solicitante", i["solicitante"]);
                Item(ficha, "Intercambio", numeroIntercambio, "Receptor", i["receptor"]);
                Item(ficha, "Intercambio", numeroIntercambio, "Motivo", i["motivo"]);
                Item(ficha, "Intercambio", numeroIntercambio, "Estado", i["estado"]);
            }
            if (numeroIntercambio == 0)
                Dato(ficha, "Registros", "No tiene intercambios registrados.");

            return ficha;
        }

        private static void Encabezado(DataTable tabla, string titulo)
        {
            tabla.Rows.Add(titulo, "", "");
        }

        // Maneja valores nulos o DBNull para que se muestren vacíos en la tabla.
        private static void Dato(DataTable tabla, string campo, object valor)
        {
            string informacion = "";
            if (valor != null && valor != DBNull.Value)
                informacion = valor.ToString();

            tabla.Rows.Add("", campo, informacion);
        }

        private static void Item(DataTable tabla, string prefijo, int numero, string campo, object valor)
        {
            Dato(tabla, prefijo + " " + numero + " - " + campo, valor);
        }
    }
}