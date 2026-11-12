using System;
using System.Windows.Forms;

namespace AgendaMedica_UL
{
    // Menú principal: desde aquí se entra a cada módulo.
    public partial class frmMenu : Form
    {
        public frmMenu()
        {
            InitializeComponent();
        }

        private void btnPersonal_Click(object sender, EventArgs e)
        {
            Abrir(new global::AgendaMedica_DAL.AgendaMedica());
        }

        private void btnPacientes_Click(object sender, EventArgs e)
        {
            // Temporal: se reemplaza por Abrir(new frmPacientes()) cuando exista la pantalla.
            MessageBox.Show("El módulo de pacientes se agregará próximamente.", "Pacientes",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnCitas_Click(object sender, EventArgs e)
        {
            Abrir(new frmCitas());
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            DialogResult respuesta = MessageBox.Show(
                "¿Desea salir de la aplicación?", "Salir",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (respuesta == DialogResult.Yes)
                Close();
        }

        // Oculta el menú mientras el módulo está abierto y lo vuelve a mostrar al cerrarlo.
        private void Abrir(Form formulario)
        {
            Hide();
            try
            {
                formulario.ShowDialog();
            }
            finally
            {
                formulario.Dispose();
                Show();
            }
        }
    }
}
