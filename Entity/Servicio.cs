using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Servicio
    {
            public String Nombre { get; set; }
            public Double Precio { get; set; }
            public Boolean Acompañante { get; set; }
            public Double Descuento { get; set; }
            public String Codigo { get; set; }
        public Servicio (string nombre, string codigo, double precio, bool acompañante, double descuento) 
        {
            Nombre = nombre;
            Codigo = codigo;
            Precio = precio;
            Acompañante = acompañante;
            Descuento = descuento;
        }
    }
}
