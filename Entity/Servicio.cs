using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Servicio
    {
            public string Nombre { get; set; }
            public double Precio { get; set; }
            public bool Acompañante { get; set; }
            public double Descuento { get; set; }
            public string Codigo { get; set; }
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
