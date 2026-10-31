namespace AgendaMedica_DAL
{
    partial class Form2
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
            this.dgvConector = new System.Windows.Forms.DataGridView();
            this.btnConectar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.txtID = new System.Windows.Forms.TextBox();
            this.btnID = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvConector)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvConector
            // 
            this.dgvConector.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvConector.Location = new System.Drawing.Point(12, 6);
            this.dgvConector.Name = "dgvConector";
            this.dgvConector.RowHeadersWidth = 51;
            this.dgvConector.RowTemplate.Height = 24;
            this.dgvConector.Size = new System.Drawing.Size(887, 280);
            this.dgvConector.TabIndex = 0;
            this.dgvConector.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvConector_CellContentClick);
            // 
            // btnConectar
            // 
            this.btnConectar.Location = new System.Drawing.Point(301, 323);
            this.btnConectar.Name = "btnConectar";
            this.btnConectar.Size = new System.Drawing.Size(119, 51);
            this.btnConectar.TabIndex = 1;
            this.btnConectar.Text = "Conectar ";
            this.btnConectar.UseVisualStyleBackColor = true;
            this.btnConectar.Click += new System.EventHandler(this.btnConectar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(317, 386);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(67, 28);
            this.btnSalir.TabIndex = 2;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(487, 352);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(97, 22);
            this.txtID.TabIndex = 3;
            this.txtID.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // btnID
            // 
            this.btnID.Location = new System.Drawing.Point(486, 380);
            this.btnID.Name = "btnID";
            this.btnID.Size = new System.Drawing.Size(98, 34);
            this.btnID.TabIndex = 4;
            this.btnID.Text = "Buscar ID";
            this.btnID.UseVisualStyleBackColor = true;
            this.btnID.Click += new System.EventHandler(this.btnID_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1013, 450);
            this.Controls.Add(this.btnID);
            this.Controls.Add(this.txtID);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnConectar);
            this.Controls.Add(this.dgvConector);
            this.Name = "Form2";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvConector)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvConector;
        private System.Windows.Forms.Button btnConectar;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.Button btnID;
    }
}