using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using System.IO;

namespace DAL
{
    public  class ServicioRepository
    {
        string ruta = "Servicios.txt";
        public void Guardar(Servicio servicio)
        {
            FileStream archivo = new FileStream(ruta, FileMode.Append);
            StreamWriter escritor = new StreamWriter(archivo);
            escritor.WriteLine(servicio.Nombre + "-" + servicio.Codigo + "-" + servicio.Precio + "-" + servicio.Acompañante + "-" + servicio.Descuento);
            escritor.Close();
            archivo.Close();
        }
        public Servicio Buscar(string codigo)
        {
            List<Servicio> servicios = ConsultarTodos();
            foreach (var item in servicios)
            {
                if (Encontrado(item.Codigo, codigo))
                {
                    return item;
                }
            }
            return null;
        }
        private bool Encontrado(string IdServicioRegistrado, string IdServicioBuscado)
        {
            return IdServicioRegistrado == IdServicioBuscado;
        }
        public List<Servicio> ConsultarTodos()
        {
            List<Servicio> servicios = new List<Servicio>();
            FileStream archivo = new FileStream(ruta, FileMode.OpenOrCreate, FileAccess.Read);
            StreamReader lector = new StreamReader(archivo);
            string linea = string.Empty;
            while ((linea = lector.ReadLine()) != null)
            {
                Servicio servicio = Mapear(linea);
                servicios.Add(servicio);
            }
            lector.Close();
            archivo.Close();
            return servicios;
        }
        private Servicio Mapear(string linea)
        {
            Servicio servicio;
            char delimiter = '-';
            string[] matrizServicio = linea.Split(delimiter);
            if (matrizServicio[3] == "Si")
            {
                servicio = new Servicio(matrizServicio[0], matrizServicio[1], double.Parse(matrizServicio[2]), true, double.Parse(matrizServicio[4]));
            }
            else
            {
                servicio = new Servicio(matrizServicio[0], matrizServicio[1], double.Parse(matrizServicio[2]), false, double.Parse(matrizServicio[4]));
            }

            return servicio;
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
        }
    }
}
