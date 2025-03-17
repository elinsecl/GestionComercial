using BLL;
using DAL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Reflection.Emit;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Centro_Comercial
{
    public partial class FrmGestionClientes : Form
    {
        private Conexion _conexion = null;
        private Clientes _cliente; // Datos del cliente
        private readonly string _tipoSolicitud; // Tipo de operación (Solicitar, Modificar, Perfil)
        private readonly int _idCliente;

        public FrmGestionClientes(string tipoSolicitud, int idCliente)
        {
            InitializeComponent();
            _conexion = new Conexion(ConfigurationManager.ConnectionStrings["StringConexion"].ConnectionString);
            CargarCombo();

            this._tipoSolicitud = tipoSolicitud;
            this._idCliente = idCliente;

            txtIdCliente.Enabled = false;
            txtIdCliente.Visible = false;
            labelId.Visible = false;
            _cliente = new Clientes();

            Comprobar_Tipo_Solicitud();
        }

        private void CargarCombo()
        {
            cmbEstado.Items.Add("Activo");
            cmbEstado.Items.Add("Inactivo");
            cmbEstado.Items.Add("Suspendido");
        }

        private void LimpiarFormulario()
        {
            txtIdCliente.Clear();
            txtNombreCompleto.Clear();
            txtCorreoElectronico.Clear();
            txtTelefono.Clear();
            txtDireccion.Clear();
            cmbEstado.SelectedIndex = -1;
            dtpFechaRegistro.Value = DateTime.Now;
            dtpFechaNacimiento.Value = DateTime.Now;
            pbFoto.Image = null;
        }

        public void Comprobar_Tipo_Solicitud()
        {
            switch (_tipoSolicitud)
            {
                case "Modificar":
                    llenar_Datos_Cliente();
                    txtIdCliente.Visible = true;
                    txtCorreoElectronico.Enabled = false;
                    labelId.Visible = true;
                    dtpFechaRegistro.Enabled = false;

                    break;
            }
        }

        public void llenar_Datos_Cliente()
        {
            try
            {
                _cliente = _conexion.BuscarPorIdCliente(_idCliente);

                if (_idCliente <= 0) // Suponiendo que _idUsuario es un int
                {
                    MessageBox.Show("El ID del cliente no puede ser cero o negativo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (_cliente != null && _idCliente > 0)
                {
                    txtIdCliente.Text = _cliente.IdCliente.ToString();
                    txtNombreCompleto.Text = _cliente.NombreCompleto;
                    txtCorreoElectronico.Text = _cliente.CorreoElectronico;
                    txtTelefono.Text = _cliente.Telefono;
                    txtDireccion.Text = _cliente.Direccion;
                    cmbEstado.SelectedItem = _cliente.EstadoCuenta;
                    dtpFechaRegistro.Value = _cliente.FechaRegistro;
                    dtpFechaNacimiento.Value = _cliente.FechaNacimiento;

                    if (!string.IsNullOrEmpty(_cliente.Foto))
                    {
                        pbFoto.Image = Image.FromFile(_cliente.Foto);
                    }
                }
                else
                {
                    MessageBox.Show("Cliente no encontrado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al buscar el cliente: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool Verificar_Campos()
        {
            List<string> mensajesError = new List<string>();

            // Verificar el nombre completo
            if (string.IsNullOrWhiteSpace(txtNombreCompleto.Text))
                mensajesError.Add("⚠️ El Nombre Completo es obligatorio.");
            else if (txtNombreCompleto.Text.Length < 3)
                mensajesError.Add("⚠️ El Nombre Completo debe tener al menos 3 caracteres.");
            else if (Regex.IsMatch(txtNombreCompleto.Text, @"\s{2,}"))  // Verificar si hay espacios consecutivos
                mensajesError.Add("⚠️ El Nombre Completo no puede contener espacios consecutivos.");

            // Verificar el correo electrónico
            if (string.IsNullOrWhiteSpace(txtCorreoElectronico.Text))
                mensajesError.Add("⚠️ El Correo Electrónico es obligatorio.");
            else if (!Regex.IsMatch(txtCorreoElectronico.Text, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                mensajesError.Add("⚠️ El Correo Electrónico ingresado no es válido.");

            // Verificar el teléfono
            if (string.IsNullOrWhiteSpace(txtTelefono.Text))
                mensajesError.Add("⚠️ El Teléfono es obligatorio.");
            else if (!Regex.IsMatch(txtTelefono.Text, @"^\+\d{1,4} \d{7,10}$"))
                mensajesError.Add("⚠️ El Teléfono debe tener el formato '+Código de país + número'. Ejemplo +506 70707070");

            // Verificar si ya existe un cliente con el mismo nombre, correo o teléfono
            if (_tipoSolicitud == "Crear" )
            {
                // Llamamos al método ClienteDuplicado para verificar si los datos están duplicados
                if (_conexion.ClienteDuplicado(txtNombreCompleto.Text, txtTelefono.Text, txtCorreoElectronico.Text))
                {
                    mensajesError.Add("⚠️ Ya existe un cliente con el mismo nombre completo, número de teléfono o correo electrónico. Por favor Actualice los registros");
                    
                }
            }

            

            // Verificar el estado de cuenta
            if (cmbEstado.SelectedIndex == -1)
                mensajesError.Add("⚠️ El Estado de Cuenta es obligatorio.");

            // Verificar la foto
            if (pbFoto.Image == null)
                mensajesError.Add("⚠️ Debe seleccionar una imagen.");

            // Verificar la fecha de nacimiento
            if (dtpFechaNacimiento.Value > DateTime.Now)
                mensajesError.Add("⚠️ La Fecha de Nacimiento no puede ser una fecha futura.");
            else if (DateTime.Now.Year - dtpFechaNacimiento.Value.Year < 18)
                mensajesError.Add("⚠️ La persona debe tener al menos 18 años.");

            // Verificar la fecha de registro
            if (dtpFechaRegistro.Value > DateTime.Now)
                mensajesError.Add("⚠️ La Fecha de Registro no puede ser una fecha futura.");
            if (!txtNombreCompleto.Text.Contains(" "))
                mensajesError.Add("⚠️ El Nombre Completo debe contener al menos un espacio entre los nombres.");

            // Si hay errores, mostrar los mensajes y devolver false
            if (mensajesError.Count > 0)
            {
                MessageBox.Show(string.Join("\n", mensajesError), "Error en el formulario", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Si no hay errores, retornar true
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

        public void Agregar_Cliente()
        {
            try
            {
                Clientes cliente = new Clientes()
                {
                    NombreCompleto = txtNombreCompleto.Text,
                    CorreoElectronico = txtCorreoElectronico.Text,
                    Telefono = txtTelefono.Text,
                    Direccion = txtDireccion.Text,
                    EstadoCuenta = cmbEstado.SelectedItem?.ToString() ?? "Activo",
                    FechaRegistro = dtpFechaRegistro.Value,
                    FechaNacimiento = dtpFechaNacimiento.Value,
                    Foto = Guardar_Imagen(pbFoto.Image)
                };

                _conexion.GuardarCliente(cliente);
                MessageBox.Show("✅ Cliente guardado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarFormulario();
            }
            catch (Exception ex)
            {
                MessageBox.Show("❌ Error al guardar el cliente: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void Modificar_Cliente()
        {
            try
            {
                Clientes clienteModificado = new Clientes()
                {
                    IdCliente = Convert.ToInt32(txtIdCliente.Text),
                    NombreCompleto = txtNombreCompleto.Text,
                    CorreoElectronico = txtCorreoElectronico.Text,
                    Telefono = txtTelefono.Text,
                    Direccion = txtDireccion.Text,
                    EstadoCuenta = cmbEstado.SelectedItem?.ToString() ?? "Activo",
                    FechaRegistro = dtpFechaRegistro.Value,
                    FechaNacimiento = dtpFechaNacimiento.Value,
                    Foto = Guardar_Imagen(pbFoto.Image)
                };

                _conexion.ModificarCliente(clienteModificado);

                MessageBox.Show("✅ Cliente modificado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarFormulario();
            }
            catch (Exception ex)
            {
                MessageBox.Show("❌ Error al modificar el cliente: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_Aceptar_Click(object sender, EventArgs e)
        {
            try
            {
                if (Verificar_Campos())
                {
                    if (_tipoSolicitud.Equals("Crear"))
                    {
                        Agregar_Cliente();
                        this.Close();
                    }

                    if (_tipoSolicitud.Equals("Modificar"))
                    {
                        Modificar_Cliente();
                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_Cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBoxSalir_Click(object sender, EventArgs e)
        {
            this.Hide();
        }


    }
}
