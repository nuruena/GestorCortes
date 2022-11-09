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
    public partial class Observacion : Form
    {
        bool seAgregoOBservacion = false;
        public Observacion()
        {
            InitializeComponent();
        }

        private void Observacion_Load(object sender, EventArgs e)
        {
            lblCorte.Text = ContenedorDatos.listaCortesAMostrar[ContenedorDatos.indiceObservacion].numCable.ToString() + " - " + ContenedorDatos.listaCortesAMostrar[ContenedorDatos.indiceObservacion].empresa.ToString() + " - " + ContenedorDatos.listaCortesAMostrar[ContenedorDatos.indiceObservacion].producto.ToString();
            txtObservacion.Text = ContenedorDatos.observacion;
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            if (ContenedorDatos.observacionObligatoria)
            {
                if (string.IsNullOrWhiteSpace(txtObservacion.Text))
                {
                    MessageBox.Show("Debe ingresar una observación.");
                    return;
                }
            }
            if (txtObservacion.Text.Length > 150)
            {
                MessageBox.Show("La observación debe tener como máximo 150 caracteres.");
                return;
            }
            ContenedorDatos.observacion = txtObservacion.Text.ToUpper();
            seAgregoOBservacion = true;
            this.Close();
        }

        private void Observacion_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (ContenedorDatos.observacionObligatoria)
            {
                if (txtObservacion.Text.Length != 0 & txtObservacion.Text.Length <= 150 & seAgregoOBservacion)
                    {
                        ContenedorDatos.observacionObligatoria = false;
                    }
                else {
                    MessageBox.Show("Debe ingresar una observación.");
                    e.Cancel = true;
                }
            }
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtObservacion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                BtnAgregar_Click(sender, e);
            }
        }
    }
}
