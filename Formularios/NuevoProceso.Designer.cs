namespace Gestor_Cortes.Formularios
{
    partial class NuevoProceso
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
            this.BtnSeleccionar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.MaskNumOrden = new System.Windows.Forms.MaskedTextBox();
            this.DgvHojasSeleccionadas = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.BtnEliminar = new System.Windows.Forms.Button();
            this.BtnAceptar = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.BtnBorrar = new System.Windows.Forms.Button();
            this.BtnAgregar = new System.Windows.Forms.Button();
            this.LblSeleccion = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.MaskCantidad = new System.Windows.Forms.MaskedTextBox();
            this.fileSystemWatcher1 = new System.IO.FileSystemWatcher();
            ((System.ComponentModel.ISupportInitialize)(this.DgvHojasSeleccionadas)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).BeginInit();
            this.SuspendLayout();
            // 
            // BtnSeleccionar
            // 
            this.BtnSeleccionar.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.BtnSeleccionar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnSeleccionar.Location = new System.Drawing.Point(632, 20);
            this.BtnSeleccionar.Margin = new System.Windows.Forms.Padding(2);
            this.BtnSeleccionar.Name = "BtnSeleccionar";
            this.BtnSeleccionar.Size = new System.Drawing.Size(138, 34);
            this.BtnSeleccionar.TabIndex = 2;
            this.BtnSeleccionar.Text = "Seleccionar";
            this.BtnSeleccionar.UseVisualStyleBackColor = true;
            this.BtnSeleccionar.Click += new System.EventHandler(this.BtnSeleccionar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 28);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 19);
            this.label1.TabIndex = 1;
            this.label1.Text = "N° de Orden:";
            // 
            // MaskNumOrden
            // 
            this.MaskNumOrden.Location = new System.Drawing.Point(138, 25);
            this.MaskNumOrden.Margin = new System.Windows.Forms.Padding(2);
            this.MaskNumOrden.Mask = "0000000000000";
            this.MaskNumOrden.Name = "MaskNumOrden";
            this.MaskNumOrden.PromptChar = ' ';
            this.MaskNumOrden.Size = new System.Drawing.Size(144, 27);
            this.MaskNumOrden.TabIndex = 0;
            this.MaskNumOrden.Click += new System.EventHandler(this.MaskNumOrden_Click);
            // 
            // DgvHojasSeleccionadas
            // 
            this.DgvHojasSeleccionadas.AllowUserToAddRows = false;
            this.DgvHojasSeleccionadas.AllowUserToDeleteRows = false;
            this.DgvHojasSeleccionadas.AllowUserToResizeRows = false;
            this.DgvHojasSeleccionadas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DgvHojasSeleccionadas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.DgvHojasSeleccionadas.BackgroundColor = System.Drawing.SystemColors.Window;
            this.DgvHojasSeleccionadas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DgvHojasSeleccionadas.DefaultCellStyle = dataGridViewCellStyle1;
            this.DgvHojasSeleccionadas.GridColor = System.Drawing.Color.Silver;
            this.DgvHojasSeleccionadas.Location = new System.Drawing.Point(4, 24);
            this.DgvHojasSeleccionadas.Margin = new System.Windows.Forms.Padding(2);
            this.DgvHojasSeleccionadas.MultiSelect = false;
            this.DgvHojasSeleccionadas.Name = "DgvHojasSeleccionadas";
            this.DgvHojasSeleccionadas.ReadOnly = true;
            this.DgvHojasSeleccionadas.RowHeadersVisible = false;
            this.DgvHojasSeleccionadas.RowHeadersWidth = 51;
            this.DgvHojasSeleccionadas.RowTemplate.Height = 40;
            this.DgvHojasSeleccionadas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvHojasSeleccionadas.Size = new System.Drawing.Size(1339, 507);
            this.DgvHojasSeleccionadas.TabIndex = 3;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.BtnEliminar);
            this.groupBox1.Controls.Add(this.BtnAceptar);
            this.groupBox1.Controls.Add(this.DgvHojasSeleccionadas);
            this.groupBox1.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 81);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(1347, 611);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Hojas de Corte Seleccionadas";
            // 
            // BtnEliminar
            // 
            this.BtnEliminar.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.BtnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnEliminar.Location = new System.Drawing.Point(6, 800);
            this.BtnEliminar.Margin = new System.Windows.Forms.Padding(2);
            this.BtnEliminar.Name = "BtnEliminar";
            this.BtnEliminar.Size = new System.Drawing.Size(115, 34);
            this.BtnEliminar.TabIndex = 9;
            this.BtnEliminar.Text = "Eliminar";
            this.BtnEliminar.UseVisualStyleBackColor = true;
            this.BtnEliminar.Click += new System.EventHandler(this.BtnEliminar_Click);
            // 
            // BtnAceptar
            // 
            this.BtnAceptar.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.BtnAceptar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnAceptar.Location = new System.Drawing.Point(1562, 800);
            this.BtnAceptar.Margin = new System.Windows.Forms.Padding(2);
            this.BtnAceptar.Name = "BtnAceptar";
            this.BtnAceptar.Size = new System.Drawing.Size(116, 34);
            this.BtnAceptar.TabIndex = 8;
            this.BtnAceptar.Text = "Aceptar";
            this.BtnAceptar.UseVisualStyleBackColor = true;
            this.BtnAceptar.Click += new System.EventHandler(this.BtnAceptar_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.BtnBorrar);
            this.groupBox2.Controls.Add(this.BtnAgregar);
            this.groupBox2.Controls.Add(this.LblSeleccion);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.BtnSeleccionar);
            this.groupBox2.Controls.Add(this.MaskCantidad);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.MaskNumOrden);
            this.groupBox2.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(1688, 65);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Nueva Hoja de Corte";
            // 
            // BtnBorrar
            // 
            this.BtnBorrar.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.BtnBorrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnBorrar.Location = new System.Drawing.Point(1578, 20);
            this.BtnBorrar.Margin = new System.Windows.Forms.Padding(2);
            this.BtnBorrar.Name = "BtnBorrar";
            this.BtnBorrar.Size = new System.Drawing.Size(100, 34);
            this.BtnBorrar.TabIndex = 8;
            this.BtnBorrar.Text = "Borrar";
            this.BtnBorrar.UseVisualStyleBackColor = true;
            this.BtnBorrar.Click += new System.EventHandler(this.BtnBorrar_Click);
            // 
            // BtnAgregar
            // 
            this.BtnAgregar.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.BtnAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnAgregar.Location = new System.Drawing.Point(1460, 20);
            this.BtnAgregar.Margin = new System.Windows.Forms.Padding(2);
            this.BtnAgregar.Name = "BtnAgregar";
            this.BtnAgregar.Size = new System.Drawing.Size(112, 34);
            this.BtnAgregar.TabIndex = 7;
            this.BtnAgregar.Text = "Agregar";
            this.BtnAgregar.UseVisualStyleBackColor = true;
            this.BtnAgregar.Click += new System.EventHandler(this.BtnAgregar_Click);
            // 
            // LblSeleccion
            // 
            this.LblSeleccion.AutoSize = true;
            this.LblSeleccion.Location = new System.Drawing.Point(778, 28);
            this.LblSeleccion.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LblSeleccion.Name = "LblSeleccion";
            this.LblSeleccion.Size = new System.Drawing.Size(107, 19);
            this.LblSeleccion.TabIndex = 6;
            this.LblSeleccion.Text = "Sin selección";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(494, 28);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(114, 19);
            this.label3.TabIndex = 5;
            this.label3.Text = "Hoja de Corte:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(299, 28);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 19);
            this.label2.TabIndex = 3;
            this.label2.Text = "Cantidad:";
            // 
            // MaskCantidad
            // 
            this.MaskCantidad.Location = new System.Drawing.Point(392, 25);
            this.MaskCantidad.Margin = new System.Windows.Forms.Padding(2);
            this.MaskCantidad.Mask = "000000";
            this.MaskCantidad.Name = "MaskCantidad";
            this.MaskCantidad.PromptChar = ' ';
            this.MaskCantidad.Size = new System.Drawing.Size(83, 27);
            this.MaskCantidad.TabIndex = 1;
            this.MaskCantidad.Click += new System.EventHandler(this.MaskCantidad_Click);
            // 
            // fileSystemWatcher1
            // 
            this.fileSystemWatcher1.EnableRaisingEvents = true;
            this.fileSystemWatcher1.SynchronizingObject = this;
            // 
            // NuevoProceso
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(1370, 749);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "NuevoProceso";
            this.Text = "Nuevo Proceso";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.NuevoProceso_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DgvHojasSeleccionadas)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BtnSeleccionar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MaskedTextBox MaskNumOrden;
        private System.Windows.Forms.DataGridView DgvHojasSeleccionadas;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button BtnEliminar;
        private System.Windows.Forms.Button BtnAceptar;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label LblSeleccion;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MaskedTextBox MaskCantidad;
        private System.IO.FileSystemWatcher fileSystemWatcher1;
        private System.Windows.Forms.Button BtnBorrar;
        private System.Windows.Forms.Button BtnAgregar;
    }
}