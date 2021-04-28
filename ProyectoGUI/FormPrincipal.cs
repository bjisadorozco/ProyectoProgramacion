using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoGUI
{
    public partial class FormPrincipal : Form
    {
        public FormPrincipal()
        {
            InitializeComponent();
            Sidepanel.Height = button1.Height;
            Sidepanel.Top = button1.Top;
            AbrirFormulario<PrimerCuadro>();
          
        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Sidepanel.Height = button1.Height;
            Sidepanel.Top = button1.Top;
            AbrirFormulario<PrimerCuadro>();




        }


        private void button2_Click(object sender, EventArgs e)
        {
            Sidepanel.Height = button2.Height;
            Sidepanel.Top = button2.Top;
            AbrirFormulario<SegundoCuadro>();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Sidepanel.Height = button3.Height;
            Sidepanel.Top = button3.Top;
            AbrirFormulario<TercerCuadro>();

            //new TercerCuadro().Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Sidepanel.Height = button4.Height;
            Sidepanel.Top = button4.Top;
            AbrirFormulario<CuartoCuadro>();
            // new CuartoCuadro().Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Sidepanel.Height = button5.Height;
            Sidepanel.Top = button5.Top;
            AbrirFormulario<QuintoCuadro>();

            
        }

        private void AbrirFormulario<MiForm>() where MiForm : Form, new()
        {
            Form formulario;
            formulario = panelFormularios.Controls.OfType<MiForm>().FirstOrDefault();//Busca en la colecion el formulario
                                                                                     //si el formulario/instancia no existe
            if (formulario == null)
            {
                formulario = new MiForm();
                formulario.TopLevel = false;
                formulario.FormBorderStyle = FormBorderStyle.None;
                formulario.Dock = DockStyle.Fill;
                panelFormularios.Controls.Add(formulario);
                panelFormularios.Tag = formulario;
                formulario.Show();
                formulario.BringToFront();
            }
            //si el formulario/instancia existe
            else
            {
                formulario.BringToFront();
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;

        }
       /* 
        int lx, ly;
        int sw, sh;
       
        private void button14_Click(object sender, EventArgs e)
        {
            lx = this.Location.X;
            ly = this.Location.Y;
            sw = this.Size.Width;
            sh = this.Size.Height;
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;
            this.Location = Screen.PrimaryScreen.WorkingArea.Location;
            
           
            BtnMaximizar.Visible = false;
            BtnMinimizar2.Visible = false;
            
        

        }
        

        private void BtnMinimizar2_Click(object sender, EventArgs e)
        {
            this.Size = new Size(sw, sh);
            this.Location = new Point(lx, ly);
            WindowState = FormWindowState.Normal;
            
            BtnMinimizar2.Visible = false;
            BtnMaximizar.Visible = false;
        }
       */

        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private Form activeForm = null;
        private void OpenPanelFormularios(Form PanelFormularios)
        {
            if (activeForm != null)
                activeForm.Close();
            activeForm = PanelFormularios;
            PanelFormularios.TopLevel = false;
            PanelFormularios.FormBorderStyle = FormBorderStyle.None;
            PanelFormularios.Dock = DockStyle.Fill;
            panelFormularios.Controls.Add(PanelFormularios);
            panelFormularios.Tag = PanelFormularios;
            PanelFormularios.BringToFront();
            PanelFormularios.Show();
        }
        
    }

}
