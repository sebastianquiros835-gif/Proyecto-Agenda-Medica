namespace AgendaMedica_UL
{
    partial class frmMenu
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblTitulo = new System.Windows.Forms.Label();
            this.btnPersonal = new System.Windows.Forms.Button();
            this.btnPacientes = new System.Windows.Forms.Button();
            this.btnCitas = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.SuspendLayout();
            //
            // lblTitulo
            //
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Location = new System.Drawing.Point(60, 25);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Text = "Medical Dreams - Agenda Médica";
            //
            // btnPersonal
            //
            this.btnPersonal.Location = new System.Drawing.Point(60, 70);
            this.btnPersonal.Name = "btnPersonal";
            this.btnPersonal.Size = new System.Drawing.Size(260, 50);
            this.btnPersonal.Text = "Personal";
            this.btnPersonal.UseVisualStyleBackColor = true;
            this.btnPersonal.Click += new System.EventHandler(this.btnPersonal_Click);
            //
            // btnPacientes
            //
            this.btnPacientes.Location = new System.Drawing.Point(60, 135);
            this.btnPacientes.Name = "btnPacientes";
            this.btnPacientes.Size = new System.Drawing.Size(260, 50);
            this.btnPacientes.Text = "Pacientes";
            this.btnPacientes.UseVisualStyleBackColor = true;
            this.btnPacientes.Click += new System.EventHandler(this.btnPacientes_Click);
            //
            // btnCitas
            //
            this.btnCitas.Location = new System.Drawing.Point(60, 200);
            this.btnCitas.Name = "btnCitas";
            this.btnCitas.Size = new System.Drawing.Size(260, 50);
            this.btnCitas.Text = "Citas";
            this.btnCitas.UseVisualStyleBackColor = true;
            this.btnCitas.Click += new System.EventHandler(this.btnCitas_Click);
            //
            // btnSalir
            //
            this.btnSalir.Location = new System.Drawing.Point(60, 280);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(260, 40);
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            //
            // frmMenu
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 351);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnCitas);
            this.Controls.Add(this.btnPacientes);
            this.Controls.Add(this.btnPersonal);
            this.Controls.Add(this.lblTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menú principal";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Button btnPersonal;
        private System.Windows.Forms.Button btnPacientes;
        private System.Windows.Forms.Button btnCitas;
        private System.Windows.Forms.Button btnSalir;
    }
}
