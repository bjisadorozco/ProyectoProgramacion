using System;
using Entity;
using BLL;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoGUI
{
    public partial class CuartoCuadro : Form
    {
        ServicioService servicioService;
        public CuartoCuadro()
        {
            InitializeComponent();
            servicioService = new ServicioService();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            var servicio = new Servicio()
            {
                Nombre = TxtNombre.Text,
                Codigo = TxtCodigo.Text,
                Precio = double.Parse(TxtPrecio.Text),
                Acompañante =  CmbAcompañante.SelectedItem.ToString(), 
                Descuento= double.Parse(TxtDescuento.Text),


            };
            var mensaje = servicioService.Guardar(servicio);
            MessageBox.Show(mensaje);
            Agregar();


        }
         private void Agregar()
        {
            var response = servicioService.Consultar();
            if (!response.Error)
            {
                DtgDatosServicios.DataSource = response.Servicios;
            }
            else
            {
                MessageBox.Show(response.Message);
            }
        }

        private void CmbAcompañante_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            if (DtgDatosServicios.SelectedRows.Count > 0)
            {

                servicioService.Eliminar(DtgDatosServicios.CurrentRow.Cells[0].Value.ToString());
            }
            else
            {
                MessageBox.Show("Seleccione una fila para editar.");
            }
            Agregar();
            

        }
    }
}
