using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using System.IO;

namespace DAL
{
    /* class FacturaRepository
     {
         string ruta = " Facturas.txt";
         public void Guardar(Factura factura)
         {
             FileStream archivo = new FileStream(ruta, FileMode.Append);
             StreamWriter escritor = new StreamWriter(archivo);
             escritor.WriteLine(factura.IdFactura + "-" + factura.IdProducto + "-" + factura.IdCliente + "-" + factura.Fecha + "-" + factura.SubTotal + "-" + factura.IVATotal + "-" + factura.TotalDescuento + "-" + factura.Total);
             escritor.Close();
             archivo.Close();
         }
         public Factura Buscar(string idFactura)
         {
             List<Factura> facturas = ConsultarTodos();
             foreach (var item in facturas)
             {
                 if (Encontrado(item.IdFactura, idFactura))
                 {
                     return item;
                 }
             }
             return null;
         }
         private bool Encontrado(string IdFacturaRegistrado, string IdFacturaBuscado)
         {
             return IdFacturaRegistrado == IdFacturaBuscado;
         }
         public List<Factura> ConsultarTodos()
         {
             List<Factura> facturas = new List<Factura>();
             FileStream archivo = new FileStream(ruta, FileMode.OpenOrCreate, FileAccess.Read);
             StreamReader lector = new StreamReader(archivo);
             string linea = string.Empty;
             while ((linea = lector.ReadLine()) != null)
             {
                 Factura factura = Mapear(linea);
                 facturas.Add(factura);
             }
             lector.Close();
             archivo.Close();
             return facturas;
         }
         private Factura Mapear(string linea)
         {
             Factura factura;
             char delimiter = '-';
             string[] matrizFactura = linea.Split(delimiter);
             factura = new Factura(matrizFactura[0], matrizFactura[1], (matrizFactura[2]), DateTime.Parse(matrizFactura[3]), double.Parse(matrizFactura[4]), double.Parse(matrizFactura[5]), double.Parse(matrizFactura[6]), double.Parse(matrizFactura[7]));

             return factura;
         }
         public void Eliminar(String codigo)
         {
             List<Servicio> servicios = new List<Servicio>();
             servicios = ConsultarTodos();
             FileStream archivo = new FileStream(ruta, FileMode.Create);
             archivo.Close();
             foreach (var item in servicios)
             {
                 if (!Encontrado(item.Codigo, codigo))
                 {
                     Guardar(item);
                 }
             }
         }
         public List<Servicio> FiltrarCodigo(string codigo)
         {
             return ConsultarTodos().Where(p => p.Codigo.Equals(codigo)).ToList();
         }*/
}


