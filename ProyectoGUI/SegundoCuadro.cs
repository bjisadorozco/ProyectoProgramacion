using BLL;
using Entity;
using System;
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
    public partial class SegundoCuadro : Form
    {
         private ClienteService clienteService ;
        public SegundoCuadro()
        {
            InitializeComponent();
            clienteService = new ClienteService();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            var cliente = new Cliente()
            {
                Nombre = TxtNombre.Text,
                Identificacion= TxtIdentificacion.Text,
                Edad = int.Parse(TxtEdad.Text),
                Telefono=TxtTelefono.Text,
                Direccion=TxtDireccion.Text,

            };
            var mensaje = clienteService.Guardar(cliente);
            MessageBox.Show(mensaje);
            mostrar();

        }
        
        private void mostrar()
        {
            var response = clienteService.Consultar();
            if (!response.Error)
            {
                DtgDatosPersona.DataSource = response.Clientes;
            }
            else
            {
                MessageBox.Show(response.Message);
            }
        }
        
       
    }
}
