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
    public partial class ProcesoActual : Form
    {

        DataTable dt = new DataTable("CortesAMostrar");

        public ProcesoActual()
        {
            InitializeComponent();
        }

        private void ProcesoActual_Load(object sender, EventArgs e)
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
            dt.Columns.Add("R E F");

            //Aca hay que meter un try catch a la ultimo
            if (ContenedorDatos.estoyViendo)
            {
                desactivarBotones();
                ContenedorDatos.estoyViendo = false;
                ContenedorDatos.LeerDatos();
                ContenedorDatos.listaCortesAMostrarAcomodadas = ContenedorDatos.darVueltaSiCorrespondeDesdeIndice(0, ContenedorDatos.listaCortesAMostrar);
                ActualizarDt();
                ActualizarDgv(true);
                desactivarAcomodado();
            }
            else if (ContenedorDatos.esRestauracion)
            {
                ContenedorDatos.esRestauracion = false;
                ContenedorDatos.LeerNombreUltimoProceso();
                ContenedorDatos.LeerDatos();
                ContenedorDatos.listaCortesAMostrarAcomodadas = ContenedorDatos.darVueltaSiCorrespondeDesdeIndice(0, ContenedorDatos.listaCortesAMostrar);
                ActualizarDt();
                ActualizarDgv(true);
                DgvCortes.Rows[ContenedorDatos.buscarIndiceAlCargar()].Selected = true;
                DgvCortes.CurrentCell = DgvCortes[0, ContenedorDatos.buscarIndiceAlCargar()];
                acomodarTablaMostrada(ContenedorDatos.buscarIndiceAlCargar());
                desactivarAcomodado();
            }
            else if (ContenedorDatos.esRestauracionAnterior)
            {
                ContenedorDatos.esRestauracionAnterior = false;
                ContenedorDatos.LeerDatos();
                ContenedorDatos.listaCortesAMostrarAcomodadas = ContenedorDatos.darVueltaSiCorrespondeDesdeIndice(0, ContenedorDatos.listaCortesAMostrar);
                ActualizarDt();
                ActualizarDgv(true);
                DgvCortes.Rows[ContenedorDatos.buscarIndiceAlCargar()].Selected = true;
                DgvCortes.CurrentCell = DgvCortes[0, ContenedorDatos.buscarIndiceAlCargar()];
                acomodarTablaMostrada(ContenedorDatos.buscarIndiceAlCargar());
                desactivarAcomodado();
            }
            else
            {
                ContenedorDatos.buscarCortesDeHojasSeleccionadas();
                ContenedorDatos.listaCortesAMostrar = ContenedorDatos.OrdenarTodosLosCortes(ContenedorDatos.listaCortes, 0);
                ContenedorDatos.cortesDescartadosAmostrar = ContenedorDatos.OrdenarTodosLosCortes(ContenedorDatos.cortesDescartados, 0);
                ContenedorDatos.cortesDescartadosAmostrar = ContenedorDatos.ordenarPorLongitudDesdeIndice(ContenedorDatos.cortesDescartadosAmostrar);
                ContenedorDatos.listaCortesAMostrar = ContenedorDatos.ordenarPorLongitudDesdeIndice(ContenedorDatos.listaCortesAMostrar);
                ContenedorDatos.listaCortesAMostrarAcomodadas = ContenedorDatos.darVueltaSiCorrespondeDesdeIndice(0, ContenedorDatos.listaCortesAMostrar);
                ActualizarDt();
                ActualizarDgv(false);
                ContenedorDatos.GrabarDatos();
                desactivarAcomodado();
            }
        }

        private void ActualizarDgv(bool esRestauracion)
        {
            DgvCortes.DataSource = dt;
            if (esRestauracion)
            {
                AsignarEstados();
            }
            ContenedorDatos.ponerTamañoMinimoColumnas(DgvCortes);
            foreach (DataGridViewColumn columna in DgvCortes.Columns)
            {
                if (columna.Name == "Producto") 
                { 
                    columna.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft; 
                }
                else { columna.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; }
            }
            DgvCortes.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        private void ActualizarDt()
        {
            dt.Rows.Clear();
            for (int i = 0; i < ContenedorDatos.listaCortesAMostrarAcomodadas.Count; i++)
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
                fila[18] = ContenedorDatos.listaCortesAMostrarAcomodadas[i].referencia;
                dt.Rows.Add(fila);
            }
            lblNombreProceso.Text = ContenedorDatos.nombreProceso;
            definirLabelCortes();
        }

        

        private void BtnCortesExcluidos_Click(object sender, EventArgs e)
        {
            CortesExcluidos cortesExcluidos = new CortesExcluidos();
            cortesExcluidos.ShowDialog();
            if (ContenedorDatos.huboCambiosExcluidos == true)
            {
                ContenedorDatos.GrabarDatos();
            }
            ContenedorDatos.huboCambiosExcluidos = false;
        }

        private void MarcarFilaActual(string estado)
        {
            if (ContenedorDatos.listaCortesAMostrar[DgvCortes.SelectedCells[0].RowIndex].estado == estado) { return; }
            if (DgvCortes.SelectedCells[0].RowIndex != 0)
            {
                if (ContenedorDatos.listaCortesAMostrar[DgvCortes.SelectedCells[0].RowIndex - 1].estado == "")
                {
                    MessageBox.Show("No se puede marcar este corte con ningun estado hasta que todos los cortes anteriores tengan un estado asignado.");
                    return;
                }
                else if (ContenedorDatos.listaCortesAMostrar[DgvCortes.SelectedCells[0].RowIndex - 1].estado == "En Proceso")
                {
                    MessageBox.Show("No se puede marcar un corte posterior a un corte que este En Proceso.");
                    return;
                }
            }
            if (estado == "Terminado") 
            { 
                DgvCortes.SelectedRows[0].DefaultCellStyle.BackColor = Color.SpringGreen; 
            }
            else if (estado == "Cancelado")
            {
                ContenedorDatos.observacionObligatoria = true;
                ContenedorDatos.observacion = ContenedorDatos.listaCortesAMostrar[DgvCortes.SelectedCells[0].RowIndex].observacion;
                Observacion observacion = new Observacion();
                observacion.ShowDialog();
                DgvCortes.SelectedRows[0].Cells[15].Value = ContenedorDatos.observacion;
                ContenedorDatos.listaCortesAMostrar[DgvCortes.SelectedCells[0].RowIndex].observacion = ContenedorDatos.observacion;
                DgvCortes.SelectedRows[0].DefaultCellStyle.BackColor = Color.Firebrick;
            }
            else if (estado == "En Proceso")
            {
                if (DgvCortes.SelectedCells[0].RowIndex < DgvCortes.Rows.Count - 1)
                {
                    if (ContenedorDatos.listaCortesAMostrar[DgvCortes.SelectedCells[0].RowIndex + 1].estado != "" | ContenedorDatos.listaCortesAMostrar[DgvCortes.SelectedCells[0].RowIndex].estado != "")
                    {
                        MessageBox.Show("No se puede marcar En Proceso a un corte ya terminado.");
                        return;
                    }
                }
                DgvCortes.SelectedRows[0].DefaultCellStyle.BackColor = Color.LightSkyBlue;
            }
            ContenedorDatos.listaCortesAMostrar[DgvCortes.SelectedCells[0].RowIndex].estado = estado;
            ContenedorDatos.GrabarDatos();
            definirLabelCortes();
            SeleccionarSiguiente();
            var test = DgvCortes.Rows.Cast<DataGridViewRow>()
                .ToList();

            acomodarTablaMostrada(DgvCortes.SelectedCells[0].RowIndex);

        }

        private void SeleccionarSiguiente()
        {
            if (DgvCortes.SelectedCells[0].RowIndex < DgvCortes.Rows.Count - 1)
            {
            DgvCortes.CurrentCell = DgvCortes[0, DgvCortes.SelectedCells[0].RowIndex + 1];
            }
            acomodarTablaMostrada(DgvCortes.SelectedCells[0].RowIndex);
        }

        private void definirLabelCortes()
        {
            int indicePrimerSinEstado = ContenedorDatos.buscarIndiceAlCargar();
            //No hay ninguno marcado
            if (indicePrimerSinEstado == 0)
            {
                lblCortesEnTabla.Text = "0" + " " + "/" + " " + ContenedorDatos.listaCortesAMostrarAcomodadas.Count.ToString();
            }
            else if (indicePrimerSinEstado == ContenedorDatos.listaCortesAMostrarAcomodadas.Count - 1)
            {
                lblCortesEnTabla.Text = ContenedorDatos.listaCortesAMostrarAcomodadas.Count.ToString() + " " + "/" + " " + ContenedorDatos.listaCortesAMostrarAcomodadas.Count.ToString();
            }
            else
            {
                lblCortesEnTabla.Text = (ContenedorDatos.buscarIndiceAlCargar()) + " " + "/" + " " + ContenedorDatos.listaCortesAMostrarAcomodadas.Count.ToString();
            }
        }

        private void BtnEnProceso_Click(object sender, EventArgs e)
        {
            MarcarFilaActual("En Proceso");
        }

        private void BtnTerminado_Click(object sender, EventArgs e)
        {
            MarcarFilaActual("Terminado");
        }

        private void BtnCancelado_Click(object sender, EventArgs e)
        {
            MarcarFilaActual("Cancelado");
        }

        private void BtnObservacion_Click(object sender, EventArgs e)
        {
            ContenedorDatos.indiceObservacion = DgvCortes.SelectedCells[0].RowIndex;
            string observacion = DgvCortes.SelectedRows[0].Cells[15].Value.ToString();
            ContenedorDatos.observacion = observacion;
            Observacion observacionF = new Observacion();
            observacionF.ShowDialog();
            DgvCortes.SelectedRows[0].Cells[15].Value = ContenedorDatos.observacion;
            ContenedorDatos.listaCortesAMostrar[ContenedorDatos.indiceObservacion].observacion = ContenedorDatos.observacion;
            ContenedorDatos.GrabarDatos();
        }

        private void AsignarEstados()
        {
            for (int i = 0; i < ContenedorDatos.listaCortesAMostrar.Count; i++)
            {
                if (ContenedorDatos.listaCortesAMostrar[i].estado == "Terminado")
                {
                    DgvCortes.Rows[i].DefaultCellStyle.BackColor = Color.SpringGreen;
                }
                else if (ContenedorDatos.listaCortesAMostrar[i].estado == "En Proceso")
                {
                    DgvCortes.Rows[i].DefaultCellStyle.BackColor = Color.LightSkyBlue;
                }
                else if (ContenedorDatos.listaCortesAMostrar[i].estado == "Cancelado")
                {
                    DgvCortes.Rows[i].DefaultCellStyle.BackColor = Color.Firebrick;
                }
            }
        }

        private void BtnAgregarCortes_Click(object sender, EventArgs e)
        {
            ContenedorDatos.HojasSeleccionadas = new List<HojaSeleccionada>();
            ContenedorDatos.listaCortes = new List<Corte>();
            ContenedorDatos.cortesDescartados = new List<Corte>();
            ContenedorDatos.agregandoDatos = true;
            NuevoProceso nuevoProceso = new NuevoProceso();
            nuevoProceso.ShowDialog();
            ContenedorDatos.agregandoDatos = false;

            if (ContenedorDatos.HojasSeleccionadas.Count != 0)
            {
                int indicePrimerSinEstado = ContenedorDatos.ObtenerIndiceCortesPorProcesar();
                int indicePrimerSinEstadoDescartados = ContenedorDatos.ObtenerIndiceCortesPorProcesar(ContenedorDatos.cortesDescartadosAmostrar);
                ContenedorDatos.buscarCortesDeHojasSeleccionadas();

                //Si hay cortes sin estado en listaCortesAMostrar
                if (indicePrimerSinEstado != -1)
                {
                    //Si hay cortes que estaban desde antes, sumo las cantidades
                    for (int i = indicePrimerSinEstado; i < ContenedorDatos.listaCortesAMostrar.Count; i++)
                    {
                        for (int j = 0; j < ContenedorDatos.listaCortes.Count; j++)
                        {
                            if (ContenedorDatos.listaCortes[j] != null)
                            {
                                if (ContenedorDatos.listaCortesAMostrar[i].numOrden == ContenedorDatos.listaCortes[j].numOrden & ContenedorDatos.listaCortesAMostrar[i].numCable == ContenedorDatos.listaCortes[j].numCable)
                                {
                                    ContenedorDatos.listaCortesAMostrar[i].cantidad += ContenedorDatos.listaCortes[j].cantidad;
                                    ContenedorDatos.listaCortes[j] = null;
                                }
                            }
                        }
                    }
                    ContenedorDatos.QuitarNullsDeLista(ContenedorDatos.listaCortes);

                    //Saco todos los cortes que queden de listaCortesAMostrar y los uno con los de listaCortes
                    for (int i = indicePrimerSinEstado; i < ContenedorDatos.listaCortesAMostrar.Count; i++)
                    {
                        ContenedorDatos.listaCortes.Add(ContenedorDatos.listaCortesAMostrar[i]);
                        ContenedorDatos.listaCortesAMostrar[i] = null;
                    }
                    ContenedorDatos.QuitarNullsDeLista(ContenedorDatos.listaCortesAMostrar);
                }

                //Si hay cortes sin estado en cortesDescartados
                if (indicePrimerSinEstadoDescartados != -1)
                {
                    //Si hay cortes que estaban desde antes, sumo las cantidades
                    for (int i = indicePrimerSinEstadoDescartados; i < ContenedorDatos.cortesDescartadosAmostrar.Count; i++)
                    {
                        for (int j = 0; j < ContenedorDatos.cortesDescartados.Count; j++)
                        {
                            if (ContenedorDatos.cortesDescartados[j] != null)
                            {
                                if (ContenedorDatos.cortesDescartadosAmostrar[i].numOrden == ContenedorDatos.cortesDescartados[j].numOrden & ContenedorDatos.cortesDescartadosAmostrar[i].numCable == ContenedorDatos.cortesDescartados[j].numCable)
                                {
                                    ContenedorDatos.cortesDescartadosAmostrar[i].cantidad += ContenedorDatos.cortesDescartados[j].cantidad;
                                    ContenedorDatos.cortesDescartados[j] = null;
                                }
                            }
                        }
                    }
                    ContenedorDatos.QuitarNullsDeLista(ContenedorDatos.cortesDescartados);

                    //Saco todos los cortes que queden de cortesDescartadosAmostrar y los uno con los de cortesDescartados
                    for (int i = indicePrimerSinEstadoDescartados; i < ContenedorDatos.cortesDescartadosAmostrar.Count; i++)
                    {
                        ContenedorDatos.cortesDescartados.Add(ContenedorDatos.cortesDescartadosAmostrar[i]);
                        ContenedorDatos.cortesDescartadosAmostrar[i] = null;
                    }
                    ContenedorDatos.QuitarNullsDeLista(ContenedorDatos.cortesDescartadosAmostrar);
                }


                //Busco los datos del ultimo corte de listaCortesAMostrar y veo si le puedo agregar alguno de listaCortes, si hay algun al menos un corte con estado asignado
                if (indicePrimerSinEstado > 0)
                {
                    string colorUltimo = ContenedorDatos.listaCortesAMostrar[indicePrimerSinEstado - 1].color;
                    string seccionUltimo = ContenedorDatos.listaCortesAMostrar[indicePrimerSinEstado - 1].seccion;
                    for (int i = 0; i < ContenedorDatos.listaCortes.Count; i++)
                    {
                        if (ContenedorDatos.listaCortes[i].color == colorUltimo & ContenedorDatos.listaCortes[i].seccion == seccionUltimo & ContenedorDatos.listaCortes[i].terminal1 == "" & ContenedorDatos.listaCortes[i].terminal2 == "")
                        {
                            ContenedorDatos.listaCortesAMostrar.Add(ContenedorDatos.listaCortes[i]);
                            ContenedorDatos.listaCortes[i] = null;
                        }
                    }
                    ContenedorDatos.QuitarNullsDeLista(ContenedorDatos.listaCortes);

                    //Busco los ultimos terminales validos de listaCortesAMostrar
                    List<string> ultimosTerminalesValidos = ContenedorDatos.obtenerUltimosTerminales(indicePrimerSinEstado, ContenedorDatos.listaCortesAMostrar);

                    //Ordeno listaCortes
                    ContenedorDatos.OrdenarTodosLosCortes(ultimosTerminalesValidos, ContenedorDatos.listaCortes, indicePrimerSinEstado, ContenedorDatos.listaCortesAMostrar);
                    //Me fijo el indice del ultimo elemento en listaCortesAMostrar (porque le pueod habre metido algun corte que tiene que ir ahi segido)
                    int nuevoUltimoIndice = ContenedorDatos.listaCortesAMostrar.Count - 1;
                    //Si se agregaron elementos a listaCortesAmostrar que los acomode
                    if (!(nuevoUltimoIndice == ContenedorDatos.listaCortesAMostrar.Count - 1))
                    {
                        ContenedorDatos.ordenarPorSeccionDesdeIndice(nuevoUltimoIndice + 1);
                        ContenedorDatos.ordenarPorColorDesdeIndice(nuevoUltimoIndice + 1);
                        ContenedorDatos.ordenarPorLongitudDesdeIndice(nuevoUltimoIndice + 1);
                    }
                    ContenedorDatos.listaCortesAMostrar = ContenedorDatos.ordenarPorLongitudDesdeIndice(ContenedorDatos.listaCortesAMostrar);
                    ContenedorDatos.acomodarComoCuandoCargasHoja(ContenedorDatos.listaCortesAMostrar);
                    ContenedorDatos.GrabarDatos();
                    ContenedorDatos.listaCortesAMostrarAcomodadas = ContenedorDatos.darVueltaSiCorrespondeDesdeIndice(0, ContenedorDatos.listaCortesAMostrar);
                    ActualizarDt();
                    ActualizarDgv(true);
                    DgvCortes.Rows[ContenedorDatos.buscarIndiceAlCargar()].Selected = true;
                    DgvCortes.CurrentCell = DgvCortes[0, ContenedorDatos.buscarIndiceAlCargar()];
                    desactivarAcomodado();
                }
                else
                {
                    ContenedorDatos.acomodarComoCuandoCargasHoja(ContenedorDatos.listaCortes);
                    ContenedorDatos.listaCortes = ContenedorDatos.OrdenarTodosLosCortes(ContenedorDatos.listaCortes, 0);
                    ContenedorDatos.AgregarCortesALista(ContenedorDatos.listaCortesAMostrar, ContenedorDatos.listaCortes);
                    ContenedorDatos.listaCortesAMostrar = ContenedorDatos.ordenarPorLongitudDesdeIndice(ContenedorDatos.listaCortesAMostrar);
                    ContenedorDatos.listaCortesAMostrarAcomodadas = ContenedorDatos.darVueltaSiCorrespondeDesdeIndice(0, ContenedorDatos.listaCortesAMostrar);
                    ActualizarDt();
                    ActualizarDgv(true);
                    ContenedorDatos.GrabarDatos();
                    desactivarAcomodado();
                }

                //Busco los datos del ultimo corte de cortesDescartadosAMostrar y veo si le puedo agregar alguno de cortesDescartados, si hay algun al menos un corte con estado asignado
                if (indicePrimerSinEstadoDescartados > 0)
                {
                    string colorUltimo = ContenedorDatos.cortesDescartadosAmostrar[indicePrimerSinEstadoDescartados - 1].color;
                    string seccionUltimo = ContenedorDatos.cortesDescartadosAmostrar[indicePrimerSinEstadoDescartados - 1].seccion;
                    for (int i = 0; i < ContenedorDatos.cortesDescartados.Count; i++)
                    {
                        if (ContenedorDatos.cortesDescartados[i].color == colorUltimo & ContenedorDatos.cortesDescartados[i].seccion == seccionUltimo & ContenedorDatos.cortesDescartados[i].terminal1 == "" & ContenedorDatos.cortesDescartados[i].terminal2 == "")
                        {
                            ContenedorDatos.cortesDescartadosAmostrar.Add(ContenedorDatos.cortesDescartados[i]);
                            ContenedorDatos.cortesDescartados[i] = null;
                        }
                    }
                    ContenedorDatos.QuitarNullsDeLista(ContenedorDatos.cortesDescartados);

                    //Busco los ultimos terminales validos de cortesDescartadosAmostrar
                    List<string> ultimosTerminalesValidos = ContenedorDatos.obtenerUltimosTerminales(indicePrimerSinEstadoDescartados, ContenedorDatos.cortesDescartadosAmostrar);

                    //Ordeno cortes descartados
                    ContenedorDatos.OrdenarTodosLosCortes(ultimosTerminalesValidos, ContenedorDatos.cortesDescartados, indicePrimerSinEstadoDescartados, ContenedorDatos.cortesDescartadosAmostrar);
                    //Me fijo el indice del ultimo elemento en cortesDescartadosAmostrar (porque le pueod habre metido algun corte que tiene que ir ahi segido)
                    int nuevoUltimoIndice = ContenedorDatos.cortesDescartadosAmostrar.Count - 1;
                    //Si se agregaron elementos a cortesDescartadosAmostrar que los acomode
                    if (!(nuevoUltimoIndice == ContenedorDatos.cortesDescartadosAmostrar.Count - 1))
                    {
                        ContenedorDatos.ordenarPorSeccionDesdeIndice(nuevoUltimoIndice + 1, ContenedorDatos.cortesDescartadosAmostrar);
                        ContenedorDatos.ordenarPorColorDesdeIndice(nuevoUltimoIndice + 1, ContenedorDatos.cortesDescartadosAmostrar);
                    }
                    ContenedorDatos.cortesDescartadosAmostrar = ContenedorDatos.ordenarPorLongitudDesdeIndice(indicePrimerSinEstadoDescartados, ContenedorDatos.cortesDescartadosAmostrar);
                    ContenedorDatos.acomodarComoCuandoCargasHoja(ContenedorDatos.cortesDescartadosAmostrar);
                    ContenedorDatos.GrabarDatos();
                    //ContenedorDatos.listaCortesAMostrarAcomodadas = ContenedorDatos.darVueltaSiCorrespondeDesdeIndice(0, ContenedorDatos.cortesDescartadosAmostrar);
                    //ActualizarDt();
                    //ActualizarDgv(true);
                    //DgvCortes.Rows[ContenedorDatos.buscarIndiceAlCargar()].Selected = true;
                    //DgvCortes.CurrentCell = DgvCortes[0, ContenedorDatos.buscarIndiceAlCargar()];
                    //desactivarAcomodado();
                }
                else
                {
                    ContenedorDatos.acomodarComoCuandoCargasHoja(ContenedorDatos.cortesDescartados);
                    ContenedorDatos.cortesDescartados = ContenedorDatos.OrdenarTodosLosCortes(ContenedorDatos.cortesDescartados, 0);
                    ContenedorDatos.cortesDescartados = ContenedorDatos.ordenarPorLongitudDesdeIndice(ContenedorDatos.cortesDescartados);
                    ContenedorDatos.AgregarCortesALista(ContenedorDatos.cortesDescartadosAmostrar, ContenedorDatos.cortesDescartados);
                    //ContenedorDatos.listaCortesAMostrarAcomodadas = ContenedorDatos.darVueltaSiCorrespondeDesdeIndice(0, ContenedorDatos.cortesDescartadosAmostrar);
                    //ActualizarDt();
                    //ActualizarDgv(false);
                    ContenedorDatos.GrabarDatos();
                    //desactivarAcomodado();
                }

            }
        }

        private void DgvCortes_SelectionChanged(object sender, EventArgs e)
        {
            if (DgvCortes.CurrentCell == null) { return; }
            if (DgvCortes.CurrentCell.RowIndex < 6) { DgvCortes.FirstDisplayedScrollingRowIndex = 0; return; }
            if (DgvCortes.CurrentCell.RowIndex < DgvCortes.Rows.Count - 6) { DgvCortes.FirstDisplayedScrollingRowIndex = DgvCortes.CurrentCell.RowIndex - 6; return; }
        }

        private void acomodarTablaMostrada(int indiceAlMedio)
        {
            if (indiceAlMedio < 6) { DgvCortes.FirstDisplayedScrollingRowIndex = 0; return; }
            if (indiceAlMedio < DgvCortes.Rows.Count - 6) { DgvCortes.FirstDisplayedScrollingRowIndex = indiceAlMedio - 6; return; }
            else { DgvCortes.FirstDisplayedScrollingRowIndex = indiceAlMedio; }
        }

        private void desactivarAcomodado()
        {
            foreach (DataGridViewColumn column in DgvCortes.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

        private void BtnGuardarYSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnCortesCancelados_Click(object sender, EventArgs e)
        {
            CortesCancelados cortesCancelados = new CortesCancelados();
            cortesCancelados.ShowDialog();
            if (ContenedorDatos.huboCambiosCancelados == true)
            {
                ContenedorDatos.GrabarDatos();
                ContenedorDatos.listaCortesAMostrarAcomodadas = ContenedorDatos.darVueltaSiCorrespondeDesdeIndice(0, ContenedorDatos.listaCortesAMostrar);
                ActualizarDt();
                ActualizarDgv(true);
                int indicePrimeroSinEstado = ContenedorDatos.buscarIndiceAlCargar();
                DgvCortes.CurrentCell = DgvCortes[0, indicePrimeroSinEstado];
                acomodarTablaMostrada(indicePrimeroSinEstado);
                desactivarAcomodado();
            }
            ContenedorDatos.huboCambiosCancelados = false;
        }

        private void desactivarBotones()
        {
            BtnTerminado.Enabled = false;
            BtnEnProceso.Enabled = false;
            BtnCancelado.Enabled = false;
            btnAgregarCortes.Enabled = false;
            btnCortesCancelados.Enabled = false;
            BtnObservacion.Enabled = false;
        }

        private void DgvCortes_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Back)
            {
                BtnCancelado_Click(sender,e);
            }
            if (e.KeyChar == (char)Keys.Enter)
            {
                BtnTerminado_Click(sender, e);
            }
            if (e.KeyChar == (char)Keys.Space)
            {
                BtnEnProceso_Click(sender, e);
            }
        }

        private void DgvCortes_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                e.Handled = true;
            }
        }
    }
}
