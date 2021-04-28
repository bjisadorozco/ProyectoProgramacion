using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Producto
    {
        public String Codigo { get; set; }
        public String Nombre { get; set; }
        public double PrecioUnitario { get; set; }
        public int Cantidad { get; set; }
        public int Existencias { get; set; }
        public double Descuento { get; set; }
        public double PorcentajeIVA { get; set; }

        public Producto() { }

        public Producto(string codigo, string nombre, double precioUnitario, int cantidad, int existencias, double descuento, double porcentajeIva)
        {
            Nombre = nombre;
            Codigo = codigo;
            PrecioUnitario = precioUnitario;
            Cantidad = cantidad;
            Existencias = existencias;
            Descuento = descuento;
            PorcentajeIVA = porcentajeIva;
        }
    }
}
