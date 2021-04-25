using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class DetalleFactura
    {
        public string CodigoDetalleFactura { get; set; }
        public int Cantidad { get; set; }
        public Factura Factura { get; set; }
        public Servicio Servicio { get; set; }
        public double PorcentajeIVA { get; set; }
        public double PorcentajeDescuento { get; set; }
        public Producto Producto { get; set; }
        public double PrecioUnitario { get; set; }
        public double Precio { get; set; }
        public double ValorDescuento { get; set; }
        public double ValorConDescuento { get; set; }
        public double ValorIVA { get; set; }
        public double Total { get; set; }
        public DetalleFactura(Producto producto,  int cantidad)
        {
            Producto = producto;
            PrecioUnitario = producto.PrecioVenta;
            PorcentajeDescuento = producto.Descuento;
            PorcentajeIVA = producto.PorcentajeIVA;
            Cantidad = cantidad;
            CalcularValoresFactura();
        }
        private void CalcularPrecio()
        {
            Precio = PrecioUnitario * Cantidad;     
        }
        private void CalcularValorDescuento()
        {
            ValorDescuento = Precio * (PorcentajeDescuento / 100);
        }
        private void CalcularValorConDescuento()
        {
            ValorConDescuento = Precio - ValorDescuento;
        }
        private void CalularIVA()
        {
            ValorIVA = ValorDescuento * (PorcentajeIVA/100);
        }
        private void CalcularTotal()
        {
            Total = (Precio - ValorDescuento + ValorIVA);
        }
        public void CalcularValoresFactura()
        {
            CalcularPrecio();
            CalcularValorDescuento();
            CalcularValorConDescuento();
            CalularIVA();
            CalcularTotal();
        }

    }
}
