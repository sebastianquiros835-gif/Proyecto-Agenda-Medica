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
using AgendaMedica_BL;

namespace AgendaMedica_DAL
{
    public partial class AgendaMedica : Form
    {
        private readonly PersonalBL personalBL = new PersonalBL();
        
                
        public AgendaMedica()
        {
            InitializeComponent();
            AgendaMedica_DAL.Estilo.Aplicar(this);

            errorProvider1.ContainerControl = this;
            errorProvider1.BlinkStyle = ErrorBlinkStyle.NeverBlink;
        

        }
        private void CargarDepartamentos()
        {
            DataTable departamentos = personalBL.ObtenerDepartamentos();

            cmbDepartamento.DataSource = departamentos;
            cmbDepartamento.DisplayMember = "nombre";
            cmbDepartamento.ValueMember = "id_departamento";
            cmbDepartamento.SelectedIndex = -1;
        }

        private void CargarPersonal()
        {
            DataTable tabla = personalBL.ObtenerTodos();

            dgvConector.DataSource = tabla;

            dgvConector.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            dgvConector.ReadOnly = true;
            dgvConector.AllowUserToAddRows = false;
            dgvConector.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            dgvConector.MultiSelect = false;

            // Ocultar el identificador interno del departamento.
            if (dgvConector.Columns.Contains("id_departamento"))
            {
                dgvConector.Columns["id_departamento"].Visible = false;
            }
        }

        private void dgvConector_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0)
                    return;

                DataGridViewRow fila = dgvConector.Rows[e.RowIndex];

                txtIDpersonal.Text = Convert.ToString(fila.Cells["id_personal"].Value);
                txtIdentificacion.Text = Convert.ToString(fila.Cells["identificacion"].Value);
                txtNombre.Text = Convert.ToString(fila.Cells["nombre"].Value);
                txtApellidos.Text = Convert.ToString(fila.Cells["apellido"].Value);
                txtTelefono.Text = Convert.ToString(fila.Cells["telefono"].Value);
                txtCorreo.Text = Convert.ToString(fila.Cells["correo"].Value);
                txtEspecialidad.Text = Convert.ToString(fila.Cells["especialidad"].Value);
                txtRol.Text = Convert.ToString(fila.Cells["rol"].Value);

                object departamento = fila.Cells["id_departamento"].Value;

                if (departamento != null && departamento != DBNull.Value)
                    cmbDepartamento.SelectedValue = departamento;
                else
                    cmbDepartamento.SelectedIndex = -1;

                cmbEstado.SelectedItem =
                    Convert.ToString(fila.Cells["estado"].Value);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al seleccionar empleado: " + ex.Message);
            }
        }

        private void AgendaMedica_Load(object sender, EventArgs e)
        {
            try
            {
                CargarDepartamentos();

                cmbEstado.Items.Clear();
                cmbEstado.Items.Add("Activo");
                cmbEstado.Items.Add("Inactivo");
                cmbEstado.SelectedItem = "Activo";

                CargarPersonal();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al cargar: " + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }


        //esta parte es la mas importante ya que aqui se hace la conexion a la base de datos y se llena el datagridview con los datos de la tabla personal
        private readonly FichaPersonalBL fichaBL = new FichaPersonalBL();
        private string consulta;
        private static object con;

        public object Estilo { get; }


        //en esta parte se hace la conexion a la base de datos y se llena el datagridview con los datos de la tabla personal
        private void btnConectar_Click(object sender, EventArgs e)
        {
            try
            {
                string mensaje;
                if (!ConexionBL.Probar(out mensaje))
                {
                    MessageBox.Show(mensaje, "Conexión",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                DataTable tabla = personalBL.ObtenerTodos();

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
                this.Close();
            }
        }

        // aqui se llena el datagridview con los datos de la tabla personal
        private void dgvConector_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0)
                    return;

                DataGridViewRow fila = dgvConector.Rows[e.RowIndex];

                txtIDpersonal.Text = Convert.ToString(fila.Cells["id_personal"].Value);
                txtIdentificacion.Text = Convert.ToString(fila.Cells["identificacion"].Value);
                txtNombre.Text = Convert.ToString(fila.Cells["nombre"].Value);
                txtApellidos.Text = Convert.ToString(fila.Cells["apellido"].Value);
                txtTelefono.Text = Convert.ToString(fila.Cells["telefono"].Value);
                txtCorreo.Text = Convert.ToString(fila.Cells["correo"].Value);
                txtEspecialidad.Text = Convert.ToString(fila.Cells["especialidad"].Value);
                txtRol.Text = Convert.ToString(fila.Cells["rol"].Value);

                cmbDepartamento.SelectedValue =
                    fila.Cells["id_departamento"].Value;

                cmbEstado.SelectedItem =
                    Convert.ToString(fila.Cells["estado"].Value);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al seleccionar personal: " + ex.Message);
            }
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

            try
            {
                // Toda la consulta se resuelve en la capa BL (que usa la DAL).
                dgvConector.DataSource = fichaBL.ObtenerFicha(id);
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
                    string seccion = Convert.ToString(fila.Cells["Sección"].Value);
                    string campo = Convert.ToString(fila.Cells["Campo"].Value);
                    string informacion = Convert.ToString(fila.Cells["Información"].Value);

                    if (!string.IsNullOrWhiteSpace(seccion)
                        && string.IsNullOrWhiteSpace(campo)
                        && string.IsNullOrWhiteSpace(informacion))
                    {
                        fila.DefaultCellStyle.Font =
                            new Font(dgvConector.Font, FontStyle.Bold);
                        fila.DefaultCellStyle.BackColor = Color.LightSteelBlue;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Consultar ID");
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
        private bool ValidarFormulario()
        {
            errorProvider1.Clear();

            bool valido = true;

            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                errorProvider1.SetError(txtNombre, "Ingrese el nombre.");
                valido = false;
            }

            if (string.IsNullOrWhiteSpace(txtApellidos.Text))
            {
                errorProvider1.SetError(txtApellidos, "Ingrese los apellidos.");
                valido = false;
            }

            if (string.IsNullOrWhiteSpace(txtIdentificacion.Text))
            {
                errorProvider1.SetError(txtIdentificacion, "Ingrese la identificación.");
                valido = false;
            }

            if (string.IsNullOrWhiteSpace(txtTelefono.Text))
            {
                errorProvider1.SetError(txtTelefono, "Ingrese el teléfono.");
                valido = false;
            }

            if (string.IsNullOrWhiteSpace(txtCorreo.Text))
            {
                errorProvider1.SetError(txtCorreo, "Ingrese el correo.");
                valido = false;
            }

            if (string.IsNullOrWhiteSpace(txtEspecialidad.Text))
            {
                errorProvider1.SetError(txtEspecialidad, "Ingrese la especialidad.");
                valido = false;
            }

            if (string.IsNullOrWhiteSpace(txtRol.Text))
            {
                errorProvider1.SetError(txtRol, "Ingrese el rol.");
                valido = false;
            }

            if (cmbDepartamento.SelectedIndex == -1 ||
                cmbDepartamento.SelectedValue == null)
            {
                errorProvider1.SetError(cmbDepartamento, "Seleccione un departamento.");
                valido = false;
            }

            return valido;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. Comprobar que exista un departamento seleccionado
                if (cmbDepartamento.SelectedIndex == -1 ||
                    cmbDepartamento.SelectedValue == null)
                {
                    MessageBox.Show("Seleccione un departamento.");
                    cmbDepartamento.Focus();
                    return;
                }
                if (!ValidarFormulario())
                {
                    return;
                }

                // 2. Obtener el ID del departamento seleccionado
                int idDepartamento =
                    Convert.ToInt32(cmbDepartamento.SelectedValue);

                // 3. Enviar los datos a la capa BL
                personalBL.Insertar(
                    txtNombre.Text,
                    txtApellidos.Text,
                    txtIdentificacion.Text,
                    txtTelefono.Text,
                    txtCorreo.Text,
                    txtEspecialidad.Text,
                    txtRol.Text,
                    idDepartamento
                );

                // 4. Actualizar el DataGridView
                CargarPersonal();

                // 5. Limpiar los campos
                txtNombre.Clear();
                txtApellidos.Clear();
                txtIdentificacion.Clear();
                txtTelefono.Clear();
                txtCorreo.Clear();
                txtEspecialidad.Clear();
                txtRol.Clear();

                cmbDepartamento.SelectedIndex = -1;
                cmbEstado.SelectedItem = "Activo";

                // 6. Mostrar confirmación
                MessageBox.Show(
                    "Empleado registrado correctamente.",
                    "Registro exitoso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al guardar el empleado: " + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {    // Validar que todos los campos estén completos
                 // Si existe algún error, se detiene la actualización
                if (!ValidarFormulario())
                {
                    return;
                }

                // Comprobar que exista un ID válido
                int idPersonal;

                if (!int.TryParse(txtIDpersonal.Text, out idPersonal))
                {
                    MessageBox.Show("Seleccione un empleado válido.");
                    return;
                }

                // Comprobar el departamento seleccionado
                if (cmbDepartamento.SelectedIndex == -1)
                {
                    MessageBox.Show("Seleccione un departamento.");
                    return;
                }

                // Obtener el ID del departamento
                int idDepartamento =
                    Convert.ToInt32(cmbDepartamento.SelectedValue);

                // Enviar los datos a la capa BL
                personalBL.Actualizar(
                    idPersonal,
                    txtNombre.Text,
                    txtApellidos.Text,
                    txtIdentificacion.Text,
                    txtTelefono.Text,
                    txtCorreo.Text,
                    txtEspecialidad.Text,
                    txtRol.Text,
                    cmbEstado.SelectedItem.ToString(),
                    idDepartamento
                );

                // Actualizar la tabla
                CargarPersonal();

                MessageBox.Show(
                    "Empleado actualizado correctamente.",
                    "Actualización exitosa",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al actualizar: " + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            // Limpiar todos los mensajes de error del ErrorProvider
            errorProvider1.Clear();

            // Limpiar los campos de texto
            txtIDpersonal.Clear();
            txtIdentificacion.Clear();
            txtNombre.Clear();
            txtApellidos.Clear();
            txtTelefono.Clear();
            txtCorreo.Clear();
            txtEspecialidad.Clear();
            txtRol.Clear();

            cmbDepartamento.SelectedIndex = -1;
            cmbEstado.SelectedIndex = -1;

            dgvConector.ClearSelection();

            txtNombre.Focus();
        
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!int.TryParse(txtIDpersonal.Text, out int idPersonal))
                {
                    MessageBox.Show("Seleccione un empleado de la tabla.");
                    return;
                }

                DialogResult respuesta = MessageBox.Show(
                    "¿Está seguro de que desea eliminar permanentemente este empleado?",
                    "Confirmar eliminación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (respuesta == DialogResult.Yes)
                {
                    personalBL.Eliminar(idPersonal);

                    CargarPersonal();

                    txtIDpersonal.Clear();
                    txtIdentificacion.Clear();
                    txtNombre.Clear();
                    txtApellidos.Clear();
                    txtTelefono.Clear();
                    txtCorreo.Clear();
                    txtEspecialidad.Clear();
                    txtRol.Clear();

                    cmbDepartamento.SelectedIndex = -1;
                    cmbEstado.SelectedIndex = -1;

                    MessageBox.Show("Empleado eliminado permanentemente.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "No se pudo eliminar el empleado.\n\n" + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );



            }

        }

        private void lblIDpersonal_Click(object sender, EventArgs e)
        {

        }

        private void txtApellidos_TextChanged(object sender, EventArgs e)
        {

        }

        private void cmbDepartamento_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtTelefono_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtEspecialidad_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtRol_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtIDpersonal_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtIdentificacion_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblIdentificacion_Click(object sender, EventArgs e)
        {

        }

        private void lblApellido_Click(object sender, EventArgs e)
        {

        }

        private void lblCorreo_Click(object sender, EventArgs e)
        {

        }

        private void lblEspecialidad_Click(object sender, EventArgs e)
        {

        }

        private void lblEstado_Click(object sender, EventArgs e)
        {

        }

        private void lblRol_Click(object sender, EventArgs e)
        {

        }

        private void lblNombre_Click(object sender, EventArgs e)
        {

        }

        private void lblTelefono_Click(object sender, EventArgs e)
        {

        }

        private void lblDepartamento_Click(object sender, EventArgs e)
        {

        }
    }
}
    
