using System;
using System.Windows.Forms;

namespace AgendaMedica_UL
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnprobar = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnprobar
            // 
            this.btnprobar.Location = new System.Drawing.Point(90, 177);
            this.btnprobar.Name = "btnprobar";
            this.btnprobar.Size = new System.Drawing.Size(75, 23);
            this.btnprobar.TabIndex = 0;
            this.btnprobar.Text = "Probar";
            this.btnprobar.UseVisualStyleBackColor = true;
            this.btnprobar.Click += new System.EventHandler(this.btnprobar_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(240, 150);
            this.dataGridView1.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(287, 270);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnprobar);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        private void btnprobar_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
            
        }

        #endregion

        private System.Windows.Forms.Button btnprobar;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}

