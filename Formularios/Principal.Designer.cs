namespace Gestor_Cortes
{
    partial class Principal
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
            this.BtnNuevoProceso = new System.Windows.Forms.Button();
            this.BtnRestaurar = new System.Windows.Forms.Button();
            this.BtnSalir = new System.Windows.Forms.Button();
            this.btnVerProceso = new System.Windows.Forms.Button();
            this.btnRestaruarAnterior = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BtnNuevoProceso
            // 
            this.BtnNuevoProceso.BackColor = System.Drawing.SystemColors.Window;
            this.BtnNuevoProceso.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.BtnNuevoProceso.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.BtnNuevoProceso.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnNuevoProceso.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnNuevoProceso.Location = new System.Drawing.Point(33, 16);
            this.BtnNuevoProceso.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.BtnNuevoProceso.Name = "BtnNuevoProceso";
            this.BtnNuevoProceso.Size = new System.Drawing.Size(137, 58);
            this.BtnNuevoProceso.TabIndex = 0;
            this.BtnNuevoProceso.Text = "Nuevo Proceso";
            this.BtnNuevoProceso.UseVisualStyleBackColor = false;
            this.BtnNuevoProceso.Click += new System.EventHandler(this.BtnNuevoProceso_Click);
            // 
            // BtnRestaurar
            // 
            this.BtnRestaurar.BackColor = System.Drawing.SystemColors.Window;
            this.BtnRestaurar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.BtnRestaurar.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.BtnRestaurar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnRestaurar.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnRestaurar.Location = new System.Drawing.Point(33, 89);
            this.BtnRestaurar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.BtnRestaurar.Name = "BtnRestaurar";
            this.BtnRestaurar.Size = new System.Drawing.Size(137, 58);
            this.BtnRestaurar.TabIndex = 1;
            this.BtnRestaurar.Text = "Restaurar Último Proceso Creado";
            this.BtnRestaurar.UseVisualStyleBackColor = false;
            this.BtnRestaurar.Click += new System.EventHandler(this.BtnRestaurar_Click);
            // 
            // BtnSalir
            // 
            this.BtnSalir.BackColor = System.Drawing.SystemColors.Window;
            this.BtnSalir.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.BtnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnSalir.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSalir.Location = new System.Drawing.Point(33, 307);
            this.BtnSalir.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.BtnSalir.Name = "BtnSalir";
            this.BtnSalir.Size = new System.Drawing.Size(137, 58);
            this.BtnSalir.TabIndex = 2;
            this.BtnSalir.Text = "Salir";
            this.BtnSalir.UseVisualStyleBackColor = false;
            this.BtnSalir.Click += new System.EventHandler(this.BtnSalir_Click);
            // 
            // btnVerProceso
            // 
            this.btnVerProceso.BackColor = System.Drawing.SystemColors.Window;
            this.btnVerProceso.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnVerProceso.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVerProceso.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVerProceso.Location = new System.Drawing.Point(33, 234);
            this.btnVerProceso.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnVerProceso.Name = "btnVerProceso";
            this.btnVerProceso.Size = new System.Drawing.Size(137, 58);
            this.btnVerProceso.TabIndex = 3;
            this.btnVerProceso.Text = "Ver Proceso";
            this.btnVerProceso.UseVisualStyleBackColor = false;
            this.btnVerProceso.Click += new System.EventHandler(this.BtnVerProceso_Click);
            // 
            // btnRestaruarAnterior
            // 
            this.btnRestaruarAnterior.BackColor = System.Drawing.SystemColors.Window;
            this.btnRestaruarAnterior.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnRestaruarAnterior.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRestaruarAnterior.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRestaruarAnterior.Location = new System.Drawing.Point(33, 162);
            this.btnRestaruarAnterior.Margin = new System.Windows.Forms.Padding(2);
            this.btnRestaruarAnterior.Name = "btnRestaruarAnterior";
            this.btnRestaruarAnterior.Size = new System.Drawing.Size(137, 58);
            this.btnRestaruarAnterior.TabIndex = 4;
            this.btnRestaruarAnterior.Text = "Restaurar Proceso Anterior";
            this.btnRestaruarAnterior.UseVisualStyleBackColor = false;
            this.btnRestaruarAnterior.Click += new System.EventHandler(this.BtnRestaruarAnterior_Click);
            // 
            // Principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(203, 381);
            this.Controls.Add(this.btnRestaruarAnterior);
            this.Controls.Add(this.btnVerProceso);
            this.Controls.Add(this.BtnSalir);
            this.Controls.Add(this.BtnRestaurar);
            this.Controls.Add(this.BtnNuevoProceso);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Principal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "G. C.";
            this.Load += new System.EventHandler(this.Principal_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BtnNuevoProceso;
        private System.Windows.Forms.Button BtnRestaurar;
        private System.Windows.Forms.Button BtnSalir;
        private System.Windows.Forms.Button btnVerProceso;
        private System.Windows.Forms.Button btnRestaruarAnterior;
    }
}

