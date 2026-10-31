using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace AgendaMedica_DAL
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        //esta parte es la mas importante ya que aqui se hace la conexion a la base de datos y se llena el datagridview con los datos de la tabla personal
        MySqlConnection ob = new MySqlConnection(
    "server=127.0.0.1;port=3306;user id=root;password=*A123456789*;database=agenda_medica;"
);
        private string consulta;
        private static object con;


        //en esta parte se hace la conexion a la base de datos y se llena el datagridview con los datos de la tabla personal
        private void btnConectar_Click(object sender, EventArgs e)
        {
            try
            {
                if (ob.State == ConnectionState.Closed)
                {
                    ob.Open();
                }

                string consulta = "SELECT * FROM personal";

                MySqlDataAdapter adaptador = new MySqlDataAdapter(consulta, ob);

                DataTable tabla = new DataTable();

                adaptador.Fill(tabla);

                dgvConector.AutoGenerateColumns = true;
                dgvConector.DataSource = tabla;

                MessageBox.Show("Registros encontrados: " + tabla.Rows.Count);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        //este metodo se encarga de cerrar la conexion a la base de datos y cerrar la aplicacion
        private void btnSalir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Desea salir de la aplicación?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                ob.Close();
                this.Close();
            }
        }

        // aqui se llena el datagridview con los datos de la tabla personal
        private void dgvConector_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            MySqlDataAdapter adaptador = new MySqlDataAdapter(consulta, ob);
            DataTable tabla = new DataTable();
            adaptador.Fill(tabla);
            dgvConector.DataSource = tabla;
        }

        private static object GetCon()
        {
            return con;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }


        // Este button nos permite buscar un ID en la base de datos y mostrar toda la información relacionada con ese ID en el DataGridView.
        private void btnID_Click(object sender, EventArgs e)
        {
  
            int id;

            if (!int.TryParse(txtID.Text.Trim(), out id))
            {
                MessageBox.Show("Ingrese un ID válido.");
                txtID.Focus();
                return;
            }

            DataTable tabla = new DataTable();

            tabla.Columns.Add("Sección");
            tabla.Columns.Add("Campo");
            tabla.Columns.Add("Información");

            try
            {
                ob.Open();

                // =====================================
                // 1. DATOS PERSONALES Y DEPARTAMENTO
                // =====================================

                string sqlPersonal = @"
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

                using (MySqlCommand cmd = new MySqlCommand(sqlPersonal, ob))
                {
                    cmd.Parameters.AddWithValue("@id", id);

                    using (MySqlDataReader lector = cmd.ExecuteReader())
                    {
                        if (!lector.Read())
                        {
                            MessageBox.Show("No se encontró ninguna persona con ese ID.");
                            return;
                        }

                        AgregarEncabezado(tabla, "DATOS PERSONALES");

                        AgregarDato(tabla, "ID", lector["id_personal"]);
                        AgregarDato(tabla, "Nombre", lector["nombre"]);
                        AgregarDato(tabla, "Apellido", lector["apellido"]);
                        AgregarDato(tabla, "Identificación", lector["identificacion"]);
                        AgregarDato(tabla, "Teléfono", lector["telefono"]);
                        AgregarDato(tabla, "Correo", lector["correo"]);
                        AgregarDato(tabla, "Especialidad", lector["especialidad"]);
                        AgregarDato(tabla, "Rol", lector["rol"]);
                        AgregarDato(tabla, "Estado", lector["estado"]);

                        AgregarEncabezado(tabla, "DEPARTAMENTO");
                        AgregarDato(tabla, "Departamento", lector["departamento"]);
                    }
                }

                // =====================================
                // 2. HORARIOS Y TURNOS
                // =====================================

                AgregarEncabezado(tabla, "HORARIOS Y TURNOS");

                string sqlHorarios = @"
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

                int numeroHorario = 0;

                using (MySqlCommand cmd = new MySqlCommand(sqlHorarios, ob))
                {
                    cmd.Parameters.AddWithValue("@id", id);

                    using (MySqlDataReader lector = cmd.ExecuteReader())
                    {
                        while (lector.Read())
                        {
                            numeroHorario++;

                            AgregarDato(
                                tabla,
                                "Horario " + numeroHorario + " - ID",
                                lector["id_horario"]);

                            AgregarDato(
                                tabla,
                                "Horario " + numeroHorario + " - Fecha",
                                lector["fecha"]);

                            AgregarDato(
                                tabla,
                                "Horario " + numeroHorario + " - Turno",
                                lector["turno"]);

                            AgregarDato(
                                tabla,
                                "Horario " + numeroHorario + " - Inicio",
                                lector["hora_inicio"]);

                            AgregarDato(
                                tabla,
                                "Horario " + numeroHorario + " - Finalización",
                                lector["hora_fin"]);

                            AgregarDato(
                                tabla,
                                "Horario " + numeroHorario + " - Observaciones",
                                lector["observaciones"]);
                        }
                    }
                }

                if (numeroHorario == 0)
                {
                    AgregarDato(tabla, "Registros", "No tiene horarios registrados.");
                }

                // =====================================
                // 3. RELEVOS
                // =====================================

                AgregarEncabezado(tabla, "RELEVOS");

                string sqlRelevos = @"
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

                int numeroRelevo = 0;

                using (MySqlCommand cmd = new MySqlCommand(sqlRelevos, ob))
                {
                    cmd.Parameters.AddWithValue("@id", id);

                    using (MySqlDataReader lector = cmd.ExecuteReader())
                    {
                        while (lector.Read())
                        {
                            numeroRelevo++;

                            AgregarDato(
                                tabla,
                                "Relevo " + numeroRelevo + " - ID",
                                lector["id_relevo"]);

                            AgregarDato(
                                tabla,
                                "Relevo " + numeroRelevo + " - Fecha y hora",
                                lector["fecha_hora"]);

                            AgregarDato(
                                tabla,
                                "Relevo " + numeroRelevo + " - Entrega",
                                lector["entrega"]);

                            AgregarDato(
                                tabla,
                                "Relevo " + numeroRelevo + " - Recibe",
                                lector["recibe"]);

                            AgregarDato(
                                tabla,
                                "Relevo " + numeroRelevo + " - Observaciones",
                                lector["observaciones"]);
                        }
                    }
                }

                if (numeroRelevo == 0)
                {
                    AgregarDato(tabla, "Registros", "No tiene relevos registrados.");
                }

                // =====================================
                // 4. INTERCAMBIOS
                // =====================================

                AgregarEncabezado(tabla, "INTERCAMBIOS");

                string sqlIntercambios = @"
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

                int numeroIntercambio = 0;

                using (MySqlCommand cmd = new MySqlCommand(sqlIntercambios, ob))
                {
                    cmd.Parameters.AddWithValue("@id", id);

                    using (MySqlDataReader lector = cmd.ExecuteReader())
                    {
                        while (lector.Read())
                        {
                            numeroIntercambio++;

                            AgregarDato(
                                tabla,
                                "Intercambio " + numeroIntercambio + " - ID",
                                lector["id_intercambio"]);

                            AgregarDato(
                                tabla,
                                "Intercambio " + numeroIntercambio + " - Fecha",
                                lector["fecha_solicitud"]);

                            AgregarDato(
                                tabla,
                                "Intercambio " + numeroIntercambio + " - Solicitante",
                                lector["solicitante"]);

                            AgregarDato(
                                tabla,
                                "Intercambio " + numeroIntercambio + " - Receptor",
                                lector["receptor"]);

                            AgregarDato(
                                tabla,
                                "Intercambio " + numeroIntercambio + " - Motivo",
                                lector["motivo"]);

                            AgregarDato(
                                tabla,
                                "Intercambio " + numeroIntercambio + " - Estado",
                                lector["estado"]);
                        }
                    }
                }

                if (numeroIntercambio == 0)
                {
                    AgregarDato(tabla, "Registros", "No tiene intercambios registrados.");
                }

                // =====================================
                // 5. MOSTRAR TODA LA INFORMACIÓN
                // =====================================

                dgvConector.DataSource = tabla;

                dgvConector.ReadOnly = true;
                dgvConector.AllowUserToAddRows = false;
                dgvConector.AutoSizeColumnsMode =
                    DataGridViewAutoSizeColumnsMode.Fill;

                dgvConector.RowHeadersVisible = false;
                dgvConector.SelectionMode =
                    DataGridViewSelectionMode.FullRowSelect;

                // Destacar los encabezados de cada sección.
                foreach (DataGridViewRow fila in dgvConector.Rows)
                {
                    string seccion = Convert.ToString(
                        fila.Cells["Sección"].Value);

                    string campo = Convert.ToString(
                        fila.Cells["Campo"].Value);

                    string informacion = Convert.ToString(
                        fila.Cells["Información"].Value);

                    if (!string.IsNullOrWhiteSpace(seccion)
                        && string.IsNullOrWhiteSpace(campo)
                        && string.IsNullOrWhiteSpace(informacion))
                    {
                        fila.DefaultCellStyle.Font =
                            new Font(dgvConector.Font, FontStyle.Bold);

                        fila.DefaultCellStyle.BackColor =
                            Color.LightSteelBlue;
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al consultar la información: " + ex.Message);
            }
            finally
            {
                if (ob.State == System.Data.ConnectionState.Open)
                {
                    ob.Close();
                }
            }
        }
        private void AgregarEncabezado(DataTable tabla, string titulo)
        {
            tabla.Rows.Add(titulo, "", "");
        }

        // Este método agrega un dato a la tabla con el formato adecuado y también maneja valores nulos o DBNull para que se muestren correctamente en el DataGridView.
        private void AgregarDato(DataTable tabla, string campo, object valor)
        {
            string informacion = "";

            if (valor != null && valor != DBNull.Value)
            {
                informacion = valor.ToString();
            }

            tabla.Rows.Add("", campo, informacion);
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
    }

    

