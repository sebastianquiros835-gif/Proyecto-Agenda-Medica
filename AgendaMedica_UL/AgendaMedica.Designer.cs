namespace AgendaMedica_DAL
{
    partial class AgendaMedica
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AgendaMedica));
            this.dgvConector = new System.Windows.Forms.DataGridView();
            this.btnConectar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.txtID = new System.Windows.Forms.TextBox();
            this.btnID = new System.Windows.Forms.Button();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.txtCorreo = new System.Windows.Forms.TextBox();
            this.txtIdentificacion = new System.Windows.Forms.TextBox();
            this.txtRol = new System.Windows.Forms.TextBox();
            this.txtApellidos = new System.Windows.Forms.TextBox();
            this.lblNombre = new System.Windows.Forms.Label();
            this.lblApellido = new System.Windows.Forms.Label();
            this.lblIdentificacion = new System.Windows.Forms.Label();
            this.lblTelefono = new System.Windows.Forms.Label();
            this.lblCorreo = new System.Windows.Forms.Label();
            this.lblRol = new System.Windows.Forms.Label();
            this.cmbDepartamento = new System.Windows.Forms.ComboBox();
            this.cmbEstado = new System.Windows.Forms.ComboBox();
            this.txtIDpersonal = new System.Windows.Forms.TextBox();
            this.lblIDpersonal = new System.Windows.Forms.Label();
            this.txtEspecialidad = new System.Windows.Forms.TextBox();
            this.lblEspecialidad = new System.Windows.Forms.Label();
            this.lblEstado = new System.Windows.Forms.Label();
            this.lblDepartamento = new System.Windows.Forms.Label();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgvConector)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvConector
            // 
            this.dgvConector.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvConector.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvConector.Location = new System.Drawing.Point(37, 474);
            this.dgvConector.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvConector.Name = "dgvConector";
            this.dgvConector.RowHeadersWidth = 51;
            this.dgvConector.RowTemplate.Height = 24;
            this.dgvConector.Size = new System.Drawing.Size(1161, 218);
            this.dgvConector.TabIndex = 0;
            this.dgvConector.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvConector_CellContentClick);
            this.dgvConector.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvConector_CellContentClick);
            // 
            // btnConectar
            // 
            this.btnConectar.Location = new System.Drawing.Point(1049, 131);
            this.btnConectar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnConectar.Name = "btnConectar";
            this.btnConectar.Size = new System.Drawing.Size(165, 52);
            this.btnConectar.TabIndex = 1;
            this.btnConectar.Text = "Conectar ";
            this.btnConectar.UseVisualStyleBackColor = true;
            this.btnConectar.Click += new System.EventHandler(this.btnConectar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(1010, 383);
            this.btnSalir.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(150, 40);
            this.btnSalir.TabIndex = 2;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(819, 271);
            this.txtID.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(150, 23);
            this.txtID.TabIndex = 3;
            this.txtID.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // btnID
            // 
            this.btnID.Location = new System.Drawing.Point(819, 206);
            this.btnID.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnID.Name = "btnID";
            this.btnID.Size = new System.Drawing.Size(150, 40);
            this.btnID.TabIndex = 4;
            this.btnID.Text = "Consultar ID";
            this.btnID.UseVisualStyleBackColor = true;
            this.btnID.Click += new System.EventHandler(this.btnID_Click);
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(146, 201);
            this.txtNombre.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(311, 23);
            this.txtNombre.TabIndex = 5;
            // 
            // txtTelefono
            // 
            this.txtTelefono.Location = new System.Drawing.Point(146, 250);
            this.txtTelefono.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(311, 23);
            this.txtTelefono.TabIndex = 6;
            this.txtTelefono.TextChanged += new System.EventHandler(this.txtTelefono_TextChanged);
            // 
            // txtCorreo
            // 
            this.txtCorreo.Location = new System.Drawing.Point(584, 250);
            this.txtCorreo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtCorreo.Name = "txtCorreo";
            this.txtCorreo.Size = new System.Drawing.Size(176, 23);
            this.txtCorreo.TabIndex = 7;
            // 
            // txtIdentificacion
            // 
            this.txtIdentificacion.Location = new System.Drawing.Point(584, 347);
            this.txtIdentificacion.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtIdentificacion.Name = "txtIdentificacion";
            this.txtIdentificacion.Size = new System.Drawing.Size(188, 23);
            this.txtIdentificacion.TabIndex = 8;
            this.txtIdentificacion.TextChanged += new System.EventHandler(this.txtIdentificacion_TextChanged);
            // 
            // txtRol
            // 
            this.txtRol.Location = new System.Drawing.Point(584, 297);
            this.txtRol.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtRol.Name = "txtRol";
            this.txtRol.Size = new System.Drawing.Size(176, 23);
            this.txtRol.TabIndex = 9;
            this.txtRol.TextChanged += new System.EventHandler(this.txtRol_TextChanged);
            // 
            // txtApellidos
            // 
            this.txtApellidos.Location = new System.Drawing.Point(584, 206);
            this.txtApellidos.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtApellidos.Name = "txtApellidos";
            this.txtApellidos.Size = new System.Drawing.Size(178, 23);
            this.txtApellidos.TabIndex = 10;
            this.txtApellidos.TextChanged += new System.EventHandler(this.txtApellidos_TextChanged);
            // 
            // lblNombre
            // 
            this.lblNombre.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(217)))), ((int)(((byte)(242)))));
            this.lblNombre.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombre.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(36)))), ((int)(((byte)(58)))));
            this.lblNombre.Location = new System.Drawing.Point(45, 199);
            this.lblNombre.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(70, 24);
            this.lblNombre.TabIndex = 11;
            this.lblNombre.Text = "Nombre";
            // 
            // lblApellido
            // 
            this.lblApellido.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(217)))), ((int)(((byte)(242)))));
            this.lblApellido.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblApellido.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(36)))), ((int)(((byte)(58)))));
            this.lblApellido.Location = new System.Drawing.Point(482, 204);
            this.lblApellido.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblApellido.Name = "lblApellido";
            this.lblApellido.Size = new System.Drawing.Size(80, 29);
            this.lblApellido.TabIndex = 12;
            this.lblApellido.Text = "Apellidos";
            // 
            // lblIdentificacion
            // 
            this.lblIdentificacion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(217)))), ((int)(((byte)(242)))));
            this.lblIdentificacion.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIdentificacion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(36)))), ((int)(((byte)(58)))));
            this.lblIdentificacion.Location = new System.Drawing.Point(465, 347);
            this.lblIdentificacion.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblIdentificacion.Name = "lblIdentificacion";
            this.lblIdentificacion.Size = new System.Drawing.Size(111, 24);
            this.lblIdentificacion.TabIndex = 13;
            this.lblIdentificacion.Text = "Identificacion";
            this.lblIdentificacion.Click += new System.EventHandler(this.lblIdentificacion_Click);
            // 
            // lblTelefono
            // 
            this.lblTelefono.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(217)))), ((int)(((byte)(242)))));
            this.lblTelefono.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTelefono.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(36)))), ((int)(((byte)(58)))));
            this.lblTelefono.Location = new System.Drawing.Point(37, 253);
            this.lblTelefono.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTelefono.Name = "lblTelefono";
            this.lblTelefono.Size = new System.Drawing.Size(78, 24);
            this.lblTelefono.TabIndex = 14;
            this.lblTelefono.Text = "Telefono";
            // 
            // lblCorreo
            // 
            this.lblCorreo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(217)))), ((int)(((byte)(242)))));
            this.lblCorreo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCorreo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(36)))), ((int)(((byte)(58)))));
            this.lblCorreo.Location = new System.Drawing.Point(482, 253);
            this.lblCorreo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCorreo.Name = "lblCorreo";
            this.lblCorreo.Size = new System.Drawing.Size(56, 24);
            this.lblCorreo.TabIndex = 15;
            this.lblCorreo.Text = "Correo";
            // 
            // lblRol
            // 
            this.lblRol.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(217)))), ((int)(((byte)(242)))));
            this.lblRol.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRol.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(36)))), ((int)(((byte)(58)))));
            this.lblRol.Location = new System.Drawing.Point(482, 299);
            this.lblRol.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRol.Name = "lblRol";
            this.lblRol.Size = new System.Drawing.Size(36, 24);
            this.lblRol.TabIndex = 16;
            this.lblRol.Text = "Rol";
            // 
            // cmbDepartamento
            // 
            this.cmbDepartamento.FormattingEnabled = true;
            this.cmbDepartamento.Location = new System.Drawing.Point(146, 395);
            this.cmbDepartamento.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbDepartamento.Name = "cmbDepartamento";
            this.cmbDepartamento.Size = new System.Drawing.Size(311, 23);
            this.cmbDepartamento.TabIndex = 17;
            this.cmbDepartamento.SelectedIndexChanged += new System.EventHandler(this.cmbDepartamento_SelectedIndexChanged);
            // 
            // cmbEstado
            // 
            this.cmbEstado.FormattingEnabled = true;
            this.cmbEstado.Location = new System.Drawing.Point(584, 401);
            this.cmbEstado.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbEstado.Name = "cmbEstado";
            this.cmbEstado.Size = new System.Drawing.Size(178, 23);
            this.cmbEstado.TabIndex = 18;
            // 
            // txtIDpersonal
            // 
            this.txtIDpersonal.Location = new System.Drawing.Point(146, 347);
            this.txtIDpersonal.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtIDpersonal.Name = "txtIDpersonal";
            this.txtIDpersonal.Size = new System.Drawing.Size(311, 23);
            this.txtIDpersonal.TabIndex = 19;
            this.txtIDpersonal.TextChanged += new System.EventHandler(this.txtIDpersonal_TextChanged);
            // 
            // lblIDpersonal
            // 
            this.lblIDpersonal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(217)))), ((int)(((byte)(242)))));
            this.lblIDpersonal.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIDpersonal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(36)))), ((int)(((byte)(58)))));
            this.lblIDpersonal.Location = new System.Drawing.Point(33, 347);
            this.lblIDpersonal.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblIDpersonal.Name = "lblIDpersonal";
            this.lblIDpersonal.Size = new System.Drawing.Size(93, 21);
            this.lblIDpersonal.TabIndex = 20;
            this.lblIDpersonal.Text = "ID personal ";
            this.lblIDpersonal.Click += new System.EventHandler(this.lblIDpersonal_Click);
            // 
            // txtEspecialidad
            // 
            this.txtEspecialidad.Location = new System.Drawing.Point(146, 297);
            this.txtEspecialidad.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtEspecialidad.Name = "txtEspecialidad";
            this.txtEspecialidad.Size = new System.Drawing.Size(311, 23);
            this.txtEspecialidad.TabIndex = 21;
            this.txtEspecialidad.TextChanged += new System.EventHandler(this.txtEspecialidad_TextChanged);
            // 
            // lblEspecialidad
            // 
            this.lblEspecialidad.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(217)))), ((int)(((byte)(242)))));
            this.lblEspecialidad.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEspecialidad.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(36)))), ((int)(((byte)(58)))));
            this.lblEspecialidad.Location = new System.Drawing.Point(33, 299);
            this.lblEspecialidad.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblEspecialidad.Name = "lblEspecialidad";
            this.lblEspecialidad.Size = new System.Drawing.Size(82, 25);
            this.lblEspecialidad.TabIndex = 22;
            this.lblEspecialidad.Text = "Especialidad";
            // 
            // lblEstado
            // 
            this.lblEstado.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(217)))), ((int)(((byte)(242)))));
            this.lblEstado.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEstado.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(36)))), ((int)(((byte)(58)))));
            this.lblEstado.Location = new System.Drawing.Point(482, 401);
            this.lblEstado.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(85, 22);
            this.lblEstado.TabIndex = 23;
            this.lblEstado.Text = "Estado";
            // 
            // lblDepartamento
            // 
            this.lblDepartamento.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(217)))), ((int)(((byte)(242)))));
            this.lblDepartamento.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDepartamento.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(36)))), ((int)(((byte)(58)))));
            this.lblDepartamento.Location = new System.Drawing.Point(33, 398);
            this.lblDepartamento.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDepartamento.Name = "lblDepartamento";
            this.lblDepartamento.Size = new System.Drawing.Size(108, 25);
            this.lblDepartamento.TabIndex = 24;
            this.lblDepartamento.Text = "Departamento";
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(819, 340);
            this.btnGuardar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(150, 40);
            this.btnGuardar.TabIndex = 25;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnActualizar
            // 
            this.btnActualizar.Location = new System.Drawing.Point(1010, 218);
            this.btnActualizar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(150, 40);
            this.btnActualizar.TabIndex = 27;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.UseVisualStyleBackColor = true;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(1010, 278);
            this.btnEliminar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(150, 40);
            this.btnEliminar.TabIndex = 28;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(1010, 328);
            this.btnLimpiar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(150, 40);
            this.btnLimpiar.TabIndex = 29;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // AgendaMedica
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(217)))), ((int)(((byte)(242)))));
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1200, 761);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnActualizar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.lblDepartamento);
            this.Controls.Add(this.lblEstado);
            this.Controls.Add(this.lblEspecialidad);
            this.Controls.Add(this.txtEspecialidad);
            this.Controls.Add(this.lblIDpersonal);
            this.Controls.Add(this.txtIDpersonal);
            this.Controls.Add(this.cmbEstado);
            this.Controls.Add(this.cmbDepartamento);
            this.Controls.Add(this.lblRol);
            this.Controls.Add(this.lblCorreo);
            this.Controls.Add(this.lblTelefono);
            this.Controls.Add(this.lblIdentificacion);
            this.Controls.Add(this.lblApellido);
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.txtApellidos);
            this.Controls.Add(this.txtRol);
            this.Controls.Add(this.txtIdentificacion);
            this.Controls.Add(this.txtCorreo);
            this.Controls.Add(this.txtTelefono);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.btnID);
            this.Controls.Add(this.txtID);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnConectar);
            this.Controls.Add(this.dgvConector);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(36)))), ((int)(((byte)(58)))));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MinimumSize = new System.Drawing.Size(1000, 800);
            this.Name = "AgendaMedica";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Agenda Medica";
            this.Load += new System.EventHandler(this.AgendaMedica_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvConector)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvConector;
        private System.Windows.Forms.Button btnConectar;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.Button btnID;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtTelefono;
        private System.Windows.Forms.TextBox txtCorreo;
        private System.Windows.Forms.TextBox txtIdentificacion;
        private System.Windows.Forms.TextBox txtRol;
        private System.Windows.Forms.TextBox txtApellidos;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label lblApellido;
        private System.Windows.Forms.Label lblIdentificacion;
        private System.Windows.Forms.Label lblTelefono;
        private System.Windows.Forms.Label lblCorreo;
        private System.Windows.Forms.Label lblRol;
        private System.Windows.Forms.ComboBox cmbDepartamento;
        private System.Windows.Forms.ComboBox cmbEstado;
        private System.Windows.Forms.TextBox txtIDpersonal;
        private System.Windows.Forms.Label lblIDpersonal;
        private System.Windows.Forms.TextBox txtEspecialidad;
        private System.Windows.Forms.Label lblEspecialidad;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.Label lblDepartamento;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}