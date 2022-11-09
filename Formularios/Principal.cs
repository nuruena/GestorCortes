using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Gestor_Cortes.Clases;
using Gestor_Cortes.Formularios;

namespace Gestor_Cortes
{
    public partial class Principal : Form
    {
        public static string path = "C:\\Gestor Cortes\\Binarios";

        public Principal()
        {
            InitializeComponent();
        }

        private void BtnNuevoProceso_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("¿Empezar un nuevo proceso? Ya no se podrá modificar el último proceso.", "Advertencia", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.OK)
            {
                ContenedorDatos.listaCortesAMostrar = new List<Corte>();
                ContenedorDatos.listaCortes = new List<Corte>();
                ContenedorDatos.HojasSeleccionadas = new List<HojaSeleccionada>();
                ContenedorDatos.cortesDescartados = new List<Corte>();
                ContenedorDatos.esRestauracion = false;
                ContenedorDatos.agregandoDatos = false;
                ContenedorDatos.nombreProceso = "";
                NuevoProceso nuevoProceso = new NuevoProceso();
                this.Visible = false;
                nuevoProceso.ShowDialog();
                this.Close();
            }
        }

        private void BtnRestaurar_Click(object sender, EventArgs e)
        {
            ContenedorDatos.esRestauracion = true;
            ProcesoActual procesoActual = new ProcesoActual();
            procesoActual.ShowDialog();
            this.Close();
        }

        private void Principal_Load(object sender, EventArgs e)
        {
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnVerProceso_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = path;
            ofd.Filter = "Procesos de Corte|*.binary";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                ContenedorDatos.nombreProceso = ofd.SafeFileName.Remove(ofd.SafeFileName.Length - 7);
                ContenedorDatos.estoyViendo = true;
                ProcesoActual pa = new ProcesoActual();
                this.Visible = false;
                pa.ShowDialog();
                this.Close();
            }
            else
            {
                return;
            }

        }

        private void BtnRestaruarAnterior_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = path;
            ofd.Filter = "Procesos de Corte|*.binary";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                ContenedorDatos.nombreProceso = ofd.SafeFileName.Remove(ofd.SafeFileName.Length - 7);
                ContenedorDatos.esRestauracionAnterior = true;
                ProcesoActual pa = new ProcesoActual();
                this.Visible = false;
                pa.ShowDialog();
                this.Close();
            }
            else
            {
                return;
            }

        }
    }
}
