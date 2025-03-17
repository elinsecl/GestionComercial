using DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Centro_Comercial
{
    public partial class FrmListadoEncuesta : Form
    {
        private Conexion _conexion = null;

        public FrmListadoEncuesta()
        {
            InitializeComponent();
            _conexion = new Conexion(ConfigurationManager.ConnectionStrings["StringConexion"].ConnectionString);
            Buscar("");
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtTipoEncuesta_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Buscar(this.txtTipoEncuesta.Text.Trim());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Buscar(string tipoEncuesta)
        {
            try
            {
                // Llamar a la base de datos y asignar los resultados al DataGridView
                this.dtgDatos.DataSource = _conexion.BuscarPorTipoEncuesta(tipoEncuesta).Tables[0];
                this.dtgDatos.AutoResizeColumns();
                this.dtgDatos.ReadOnly = true;
                this.dtgDatos.Sort(this.dtgDatos.Columns["IdEncuesta"], ListSortDirection.Ascending);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                // Se llama al método MostrarEncuesta con la acción "Crear" y el ID 0 para crear una nueva encuesta
                MostrarEncuesta("Crear", 0);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MostrarEncuesta(string funcion, int idEncuesta)
        {
            try
            {
                // Se crea una instancia del formulario FrmGestionEncuestas
                FrmGestionEncuestas frmGestionEncuestas = new FrmGestionEncuestas(funcion, idEncuesta);

                // Se actualiza la lista de encuestas cuando se cierre el formulario
                frmGestionEncuestas.FormClosed += (s, args) => Buscar("");

                // Se muestra el formulario
                frmGestionEncuestas.ShowDialog();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void editarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dtgDatos.SelectedRows.Count > 0)
                {
                    // Se obtiene el idEncuesta de la encuesta seleccionada
                    int idEncuesta = Convert.ToInt32(this.dtgDatos.SelectedRows[0].Cells["IdEncuesta"].Value);
                    // Se llama al método MostrarEncuesta con la acción "Modificar"
                    MostrarEncuesta("Modificar", idEncuesta);
                }
                else
                {
                    throw new Exception("Seleccione la fila de la encuesta que desea modificar");
                }
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
                    int idEncuesta = Convert.ToInt32(this.dtgDatos.SelectedRows[0].Cells["IdEncuesta"].Value);
                    DialogResult result = MessageBox.Show("¿Está seguro de que desea eliminar esta encuesta?", "Confirmar eliminación",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (result == DialogResult.Yes)
                    {
                        _conexion.EliminarEncuesta(idEncuesta);
                        Buscar(""); // Refrescar la lista
                    }
                }
                else
                {
                    throw new Exception("Seleccione una encuesta para eliminar.");
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
                FrmReporteEncuesta formulario = new FrmReporteEncuesta();
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
