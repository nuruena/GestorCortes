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
    public partial class NombreNuevoProceso : Form
    {
        public NombreNuevoProceso()
        {
            InitializeComponent();
        }

        private void BtnAceptar_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text.Length == 0 | txtNombre.Text.Length > 100 | txtNombre.Text.IndexOfAny(Path.GetInvalidFileNameChars()) >= 0) { MessageBox.Show("El nombre ingresado debe tener entre 1 y 100 caracteres, y no se permiten caracteres especiales", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
            DirectoryInfo carpeta = new DirectoryInfo("C:\\Gestor Cortes\\Binarios");
            FileInfo[] archivos = carpeta.GetFiles("*.binary");
            foreach (FileInfo archivo in archivos)
            {
                if (archivo.Name == txtNombre.Text + ".binary") { MessageBox.Show("Ya se encuentra un archivo llamado '" + txtNombre.Text + "', elija otro nombre", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
            }
            if (MessageBox.Show("¿Crear el proceso '" + txtNombre.Text + "'?", "Advertencia", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.OK)
            {
                ContenedorDatos.nombreProceso = txtNombre.Text;
                this.Close();
            }
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

