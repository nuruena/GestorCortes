namespace Gestor_Cortes.Formularios
{
    partial class CortesCancelados
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnTerminado = new System.Windows.Forms.Button();
            this.btnCancelado = new System.Windows.Forms.Button();
            this.lblCortesCancelados = new System.Windows.Forms.Label();
            this.btnObservacion = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvCortesCancelados = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCortesCancelados)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnSalir);
            this.groupBox1.Controls.Add(this.btnTerminado);
            this.groupBox1.Controls.Add(this.btnCancelado);
            this.groupBox1.Controls.Add(this.lblCortesCancelados);
            this.groupBox1.Controls.Add(this.btnObservacion);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.dgvCortesCancelados);
            this.groupBox1.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1688, 913);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Cortes Cancelados";
            // 
            // btnSalir
            // 
            this.btnSalir.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalir.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalir.Location = new System.Drawing.Point(1487, 853);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(195, 53);
            this.btnSalir.TabIndex = 4;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.BtnSalir_Click);
            // 
            // btnTerminado
            // 
            this.btnTerminado.BackColor = System.Drawing.Color.PaleGreen;
            this.btnTerminado.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnTerminado.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTerminado.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTerminado.Location = new System.Drawing.Point(6, 853);
            this.btnTerminado.Name = "btnTerminado";
            this.btnTerminado.Size = new System.Drawing.Size(216, 53);
            this.btnTerminado.TabIndex = 3;
            this.btnTerminado.Text = "Terminado";
            this.btnTerminado.UseVisualStyleBackColor = false;
            this.btnTerminado.Click += new System.EventHandler(this.BtnTerminado_Click);
            // 
            // btnCancelado
            // 
            this.btnCancelado.BackColor = System.Drawing.Color.Firebrick;
            this.btnCancelado.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnCancelado.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelado.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelado.Location = new System.Drawing.Point(228, 853);
            this.btnCancelado.Name = "btnCancelado";
            this.btnCancelado.Size = new System.Drawing.Size(198, 53);
            this.btnCancelado.TabIndex = 6;
            this.btnCancelado.Text = "Cancelado";
            this.btnCancelado.UseVisualStyleBackColor = false;
            this.btnCancelado.Click += new System.EventHandler(this.BtnCancelado_Click);
            // 
            // lblCortesCancelados
            // 
            this.lblCortesCancelados.AutoSize = true;
            this.lblCortesCancelados.Location = new System.Drawing.Point(172, 23);
            this.lblCortesCancelados.Name = "lblCortesCancelados";
            this.lblCortesCancelados.Size = new System.Drawing.Size(15, 19);
            this.lblCortesCancelados.TabIndex = 2;
            this.lblCortesCancelados.Text = "-";
            // 
            // btnObservacion
            // 
            this.btnObservacion.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnObservacion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnObservacion.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnObservacion.Location = new System.Drawing.Point(432, 853);
            this.btnObservacion.Name = "btnObservacion";
            this.btnObservacion.Size = new System.Drawing.Size(247, 53);
            this.btnObservacion.TabIndex = 5;
            this.btnObservacion.Text = "Agregar Observación";
            this.btnObservacion.UseVisualStyleBackColor = true;
            this.btnObservacion.Click += new System.EventHandler(this.btnObservacion_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(150, 19);
            this.label1.TabIndex = 1;
            this.label1.Text = "Cortes cancelados:";
            // 
            // dgvCortesCancelados
            // 
            this.dgvCortesCancelados.AllowUserToAddRows = false;
            this.dgvCortesCancelados.AllowUserToDeleteRows = false;
            this.dgvCortesCancelados.AllowUserToResizeRows = false;
            this.dgvCortesCancelados.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader;
            this.dgvCortesCancelados.BackgroundColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCortesCancelados.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvCortesCancelados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCortesCancelados.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvCortesCancelados.Location = new System.Drawing.Point(6, 42);
            this.dgvCortesCancelados.MultiSelect = false;
            this.dgvCortesCancelados.Name = "dgvCortesCancelados";
            this.dgvCortesCancelados.ReadOnly = true;
            this.dgvCortesCancelados.RowHeadersVisible = false;
            this.dgvCortesCancelados.RowHeadersWidth = 51;
            this.dgvCortesCancelados.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvCortesCancelados.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvCortesCancelados.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            this.dgvCortesCancelados.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.dgvCortesCancelados.RowTemplate.Height = 40;
            this.dgvCortesCancelados.RowTemplate.ReadOnly = true;
            this.dgvCortesCancelados.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCortesCancelados.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCortesCancelados.Size = new System.Drawing.Size(1676, 805);
            this.dgvCortesCancelados.TabIndex = 0;
            // 
            // CortesCancelados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1712, 935);
            this.Controls.Add(this.groupBox1);
            this.Name = "CortesCancelados";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CortesCancelados";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.CortesCancelados_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCortesCancelados)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblCortesCancelados;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvCortesCancelados;
        private System.Windows.Forms.Button btnTerminado;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnObservacion;
        private System.Windows.Forms.Button btnCancelado;
    }
}