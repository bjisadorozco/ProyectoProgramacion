using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using System.IO;

namespace DAL
{
    public class ClienteRepository
    {
        string ruta = "Clientes.txt";
        public void Guardar(Cliente cliente)
        {
            FileStream archivo = new FileStream(ruta, FileMode.Append);
            StreamWriter escritor = new StreamWriter(archivo);
            escritor.WriteLine(cliente.Nombre + "-" + cliente.Identificacion+ "-" + cliente.Edad + "-" + cliente.Telefono+ "-" + cliente.Direccion);
            escritor.Close();
            archivo.Close();
        }
        public Cliente Buscar(string identificacion)
        {
            List<Cliente> clientes = ConsultarTodos();
            foreach (var item in clientes)
            {
                if (Encontrado(item.Identificacion, identificacion))
                {
                    return item;
                }
            }
            return null;
        }
        private bool Encontrado(string IdClienteRegistrado, string IdClienteBuscado)
        {
            return IdClienteRegistrado == IdClienteBuscado;
        }
        public List<Cliente> ConsultarTodos()
        {
            List<Cliente> clientes = new List<Cliente>();
            FileStream archivo = new FileStream(ruta, FileMode.OpenOrCreate, FileAccess.Read);
            StreamReader lector = new StreamReader(archivo);
            string linea = string.Empty;
            while ((linea = lector.ReadLine()) != null)
            {
                Cliente cliente = Mapear(linea);
                clientes.Add(cliente);
            }
            lector.Close();
            archivo.Close();
            return clientes;
        }
        private Cliente Mapear(string linea)
        {
            Cliente cliente;
            char delimiter = '-';
            string[] matrizCliente = linea.Split(delimiter);
            cliente = new Cliente(matrizCliente[0], matrizCliente[1], int.Parse(matrizCliente[2]), (matrizCliente[3]), (matrizCliente[4]));
            return cliente;
        }
        public void Eliminar(String identificacion)
        {
            List<Cliente> clientes = new List<Cliente>();
            clientes = ConsultarTodos();
            FileStream archivo = new FileStream(ruta, FileMode.Create);
            archivo.Close();
            foreach (var item in clientes)
            {
                if (!Encontrado(item.Identificacion, identificacion))
                {
                    Guardar(item);
                }
            }
        }
        public List<Cliente> FiltrarIdentificacion(string identificacion)
        {
            return ConsultarTodos().Where(p => p.Identificacion.Equals(identificacion)).ToList();
        }
    }
}

