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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        MySqlconection ob = new MySqlconection("datasource=127.0.0.1; port=3306; username=root;password = *A123456789* = database=agenda_medica");
        private void BtnConectar_Click(object sender, EventArgs e)
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

                dgvConector.DataSource = tabla;

                MessageBox.Show("Datos de la tabla personal cargados correctamente");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Desea salir de la aplicación?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                ob.Close();
                this.Close();
            }
        }
    }
}
    

