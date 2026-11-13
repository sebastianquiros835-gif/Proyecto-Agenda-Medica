using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AgendaMedica_BL;

namespace AgendaMedica_UL
{
    public partial class frmPacientes : Form
    {
        private readonly PacienteBL pacienteBL = new PacienteBL();

        public frmPacientes()
        {
            InitializeComponent();
        }

        private void frmPacientes_Load(object sender, EventArgs e)
        {
            try
            {
                cmbEstado.SelectedItem = "Activo";
                CargarPacientes();
                LimpiarFormulario();
            }
            catch (Exception ex)
            {
                MostrarError("Error al cargar la pantalla de pacientes", ex);
            }
        }

        private void CargarPacientes()
        {
            dgvPacientes.DataSource = pacienteBL.ObtenerTodos();
        }

        private void dtpNacimiento_ValueChanged(object sender, EventArgs e)
        {
            if (!dtpNacimiento.Checked)
            {
                txtEdad.Clear();
                return;
            }

            DateTime nacimiento = dtpNacimiento.Value.Date;
            int edad = DateTime.Today.Year - nacimiento.Year;
            if (nacimiento > DateTime.Today.AddYears(-edad))
                edad--;

            txtEdad.Text = edad.ToString();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                pacienteBL.Insertar(LeerPaciente());
                CargarPacientes();
                LimpiarFormulario();
                MessageBox.Show("Paciente guardado correctamente.", "Pacientes",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MostrarError("No se pudo guardar el paciente", ex);
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                Paciente paciente = LeerPaciente();
                paciente.IdPaciente = IdSeleccionado();
                pacienteBL.Actualizar(paciente);
                CargarPacientes();
                LimpiarFormulario();
                MessageBox.Show("Paciente actualizado correctamente.", "Pacientes",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MostrarError("No se pudo actualizar el paciente", ex);
            }
        }

        private void btnDesactivar_Click(object sender, EventArgs e)
        {
            try
            {
                pacienteBL.Desactivar(IdSeleccionado());
                CargarPacientes();
                LimpiarFormulario();
                MessageBox.Show("Paciente desactivado correctamente.", "Pacientes",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MostrarError("No se pudo desactivar el paciente", ex);
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
            dgvPacientes.ClearSelection();
        }

        private void dgvPacientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0)
                    return;

                DataGridViewRow fila = dgvPacientes.Rows[e.RowIndex];
                txtIdPaciente.Text = Texto(fila, "id_paciente");
                txtIdentificacion.Text = Texto(fila, "identificacion");
                txtNombre.Text = Texto(fila, "nombre");
                txtApellido.Text = Texto(fila, "apellido");
                txtTelefono.Text = Texto(fila, "telefono");
                txtCorreo.Text = Texto(fila, "correo");
                cmbEstado.SelectedItem = Texto(fila, "estado");

                object fecha = fila.Cells["fecha_nacimiento"].Value;
                if (fecha == null || fecha == DBNull.Value)
                {
                    dtpNacimiento.Checked = false;
                    txtEdad.Clear();
                }
                else
                {
                    dtpNacimiento.Value = Convert.ToDateTime(fecha);
                    dtpNacimiento.Checked = true;
                }
            }
            catch (Exception ex)
            {
                MostrarError("Error al seleccionar el paciente", ex);
            }
        }

        private Paciente LeerPaciente()
        {
            return new Paciente
            {
                Identificacion = txtIdentificacion.Text,
                Nombre = txtNombre.Text,
                Apellido = txtApellido.Text,
                Telefono = txtTelefono.Text,
                Correo = txtCorreo.Text,
                FechaNacimiento = dtpNacimiento.Checked ? (DateTime?)dtpNacimiento.Value.Date : null,
                Estado = cmbEstado.SelectedItem == null ? "" : cmbEstado.SelectedItem.ToString()
            };
        }

        private int IdSeleccionado()
        {
            int id;
            return int.TryParse(txtIdPaciente.Text, out id) ? id : 0;
        }

        private void LimpiarFormulario()
        {
            txtIdPaciente.Clear();
            txtIdentificacion.Clear();
            txtNombre.Clear();
            txtApellido.Clear();
            txtTelefono.Clear();
            txtCorreo.Clear();
            dtpNacimiento.Value = DateTime.Today;
            dtpNacimiento.Checked = false;
            txtEdad.Clear();
            cmbEstado.SelectedItem = "Activo";
        }

        private static string Texto(DataGridViewRow fila, string columna)
        {
            object valor = fila.Cells[columna].Value;
            return valor == null || valor == DBNull.Value ? "" : valor.ToString();
        }

        private static void MostrarError(string titulo, Exception ex)
        {
            MessageBox.Show(titulo + ":\n\n" + ex.Message, "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
