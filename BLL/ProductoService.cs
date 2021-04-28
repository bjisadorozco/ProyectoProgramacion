using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using DAL;

namespace BLL
{
    class ProductoService
    {
        private ProductoRepository productoRepository;
        public ProductoService()
        {
            productoRepository = new ProductoRepository();
        }
        public string Guardar(Producto producto)
        {
            try
            {
                if (productoRepository.Buscar(producto.Codigo) == null)
                {
                    productoRepository.Guardar(producto);
                    return "Se guardaron los datos de manera exitosa";
                }
                return "No es posible guardar los datos";
            }
            catch (Exception e)
            {
                return "Error:" + e.Message;
            }
        }
        public ProductoConsultaResponse Consultar()
        {
            try
            {
                List<Producto> productos = productoRepository.ConsultarTodos();
                var response = new ProductoConsultaResponse(productos);
                return response;
            }
            catch (Exception e)
            {
                var response = new ProductoConsultaResponse("Error:" + e.Message);
                return response;
            }
        }
        public string Eliminar(string codigo)
        {
            try
            {
                if (productoRepository.Buscar(codigo) != null)
                {
                    productoRepository.Eliminar(codigo);
                    return ($"se han Eliminado Satisfactoriamente los datos del paciente con numero de liquidacion: {codigo} ");
                }
                else
                {
                    return ($"Lo sentimos, no se encuentra registrado un paciente con liquidacion {codigo}");
                }
            }
            catch (Exception e)
            {

                return $"Error de la Aplicacion: {e.Message}";
            }
        }
        public ProductoConsultaResponse ConsultarCodigo(string codigo)
        {
            try
            {
                List<Producto> productos = productoRepository.FiltrarCodigo(codigo);
                var response = new ProductoConsultaResponse(productos);
                return response;
            }
            catch (Exception e)
            {
                var response = new ProductoConsultaResponse("Error:" + e.Message);
                return response;
            }
        }

        public class ProductoConsultaResponse
        {
            public List<Producto> Productos { get; set; }
            public string Message { get; set; }
            public bool Error { get; set; }
            public bool ProductoEncontrado { get; set; }
            public ProductoConsultaResponse(string message)
            {
                Error = true;
                Message = message;
                ProductoEncontrado = false;
            }
            public ProductoConsultaResponse(List<Producto> productos)
            {
                Productos = productos;
                Error = false;
                ProductoEncontrado = true;
            }
        }
    }
}

