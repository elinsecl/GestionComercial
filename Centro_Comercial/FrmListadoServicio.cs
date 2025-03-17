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
    public partial class FrmListadoServicio : Form
    {
        private Conexion _conexion = null;

        public FrmListadoServicio()
        {
            InitializeComponent();
            _conexion = new Conexion(ConfigurationManager.ConnectionStrings["StringConexion"].ConnectionString);
            Buscar("");
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                // Se llama al método MostrarServicio con la acción "Crear"
                MostrarServicio("Crear", 0);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MostrarServicio(string funcion, int idServicio)
        {
            try
            {
                // Se crea una instancia del formulario FrmCuenta
                FrmGestionServicios frmGestionServicios = new FrmGestionServicios(funcion, idServicio);

                // Se actualiza la lista de usuarios cuando se cierre el formulario
                frmGestionServicios.FormClosed += (s, args) => Buscar("");

                // Se muestra el formulario
                frmGestionServicios.Show();
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

        private void txtNombreServicio_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Buscar(this.txtNombreServicio.Text.Trim());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Este es el método que realiza la búsqueda por nombre de servicio
        private void Buscar(string nombreServicio)
        {
            try
            {
                this.dtgDatos.DataSource = _conexion.BuscarPorNombreServicio(nombreServicio).Tables[0];
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
                    int idServicio = Convert.ToInt32(this.dtgDatos.SelectedRows[0].Cells["IdServicio"].Value);
                    DialogResult result = MessageBox.Show("¿Está seguro de que desea eliminar este servicio?", "Confirmar eliminación",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (result == DialogResult.Yes)
                    {
                        _conexion.EliminarServicio(idServicio);
                        Buscar("");
                    }
                }
                else
                {
                    throw new Exception("Seleccione un servicio para eliminar.");
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
                    // Se obtiene el idServicio del servicio seleccionado
                    int idServicio = Convert.ToInt32(this.dtgDatos.SelectedRows[0].Cells["idServicio"].Value);
                    // Se llama al método MostrarServicio con la acción "Modificar"
                    MostrarServicio("Modificar", idServicio);
                }
                else
                {
                    throw new Exception("Seleccione la fila del servicio que desea modificar");
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
                FrmReporteServicio formulario = new FrmReporteServicio();
                formulario.FormClosed += (s, args) => Buscar("");

                formulario.ShowDialog();

                formulario.Dispose();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
    }
}
