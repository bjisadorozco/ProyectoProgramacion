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
    public partial class TercerCuadro : Form
    {
        private ProductoService productoService;
        public TercerCuadro()
        {
            InitializeComponent();
            productoService = new ProductoService();
        }

        private void BtnCerrar_Click(object sender, EventArgs e)
        {

        }

        private void BtnRegistrar_Click(object sender, EventArgs e)
        {
            var producto = new Producto()
            {
                Codigo=TxtCodigo.Text,
                Nombre=TxtNombre.Text,
                PrecioUnitario=double.Parse(TxtPrecio.Text),
                Cantidad=int.Parse(TxtCantidad.Text),
                Existencias=int.Parse(TxtExistencias.Text),
                Descuento=Double.Parse(TxtDescuento.Text),
                PorcentajeIVA=Double.Parse(TxtIVA.Text),
            };
            var mensaje = productoService.Guardar(producto);
            MessageBox.Show(mensaje);
            Agregar();
        }
         
        private void Agregar()
        {
            var response = productoService.Consultar();
                if (!response.Error)
                {
                DtgDatosProductos.DataSource = response.Productos;
                }
                else
                {
                MessageBox.Show(response.Message);
                }
            
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            if (DtgDatosProductos.SelectedRows.Count > 0)
            {

                productoService.Eliminar(DtgDatosProductos.CurrentRow.Cells[0].Value.ToString());
            }
            else
            {
                MessageBox.Show("Seleccione una fila para editar.");
            }
            Agregar();

        }
    }
}
