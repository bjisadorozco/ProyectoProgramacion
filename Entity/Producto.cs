using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    class Producto
    {
        public String Codigo { get; set; }
        public String Nombre { get; set; }
        public Double PrecioVenta { get; set; }
        public Double Cantidad { get; set; }
        public double Descuento { get; set; }
        public double PorcentajeIVA { get; set; }

    }
}
