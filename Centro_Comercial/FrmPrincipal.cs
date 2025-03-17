using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Centro_Comercial
{
    public partial class FrmPrincipal : Form
    {
        public FrmPrincipal()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

      

        private void btnEncuesta_Click(object sender, EventArgs e)
        {
            // Crear la instancia del formulario FrmListadoEncuesta
            FrmListadoEncuesta frmListadoEncuesta = new FrmListadoEncuesta();

            // Configuramos que este formulario se muestre dentro del panel, no como una ventana independiente
            frmListadoEncuesta.TopLevel = false;  // Esto hace que no se abra como una ventana separada
            frmListadoEncuesta.FormBorderStyle = FormBorderStyle.None;  // Elimina los bordes
            frmListadoEncuesta.Dock = DockStyle.Fill;  // Hace que el formulario llene todo el panel

            // Limpiar el contenido del panel3 (si ya hay algo cargado) antes de agregar el nuevo formulario
            this.panel3.Controls.Clear();

            // Agregar el formulario dentro de panel3
            this.panel3.Controls.Add(frmListadoEncuesta);

            // Mostrar el formulario
            frmListadoEncuesta.Show();
        }

        private void btnServicio_Click(object sender, EventArgs e)
        {
            // Crear la instancia del formulario FrmListadoServicio
            FrmListadoServicio frmListadoServicio = new FrmListadoServicio();

            // Configuramos que este formulario se muestre dentro del panel, no como una ventana independiente
            frmListadoServicio.TopLevel = false;  // Esto hace que no se abra como una ventana separada
            frmListadoServicio.FormBorderStyle = FormBorderStyle.None;  // Elimina los bordes
            frmListadoServicio.Dock = DockStyle.Fill;  // Hace que el formulario llene todo el panel

            // Limpiar el contenido del panel3 (si ya hay algo cargado) antes de agregar el nuevo formulario
            this.panel3.Controls.Clear();

            // Agregar el formulario dentro de panel3
            this.panel3.Controls.Add(frmListadoServicio);

            // Mostrar el formulario
            frmListadoServicio.Show();
        }

        private void btnCliente_Click(object sender, EventArgs e)
        {
            // Crear la instancia del formulario FrmListadoCliente
            FrmListadoCliente frmListadoCliente = new FrmListadoCliente();

            // Configurar el formulario para que se muestre dentro del panel3
            frmListadoCliente.TopLevel = false;  // Hace que el formulario no sea independiente
            frmListadoCliente.FormBorderStyle = FormBorderStyle.None;  // Quita bordes
            frmListadoCliente.Dock = DockStyle.Fill;  // Ocupa todo el espacio del panel

            // Limpiar el contenido previo del panel antes de cargar el nuevo formulario
            this.panel3.Controls.Clear();

            // Agregar el formulario dentro de panel3
            this.panel3.Controls.Add(frmListadoCliente);

            // Mostrar el formulario
            frmListadoCliente.Show();
        }


        private void btnCliente_Click_1(object sender, EventArgs e)
        {
            // Crear la instancia del formulario FrmListadoCliente
            FrmListadoCliente frmListadoCliente = new FrmListadoCliente();

            // Configurar el formulario para que se muestre dentro del panel3
            frmListadoCliente.TopLevel = false;  // Hace que el formulario no sea independiente
            frmListadoCliente.FormBorderStyle = FormBorderStyle.None;  // Quita bordes
            frmListadoCliente.Dock = DockStyle.Fill;  // Ocupa todo el espacio del panel

            // Limpiar el contenido previo del panel antes de cargar el nuevo formulario
            this.panel3.Controls.Clear();

            // Agregar el formulario dentro de panel3
            this.panel3.Controls.Add(frmListadoCliente);

            // Mostrar el formulario
            frmListadoCliente.Show();
        }

        private void porNombreServicioToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void porNombreClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void porTipoEncuestaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void agregarEncuestaToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void agregarEncuestaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void agregarServicioToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
