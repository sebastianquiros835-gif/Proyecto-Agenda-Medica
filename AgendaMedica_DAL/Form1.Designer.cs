namespace AgendaMedica_DAL
{
    partial class form1
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
            ((System.ComponentModel.ISupportInitialize)(this.dgvConector)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvConector
            // 
            this.dgvConector.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvConector.Location = new System.Drawing.Point(174, 56);
            this.dgvConector.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dgvConector.Name = "dgvConector";
            this.dgvConector.RowHeadersWidth = 51;
            this.dgvConector.RowTemplate.Height = 24;
            this.dgvConector.Size = new System.Drawing.Size(213, 101);
            this.dgvConector.TabIndex = 0;
            this.dgvConector.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvConector_CellContentClick);
            // 
            // btnConectar
            // 
            this.btnConectar.Location = new System.Drawing.Point(239, 169);
            this.btnConectar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnConectar.Name = "btnConectar";
            this.btnConectar.Size = new System.Drawing.Size(68, 41);
            this.btnConectar.TabIndex = 1;
            this.btnConectar.Text = "Conectar ";
            this.btnConectar.UseVisualStyleBackColor = true;
            this.btnConectar.Click += new System.EventHandler(this.btnConectar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(256, 232);
            this.btnSalir.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(50, 23);
            this.btnSalir.TabIndex = 2;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 366);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnConectar);
            this.Controls.Add(this.dgvConector);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dgvConector)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvConector;
        private System.Windows.Forms.Button btnConectar;
        private System.Windows.Forms.Button btnSalir;
    }
}