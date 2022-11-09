using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestor_Cortes.Clases
{
    public class HojaSeleccionada
    {
        public string NombreArchivo;
        public string Ruta;
        public int NumOrden;
        public int cantidad;

        public HojaSeleccionada(string nombreArchivo, string ruta, int numOrden, int cantidad)
        {
            NombreArchivo = nombreArchivo;
            Ruta = ruta;
            NumOrden = numOrden;
            this.cantidad = cantidad;
        }
    }


}
