using System;
using System.Data;
using System.Windows.Forms;
using AgendaMedica_BL;

namespace AgendaMedica_UL
{
    // Pantalla funcional de citas. Solo habla con la capa BL; no usa SQL ni MySqlConnection.
    public partial class frmCitas : Form
    {
        private readonly CitaBL citaBL = new CitaBL();

        public frmCitas()
        {
            InitializeComponent();
        }

        private void frmCitas_Load(object sender, EventArgs e)
        {
            try
            {
                CargarCombos();
                CargarCitas();
                LimpiarFormulario();
            }
            catch (Exception ex)
            {
                MostrarError("Error al cargar la pantalla de citas", ex);
            }
        }

        // ---------- Carga de datos ----------

        private void CargarCombos()
        {
            cmbPaciente.DataSource = citaBL.ObtenerPacientes();
            cmbPaciente.DisplayMember = "nombre_completo";
            cmbPaciente.ValueMember = "id_paciente";

            cmbMedico.DataSource = citaBL.ObtenerMedicos();
            cmbMedico.DisplayMember = "nombre_completo";
            cmbMedico.ValueMember = "id_personal";

            cmbGravedad.Items.Clear();
            cmbGravedad.Items.AddRange(CitaBL.Gravedades);
        }

        private void CargarCitas()
        {
            dgvCitas.DataSource = citaBL.ObtenerTodas();

            if (dgvCitas.Columns.Contains("id_paciente"))
                dgvCitas.Columns["id_paciente"].Visible = false;
            if (dgvCitas.Columns.Contains("id_medico"))
                dgvCitas.Columns["id_medico"].Visible = false;
            if (dgvCitas.Columns.Contains("fecha_hora_inicio"))
                dgvCitas.Columns["fecha_hora_inicio"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
        }

        // ---------- Botones ----------

        private void btnAgendar_Click(object sender, EventArgs e)
        {
            try
            {
                citaBL.Agendar(LeerCita());

                CargarCitas();
                LimpiarFormulario();
                MessageBox.Show("Cita agendada correctamente.", "Citas",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MostrarError("No se pudo agendar la cita", ex);
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                Cita cita = LeerCita();
                cita.IdCita = IdSeleccionado();
                citaBL.Actualizar(cita);

                CargarCitas();
                LimpiarFormulario();
                MessageBox.Show("Cita actualizada correctamente.", "Citas",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MostrarError("No se pudo actualizar la cita", ex);
            }
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            try
            {
                citaBL.Confirmar(IdSeleccionado());

                CargarCitas();
                LimpiarFormulario();
                MessageBox.Show("Cita confirmada.", "Citas",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MostrarError("No se pudo confirmar la cita", ex);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            try
            {
                if (IdSeleccionado() <= 0)
                {
                    MessageBox.Show("Seleccione una cita de la tabla.", "Citas");
                    return;
                }

                DialogResult respuesta = MessageBox.Show(
                    "¿Desea cancelar esta cita?", "Cancelar cita",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (respuesta != DialogResult.Yes)
                    return;

                citaBL.Cancelar(IdSeleccionado());

                CargarCitas();
                LimpiarFormulario();
                MessageBox.Show("Cita cancelada.", "Citas",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MostrarError("No se pudo cancelar la cita", ex);
            }
        }

        private void btnEvaluar_Click(object sender, EventArgs e)
        {
            try
            {
                citaBL.Evaluar(IdSeleccionado(), txtDiagnostico.Text, txtObservaciones.Text);

                CargarCitas();
                LimpiarFormulario();
                MessageBox.Show("Evaluación guardada. La cita quedó como Atendida.", "Citas",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MostrarError("No se pudo guardar la evaluación", ex);
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
            dgvCitas.ClearSelection();
        }

        // ---------- Selección en la tabla ----------

        private void dgvCitas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0)
                    return;

                DataGridViewRow fila = dgvCitas.Rows[e.RowIndex];

                txtIdCita.Text = Texto(fila, "id_cita");

                cmbPaciente.SelectedValue = fila.Cells["id_paciente"].Value;
                cmbMedico.SelectedValue = fila.Cells["id_medico"].Value;

                dtpFecha.Value = Convert.ToDateTime(fila.Cells["fecha_hora_inicio"].Value);
                nudDuracion.Value = Convert.ToDecimal(fila.Cells["duracion_min"].Value);
                cmbGravedad.SelectedItem = Texto(fila, "gravedad");

                txtMotivo.Text = Texto(fila, "motivo");
                txtDiagnostico.Text = Texto(fila, "diagnostico");
                txtObservaciones.Text = Texto(fila, "observaciones");
            }
            catch (Exception ex)
            {
                MostrarError("Error al seleccionar la cita", ex);
            }
        }

        // ---------- Auxiliares ----------

        // Arma la entidad con lo que hay en pantalla. Las reglas las valida la BL.
        private Cita LeerCita()
        {
            DateTime v = dtpFecha.Value;

            return new Cita
            {
                IdPaciente = cmbPaciente.SelectedValue == null
                    ? 0 : Convert.ToInt32(cmbPaciente.SelectedValue),
                IdMedico = cmbMedico.SelectedValue == null
                    ? 0 : Convert.ToInt32(cmbMedico.SelectedValue),
                // Se descartan los segundos para que las comparaciones de horario sean exactas.
                FechaHoraInicio = new DateTime(v.Year, v.Month, v.Day, v.Hour, v.Minute, 0),
                DuracionMin = Convert.ToInt32(nudDuracion.Value),
                Motivo = txtMotivo.Text,
                Gravedad = cmbGravedad.SelectedItem == null
                    ? "" : cmbGravedad.SelectedItem.ToString(),
                Observaciones = txtObservaciones.Text
            };
        }

        private int IdSeleccionado()
        {
            int id;
            return int.TryParse(txtIdCita.Text, out id) ? id : 0;
        }

        private void LimpiarFormulario()
        {
            txtIdCita.Clear();
            txtMotivo.Clear();
            txtDiagnostico.Clear();
            txtObservaciones.Clear();

            cmbPaciente.SelectedIndex = -1;
            cmbMedico.SelectedIndex = -1;
            cmbGravedad.SelectedItem = "Leve";

            nudDuracion.Value = CitaBL.DuracionPorDefecto;
            dtpFecha.Value = DateTime.Today.AddDays(1).AddHours(8);
        }

        private static string Texto(DataGridViewRow fila, string columna)
        {
            object valor = fila.Cells[columna].Value;
            return (valor == null || valor == DBNull.Value) ? "" : valor.ToString();
        }

        private static void MostrarError(string titulo, Exception ex)
        {
            MessageBox.Show(titulo + ":\n\n" + ex.Message, "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
