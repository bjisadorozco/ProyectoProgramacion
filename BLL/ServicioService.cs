using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using DAL;

namespace BLL
{
    class ServicioService
    {
        private ServicioRepository servicioRepository;
        public ServicioService()
        {
            servicioRepository = new ServicioRepository();
        }
        public string Guardar(Servicio servicio)
        {
            try
            {
                if (servicioRepository.Buscar(servicio.Codigo) == null)
                {
                    servicioRepository.Guardar(servicio);
                    return "Se guardaron los datos de manera exitosa";
                }
                return "No es posible guardar los datos";
            }
            catch (Exception e)
            {
                return "Error:" + e.Message;
            }
        }
        public ServicioConsultaResponse Consultar()
        {
            try
            {
                List<Servicio> servicios = servicioRepository.ConsultarTodos();
                var response = new ServicioConsultaResponse(servicios);
                return response;
            }
            catch (Exception e)
            {
                var response = new ServicioConsultaResponse("Error:" + e.Message);
                return response;
            }
        }
        public string Eliminar(string codigo)
        {
            try
            {
                if (servicioRepository.Buscar(codigo) != null)
                {
                    servicioRepository.Eliminar(codigo);
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
        public ServicioConsultaResponse ConsultarCodigo(string codigo)
        {
            try
            {
                List<Servicio> servicios = servicioRepository.FiltrarCodigo(codigo);
                var response = new ServicioConsultaResponse(servicios);
                return response;
            }
            catch (Exception e)
            {
                var response = new ServicioConsultaResponse("Error:" + e.Message);
                return response;
            }
        }

        public class ServicioConsultaResponse
        {
            public List<Servicio> Servicios { get; set; }
            public string Message { get; set; }
            public bool Error { get; set; }
            public bool ServicioEncontrado { get; set; }
            public ServicioConsultaResponse(string message)
            {
                Error = true;
                Message = message;
                ServicioEncontrado = false;
            }
            public ServicioConsultaResponse(List<Servicio> servicios)
            {
                Servicios = servicios;
                Error = false;
                ServicioEncontrado = true;
            }
        }
    }
}
