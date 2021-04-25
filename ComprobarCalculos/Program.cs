using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;

namespace ComprobarCalculos
{
    public class Program
    {
        static void Main(string[] args)
        {
            Cliente cliente = new Cliente
            {
                Nombre = "Brayan",

            };
            Factura factura = new Factura()
            {
                CodigoFactura = "ABC",
                Cliente = cliente,
                IdCliente = cliente.Identificacion,
            };

            Producto producto = new Producto()
            {
                Codigo = "123",
                Descripcion = "crema",
                Descuento = 5,
                PorcentajeIVA = 16,
                PrecioUnitario = 100,
            };
            factura.AgregarDetalle(producto, 5);
            Console.WriteLine("imprimir");
            Console.WriteLine(cliente.Nombre);
            Console.WriteLine(factura.Total);
            Console.ReadKey();
        }
    }
}
