using System;
using Centro_Comercial;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL;
using System.Configuration;

namespace Centro_Comercial
{
    public partial class FrmListadoCliente : Form
    {
        private Conexion _conexion = null;

        public FrmListadoCliente()
        {
            InitializeComponent();
            _conexion = new Conexion(ConfigurationManager.ConnectionStrings["StringConexion"].ConnectionString);
            Buscar("");
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                // Se llama al método MostrarCliente con la acción "Crear"
                MostrarCliente("Crear", 0);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MostrarCliente(string funcion, int idCliente)
        {
            try
            {
                // Se crea una instancia del formulario FrmGestionClientes
                FrmGestionClientes frmGestionClientes = new FrmGestionClientes(funcion, idCliente);

                // Se actualiza la lista de clientes cuando se cierre el formulario
                frmGestionClientes.FormClosed += (s, args) => Buscar("");

                // Se muestra el formulario
                frmGestionClientes.Show();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtNombreCliente_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Buscar(this.txtNombreCliente.Text.Trim());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Este es el método que realiza la búsqueda por nombre de cliente
        private void Buscar(string nombre)
        {
            try
            {
                this.dtgDatos.DataSource = _conexion.BuscarPorNombreCliente(nombre).Tables[0];
                this.dtgDatos.AutoResizeColumns();
                this.dtgDatos.ReadOnly = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dtgDatos.SelectedRows.Count > 0)
                {
                    int idCliente = Convert.ToInt32(this.dtgDatos.SelectedRows[0].Cells["IdCliente"].Value);
                    DialogResult result = MessageBox.Show("¿Está seguro de que desea eliminar este cliente?", "Confirmar eliminación",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (result == DialogResult.Yes)
                    {
                        _conexion.EliminarCliente(idCliente);
                        Buscar("");
                    }
                }
                else
                {
                    throw new Exception("Seleccione un cliente para eliminar.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void editarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dtgDatos.SelectedRows.Count > 0)
                {
                    // Se obtiene el idCliente del cliente seleccionado
                    int idCliente = Convert.ToInt32(this.dtgDatos.SelectedRows[0].Cells["IdCliente"].Value);
                    // Se llama al método MostrarCliente con la acción "Modificar"
                    MostrarCliente("Modificar", idCliente);
                }
                else
                {
                    throw new Exception("Seleccione la fila del cliente que desea modificar");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            try
            {
                MostrarInforme();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        

        public void MostrarInforme()
        {
            try
            {
                FrmReporteCliente formulario = new FrmReporteCliente();
                formulario.FormClosed += (s, args) => Buscar("");

                formulario.ShowDialog();

                formulario.Dispose();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            _conexion.VerificarClientesInactivos();

        }
    }
}
