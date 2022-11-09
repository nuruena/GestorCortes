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
    public partial class CortesCancelados : Form
    {
        DataTable dt = new DataTable("CortesCancelados");
        List<int> indiceDeCadaCorteCancelado = new List<int>();
        List<Corte> cortesCancelados = new List<Corte>();


        public CortesCancelados()
        {
            InitializeComponent();
        }

        private void CortesCancelados_Load(object sender, EventArgs e)
        {
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
            dgvCortesCancelados.DataSource = dt;
            marcarTodosCancelados();
            ContenedorDatos.ponerTamañoMinimoColumnas(dgvCortesCancelados);
            foreach (DataGridViewColumn columna in dgvCortesCancelados.Columns)
            {
                if (columna.Name == "Producto") { columna.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft; }
                else { columna.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; }
            }
            dgvCortesCancelados.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

        }

        private void ActualizarDt()
        {
            cortesCancelados = new List<Corte>();
            dt.Rows.Clear();
            for (int i = 0; i < ContenedorDatos.listaCortesAMostrarAcomodadas.Count; i++)
            {
                if (ContenedorDatos.listaCortesAMostrarAcomodadas[i].estado == "Cancelado")
                {
                    DataRow fila = dt.NewRow();
                    fila[0] = ContenedorDatos.listaCortesAMostrarAcomodadas[i].numOrden;
                    fila[1] = ContenedorDatos.listaCortesAMostrarAcomodadas[i].numCable;
                    fila[2] = ContenedorDatos.listaCortesAMostrarAcomodadas[i].cantidad;
                    fila[3] = ContenedorDatos.listaCortesAMostrarAcomodadas[i].color;
                    fila[4] = ContenedorDatos.listaCortesAMostrarAcomodadas[i].largo;
                    fila[5] = ContenedorDatos.listaCortesAMostrarAcomodadas[i].seccion;
                    fila[6] = ContenedorDatos.listaCortesAMostrarAcomodadas[i].despunteU1;
                    fila[7] = ContenedorDatos.listaCortesAMostrarAcomodadas[i].despunteT1;
                    fila[8] = ContenedorDatos.listaCortesAMostrarAcomodadas[i].identifYDistancia1;
                    fila[9] = ContenedorDatos.listaCortesAMostrarAcomodadas[i].terminal1;
                    fila[10] = ContenedorDatos.listaCortesAMostrarAcomodadas[i].desgarrado;
                    fila[11] = ContenedorDatos.listaCortesAMostrarAcomodadas[i].terminal2;
                    fila[12] = ContenedorDatos.listaCortesAMostrarAcomodadas[i].identifYDistancia2;
                    fila[13] = ContenedorDatos.listaCortesAMostrarAcomodadas[i].despunteT2;
                    fila[14] = ContenedorDatos.listaCortesAMostrarAcomodadas[i].despunteU2;
                    fila[15] = ContenedorDatos.listaCortesAMostrarAcomodadas[i].observacion;
                    fila[16] = ContenedorDatos.listaCortesAMostrarAcomodadas[i].empresa;
                    fila[17] = ContenedorDatos.listaCortesAMostrarAcomodadas[i].producto;
                    dt.Rows.Add(fila);
                    indiceDeCadaCorteCancelado.Add(i);
                    cortesCancelados.Add(ContenedorDatos.listaCortesAMostrarAcomodadas[i]);
                }
            }
            if (cortesCancelados.Count == 0)
            {
                MessageBox.Show("No hay cortes cancelados para mostrar.");
                Close();
            }
            lblCortesCancelados.Text = cortesCancelados.Count.ToString();
        }

        private void marcarTodosCancelados()
        {
            for (int i = 0; i < cortesCancelados.Count; i++)
            {
                dgvCortesCancelados.Rows[i].DefaultCellStyle.BackColor = Color.Firebrick;
            }
        }

        private void BtnTerminado_Click(object sender, EventArgs e)
        {
            MarcarFila(dgvCortesCancelados.SelectedRows[0].Index, "Terminado");
        }

        private void MarcarFila(int indice, string estado)
        {
            ContenedorDatos.huboCambiosCancelados = true;
            if (ContenedorDatos.listaCortesAMostrar[indiceDeCadaCorteCancelado[indice]].estado == estado) { return; }
            if (estado == "Terminado")
            {
                dgvCortesCancelados.SelectedRows[0].DefaultCellStyle.BackColor = Color.SpringGreen;
                ContenedorDatos.listaCortesAMostrar[indiceDeCadaCorteCancelado[indice]].estado = "Terminado";
                SeleccionarSiguiente();
            }
            else
            {
                ContenedorDatos.observacionObligatoria = true;
                ContenedorDatos.observacion = ContenedorDatos.listaCortesAMostrar[indiceDeCadaCorteCancelado[indice]].observacion;
                Observacion observacion = new Observacion();
                observacion.ShowDialog();
                ContenedorDatos.listaCortesAMostrar[indiceDeCadaCorteCancelado[indice]].observacion = ContenedorDatos.observacion;
                ContenedorDatos.listaCortesAMostrar[indiceDeCadaCorteCancelado[indice]].estado = "Cancelado";
                ActualizarDt();
                dgvCortesCancelados.DataSource = dt;
                AsignarEstados();
                SeleccionarSiguiente();
            }
        }

        private void SeleccionarSiguiente()
        {
            if (dgvCortesCancelados.SelectedCells[0].RowIndex < dgvCortesCancelados.Rows.Count - 1)
            {
                dgvCortesCancelados.Rows[dgvCortesCancelados.SelectedCells[0].RowIndex + 1].Selected = true;
            }
            acomodarTablaMostrada(dgvCortesCancelados.SelectedCells[0].RowIndex);
        }

        private void acomodarTablaMostrada(int indiceAlMedio)
        {
            if (indiceAlMedio < 6) { dgvCortesCancelados.FirstDisplayedScrollingRowIndex = 0; return; }
            if (indiceAlMedio < dgvCortesCancelados.Rows.Count - 6) { dgvCortesCancelados.FirstDisplayedScrollingRowIndex = indiceAlMedio - 6; return; }
        }

        private void BtnCancelado_Click(object sender, EventArgs e)
        {
            MarcarFila(dgvCortesCancelados.SelectedRows[0].Index, "Cancelado");
        }

        private void AsignarEstados()
        {
            for (int i = 0; i < cortesCancelados.Count; i++)
            {
                if (cortesCancelados[i].estado == "Terminado")
                {
                    dgvCortesCancelados.Rows[i].DefaultCellStyle.BackColor = Color.SpringGreen;
                }
                else
                {
                    dgvCortesCancelados.Rows[i].DefaultCellStyle.BackColor = Color.Firebrick;
                }
            }
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnObservacion_Click(object sender, EventArgs e)
        {
            ContenedorDatos.huboCambiosCancelados = true;
            ContenedorDatos.indiceObservacion = indiceDeCadaCorteCancelado[dgvCortesCancelados.SelectedCells[0].RowIndex];
            ContenedorDatos.observacion = dgvCortesCancelados.SelectedRows[0].Cells[15].Value.ToString();
            Observacion observacionF = new Observacion();
            observacionF.ShowDialog();
            dgvCortesCancelados.SelectedRows[0].Cells[15].Value = ContenedorDatos.observacion;
            ContenedorDatos.listaCortesAMostrar[ContenedorDatos.indiceObservacion].observacion = ContenedorDatos.observacion;
            ContenedorDatos.GrabarDatos();
        }
    }
}
