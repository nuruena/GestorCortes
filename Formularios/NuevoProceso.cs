using Gestor_Cortes.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gestor_Cortes.Formularios
{
    public partial class NuevoProceso : Form
    {
        OpenFileDialog ofd = null;
        public static string path = "C:\\Gestor Cortes\\Plantillas";
        DataTable dt = new DataTable("Cortes");

        public NuevoProceso()
        {
            InitializeComponent();
        }
        private void BtnSeleccionar_Click(object sender, EventArgs e)
        {
            ofd = new OpenFileDialog();
            ofd.InitialDirectory = path;
            ofd.Filter = "Archivos Excel|*.xls;*.xlsx;*.xlsm";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                if (ofd.SafeFileName.Length >= 41)
                {
                    LblSeleccion.Text = ofd.SafeFileName.Remove(40) + "...";
                }
                else
                {
                    LblSeleccion.Text = ofd.SafeFileName;
                }
            }
            else
            {
                LblSeleccion.Text = "Sin selección";
            }
        }

        private void NuevoProceso_Load(object sender, EventArgs e)
        {
            dt.Columns.Add("N° Orden");
            dt.Columns.Add("Cantidad");
            dt.Columns.Add("Hoja de Corte");
            dt.Columns.Add("Ubicación");
            ActualizarDgv();
            DgvHojasSeleccionadas.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            if (MaskCantidad.Text == "" | MaskCantidad.Text == "0") { MessageBox.Show("Ingrese una cantidad", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); MaskCantidad.Text = ""; return; }
            if (MaskNumOrden.Text == "") { MessageBox.Show("Ingrese un N° de Orden","Error",MessageBoxButtons.OK,MessageBoxIcon.Error); return; }
            if (LblSeleccion.Text == "Sin selección") { MessageBox.Show("Seleccione una hoja de corte", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }

            HojaSeleccionada nuevaHoja = new HojaSeleccionada(ofd.SafeFileName, ofd.FileName, Int32.Parse(MaskNumOrden.Text), Int32.Parse(MaskCantidad.Text));
            if (NumDeOrdenYaExiste(nuevaHoja))
            {
                MessageBox.Show("Ese N° de Orden ya se cargó", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (ContenedorDatos.agregandoDatos)
            {
                if (!NumOrdenValidoAlAgregar(nuevaHoja))
                {
                    MessageBox.Show("Este N° de Orden tiene asignado otro producto.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    AgregarHojaDeCorte(nuevaHoja);
                    BorrarDatos(); ;
                }
            }
            else
            {
                AgregarHojaDeCorte(nuevaHoja);
                BorrarDatos(); ;
            }
        }

        //Controla que el numero de orden ingresado no este en la tabla, o que este con el mismo archivo
        private bool NumDeOrdenYaExiste(HojaSeleccionada hoja)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (Int32.Parse(dt.Rows[i][0].ToString()) == hoja.NumOrden)
                {
                    return true;
                }
            }
            return false;
        }

        private bool NumOrdenValidoAlAgregar(HojaSeleccionada hoja)
        {
            for (int i = 0; i < ContenedorDatos.numerosDeOrden.Count; i++)
            {
                if (hoja.NumOrden == ContenedorDatos.numerosDeOrden[i] & hoja.Ruta != ContenedorDatos.rutas[i])
                {
                    return false;
                }
            }
            return true;
        }

        private void AgregarHojaDeCorte(HojaSeleccionada hoja)
        {
            DataRow fila = dt.NewRow();
            fila[0] = hoja.NumOrden;
            fila[1] = hoja.cantidad;
            fila[2] = hoja.NombreArchivo;
            fila[3] = hoja.Ruta;
            dt.Rows.Add(fila);
            ActualizarDgv();
        }

        private void ActualizarDgv()
        {
            DgvHojasSeleccionadas.DataSource = dt;
        }

        private void BtnBorrar_Click(object sender, EventArgs e)
        {
            BorrarDatos();
        }

        private void BorrarDatos()
        {
            MaskCantidad.Text = "";
            MaskNumOrden.Text = "";
            ofd = new OpenFileDialog();
            LblSeleccion.Text = "Sin selección";
        }

        private void MaskNumOrden_Click(object sender, EventArgs e)
        {
            if(MaskNumOrden.Text == "") { MaskNumOrden.Select(0, 0); }
            else { MaskNumOrden.SelectAll(); }
        }

        private void MaskCantidad_Click(object sender, EventArgs e)
        {
            if (MaskCantidad.Text == "") { MaskCantidad.Select(0, 0); }
            else { MaskCantidad.SelectAll(); }
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            if (dt.Rows.Count == 0) { MessageBox.Show("Seleccione al menos una hoja de la tabla", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
            if (MessageBox.Show("¿Está seguro de que desea eliminar la hoja de corte seleccionada?", "Advertencia", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.OK)
            {
                dt.Rows.RemoveAt(DgvHojasSeleccionadas.SelectedCells[0].RowIndex);
                ActualizarDgv();
            }
        }

        private void BtnAceptar_Click(object sender, EventArgs e)
        {
            if (dt.Rows.Count == 0) { MessageBox.Show("Debe seleccionar al menos una hoja de corte", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
            if (MessageBox.Show("¿Procesar las hojas de corte seleccionadas?", "Advertencia", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.OK)
            {
                ContenedorDatos.HojasSeleccionadas = new List<HojaSeleccionada>();
                ContenedorDatos.listaCortes = new List<Corte>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    ContenedorDatos.HojasSeleccionadas.Add(new HojaSeleccionada(dt.Rows[i][2].ToString(), dt.Rows[i][3].ToString(), Int32.Parse(dt.Rows[i][0].ToString()), Int32.Parse(dt.Rows[i][1].ToString())));
                }
                if (ContenedorDatos.agregandoDatos)
                {
                    this.Close();
                }
                else
                {
                    NombreNuevoProceso nnp = new NombreNuevoProceso();
                    nnp.ShowDialog();
                    if (ContenedorDatos.nombreProceso != "")
                    {
                        guardarArchivoComoElMasReciente();
                        ProcesoActual procesoActual = new ProcesoActual();
                        this.Visible = false;
                        procesoActual.ShowDialog();
                        this.Close();
                    }
                    else
                    {
                        return;
                    }
                }
                
            }
        }

        private void guardarArchivoComoElMasReciente()
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream fsout = new FileStream("C:\\Gestor Cortes\\Binarios\\IUP\\iup.binary", FileMode.Create, FileAccess.Write, FileShare.None);
            try
            {
                using (fsout)
                {
                    bf.Serialize(fsout, ContenedorDatos.nombreProceso);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar el índice del proceso en el archivo binario. Descripción del error: " + ex.Message);
            }
        }
    }
}
