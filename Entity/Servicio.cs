using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Servicio: ProductoServicio
    {  
        public Servicio()
        {

        }
        public Servicio(string nombre, string codigo, double precio, int existencias)
        {
            Nombre = nombre;
            Codigo = codigo;
            Precio = precio;
            Existencias = existencias;
        }
    }
}
