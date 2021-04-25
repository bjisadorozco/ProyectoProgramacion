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
                Nombre = 'brayan',

            };
            Factura factura = new Factura()
            {
                CodigoFactura = 1,
                cliente = cliente,
                idCliente = cliente.identificacion,

            };

            Producto producto = new Producto()
            {
                IdProducto = '1',
                Descripcion = "chanclas boconas",
                Descuento = 5,
                IVA = 16,
                Existencia = 20,
                PrecioUnitario = 100,
            };

            DetalleFactura detalleFactura = new DetalleFactura(producto, 5);
            factura.AgregarDetalle(detalleFactura);
            factura2.AgregarDetalle(detalleFactura);
        }
    }
}
