using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
   public class Factura
    {
         public DateTime Fecha { get; set; }
        public Double Total { get; set; }
        public Persona Cliente { get; set; }
        public String IdCliente { get; set; }
        public String CodigoFactura { get; set; }
        public Double SubTotal { get; set; }
        public Double TotalDescuento { get; set; }
        public Double IVATotal { get; set; }
        public Factura()
        {
            Detalles = new List<DetalleFactura>();
        }

        public List<DetalleFactura> Detalles { get; set; }

        public void AgregarDetalle(Producto producto, int cantidad)
        {
            DetalleFactura detalle = new DetalleFactura(producto, cantidad);
            Detalles.Add(detalle);
        }

        public void CalcularSubTotal()
        {
            SubTotal = 0;
            foreach (var item in Detalles)
            {
                SubTotal += item.Precio;
            }
        }


        public void CalcularTotalDescuento()
        {
            TotalDescuento = 0;
            foreach (var item in Detalles)
            {
                TotalDescuento += item.ValorDescuento;
            }
        }

        public void CalcularTotalIVA()
        {
            IVATotal = 0;
            foreach (var item in Detalles)
            {
                IVATotal += item.ValorIVA;
            }
        }

        public void CalcularTotal()
        {
            Total = SubTotal - TotalDescuento + IVATotal;
        }




        

        
    }
}
