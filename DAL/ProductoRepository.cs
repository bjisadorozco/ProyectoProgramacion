using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using System.IO;

namespace DAL
{
    public class ProductoRepository
    {
        string ruta = "Productos.txt";
        public void Guardar(Producto producto)
        {
            FileStream archivo = new FileStream(ruta, FileMode.Append);
            StreamWriter escritor = new StreamWriter(archivo);
            escritor.WriteLine(producto.Nombre + "-" + producto.Codigo + "-" + producto.PrecioUnitario + "-" + producto.Cantidad + "-" + producto.Existencias + "-" + producto.Descuento + "-" + producto.PorcentajeIVA);
            escritor.Close();
            archivo.Close();
        }
        public Producto Buscar(string codigo)
        {
            List<Producto> productos = ConsultarTodos();
            foreach (var item in productos)
            {
                if (Encontrado(item.Codigo, codigo))
                {
                    return item;
                }
            }
            return null;
        }
        private bool Encontrado(string IdProductoRegistrado, string IdProductoBuscado)
        {
            return IdProductoRegistrado == IdProductoBuscado;
        }
        public List<Producto> ConsultarTodos()
        {
            List<Producto> productos = new List<Producto>();
            FileStream archivo = new FileStream(ruta, FileMode.OpenOrCreate, FileAccess.Read);
            StreamReader lector = new StreamReader(archivo);
            string linea = string.Empty;
            while ((linea = lector.ReadLine()) != null)
            {
                Producto producto = Mapear(linea);
                productos.Add(producto);
            }
            lector.Close();
            archivo.Close();
            return productos;
        }
        private Producto Mapear(string linea)
        {
            Producto producto;
            char delimiter = '-';
            string[] matrizCliente = linea.Split(delimiter);
            producto = new Producto(matrizCliente[0], matrizCliente[1], double.Parse(matrizCliente[2]), int.Parse(matrizCliente[3]), int.Parse(matrizCliente[4]), double.Parse(matrizCliente[5]), double.Parse(matrizCliente[6]));
            return producto;
        }
        public void Eliminar(String codigo)
        {
            List<Producto> productos = new List<Producto>();
            productos = ConsultarTodos();
            FileStream archivo = new FileStream(ruta, FileMode.Create);
            archivo.Close();
            foreach (var item in productos)
            {
                if (!Encontrado(item.Codigo, codigo))
                {
                    Guardar(item);
                }
            }
        }
        public List<Producto> FiltrarCodigo(string codigo)
        {
            return ConsultarTodos().Where(p => p.Codigo.Equals(codigo)).ToList();
        }
    }
}

