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

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnProbar_Click(object sender, EventArgs e)
        {
            // Implementación real del botón Probar
            string mensaje;
            bool ok = ConexionBL.Probar(out mensaje);

            MessageBox.Show(mensaje,
                ok ? "Éxito" : "Error",
                MessageBoxButtons.OK,
                ok ? MessageBoxIcon.Information : MessageBoxIcon.Error);
        }
    }
}
