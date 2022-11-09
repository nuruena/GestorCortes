using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestor_Cortes.Clases
{
    [Serializable]
    public class Corte
    {
        public int numOrden;
        public string numCable;
        public int cantidad;
        public string color;
        public string largo;
        public string seccion;
        public string despunteU1;
        public string despunteT1;
        public string identifYDistancia1;
        public string terminal1;
        public string despunteU2;
        public string despunteT2;
        public string identifYDistancia2;
        public string terminal2;
        public string desgarrado;
        public string estado;
        public string observacion;
        public string empresa;
        public string producto;
        public string referencia;

        public Corte(
            int numOrden, string numCable, int cantidad,
            string color, string largo, string seccion, string despunteU1, 
            string despunteT1, string identifYDistancia1, string terminal1, 
            string despunteU2, string despunteT2, string identifYDistancia2, 
            string terminal2, string desgarrado, string estado, string observacion,
            string empresa, string producto, string referencia)
        {
            this.numOrden = numOrden;
            this.numCable = numCable;
            this.cantidad = cantidad;
            this.color = color;
            this.largo = largo;
            this.seccion = seccion;
            this.despunteU1 = despunteU1;
            this.despunteT1 = despunteT1;
            this.identifYDistancia1 = identifYDistancia1;
            this.terminal1 = terminal1;
            this.despunteU2 = despunteU2;
            this.despunteT2 = despunteT2;
            this.identifYDistancia2 = identifYDistancia2;
            this.terminal2 = terminal2;
            this.desgarrado = desgarrado;
            this.estado = estado;
            this.observacion = observacion;
            this.empresa = empresa;
            this.producto = producto;
            this.referencia = referencia;
        }
    }
}
