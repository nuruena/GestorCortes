using Gestor_Cortes.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gestor_Cortes.Formularios
{
    public partial class CortesExcluidos : Form
    {
        DataTable dt = new DataTable("CortesExcluidos");

        public CortesExcluidos()
        {
            InitializeComponent();
        }

        private void CortesExcluidos_Load(object sender, EventArgs e)
        {
            if (ContenedorDatos.cortesDescartadosAmostrar.Count == 0)
            {
                MessageBox.Show("No hay cortes descartados en el proceso actual.");
                this.Close();
                return;
            }
            dt.Columns.Add("N° O.");
            dt.Columns.Add("N° C.");
            dt.Columns.Add("Cant.");
            dt.Columns.Add("Color");
            dt.Columns.Add("Long.");
            dt.Columns.Add("Secc.");
            dt.Columns.Add("D U 1");
            dt.Columns.Add("D T 1");
            dt.Columns.Add("I D 1");
            dt.Columns.Add("T 1");
            dt.Columns.Add("Desg.");
            dt.Columns.Add("T 2");
            dt.Columns.Add("I D 2");
            dt.Columns.Add("D T 2");
            dt.Columns.Add("D U 2");
            dt.Columns.Add("Obs.");
            dt.Columns.Add("Empresa");
            dt.Columns.Add("Producto");
            ActualizarDt();
            ActualizarDgv();
            AsignarEstados();
        }
        private void ActualizarDgv()
        {
            dgvCortesExcluidos.DataSource = dt;
            ContenedorDatos.ponerTamañoMinimoColumnas(dgvCortesExcluidos);
            foreach (DataGridViewColumn columna in dgvCortesExcluidos.Columns)
            {
                if (columna.Name == "Producto") { columna.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft; }
                else { columna.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; }
            }
            dgvCortesExcluidos.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            int indiceAlCargar = buscarIndiceAlCargar();
            dgvCortesExcluidos.Rows[indiceAlCargar].Selected = true;
            dgvCortesExcluidos.CurrentCell = dgvCortesExcluidos[0, indiceAlCargar];
            acomodarTablaMostrada(indiceAlCargar);
        }

        private void btn_terminado_Click(object sender, EventArgs e)
        {
            MarcarFila(dgvCortesExcluidos.SelectedRows[0].Index, "Terminado");
        }

        private void acomodarTablaMostrada(int indiceAlMedio)
        {
            if (indiceAlMedio < 6) { dgvCortesExcluidos.FirstDisplayedScrollingRowIndex = 0; return; }
            if (indiceAlMedio < dgvCortesExcluidos.Rows.Count - 6) { dgvCortesExcluidos.FirstDisplayedScrollingRowIndex = indiceAlMedio - 6; return; }
            else { dgvCortesExcluidos.FirstDisplayedScrollingRowIndex = indiceAlMedio; }
        }

        private void MarcarFila(int indice, string estado)
        {
            if (ContenedorDatos.cortesDescartadosAmostrar[indice].estado == estado) { return; }
            if (dgvCortesExcluidos.SelectedCells[0].RowIndex != 0)
            {
                if (ContenedorDatos.cortesDescartadosAmostrar[dgvCortesExcluidos.SelectedCells[0].RowIndex - 1].estado == "")
                {
                    MessageBox.Show("No se puede marcar este corte con ningun estado hasta que todos los cortes anteriores tengan un estado asignado.");
                    return;
                }
            }
            ContenedorDatos.huboCambiosExcluidos = true;
            int filaSeleccionada = dgvCortesExcluidos.CurrentCell.RowIndex;
            if (estado == "Terminado")
            {
                dgvCortesExcluidos.SelectedRows[0].DefaultCellStyle.BackColor = Color.SpringGreen;
                ContenedorDatos.cortesDescartadosAmostrar[indice].estado = "Terminado";
                SeleccionarSiguiente(filaSeleccionada);
            }
            else
            {
                ContenedorDatos.observacionObligatoria = true;
                ContenedorDatos.observacion = ContenedorDatos.cortesDescartadosAmostrar[indice].observacion;
                Observacion observacion = new Observacion();
                observacion.ShowDialog();
                ContenedorDatos.cortesDescartadosAmostrar[indice].observacion = ContenedorDatos.observacion;
                ContenedorDatos.cortesDescartadosAmostrar[indice].estado = "Cancelado";
                ActualizarDt();
                dgvCortesExcluidos.DataSource = dt;
                AsignarEstados();
                SeleccionarSiguiente(filaSeleccionada);
            }
        }

        private void SeleccionarSiguiente(int filaDesdeLaQueAvanzo)
        {
            if (filaDesdeLaQueAvanzo < dgvCortesExcluidos.Rows.Count - 1)
            {
                dgvCortesExcluidos.CurrentCell = dgvCortesExcluidos[0, filaDesdeLaQueAvanzo+1];
                dgvCortesExcluidos.Rows[filaDesdeLaQueAvanzo + 1].Selected = true;
            }
            acomodarTablaMostrada(dgvCortesExcluidos.SelectedCells[0].RowIndex);
        }

        private void ActualizarDt()
        {
            if (ContenedorDatos.cortesDescartadosAmostrar.Count == 0)
            {
                MessageBox.Show("No hay cortes excluídos en este proceso para mostrar.");
                Close();
            }
            dt.Rows.Clear();
            for (int i = 0; i < ContenedorDatos.cortesDescartadosAmostrar.Count; i++)
            {
                DataRow fila = dt.NewRow();
                fila[0] = ContenedorDatos.cortesDescartadosAmostrar[i].numOrden;
                fila[1] = ContenedorDatos.cortesDescartadosAmostrar[i].numCable;
                fila[2] = ContenedorDatos.cortesDescartadosAmostrar[i].cantidad;
                fila[3] = ContenedorDatos.cortesDescartadosAmostrar[i].color;
                fila[4] = ContenedorDatos.cortesDescartadosAmostrar[i].largo;
                fila[5] = ContenedorDatos.cortesDescartadosAmostrar[i].seccion;
                fila[6] = ContenedorDatos.cortesDescartadosAmostrar[i].despunteU1;
                fila[7] = ContenedorDatos.cortesDescartadosAmostrar[i].despunteT1;
                fila[8] = ContenedorDatos.cortesDescartadosAmostrar[i].identifYDistancia1;
                fila[9] = ContenedorDatos.cortesDescartadosAmostrar[i].terminal1;
                fila[10] = ContenedorDatos.cortesDescartadosAmostrar[i].desgarrado;
                fila[11] = ContenedorDatos.cortesDescartadosAmostrar[i].terminal2;
                fila[12] = ContenedorDatos.cortesDescartadosAmostrar[i].identifYDistancia2;
                fila[13] = ContenedorDatos.cortesDescartadosAmostrar[i].despunteT2;
                fila[14] = ContenedorDatos.cortesDescartadosAmostrar[i].despunteU2;
                fila[15] = ContenedorDatos.cortesDescartadosAmostrar[i].observacion;
                fila[16] = ContenedorDatos.cortesDescartadosAmostrar[i].empresa;
                fila[17] = ContenedorDatos.cortesDescartadosAmostrar[i].producto;
                dt.Rows.Add(fila);
            }
            lblCortesEnTabla.Text = ContenedorDatos.cortesDescartadosAmostrar.Count.ToString();
        }

        private void AsignarEstados()
        {
            for (int i = 0; i < ContenedorDatos.cortesDescartadosAmostrar.Count; i++)
            {
                if (ContenedorDatos.cortesDescartadosAmostrar[i].estado == "Terminado")
                {
                    dgvCortesExcluidos.Rows[i].DefaultCellStyle.BackColor = Color.SpringGreen;
                }
                else if (ContenedorDatos.cortesDescartadosAmostrar[i].estado == "Cancelado")
                {
                    dgvCortesExcluidos.Rows[i].DefaultCellStyle.BackColor = Color.Firebrick;
                }
            }
        }

        private void btn_cancelado_Click(object sender, EventArgs e)
        {
            MarcarFila(dgvCortesExcluidos.SelectedRows[0].Index, "Cancelado");
        }

        private void btn_agregar_observacion_Click(object sender, EventArgs e)
        {
            ContenedorDatos.huboCambiosExcluidos = true;
            ContenedorDatos.indiceObservacion = dgvCortesExcluidos.SelectedCells[0].RowIndex;
            ContenedorDatos.observacion = dgvCortesExcluidos.SelectedRows[0].Cells[15].Value.ToString();
            Observacion observacionF = new Observacion();
            observacionF.ShowDialog();
            dgvCortesExcluidos.SelectedRows[0].Cells[15].Value = ContenedorDatos.observacion;
            ContenedorDatos.cortesDescartadosAmostrar[dgvCortesExcluidos.SelectedCells[0].RowIndex].observacion = ContenedorDatos.observacion;
            ContenedorDatos.GrabarDatos();
        }

        public static int buscarIndiceAlCargar()
        {
            for (int i = 0; i < ContenedorDatos.cortesDescartadosAmostrar.Count; i++)
            {
                if (ContenedorDatos.cortesDescartadosAmostrar[i].estado == "")
                {
                    return i;
                }
            }
            return ContenedorDatos.cortesDescartadosAmostrar.Count - 1;
        }

        private void dgvCortesExcluidos_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btn_terminado_Click(sender, e);
            }
            if (e.KeyChar == (char)Keys.Back)
            {
                btn_cancelado_Click(sender, e);
            }
        }

        private void dgvCortesExcluidos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                e.Handled = true;
            }
        }
    }
}
