namespace Gestor_Cortes.Formularios
{
    partial class CortesExcluidos
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_terminado = new System.Windows.Forms.Button();
            this.btn_cancelado = new System.Windows.Forms.Button();
            this.btn_agregar_observacion = new System.Windows.Forms.Button();
            this.lblCortesEnTabla = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvCortesExcluidos = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCortesExcluidos)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_terminado);
            this.groupBox1.Controls.Add(this.btn_cancelado);
            this.groupBox1.Controls.Add(this.btn_agregar_observacion);
            this.groupBox1.Controls.Add(this.lblCortesEnTabla);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.dgvCortesExcluidos);
            this.groupBox1.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1688, 913);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Cortes Excluídos";
            // 
            // btn_terminado
            // 
            this.btn_terminado.BackColor = System.Drawing.Color.PaleGreen;
            this.btn_terminado.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btn_terminado.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_terminado.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_terminado.Location = new System.Drawing.Point(10, 854);
            this.btn_terminado.Name = "btn_terminado";
            this.btn_terminado.Size = new System.Drawing.Size(216, 53);
            this.btn_terminado.TabIndex = 10;
            this.btn_terminado.Text = "Terminado";
            this.btn_terminado.UseVisualStyleBackColor = false;
            this.btn_terminado.Click += new System.EventHandler(this.btn_terminado_Click);
            // 
            // btn_cancelado
            // 
            this.btn_cancelado.BackColor = System.Drawing.Color.Firebrick;
            this.btn_cancelado.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btn_cancelado.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_cancelado.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_cancelado.Location = new System.Drawing.Point(232, 854);
            this.btn_cancelado.Name = "btn_cancelado";
            this.btn_cancelado.Size = new System.Drawing.Size(198, 53);
            this.btn_cancelado.TabIndex = 12;
            this.btn_cancelado.Text = "Cancelado";
            this.btn_cancelado.UseVisualStyleBackColor = false;
            this.btn_cancelado.Click += new System.EventHandler(this.btn_cancelado_Click);
            // 
            // btn_agregar_observacion
            // 
            this.btn_agregar_observacion.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btn_agregar_observacion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_agregar_observacion.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_agregar_observacion.Location = new System.Drawing.Point(436, 854);
            this.btn_agregar_observacion.Name = "btn_agregar_observacion";
            this.btn_agregar_observacion.Size = new System.Drawing.Size(247, 53);
            this.btn_agregar_observacion.TabIndex = 11;
            this.btn_agregar_observacion.Text = "Agregar Observación";
            this.btn_agregar_observacion.UseVisualStyleBackColor = true;
            this.btn_agregar_observacion.Click += new System.EventHandler(this.btn_agregar_observacion_Click);
            // 
            // lblCortesEnTabla
            // 
            this.lblCortesEnTabla.AutoSize = true;
            this.lblCortesEnTabla.Location = new System.Drawing.Point(162, 24);
            this.lblCortesEnTabla.Name = "lblCortesEnTabla";
            this.lblCortesEnTabla.Size = new System.Drawing.Size(15, 19);
            this.lblCortesEnTabla.TabIndex = 2;
            this.lblCortesEnTabla.Text = "-";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(141, 19);
            this.label1.TabIndex = 1;
            this.label1.Text = "Cortes en la tabla:";
            // 
            // dgvCortesExcluidos
            // 
            this.dgvCortesExcluidos.AllowUserToAddRows = false;
            this.dgvCortesExcluidos.AllowUserToDeleteRows = false;
            this.dgvCortesExcluidos.AllowUserToResizeRows = false;
            this.dgvCortesExcluidos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader;
            this.dgvCortesExcluidos.BackgroundColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCortesExcluidos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvCortesExcluidos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCortesExcluidos.Location = new System.Drawing.Point(6, 44);
            this.dgvCortesExcluidos.MultiSelect = false;
            this.dgvCortesExcluidos.Name = "dgvCortesExcluidos";
            this.dgvCortesExcluidos.ReadOnly = true;
            this.dgvCortesExcluidos.RowHeadersVisible = false;
            this.dgvCortesExcluidos.RowHeadersWidth = 51;
            this.dgvCortesExcluidos.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvCortesExcluidos.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvCortesExcluidos.RowTemplate.Height = 40;
            this.dgvCortesExcluidos.RowTemplate.ReadOnly = true;
            this.dgvCortesExcluidos.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCortesExcluidos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCortesExcluidos.Size = new System.Drawing.Size(1676, 804);
            this.dgvCortesExcluidos.TabIndex = 0;
            this.dgvCortesExcluidos.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvCortesExcluidos_KeyDown);
            this.dgvCortesExcluidos.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dgvCortesExcluidos_KeyPress);
            // 
            // CortesExcluidos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(1446, 935);
            this.Controls.Add(this.groupBox1);
            this.Name = "CortesExcluidos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cortes Excluídos";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.CortesExcluidos_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCortesExcluidos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvCortesExcluidos;
        private System.Windows.Forms.Label lblCortesEnTabla;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_terminado;
        private System.Windows.Forms.Button btn_cancelado;
        private System.Windows.Forms.Button btn_agregar_observacion;
    }
}