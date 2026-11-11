using System.Drawing;
using System.Windows.Forms;

namespace AgendaMedica_DAL
{
    public static class Estilo
    {
        static readonly Color Primario = Color.FromArgb(11, 74, 143);
        static readonly Color Acento = Color.FromArgb(0, 132, 189);
        static readonly Color Peligro = Color.FromArgb(192, 57, 43);
        static readonly Color Neutro = Color.FromArgb(100, 116, 139);
        static readonly Color Texto = Color.FromArgb(30, 41, 59);

        public static void Aplicar(Form f)
        {
            f.SuspendLayout();
            f.Font = new Font("Segoe UI", 10F);
            Recorrer(f.Controls);
            f.ResumeLayout();
        }

        static void Recorrer(Control.ControlCollection controles)
        {
            foreach (Control c in controles)
            {
                if (c is Button b) Boton(b);
                else if (c is TextBox t) { t.BorderStyle = BorderStyle.FixedSingle; t.BackColor = Color.White; }
                else if (c is ComboBox cb) { cb.FlatStyle = FlatStyle.Flat; cb.BackColor = Color.White; }
                else if (c is DataGridView g) Tabla(g);
                if (c.HasChildren) Recorrer(c.Controls);
            }
        }

        static void Boton(Button b)
        {
            Color color = Primario;
            if (b.Name == "btnEliminar") color = Peligro;
            else if (b.Name == "btnLimpiar" || b.Name == "btnSalir") color = Neutro;
            else if (b.Name == "btnID" || b.Name == "btnConectar") color = Acento;

            b.FlatStyle = FlatStyle.Flat;
            b.FlatAppearance.BorderSize = 0;
            b.BackColor = color;
            b.ForeColor = Color.White;
            b.Font = new Font("Segoe UI Semibold", 10F);
            b.Cursor = Cursors.Hand;
        }

        static void Tabla(DataGridView g)
        {
            g.BorderStyle = BorderStyle.None;
            g.BackgroundColor = Color.White;
            g.EnableHeadersVisualStyles = false;
            g.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            g.ColumnHeadersHeight = 36;
            g.ColumnHeadersDefaultCellStyle.BackColor = Primario;
            g.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            g.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI Semibold", 10F);
            g.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 244, 251);
            g.DefaultCellStyle.SelectionBackColor = Color.FromArgb(191, 219, 254);
            g.DefaultCellStyle.SelectionForeColor = Texto;
            g.RowHeadersVisible = false;
            g.ReadOnly = true;
            g.AllowUserToAddRows = false;
            g.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            g.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
    }
}