using BLL;
using DAL;
using Centro_Comercial;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Reflection.Emit;

namespace Centro_Comercial
{
    public partial class FrmGestionServicios : Form
    {
        private Conexion _conexion = null;
        private Servicios _servicio; // Datos del servicio
        private readonly string _tipoSolicitud; // Tipo de operación (Solicitar, Modificar, Perfil)
        private readonly int _idServicio; 

        public FrmGestionServicios(string tipoSolicitud, int idServicio)
        {
            InitializeComponent();
            _conexion = new Conexion(ConfigurationManager.ConnectionStrings["StringConexion"].ConnectionString);
            CargarCombo();



            this._tipoSolicitud = tipoSolicitud;

            this._idServicio = idServicio;

            txtIdServicio.Enabled = false;
            txtIdServicio.Visible = false;
            labelId.Visible = false;
            _servicio = new Servicios();

            Comprobar_Tipo_Solicitud();
        }

        private void CargarCombo()
        {

            cmbCategoria.Items.Add("Salud");
            cmbCategoria.Items.Add("Entretenimiento");
            cmbCategoria.Items.Add("Estetica");
            cmbEstado.Items.Add("Activo");
            cmbEstado.Items.Add("Inactivo");

        }
        private void LimpiarFormulario()
        {

            txtIdServicio.Clear();
            txtNombreServicio.Clear();
            txtDescripcion.Clear();
            txtPrecio.Clear();
            txtDuracion.Clear();
            cmbEstado.SelectedIndex = -1;
            cmbCategoria.SelectedIndex = -1;
            dtpFechaCreacion.Value = DateTime.Now;
            pbFoto.Image = null;
        }

        public void Comprobar_Tipo_Solicitud()
        {
            // Mostrar el campo de clave y sus controles asociados

            switch (_tipoSolicitud)
            {
                // Verificar si el tipo de solicitud es "Solicitar"


                // Verificar si el tipo de solicitud es "Modificar"
                case "Modificar":
                    // Llenar los datos del usuario para modificación
                    llenar_Datos_Servicio();
                    txtIdServicio.Visible = true;
                    labelId.Visible = true;
                    
                    // Mostrar el campo de Estado y sus controles asociados
                    dtpFechaCreacion.Enabled = false;
                    break;

                    // Verificar si el tipo de solicitud es "Perfil"

            }

        }

        
        public void llenar_Datos_Servicio()
        {

            try
            {


                // Llama al método BuscarPorIdServicio para obtener los detalles del servicio
                _servicio = _conexion.BuscarPorIdServicio(_idServicio);

                if (_idServicio <= 0) // Suponiendo que _idUsuario es un int
                {
                    MessageBox.Show("El ID de servicio no puede ser cero o negativo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }


                if (_servicio != null && _idServicio > 0)
                {
                    // Si se encuentra el servicio, muestra los datos en los controles
                    txtIdServicio.Text = _servicio.IdServicio.ToString();
                    txtNombreServicio.Text = _servicio.NombreServicio;
                    txtDescripcion.Text = _servicio.Descripcion;
                    txtPrecio.Text = _servicio.Precio.ToString();
                    txtDuracion.Text = _servicio.Duracion.ToString();
                    cmbCategoria.SelectedItem = _servicio.Categoria;
                    cmbEstado.SelectedItem = _servicio.Estado;
                    dtpFechaCreacion.Value = _servicio.FechaCreacion;

                    // Si tienes un PictureBox para la foto, puedes cargarla aquí
                    if (!string.IsNullOrEmpty(_servicio.Foto))
                    {
                        pbFoto.Image = Image.FromFile(_servicio.Foto);  // Asume que la ruta de la foto está bien almacenada
                    }
                }
                else
                {
                    MessageBox.Show("Servicio no encontrado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al buscar el servicio: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);


            }
            

        }

        private void pictureBoxSalir_Click(object sender, EventArgs e)
        {
            this.Hide();
        }


        private bool Verificar_Campos()
        {
            List<string> mensajeError = new List<string>();

            // Verificar que los campos de texto no estén vacíos
            if (string.IsNullOrWhiteSpace(txtNombreServicio.Text))
            {
                mensajeError.Add("⚠️ El nombre del servicio es obligatorio.");
            }

            if (string.IsNullOrWhiteSpace(txtDescripcion.Text))
            {
                mensajeError.Add("⚠️ La descripción es obligatoria.");
            }

            if (!decimal.TryParse(txtPrecio.Text, out decimal precio))
            {
                mensajeError.Add("⚠️ Ingrese un precio válido.");
            }

            if (!int.TryParse(txtDuracion.Text, out int duracion))
            {
                mensajeError.Add("⚠️ Ingrese una duración válida.");
            }

            // Validar que la duración no sea mayor a 500 minutos
            if (duracion > 500)
            {
                mensajeError.Add("⚠️ La duración no puede ser mayor a 500 minutos.");
                
            }
            // Verificar que se haya seleccionado una categoría
            if (cmbCategoria.SelectedIndex == -1)
            {
                mensajeError.Add("⚠️ Seleccione una categoría.");
            }

            // Verificar que se haya seleccionado un estado
            if (cmbEstado.SelectedIndex == -1)
            {
                mensajeError.Add("⚠️ Seleccione un estado.");
            }

            // Verificar que la imagen no esté vacía
            if (pbFoto.Image == null)
            {
                mensajeError.Add("⚠️ Debe seleccionar una imagen.");
            }

            // Validación de precio por categoría
            string categoriaSeleccionada = cmbCategoria.SelectedItem?.ToString();
            if (categoriaSeleccionada == "Salud" && precio < 10000.45m)
            {
                mensajeError.Add("⚠️ El precio para 'Salud' no puede ser menor a 10,000.45.");
            }

            if (categoriaSeleccionada == "Entretenimiento" && precio < 4000.86m)
            {
                mensajeError.Add("⚠️ El precio para 'Entretenimiento' no puede ser menor a 4,000.86.");
            }

            if (categoriaSeleccionada == "Estetica" && precio < 50000.97m)
            {
                mensajeError.Add("⚠️ El precio para 'Estética' no puede ser menor a 50,000.97.");
            }

            // Validar la fecha de creación
            if (dtpFechaCreacion.Value > DateTime.Now)
            {
                mensajeError.Add("⚠️ La fecha de creación no puede ser en el futuro.");
            }

            // Mostrar errores si los hay
            if (mensajeError.Count > 0)
            {
                MessageBox.Show("Error de validación:\n\n" + string.Join("\n", mensajeError),
                                "Error en el formulario", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }



        private string Guardar_Imagen(Image imagen)
        {
            if (imagen == null)
            {
                return null;
            }

            try
            {
                string carpetaFotos = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Fotos");

                if (!System.IO.Directory.Exists(carpetaFotos))
                {
                    System.IO.Directory.CreateDirectory(carpetaFotos);
                }

                string ruta = System.IO.Path.Combine(carpetaFotos, $"{Guid.NewGuid()}.png");

                imagen.Save(ruta, System.Drawing.Imaging.ImageFormat.Png);

                return ruta;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al guardar la imagen: " + ex.Message, ex);
            }
        }

        private void pb_Editar_Imag_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Imágenes|*.jpg;*.png;*.bnp";
                openFileDialog.Title = "Seleccionar imagen";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        Image imagenSeleccionada = Image.FromFile(openFileDialog.FileName);

                        Image imagenRedimensionada = Redimensionar_Y_Recortar_Circular(imagenSeleccionada, 50, 50);

                        pbFoto.Image = imagenRedimensionada;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al cargar la imagen: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private Image Redimensionar_Y_Recortar_Circular(Image imagen, int ancho, int alto)
        {
            Bitmap bitmapRedimensionado = new Bitmap(ancho, alto);

            using (Graphics g = Graphics.FromImage(bitmapRedimensionado))
            {
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
                g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;

                using (GraphicsPath path = new GraphicsPath())
                {
                    path.AddEllipse(0, 0, ancho, alto);

                    g.SetClip(path);

                    float ratioImagen = (float)imagen.Width / imagen.Height;
                    float ratioDestino = (float)ancho / alto;

                    RectangleF destino;
                    if (ratioImagen > ratioDestino)
                    {
                        float escala = (float)alto / imagen.Height;
                        float nuevoAncho = imagen.Width * escala;
                        float offsetX = (nuevoAncho - ancho) / 2;
                        destino = new RectangleF(-offsetX, 0, nuevoAncho, alto);
                    }
                    else
                    {
                        float escala = (float)ancho / imagen.Width;
                        float nuevoAlto = imagen.Height * escala;
                        float offsetY = (nuevoAlto - alto) / 2;
                        destino = new RectangleF(0, -offsetY, ancho, nuevoAlto);
                    }

                    g.DrawImage(imagen, destino);
                }
            }
            return bitmapRedimensionado;
        }

        /*private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                MostrarInforme();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }*/


        /*public void MostrarInforme()
        {
            try
            {
                FrmReporte formulario = new FrmReporte();
                // formulario.FormClosed += (s, args) => Buscar("");
                formulario.ShowDialog();
                formulario.Dispose();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }*/
        /*     private void Buscar(string sNombreServicio)
              {
                  try
                  {
                      this.dtgDatos.DataSource = _conexion.BuscarPorNombreServicio(sNombreServicio).Tables[0];
                      this.dtgDatos.AutoResizeColumns();
                      this.dtgDatos.ReadOnly = true;
                  }
                  catch (Exception ex)
                  {

                      throw ex;
                  }
              }*/



        public void Agregar_Servicio()
        {
            try
            {


                


                if (!decimal.TryParse(txtPrecio.Text, out decimal precio))
                {
                    MessageBox.Show("⚠️ Ingrese un precio válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!int.TryParse(txtDuracion.Text, out int duracion))
                {
                    MessageBox.Show("⚠️ Ingrese una duración válida.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                
                Servicios servicio = new Servicios()
                {
                    NombreServicio = txtNombreServicio.Text,
                    Descripcion = txtDescripcion.Text,
                    Precio = precio,
                    Duracion = duracion,
                    Categoria = cmbCategoria.SelectedItem?.ToString(),
                    Estado = cmbEstado.SelectedItem?.ToString() ?? "Activo",
                    FechaCreacion = dtpFechaCreacion.Value,
                    Foto = Guardar_Imagen(pbFoto.Image)
                };

                _conexion.GuardarServicio(servicio);
                MessageBox.Show("✅ Servicio guardado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarFormulario();
            }
            catch (Exception ex)
            {
                MessageBox.Show("❌ Error al guardar el servicio: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        

       

        public void Modificar_Servicio()
        {
            try
            {
                // Verificar que los campos sean válidos antes de continuar
                

                if (!decimal.TryParse(txtPrecio.Text, out decimal precio))
                {
                    MessageBox.Show("⚠️ Ingrese un precio válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!int.TryParse(txtDuracion.Text, out int duracion))
                {
                    MessageBox.Show("⚠️ Ingrese una duración válida.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Obtener los valores modificados del formulario
                Servicios servicioModificado = new Servicios()
                {
                    IdServicio = Convert.ToInt32(txtIdServicio.Text), // Utiliza el ID del servicio
                    NombreServicio = txtNombreServicio.Text,
                    Descripcion = txtDescripcion.Text,
                    Precio = precio,
                    Duracion = duracion,
                    Categoria = cmbCategoria.SelectedItem?.ToString(),
                    Estado = cmbEstado.SelectedItem?.ToString() ?? "Activo", // Valor predeterminado si no se selecciona
                    FechaCreacion = dtpFechaCreacion.Value, // Usar la fecha seleccionada
                    Foto = Guardar_Imagen(pbFoto.Image)
                };

                // Llamar al método para modificar el servicio en la base de datos
                _conexion.ModificarServicio(servicioModificado);

                MessageBox.Show("✅ Servicio modificado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarFormulario(); // Limpiar formulario después de la modificación
            }
            catch (Exception ex)
            {
                MessageBox.Show("❌ Error al modificar el servicio: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btn_Aceptar_Click(object sender, EventArgs e)
        {
            try
            {// Verificar los campos
                if(Verificar_Campos())
                {

                    // Si no hay errores, continuar con la operación
                    if (_tipoSolicitud.Equals("Crear"))
                    {
                        Agregar_Servicio();

                        this.Close();
                    }

                    // Verificar si el tipo de operación es "Modificar" o "Perfil"
                    if (_tipoSolicitud.Equals("Modificar"))
                    {
                        //Modificar el usuario
                        Modificar_Servicio();


                        this.Close();
                    }

                }
                    
                
            }
            catch (Exception ex)
            {
                // Mostrar un mensaje de error si algo sale mal
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




        private void btn_Cancelar_Click(object sender, EventArgs e)
        {

          this.Close();

        }
            
               


    }
}

