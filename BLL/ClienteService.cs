using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using DAL;
namespace BLL
{
   public  class ClienteService
    {
        private ClienteRepository clienteRepository;
        public ClienteService()
        {
            clienteRepository = new ClienteRepository();
        }
        public string Guardar(Cliente cliente)
        {
            try
            {
                if (clienteRepository.Buscar(cliente.Identificacion) == null)
                {
                    clienteRepository.Guardar(cliente);
                    return "Se guardaron los datos de manera exitosa";
                }
                return "No es posible guardar los datos";
            }
            catch (Exception e)
            {
                return "Error:" + e.Message;
            }
        }
        public ClienteConsultaResponse Consultar()
        {
            try
            {
                List<Cliente> clientes = clienteRepository.ConsultarTodos();
                var response = new ClienteConsultaResponse(clientes);
                return response;
            }
            catch (Exception e)
            {
                var response = new ClienteConsultaResponse("Error:" + e.Message);
                return response;
            }
        }
        public string Eliminar(string identificacion)
        {
            try
            {
                if (clienteRepository.Buscar(identificacion) != null)
                {
                    clienteRepository.Eliminar(identificacion);
                    return ($"se han Eliminado Satisfactoriamente los datos del paciente con numero de liquidacion: {identificacion} ");
                }
                else
                {
                    return ($"Lo sentimos, no se encuentra registrado un paciente con liquidacion {identificacion}");
                }
            }
            catch (Exception e)
            {

                return $"Error de la Aplicacion: {e.Message}";
            }
        }
        public ClienteConsultaResponse ConsultarIdentificacion(string identificacion)
        {
            try
            {
                List<Cliente> clientes  = clienteRepository.FiltrarIdentificacion(identificacion);
                var response = new ClienteConsultaResponse(clientes);
                return response;
            }
            catch (Exception e)
            {
                var response = new  ClienteConsultaResponse("Error:" + e.Message);
                return response;
            }
        }

        public class ClienteConsultaResponse
        {
            public List<Cliente> Clientes { get; set; }
            public string Message { get; set; }
            public bool Error { get; set; }
            public bool ClienteEncontrado { get; set; }
            public ClienteConsultaResponse(string message)
            {
                Error = true;
                Message = message;
                ClienteEncontrado = false;
            }
            public ClienteConsultaResponse(List<Cliente> clientes)
            {
                Clientes = clientes;
                Error = false;
                ClienteEncontrado = true;
            }
        }
    }
}

