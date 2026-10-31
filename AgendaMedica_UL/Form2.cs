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

        MySqlConnection ob = new MySqlConnection(
     "server=127.0.0.1;port=3306;user id=root;password=*A123456789*;database=agenda_medica;"
 );
        private string consulta;
        private static object con;

        private void btnConectar_Click(object sender, EventArgs e)
        {
            try

            {   
                ob.Open();
                MessageBox.Show("Conexión exitosa");
            }
            catch (Exception)
            {
                MessageBox.Show("no se pudo conectar a la base de datos");
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
    }
}
    

