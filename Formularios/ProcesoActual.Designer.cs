namespace Gestor_Cortes.Formularios
{
    partial class ProcesoActual
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblNombreProceso = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCortesCancelados = new System.Windows.Forms.Button();
            this.lblCortesEnTabla = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnAgregarCortes = new System.Windows.Forms.Button();
            this.BtnCortesExcluidos = new System.Windows.Forms.Button();
            this.BtnEnProceso = new System.Windows.Forms.Button();
            this.BtnTerminado = new System.Windows.Forms.Button();
            this.BtnCancelado = new System.Windows.Forms.Button();
            this.BtnObservacion = new System.Windows.Forms.Button();
            this.BtnGuardarYSalir = new System.Windows.Forms.Button();
            this.DgvCortes = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvCortes)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.lblNombreProceso);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnCortesCancelados);
            this.groupBox1.Controls.Add(this.lblCortesEnTabla);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.btnAgregarCortes);
            this.groupBox1.Controls.Add(this.BtnCortesExcluidos);
            this.groupBox1.Controls.Add(this.BtnEnProceso);
            this.groupBox1.Controls.Add(this.BtnTerminado);
            this.groupBox1.Controls.Add(this.BtnCancelado);
            this.groupBox1.Controls.Add(this.BtnObservacion);
            this.groupBox1.Controls.Add(this.BtnGuardarYSalir);
            this.groupBox1.Controls.Add(this.DgvCortes);
            this.groupBox1.Font = new System.Drawing.Font("Arial", 10F);
            this.groupBox1.Location = new System.Drawing.Point(12, 11);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(1688, 913);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Cortes";
            // 
            // lblNombreProceso
            // 
            this.lblNombreProceso.AutoSize = true;
            this.lblNombreProceso.Location = new System.Drawing.Point(407, 22);
            this.lblNombreProceso.Name = "lblNombreProceso";
            this.lblNombreProceso.Size = new System.Drawing.Size(15, 19);
            this.lblNombreProceso.TabIndex = 12;
            this.lblNombreProceso.Text = "-";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(326, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 19);
            this.label1.TabIndex = 11;
            this.label1.Text = "Proceso:";
            // 
            // btnCortesCancelados
            // 
            this.btnCortesCancelados.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnCortesCancelados.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCortesCancelados.Location = new System.Drawing.Point(1167, 860);
            this.btnCortesCancelados.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCortesCancelados.Name = "btnCortesCancelados";
            this.btnCortesCancelados.Size = new System.Drawing.Size(211, 43);
            this.btnCortesCancelados.TabIndex = 10;
            this.btnCortesCancelados.Text = "Ver Cortes Cancelados";
            this.btnCortesCancelados.UseVisualStyleBackColor = true;
            this.btnCortesCancelados.Click += new System.EventHandler(this.BtnCortesCancelados_Click);
            // 
            // lblCortesEnTabla
            // 
            this.lblCortesEnTabla.AutoSize = true;
            this.lblCortesEnTabla.Location = new System.Drawing.Point(136, 22);
            this.lblCortesEnTabla.Name = "lblCortesEnTabla";
            this.lblCortesEnTabla.Size = new System.Drawing.Size(15, 19);
            this.lblCortesEnTabla.TabIndex = 7;
            this.lblCortesEnTabla.Text = "-";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(124, 19);
            this.label2.TabIndex = 6;
            this.label2.Text = "Cortes en tabla:";
            // 
            // btnAgregarCortes
            // 
            this.btnAgregarCortes.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnAgregarCortes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregarCortes.Location = new System.Drawing.Point(773, 860);
            this.btnAgregarCortes.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAgregarCortes.Name = "btnAgregarCortes";
            this.btnAgregarCortes.Size = new System.Drawing.Size(184, 43);
            this.btnAgregarCortes.TabIndex = 3;
            this.btnAgregarCortes.Text = "Agregar Cortes";
            this.btnAgregarCortes.UseVisualStyleBackColor = true;
            this.btnAgregarCortes.Click += new System.EventHandler(this.BtnAgregarCortes_Click);
            // 
            // BtnCortesExcluidos
            // 
            this.BtnCortesExcluidos.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.BtnCortesExcluidos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnCortesExcluidos.Location = new System.Drawing.Point(963, 860);
            this.BtnCortesExcluidos.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BtnCortesExcluidos.Name = "BtnCortesExcluidos";
            this.BtnCortesExcluidos.Size = new System.Drawing.Size(198, 43);
            this.BtnCortesExcluidos.TabIndex = 2;
            this.BtnCortesExcluidos.Text = "Ver Cortes Excluídos";
            this.BtnCortesExcluidos.UseVisualStyleBackColor = true;
            this.BtnCortesExcluidos.Click += new System.EventHandler(this.BtnCortesExcluidos_Click);
            // 
            // BtnEnProceso
            // 
            this.BtnEnProceso.BackColor = System.Drawing.Color.LightSkyBlue;
            this.BtnEnProceso.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.BtnEnProceso.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnEnProceso.Location = new System.Drawing.Point(6, 860);
            this.BtnEnProceso.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BtnEnProceso.Name = "BtnEnProceso";
            this.BtnEnProceso.Size = new System.Drawing.Size(184, 43);
            this.BtnEnProceso.TabIndex = 2;
            this.BtnEnProceso.Text = "En Proceso";
            this.BtnEnProceso.UseVisualStyleBackColor = false;
            this.BtnEnProceso.Click += new System.EventHandler(this.BtnEnProceso_Click);
            // 
            // BtnTerminado
            // 
            this.BtnTerminado.BackColor = System.Drawing.Color.PaleGreen;
            this.BtnTerminado.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.BtnTerminado.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnTerminado.Location = new System.Drawing.Point(196, 860);
            this.BtnTerminado.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BtnTerminado.Name = "BtnTerminado";
            this.BtnTerminado.Size = new System.Drawing.Size(184, 43);
            this.BtnTerminado.TabIndex = 1;
            this.BtnTerminado.Text = "Terminado";
            this.BtnTerminado.UseVisualStyleBackColor = false;
            this.BtnTerminado.Click += new System.EventHandler(this.BtnTerminado_Click);
            // 
            // BtnCancelado
            // 
            this.BtnCancelado.BackColor = System.Drawing.Color.Firebrick;
            this.BtnCancelado.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.BtnCancelado.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnCancelado.Location = new System.Drawing.Point(386, 860);
            this.BtnCancelado.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BtnCancelado.Name = "BtnCancelado";
            this.BtnCancelado.Size = new System.Drawing.Size(184, 43);
            this.BtnCancelado.TabIndex = 5;
            this.BtnCancelado.Text = "Cancelado";
            this.BtnCancelado.UseVisualStyleBackColor = false;
            this.BtnCancelado.Click += new System.EventHandler(this.BtnCancelado_Click);
            // 
            // BtnObservacion
            // 
            this.BtnObservacion.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.BtnObservacion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnObservacion.Location = new System.Drawing.Point(576, 860);
            this.BtnObservacion.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BtnObservacion.Name = "BtnObservacion";
            this.BtnObservacion.Size = new System.Drawing.Size(191, 43);
            this.BtnObservacion.TabIndex = 4;
            this.BtnObservacion.Text = "Agregar Observación";
            this.BtnObservacion.UseVisualStyleBackColor = true;
            this.BtnObservacion.Click += new System.EventHandler(this.BtnObservacion_Click);
            // 
            // BtnGuardarYSalir
            // 
            this.BtnGuardarYSalir.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.BtnGuardarYSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnGuardarYSalir.Location = new System.Drawing.Point(1506, 860);
            this.BtnGuardarYSalir.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BtnGuardarYSalir.Name = "BtnGuardarYSalir";
            this.BtnGuardarYSalir.Size = new System.Drawing.Size(176, 43);
            this.BtnGuardarYSalir.TabIndex = 3;
            this.BtnGuardarYSalir.Text = "Guardar y Salir";
            this.BtnGuardarYSalir.UseVisualStyleBackColor = true;
            this.BtnGuardarYSalir.Click += new System.EventHandler(this.BtnGuardarYSalir_Click);
            // 
            // DgvCortes
            // 
            this.DgvCortes.AllowUserToAddRows = false;
            this.DgvCortes.AllowUserToDeleteRows = false;
            this.DgvCortes.AllowUserToResizeRows = false;
            this.DgvCortes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DgvCortes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader;
            this.DgvCortes.BackgroundColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Info;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 10F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvCortes.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.DgvCortes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvCortes.Location = new System.Drawing.Point(6, 46);
            this.DgvCortes.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.DgvCortes.MultiSelect = false;
            this.DgvCortes.Name = "DgvCortes";
            this.DgvCortes.ReadOnly = true;
            this.DgvCortes.RowHeadersVisible = false;
            this.DgvCortes.RowHeadersWidth = 4;
            this.DgvCortes.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.DgvCortes.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DgvCortes.RowTemplate.Height = 40;
            this.DgvCortes.RowTemplate.ReadOnly = true;
            this.DgvCortes.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.DgvCortes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvCortes.Size = new System.Drawing.Size(1682, 805);
            this.DgvCortes.TabIndex = 0;
            this.DgvCortes.SelectionChanged += new System.EventHandler(this.DgvCortes_SelectionChanged);
            this.DgvCortes.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DgvCortes_KeyDown);
            this.DgvCortes.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.DgvCortes_KeyPress);
            // 
            // ProcesoActual
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(1712, 935);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "ProcesoActual";
            this.Text = "Proceso Actual";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.ProcesoActual_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvCortes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView DgvCortes;
        private System.Windows.Forms.Button BtnCancelado;
        private System.Windows.Forms.Button BtnObservacion;
        private System.Windows.Forms.Button BtnGuardarYSalir;
        private System.Windows.Forms.Button BtnCortesExcluidos;
        private System.Windows.Forms.Button BtnTerminado;
        private System.Windows.Forms.Button BtnEnProceso;
        private System.Windows.Forms.Button btnAgregarCortes;
        private System.Windows.Forms.Label lblCortesEnTabla;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnCortesCancelados;
        private System.Windows.Forms.Label lblNombreProceso;
        private System.Windows.Forms.Label label1;
    }
}