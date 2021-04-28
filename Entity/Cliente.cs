using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Cliente: Persona
    {
        public Cliente() { }
        public Cliente (string nombre, string identificacion, int edad, string telefono, string direccion)
        {
            Nombre = nombre;
            Identificacion = identificacion;
            Edad = edad;
            Telefono = telefono;
            Direccion = direccion;
        }
    }
}
