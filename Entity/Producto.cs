using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Producto: ProductoServicio
    {
        public DateTime Fecha { get; set; }
        public double Descuento { get; set; }
        public double PorcentajeIVA { get; set; }

        public Producto() { }

        public Producto(string codigo, string nombre, double precioUnitario, int cantidad, int existencias, double descuento, double porcentajeIva)
        {
            Nombre = nombre;
            Codigo = codigo;
            Precio = precioUnitario;
            Existencias = existencias;
            Descuento = descuento;
            PorcentajeIVA = porcentajeIva;
        }
    }
}
