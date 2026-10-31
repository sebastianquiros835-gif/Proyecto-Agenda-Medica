
using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace AgendaMedica_DAL
{
    public partial class Form1 : Form
    {
        MySqlConnection ob = new MySqlConnection(
            "server=127.0.0.1;port=3306;user id=root;password=*A123456789*;database=agenda_medica;"
        );

        public Form1()
        {
            InitializeComponent();
        }

        private void btnConectar_Click(object sender, EventArgs e)        {
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
                dgvConector.DataSource = null;
                dgvConector.DataSource = tabla;

                MessageBox.Show(
                    "Filas encontradas: " + tabla.Rows.Count +
                    "\nColumnas encontradas: " + tabla.Columns.Count
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
        private void btnSalir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(
                "¿Desea salir de la aplicación?",
                "Salir",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (ob.State != ConnectionState.Closed)
                {
                    ob.Close();
                }

                this.Close();
            }
        }

        private void dgvConector_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
    

