namespace AgendaMedica_UL
{
    partial class frmCitas
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
            this.lblPaciente = new System.Windows.Forms.Label();
            this.lblMedico = new System.Windows.Forms.Label();
            this.lblFecha = new System.Windows.Forms.Label();
            this.lblDuracion = new System.Windows.Forms.Label();
            this.lblGravedad = new System.Windows.Forms.Label();
            this.lblMotivo = new System.Windows.Forms.Label();
            this.lblIdCita = new System.Windows.Forms.Label();
            this.lblDiagnostico = new System.Windows.Forms.Label();
            this.lblObservaciones = new System.Windows.Forms.Label();
            this.cmbPaciente = new System.Windows.Forms.ComboBox();
            this.cmbMedico = new System.Windows.Forms.ComboBox();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.nudDuracion = new System.Windows.Forms.NumericUpDown();
            this.cmbGravedad = new System.Windows.Forms.ComboBox();
            this.txtMotivo = new System.Windows.Forms.TextBox();
            this.txtIdCita = new System.Windows.Forms.TextBox();
            this.txtDiagnostico = new System.Windows.Forms.TextBox();
            this.txtObservaciones = new System.Windows.Forms.TextBox();
            this.btnAgendar = new System.Windows.Forms.Button();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnEvaluar = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.dgvCitas = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.nudDuracion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCitas)).BeginInit();
            this.SuspendLayout();
            //
            // lblPaciente
            //
            this.lblPaciente.AutoSize = true;
            this.lblPaciente.Location = new System.Drawing.Point(20, 24);
            this.lblPaciente.Name = "lblPaciente";
            this.lblPaciente.Text = "Paciente";
            //
            // lblMedico
            //
            this.lblMedico.AutoSize = true;
            this.lblMedico.Location = new System.Drawing.Point(20, 59);
            this.lblMedico.Name = "lblMedico";
            this.lblMedico.Text = "Médico";
            //
            // lblFecha
            //
            this.lblFecha.AutoSize = true;
            this.lblFecha.Location = new System.Drawing.Point(20, 94);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Text = "Fecha y hora";
            //
            // lblDuracion
            //
            this.lblDuracion.AutoSize = true;
            this.lblDuracion.Location = new System.Drawing.Point(20, 129);
            this.lblDuracion.Name = "lblDuracion";
            this.lblDuracion.Text = "Duración (min)";
            //
            // lblGravedad
            //
            this.lblGravedad.AutoSize = true;
            this.lblGravedad.Location = new System.Drawing.Point(20, 164);
            this.lblGravedad.Name = "lblGravedad";
            this.lblGravedad.Text = "Gravedad";
            //
            // lblMotivo
            //
            this.lblMotivo.AutoSize = true;
            this.lblMotivo.Location = new System.Drawing.Point(20, 199);
            this.lblMotivo.Name = "lblMotivo";
            this.lblMotivo.Text = "Motivo";
            //
            // lblIdCita
            //
            this.lblIdCita.AutoSize = true;
            this.lblIdCita.Location = new System.Drawing.Point(430, 24);
            this.lblIdCita.Name = "lblIdCita";
            this.lblIdCita.Text = "ID cita";
            //
            // lblDiagnostico
            //
            this.lblDiagnostico.AutoSize = true;
            this.lblDiagnostico.Location = new System.Drawing.Point(430, 59);
            this.lblDiagnostico.Name = "lblDiagnostico";
            this.lblDiagnostico.Text = "Diagnóstico";
            //
            // lblObservaciones
            //
            this.lblObservaciones.AutoSize = true;
            this.lblObservaciones.Location = new System.Drawing.Point(430, 94);
            this.lblObservaciones.Name = "lblObservaciones";
            this.lblObservaciones.Text = "Observaciones";
            //
            // cmbPaciente
            //
            this.cmbPaciente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPaciente.Location = new System.Drawing.Point(140, 20);
            this.cmbPaciente.Name = "cmbPaciente";
            this.cmbPaciente.Size = new System.Drawing.Size(260, 24);
            //
            // cmbMedico
            //
            this.cmbMedico.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMedico.Location = new System.Drawing.Point(140, 55);
            this.cmbMedico.Name = "cmbMedico";
            this.cmbMedico.Size = new System.Drawing.Size(260, 24);
            //
            // dtpFecha
            //
            this.dtpFecha.CustomFormat = "dd/MM/yyyy HH:mm";
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFecha.Location = new System.Drawing.Point(140, 90);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(260, 22);
            //
            // nudDuracion
            //
            this.nudDuracion.Increment = new decimal(new int[] { 5, 0, 0, 0 });
            this.nudDuracion.Location = new System.Drawing.Point(140, 125);
            this.nudDuracion.Maximum = new decimal(new int[] { 120, 0, 0, 0 });
            this.nudDuracion.Minimum = new decimal(new int[] { 10, 0, 0, 0 });
            this.nudDuracion.Name = "nudDuracion";
            this.nudDuracion.Size = new System.Drawing.Size(100, 22);
            this.nudDuracion.Value = new decimal(new int[] { 30, 0, 0, 0 });
            //
            // cmbGravedad
            //
            this.cmbGravedad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGravedad.Location = new System.Drawing.Point(140, 160);
            this.cmbGravedad.Name = "cmbGravedad";
            this.cmbGravedad.Size = new System.Drawing.Size(260, 24);
            //
            // txtMotivo
            //
            this.txtMotivo.Location = new System.Drawing.Point(140, 195);
            this.txtMotivo.MaxLength = 200;
            this.txtMotivo.Name = "txtMotivo";
            this.txtMotivo.Size = new System.Drawing.Size(260, 22);
            //
            // txtIdCita
            //
            this.txtIdCita.Location = new System.Drawing.Point(540, 20);
            this.txtIdCita.Name = "txtIdCita";
            this.txtIdCita.ReadOnly = true;
            this.txtIdCita.Size = new System.Drawing.Size(80, 22);
            //
            // txtDiagnostico
            //
            this.txtDiagnostico.Location = new System.Drawing.Point(540, 55);
            this.txtDiagnostico.MaxLength = 200;
            this.txtDiagnostico.Name = "txtDiagnostico";
            this.txtDiagnostico.Size = new System.Drawing.Size(400, 22);
            //
            // txtObservaciones
            //
            this.txtObservaciones.Location = new System.Drawing.Point(540, 90);
            this.txtObservaciones.MaxLength = 500;
            this.txtObservaciones.Multiline = true;
            this.txtObservaciones.Name = "txtObservaciones";
            this.txtObservaciones.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtObservaciones.Size = new System.Drawing.Size(400, 100);
            //
            // btnAgendar
            //
            this.btnAgendar.Location = new System.Drawing.Point(20, 235);
            this.btnAgendar.Name = "btnAgendar";
            this.btnAgendar.Size = new System.Drawing.Size(120, 36);
            this.btnAgendar.Text = "Agendar";
            this.btnAgendar.UseVisualStyleBackColor = true;
            this.btnAgendar.Click += new System.EventHandler(this.btnAgendar_Click);
            //
            // btnActualizar
            //
            this.btnActualizar.Location = new System.Drawing.Point(150, 235);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(120, 36);
            this.btnActualizar.Text = "Reprogramar";
            this.btnActualizar.UseVisualStyleBackColor = true;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            //
            // btnConfirmar
            //
            this.btnConfirmar.Location = new System.Drawing.Point(280, 235);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(120, 36);
            this.btnConfirmar.Text = "Confirmar";
            this.btnConfirmar.UseVisualStyleBackColor = true;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            //
            // btnCancelar
            //
            this.btnCancelar.Location = new System.Drawing.Point(410, 235);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(120, 36);
            this.btnCancelar.Text = "Cancelar cita";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            //
            // btnEvaluar
            //
            this.btnEvaluar.Location = new System.Drawing.Point(540, 235);
            this.btnEvaluar.Name = "btnEvaluar";
            this.btnEvaluar.Size = new System.Drawing.Size(170, 36);
            this.btnEvaluar.Text = "Guardar evaluación";
            this.btnEvaluar.UseVisualStyleBackColor = true;
            this.btnEvaluar.Click += new System.EventHandler(this.btnEvaluar_Click);
            //
            // btnLimpiar
            //
            this.btnLimpiar.Location = new System.Drawing.Point(720, 235);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(120, 36);
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            //
            // dgvCitas
            //
            this.dgvCitas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvCitas.AllowUserToAddRows = false;
            this.dgvCitas.AllowUserToDeleteRows = false;
            this.dgvCitas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCitas.Location = new System.Drawing.Point(20, 290);
            this.dgvCitas.MultiSelect = false;
            this.dgvCitas.Name = "dgvCitas";
            this.dgvCitas.ReadOnly = true;
            this.dgvCitas.RowHeadersVisible = false;
            this.dgvCitas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCitas.Size = new System.Drawing.Size(1040, 360);
            this.dgvCitas.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCitas_CellClick);
            //
            // frmCitas
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1084, 671);
            this.Controls.Add(this.dgvCitas);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.btnEvaluar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnConfirmar);
            this.Controls.Add(this.btnActualizar);
            this.Controls.Add(this.btnAgendar);
            this.Controls.Add(this.txtObservaciones);
            this.Controls.Add(this.txtDiagnostico);
            this.Controls.Add(this.txtIdCita);
            this.Controls.Add(this.txtMotivo);
            this.Controls.Add(this.cmbGravedad);
            this.Controls.Add(this.nudDuracion);
            this.Controls.Add(this.dtpFecha);
            this.Controls.Add(this.cmbMedico);
            this.Controls.Add(this.cmbPaciente);
            this.Controls.Add(this.lblObservaciones);
            this.Controls.Add(this.lblDiagnostico);
            this.Controls.Add(this.lblIdCita);
            this.Controls.Add(this.lblMotivo);
            this.Controls.Add(this.lblGravedad);
            this.Controls.Add(this.lblDuracion);
            this.Controls.Add(this.lblFecha);
            this.Controls.Add(this.lblMedico);
            this.Controls.Add(this.lblPaciente);
            this.Name = "frmCitas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Citas";
            this.Load += new System.EventHandler(this.frmCitas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudDuracion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCitas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label lblPaciente;
        private System.Windows.Forms.Label lblMedico;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.Label lblDuracion;
        private System.Windows.Forms.Label lblGravedad;
        private System.Windows.Forms.Label lblMotivo;
        private System.Windows.Forms.Label lblIdCita;
        private System.Windows.Forms.Label lblDiagnostico;
        private System.Windows.Forms.Label lblObservaciones;
        private System.Windows.Forms.ComboBox cmbPaciente;
        private System.Windows.Forms.ComboBox cmbMedico;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.NumericUpDown nudDuracion;
        private System.Windows.Forms.ComboBox cmbGravedad;
        private System.Windows.Forms.TextBox txtMotivo;
        private System.Windows.Forms.TextBox txtIdCita;
        private System.Windows.Forms.TextBox txtDiagnostico;
        private System.Windows.Forms.TextBox txtObservaciones;
        private System.Windows.Forms.Button btnAgendar;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.Button btnConfirmar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnEvaluar;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.DataGridView dgvCitas;
    }
}
