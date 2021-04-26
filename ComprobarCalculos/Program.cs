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
                Nombre = "crema",
                Descuento = 5,
                PorcentajeIVA = 16,
                PrecioUnitario = 100,
            };

            Producto producto1= new Producto()
            {
                Codigo = "1234",
                Nombre = "Jabon",
                Descuento = 10,
                PorcentajeIVA = 19,
                PrecioUnitario = 200,
            };


            DetalleFactura detalleFacturanuevo = new DetalleFactura(producto, 5);
            factura.AgregarDetalle(producto, 5);
            factura.AgregarDetalle(producto1, 5);

            DetalleFactura detalleFactura1 = new DetalleFactura(producto1, 5);
            factura.AgregarDetalle(producto1, 5);
             factura.AgregarDetalle(producto, 5);
            
            Console.WriteLine("imprimir");
            //Console.WriteLine("Descuento "+DetalleFactura);
            Console.WriteLine("Precio "+detalleFacturanuevo.Precio);
            Console.WriteLine("Sin Descuento "+detalleFacturanuevo.ValorDescuento);
             Console.WriteLine("valor con Descuento "+detalleFacturanuevo.ValorConDescuento);
            Console.WriteLine("Valor Del IVA " + detalleFacturanuevo.ValorIVA);
            Console.WriteLine("Total" +detalleFacturanuevo.Total);

            Console.WriteLine("--------------------------");
            Console.WriteLine("imprimir");
            //Console.WriteLine("Descuento "+DetalleFactura);
            Console.WriteLine("Precio "+detalleFactura1.Precio);
            Console.WriteLine("Sin Descuento "+detalleFactura1.ValorDescuento);
             Console.WriteLine("valor con Descuento "+detalleFactura1.ValorConDescuento);
            Console.WriteLine("Valor Del IVA " + detalleFactura1.ValorIVA);
            Console.WriteLine("Total" +detalleFactura1.Total);
           
            Console.WriteLine(cliente.Nombre);
            Console.WriteLine(factura.Total);
            Console.ReadKey();
        }
    }
}
