using BLL;
using Centro_Comercial;
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
    public partial class FrmGestionEncuestas : Form
    {
        private Conexion _conexion = null;
        private Encuestas _encuesta; 
        private readonly string _tipoSolicitud; 
        private readonly int _idEncuesta;

        public FrmGestionEncuestas(string tipoSolicitud, int idEncuesta)
        {
            InitializeComponent();
            _conexion = new Conexion(ConfigurationManager.ConnectionStrings["StringConexion"].ConnectionString);
            CargarCombos();
            this._tipoSolicitud = tipoSolicitud;
            this._idEncuesta = idEncuesta;
            txtIdEncuesta.Enabled = false;
            _encuesta = new Encuestas();
            Comprobar_Tipo_Solicitud();
        }

        private void CargarCombos()
        {
            cmbCalificacionEncuesta.Items.AddRange(new object[] { "1", "2", "3", "4", "5" });
            cmbTipoEncuesta.Items.AddRange(new object[] { "Satisfacción", "Recomendación", "Opinión" });
            cmbEstadoEncuesta.Items.AddRange(new object[] { "Completada", "Pendiente" });
        }

        private void LimpiarFormulario()
        {
            txtIdEncuesta.Clear();
            txtIdCliente.Clear();
            txtServicio.Clear();
            txtComentarios.Clear();
            dtpFechaEncuesta.Value = DateTime.Now;
            cmbCalificacionEncuesta.SelectedIndex = -1;
            cmbTipoEncuesta.SelectedIndex = -1;
            cmbEstadoEncuesta.SelectedIndex = -1;
        }

        public void Comprobar_Tipo_Solicitud()
        {
            switch (_tipoSolicitud)
            {
                case "Modificar":
                    // Mostrar el Label y el TextBox del ID de Encuesta
                    label1.Visible = true;
                    txtIdEncuesta.Visible = true;
                    llenar_Datos_Encuesta();
                    dtpFechaEncuesta.Enabled = false;  // Deshabilitar la fecha para modificaciones
                    break;

                case "Crear":
                    // Ocultar el Label y el TextBox del ID de Encuesta
                    label1.Visible = false;
                    txtIdEncuesta.Visible = false;
                    LimpiarFormulario(); // Limpiar el formulario cuando se crea una nueva encuesta
                    break;
            }
        }

        public void llenar_Datos_Encuesta()
        {
            try
            {
                _encuesta = _conexion.BuscarPorIdEncuesta(_idEncuesta);

                if (_idEncuesta <= 0)
                {
                    MessageBox.Show("El ID de encuesta no puede ser cero o negativo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (_encuesta != null && _idEncuesta > 0)
                {
                    txtIdEncuesta.Text = _encuesta.IdEncuesta.ToString();
                    txtIdCliente.Text = _encuesta.IdCliente.ToString();
                    txtServicio.Text = _encuesta.IdServicio.ToString();
                    txtComentarios.Text = _encuesta.Comentarios;
                    dtpFechaEncuesta.Value = _encuesta.FechaEncuesta;
                    cmbCalificacionEncuesta.SelectedItem = _encuesta.CalificacionEncuesta.ToString(); ;
                    cmbTipoEncuesta.SelectedItem = _encuesta.TipoEncuesta;
                    cmbEstadoEncuesta.SelectedItem = _encuesta.EstadoEncuesta;
                }
                else
                {
                    MessageBox.Show("Encuesta no encontrada.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al buscar la encuesta: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pictureBoxSalir_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private bool Verificar_Campos()
        {
            List<string> errores = new List<string>();

            if (cmbCalificacionEncuesta.SelectedIndex == -1)
                errores.Add("⚠ Debe seleccionar una calificación (1-5).");

            if (cmbTipoEncuesta.SelectedIndex == -1)
                errores.Add("⚠ Debe seleccionar un tipo de encuesta (Satisfacción, Recomendación, Opinión).");

            if (cmbEstadoEncuesta.SelectedIndex == -1)
                errores.Add("⚠ Debe seleccionar un estado de la encuesta (Completada, Pendiente).");

            if (dtpFechaEncuesta.Value > DateTime.Now)
                errores.Add("⚠ La fecha de la encuesta no puede ser superior a la actual.");

            // Validar que el ID de Servicio sea obligatorio
            if (string.IsNullOrWhiteSpace(txtServicio.Text))
                errores.Add("⚠ Debe ingresar un ID de servicio válido.");

            // Validar que los comentarios no excedan 1000 caracteres
            if (txtComentarios.Text.Length > 1000)
                errores.Add("⚠ Los comentarios no pueden tener más de 1000 caracteres.");

            // ✅ Validar cliente activo (solo si no es anónima)
            if (!string.IsNullOrWhiteSpace(txtIdCliente.Text))
            {
                int idCliente = Convert.ToInt32(txtIdCliente.Text);
                if (!_conexion.ClienteEsActivo(idCliente))
                    errores.Add("⚠ Solo los clientes activos pueden responder encuestas.");
            }

            if (errores.Count > 0)
            {
                MessageBox.Show("❌ Errores en el formulario:\n\n" + string.Join("\n", errores),
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void Agregar_Encuesta()
        {
            try
            {
                // Validación para asegurarse de que solo las encuestas de satisfacción pueden ser anónimas
                if (string.IsNullOrWhiteSpace(txtIdCliente.Text) &&
                    cmbTipoEncuesta.SelectedItem.ToString().Trim().Normalize(NormalizationForm.FormD) != "Satisfacción".Normalize(NormalizationForm.FormD))
                {
                    MessageBox.Show("⚠️ Solo las encuestas de satisfacción pueden ser anónimas.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return; // El return previene la ejecución si la validación falla
                }

                // Validación para permitir que el ID de Cliente sea nulo solo si es una encuesta anónima
                int? idCliente = null;  // Usamos tipo int? para permitir valores nulos
                if (!string.IsNullOrWhiteSpace(txtIdCliente.Text))
                {
                    idCliente = Convert.ToInt32(txtIdCliente.Text);  // Asignamos el IdCliente si no es nulo
                }

                // Creación del objeto Encuestas con los datos del formulario
                Encuestas encuesta = new Encuestas()
                {
                    IdCliente = idCliente,  // Asignamos el valor null o el valor de cliente
                    IdServicio = Convert.ToInt32(txtServicio.Text),
                    Comentarios = string.IsNullOrWhiteSpace(txtComentarios.Text) ? null : txtComentarios.Text,
                    FechaEncuesta = dtpFechaEncuesta.Value,
                    CalificacionEncuesta = Convert.ToInt32(cmbCalificacionEncuesta.SelectedItem),
                    TipoEncuesta = cmbTipoEncuesta.SelectedItem.ToString().Trim(),
                    EstadoEncuesta = cmbEstadoEncuesta.SelectedItem.ToString()
                };

                // Llamada al método para guardar la encuesta en la base de datos
                _conexion.GuardarEncuesta(encuesta);

                // Cerrar encuestas pendientes (si corresponde)
                CerrarEncuestasPendientes();

                // Confirmación de éxito
                MessageBox.Show("✅ Encuesta guardada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Limpiar el formulario
                LimpiarFormulario();

                // Si todo es correcto, cerramos el formulario
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("❌ Error al guardar la encuesta: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void Modificar_Encuesta()
        {
            try
            {
                // Validar que el ID de la encuesta sea válido
                if (string.IsNullOrWhiteSpace(txtIdEncuesta.Text))
                {
                    MessageBox.Show("⚠️ Debe ingresar un ID de encuesta válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Verificar que los campos sean válidos antes de continuar
                if (!Verificar_Campos()) return;

                int idEncuesta = Convert.ToInt32(txtIdEncuesta.Text);
                Encuestas encuestaExistente = _conexion.BuscarPorIdEncuesta(idEncuesta);

                // Verificar si la encuesta existe
                if (encuestaExistente == null)
                {
                    MessageBox.Show("❌ No se encontró ninguna encuesta con el ID ingresado.", "Encuesta no encontrada", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Validar que no se pueda modificar una encuesta completada
                if (encuestaExistente.EstadoEncuesta == "Completada")
                {
                    MessageBox.Show("⚠️ No se pueden modificar encuestas completadas.", "Operación no permitida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Validación para asegurarse de que solo las encuestas de satisfacción pueden ser anónimas
                if (string.IsNullOrWhiteSpace(txtIdCliente.Text) &&
                    encuestaExistente.TipoEncuesta.Trim().Normalize(NormalizationForm.FormD) != "Satisfacción".Normalize(NormalizationForm.FormD))
                {
                    MessageBox.Show("⚠️ Solo las encuestas de satisfacción pueden ser anónimas.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Crear el objeto Encuesta con los datos modificados
                Encuestas encuesta = new Encuestas()
                {
                    IdEncuesta = Convert.ToInt32(txtIdEncuesta.Text),
                    IdCliente = string.IsNullOrWhiteSpace(txtIdCliente.Text) ? (int?)null : Convert.ToInt32(txtIdCliente.Text),
                    IdServicio = Convert.ToInt32(txtServicio.Text),
                    Comentarios = string.IsNullOrWhiteSpace(txtComentarios.Text) ? null : txtComentarios.Text,
                    FechaEncuesta = dtpFechaEncuesta.Value,
                    CalificacionEncuesta = Convert.ToInt32(cmbCalificacionEncuesta.SelectedItem),
                    TipoEncuesta = cmbTipoEncuesta.SelectedItem.ToString(),
                    EstadoEncuesta = cmbEstadoEncuesta.SelectedItem.ToString()
                };

                // Llamada al método para modificar la encuesta en la base de datos
                _conexion.ModificarEncuesta(encuesta);

                // Confirmación de éxito
                MessageBox.Show("✅ Encuesta modificada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Limpiar el formulario
                LimpiarFormulario();
            }
            catch (Exception ex)
            {
                MessageBox.Show("❌ Error al modificar la encuesta: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                // Verificar si los campos son válidos antes de proceder
                if (Verificar_Campos())
                {
                    // Si la operación es "Crear", agregar la nueva encuesta
                    if (_tipoSolicitud.Equals("Crear"))
                    {
                        Agregar_Encuesta(); // Solo agregar la encuesta si la validación pasa

                        // Solo cerramos si la encuesta se agregó correctamente
                        this.Close();  // Cerrar la ventana después de agregar
                    }
                    // Si la operación es "Modificar", modificar la encuesta existente
                    else if (_tipoSolicitud.Equals("Modificar"))
                    {
                        Modificar_Encuesta();
                        this.Close();  // Cerrar la ventana después de modificar
                    }
                }
                else
                {
                    // Si los campos no son válidos, no cerramos la ventana
                    MessageBox.Show("Por favor, corrija los errores antes de continuar.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                // Mostrar mensaje de error si algo sale mal
                MessageBox.Show($"❌ Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CerrarEncuestasPendientes()
        {
            int cerradas = _conexion.CerrarEncuestasPendientes(); // Ahora devuelve un int
            if (cerradas > 0)
            {
                MessageBox.Show($"✅ {cerradas} encuestas pendientes fueron cerradas automáticamente.",
                                "Cierre Automático", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }



    }
}