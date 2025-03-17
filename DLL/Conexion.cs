using BLL;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace DAL
{
    public class Conexion
    {
        //Objeto para interactuar con el servidor de la Base de Datos
        private string StringConexion;

        //Variable para manejar la referencia para la conexion
        private SqlConnection _connection;

        //Variable para ejecutar transac-sql del lado del servidro de Base de Datos
        private SqlCommand _command;

        //Variable que permite ejecutar transac-sql de consulta
        private SqlDataReader _reader;


        public Conexion(string pStringCnx)
        {
            StringConexion = pStringCnx;
        }

        public void GuardarServicio(Servicios servicio)
        {
            try
            {
                // Se instancia la conexión con la base de datos utilizando la cadena de conexión definida.
                _connection = new SqlConnection(StringConexion);

                // Se abre la conexión a la base de datos.
                _connection.Open();

                // Se instancia el objeto SqlCommand para ejecutar el procedimiento almacenado.
                _command = new SqlCommand();

                // Se asigna la conexión establecida al comando SQL.
                _command.Connection = _connection;

                // Se especifica que el comando es un procedimiento almacenado.
                _command.CommandType = CommandType.StoredProcedure;

                // Se asigna el nombre del procedimiento almacenado que se ejecutará.
                _command.CommandText = "[Sp_Ins_Servicio]";

                _command.Parameters.AddWithValue("@NombreServicio", servicio.NombreServicio);
                _command.Parameters.AddWithValue("@Descripcion", servicio.Descripcion);
                _command.Parameters.AddWithValue("@Precio", servicio.Precio);
                _command.Parameters.AddWithValue("@Duracion", servicio.Duracion);
                _command.Parameters.AddWithValue("@Categoria", servicio.Categoria);
                _command.Parameters.AddWithValue("@Estado", servicio.Estado);
                _command.Parameters.AddWithValue("@FechaCreacion", servicio.FechaCreacion);
                _command.Parameters.AddWithValue("@Foto", servicio.Foto);

                _command.ExecuteNonQuery();
                _connection.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ModificarServicio(Servicios servicio)
        {
            try
            {
                // Se instancia la conexión a la base de datos utilizando la cadena de conexión.
                _connection = new SqlConnection(StringConexion);

                // Se abre la conexión a la base de datos.
                _connection.Open();

                // Se instancia el comando SQL que se ejecutará.
                _command = new SqlCommand();

                // Se asigna la conexión al comando.
                _command.Connection = _connection;

                // Se especifica que el comando es de tipo procedimiento almacenado.
                _command.CommandType = CommandType.StoredProcedure;

                // Se asigna el nombre del procedimiento almacenado que se ejecutará.
                _command.CommandText = "[Sp_Upd_Servicio]";

                _command.Parameters.AddWithValue("@IdServicio", servicio.IdServicio);
                _command.Parameters.AddWithValue("@NombreServicio", servicio.NombreServicio);
                _command.Parameters.AddWithValue("@Descripcion", servicio.Descripcion);
                _command.Parameters.AddWithValue("@Precio", servicio.Precio);
                _command.Parameters.AddWithValue("@Duracion", servicio.Duracion);
                _command.Parameters.AddWithValue("@Categoria", servicio.Categoria);
                _command.Parameters.AddWithValue("@Estado", servicio.Estado);
                _command.Parameters.AddWithValue("@FechaCreacion", servicio.FechaCreacion);
                _command.Parameters.AddWithValue("@Foto", servicio.Foto);

                _command.ExecuteNonQuery();
                _connection.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void EliminarServicio(int idServicio)
        {
            try
            {
                // Se instancia la conexión a la base de datos utilizando la cadena de conexión.
                _connection = new SqlConnection(StringConexion);

                // Se abre la conexión a la base de datos.
                _connection.Open();

                // Se instancia el comando SQL que se ejecutará.
                _command = new SqlCommand();

                // Se asigna la conexión al comando.
                _command.Connection = _connection;

                // Se especifica que el comando es de tipo procedimiento almacenado.
                _command.CommandType = CommandType.StoredProcedure;

                // Se asigna el nombre del procedimiento almacenado que se ejecutará.
                _command.CommandText = "[Sp_Del_Servicio]";
                _command.Parameters.AddWithValue("@IdServicio", idServicio); // Se añade el parámetro del procedimiento almacenado con el valor del email.

                // Se ejecuta el comando (en este caso, no se espera ningún valor de retorno, solo se realiza la eliminación).
                _command.ExecuteNonQuery();

                // Se cierra la conexión con la base de datos una vez se ha ejecutado el procedimiento.
                _connection.Close();

                // Se liberan los recursos de la conexión.
                _connection.Dispose();

                // Se liberan los recursos del comando.
                _command.Dispose();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet BuscarPorNombreServicio(string nombre)
        {
            try
            {
                // Se instancia la conexión a la base de datos utilizando la cadena de conexión.
                _connection = new SqlConnection(StringConexion);

                // Se abre la conexión a la base de datos.
                _connection.Open();

                // Se instancia el comando SQL que se ejecutará.
                _command = new SqlCommand();

                // Se asigna la conexión al comando.
                _command.Connection = _connection;

                // Se especifica que el comando es de tipo procedimiento almacenado.
                _command.CommandType = CommandType.StoredProcedure;

                // Se asigna el nombre del procedimiento almacenado que se ejecutará.
                _command.CommandText = "[Sp_Buscar_Nombre_Servicio]";

                // Se añade el parámetro del procedimiento almacenado con el valor del nombre proporcionado.
                _command.Parameters.AddWithValue("@NombreServicio", nombre);

                // Se instancia un adaptador de datos para llenar el DataSet con los resultados de la consulta.
                SqlDataAdapter adapter = new SqlDataAdapter();
                DataSet datos = new DataSet(); // Se crea un DataSet para almacenar los datos tabulados.

                // Se asigna el comando SQL al adaptador.
                adapter.SelectCommand = _command;

                // Se llena el DataSet con los datos obtenidos por el adaptador.
                adapter.Fill(datos);

                // Se cierra la conexión con la base de datos.
                _connection.Close();

                // Se liberan los recursos de la conexión.
                _connection.Dispose();

                // Se liberan los recursos del comando.
                _command.Dispose();

                // Se liberan los recursos del adaptador.
                adapter.Dispose();

                // Se retorna el conjunto de datos con los resultados de la búsqueda.
                return datos;
            }
            catch (Exception ex)
            {
                // Si ocurre una excepción, se vuelve a lanzar para ser manejada por el llamador.
                throw ex;
            }
        }

        public Servicios BuscarPorIdServicio(int idServicio)
        {
            try
            {
                _connection = new SqlConnection(StringConexion);
                _connection.Open();
                _command = new SqlCommand("[Sp_Buscar_Id_Servicio]", _connection);
                _command.CommandType = CommandType.StoredProcedure;
                _command.Parameters.AddWithValue("@IdServicio", idServicio);

                _reader = _command.ExecuteReader();
                Servicios temp = null;

                if (_reader.Read())
                {
                    temp = new Servicios()
                    {
                        IdServicio = Convert.ToInt32(_reader["IdServicio"]),
                        NombreServicio = _reader["NombreServicio"].ToString(),
                        Descripcion = _reader["Descripcion"].ToString(),
                        Precio = Convert.ToDecimal(_reader["Precio"]),
                        Duracion = Convert.ToInt32(_reader["Duracion"]),
                        Categoria = _reader["Categoria"].ToString(),
                        Estado = _reader["Estado"].ToString(),
                        FechaCreacion = Convert.ToDateTime(_reader["FechaCreacion"]),
                        Foto = _reader["Foto"].ToString()
                    };
                }

                _connection.Close();
                return temp;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //Conexion para cliente 


        public void GuardarCliente(Clientes cliente)
            {
                try
                {
                    _connection = new SqlConnection(StringConexion);
                    _connection.Open();

                    _command = new SqlCommand();
                    _command.Connection = _connection;
                    _command.CommandType = CommandType.StoredProcedure;
                    _command.CommandText = "[Sp_Ins_Cliente]"; // Procedimiento almacenado para insertar un cliente.

                    _command.Parameters.AddWithValue("@NombreCompleto", cliente.NombreCompleto);
                    _command.Parameters.AddWithValue("@FechaNacimiento", cliente.FechaNacimiento);
                    _command.Parameters.AddWithValue("@CorreoElectronico", cliente.CorreoElectronico);
                    _command.Parameters.AddWithValue("@Telefono", cliente.Telefono);
                    _command.Parameters.AddWithValue("@Direccion", cliente.Direccion);
                    _command.Parameters.AddWithValue("@FechaRegistro", cliente.FechaRegistro);
                    _command.Parameters.AddWithValue("@EstadoCuenta", cliente.EstadoCuenta);
                    _command.Parameters.AddWithValue("@Foto", cliente.Foto);

                    _command.ExecuteNonQuery();
                    _connection.Close();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            public void ModificarCliente(Clientes cliente)
            {
                try
                {
                    _connection = new SqlConnection(StringConexion);
                    _connection.Open();

                    _command = new SqlCommand();
                    _command.Connection = _connection;
                    _command.CommandType = CommandType.StoredProcedure;
                    _command.CommandText = "[Sp_Upd_Cliente]"; // Procedimiento almacenado para actualizar un cliente.

                    _command.Parameters.AddWithValue("@IdCliente", cliente.IdCliente);
                    _command.Parameters.AddWithValue("@NombreCompleto", cliente.NombreCompleto);
                    _command.Parameters.AddWithValue("@FechaNacimiento", cliente.FechaNacimiento);
                    _command.Parameters.AddWithValue("@CorreoElectronico", cliente.CorreoElectronico);
                    _command.Parameters.AddWithValue("@Telefono", cliente.Telefono);
                    _command.Parameters.AddWithValue("@Direccion", cliente.Direccion);
                    _command.Parameters.AddWithValue("@FechaRegistro", cliente.FechaRegistro);
                    _command.Parameters.AddWithValue("@EstadoCuenta", cliente.EstadoCuenta);
                    _command.Parameters.AddWithValue("@Foto", cliente.Foto);

                    _command.ExecuteNonQuery();
                    _connection.Close();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            public void EliminarCliente(int idCliente)
            {
                try
                {
                    _connection = new SqlConnection(StringConexion);
                    _connection.Open();

                    _command = new SqlCommand();
                    _command.Connection = _connection;
                    _command.CommandType = CommandType.StoredProcedure;
                    _command.CommandText = "[Sp_Del_Cliente]"; // Procedimiento almacenado para eliminar un cliente.
                    _command.Parameters.AddWithValue("@IdCliente", idCliente);

                    _command.ExecuteNonQuery();
                    _connection.Close();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            public DataSet BuscarPorNombreCliente(string nombre)
            {
                try
                {
                    _connection = new SqlConnection(StringConexion);
                    _connection.Open();

                    _command = new SqlCommand();
                    _command.Connection = _connection;
                    _command.CommandType = CommandType.StoredProcedure;
                    _command.CommandText = "[Sp_Buscar_Nombre_Clientes]"; // Procedimiento almacenado para buscar clientes por nombre.

                    _command.Parameters.AddWithValue("@NombreCompleto", nombre);

                    SqlDataAdapter adapter = new SqlDataAdapter();
                    DataSet datos = new DataSet();

                    adapter.SelectCommand = _command;
                    adapter.Fill(datos);

                    _connection.Close();
                    return datos;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

        public Clientes BuscarPorIdCliente(int idCliente)
        {
            try
            {
                _connection = new SqlConnection(StringConexion);
                _connection.Open();
                _command = new SqlCommand("[Sp_Buscar_Id_Cliente]", _connection);
                _command.CommandType = CommandType.StoredProcedure;
                _command.Parameters.AddWithValue("@IdCliente", idCliente);

                _reader = _command.ExecuteReader();
                Clientes temp = null;

                if (_reader.Read())
                {
                    temp = new Clientes()
                    {
                        IdCliente = Convert.ToInt32(_reader["IdCliente"]),
                        NombreCompleto = _reader["NombreCompleto"].ToString(),
                        CorreoElectronico = _reader["CorreoElectronico"].ToString(),
                        EstadoCuenta = _reader["EstadoCuenta"].ToString(),
                        Telefono = _reader["Telefono"].ToString(),
                        Direccion = _reader["Direccion"].ToString(),
                        FechaNacimiento = Convert.ToDateTime(_reader["FechaNacimiento"]),
                        FechaRegistro = Convert.ToDateTime(_reader["FechaRegistro"]),
                        Foto = _reader["Foto"].ToString()
                    };
                }

                _connection.Close();
                return temp;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public Clientes BuscarClientePorDatos(string nombre, string correo, string telefono)
        {
            try
            {
                string query = "SELECT * FROM Clientes WHERE NombreCompleto = @Nombre OR CorreoElectronico = @Correo OR Telefono = @Telefono";

                using (SqlConnection conn = new SqlConnection(StringConexion))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Nombre", nombre);
                        cmd.Parameters.AddWithValue("@Correo", correo);
                        cmd.Parameters.AddWithValue("@Telefono", telefono);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new Clientes
                                {
                                    IdCliente = Convert.ToInt32(reader["IdCliente"]),
                                    NombreCompleto = reader["NombreCompleto"].ToString(),
                                    CorreoElectronico = reader["CorreoElectronico"].ToString(),
                                    Telefono = reader["Telefono"].ToString(),
                                    Direccion = reader["Direccion"].ToString(),
                                    EstadoCuenta = reader["EstadoCuenta"].ToString(),
                                    FechaRegistro = Convert.ToDateTime(reader["FechaRegistro"]),
                                    FechaNacimiento = Convert.ToDateTime(reader["FechaNacimiento"]),
                                    Foto = reader["Foto"].ToString()
                                };
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al buscar cliente por datos: " + ex.Message, ex);
            }

            return null;
        }


        /// <summary>
        /// Verifica el estado de la cuenta de un cliente por su ID.
        /// </summary>
        /// <param name="idCliente">ID del cliente a verificar.</param>
        /// <returns>El estado de la cuenta del cliente.</returns>
        public bool ClienteEsActivo(int idCliente)
        {
            try
            {
                using (SqlConnection _connection = new SqlConnection(StringConexion))
                {
                    _connection.Open();
                    using (SqlCommand _command = new SqlCommand("SELECT EstadoCuenta FROM Clientes WHERE IdCliente = @IdCliente", _connection))
                    {
                        _command.Parameters.AddWithValue("@IdCliente", idCliente);

                        object result = _command.ExecuteScalar();
                        return result != null && result.ToString() == "Activo";
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al verificar el estado del cliente: " + ex.Message, ex);
            }
        }


        /// <summary>
        /// Verifica si el correo electrónico ya está registrado en la base de datos.
        /// </summary>
        /// <param name="correoElectronico">El correo electrónico que se desea verificar.</param>
        /// <returns>True si el correo electrónico ya existe, de lo contrario, false.</returns>
        





        // Método para guardar una nueva encuesta en la base de datos
        public void GuardarEncuesta(Encuestas encuesta)
        {
            try
            {
                _connection = new SqlConnection(StringConexion);

                _connection.Open();

                _command = new SqlCommand();

                _command.Connection = _connection;

                _command.CommandType = CommandType.StoredProcedure;

                _command.CommandText = "[Sp_Ins_Encuesta]";

                // Parámetros del procedimiento almacenado
                _command.Parameters.AddWithValue("@IdCliente", (object)encuesta.IdCliente ?? DBNull.Value);
                _command.Parameters.AddWithValue("@IdServicio", encuesta.IdServicio);
                _command.Parameters.AddWithValue("@Comentarios", (object)encuesta.Comentarios ?? DBNull.Value);
                _command.Parameters.AddWithValue("@FechaEncuesta", encuesta.FechaEncuesta);
                _command.Parameters.AddWithValue("@CalificacionEncuesta", encuesta.CalificacionEncuesta);
                _command.Parameters.AddWithValue("@TipoEncuesta", encuesta.TipoEncuesta);
                _command.Parameters.AddWithValue("@EstadoEncuesta", encuesta.EstadoEncuesta);

                _command.ExecuteNonQuery();

                _connection.Close();

                _connection.Dispose();

                _command.Dispose();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // Método para modificar una encuesta existente en la base de datos
        public void ModificarEncuesta(Encuestas encuesta)
        {
            try
            {
                _connection = new SqlConnection(StringConexion);

                _connection.Open();

                _command = new SqlCommand();

                _command.Connection = _connection;

                _command.CommandType = CommandType.StoredProcedure;

                _command.CommandText = "[Sp_Upd_Encuesta]";

                // Parámetros del procedimiento almacenado
                _command.Parameters.AddWithValue("@IdEncuesta", encuesta.IdEncuesta);
                _command.Parameters.AddWithValue("@IdCliente", (object)encuesta.IdCliente ?? DBNull.Value);
                _command.Parameters.AddWithValue("@IdServicio", encuesta.IdServicio);
                _command.Parameters.AddWithValue("@Comentarios", (object)encuesta.Comentarios ?? DBNull.Value);
                _command.Parameters.AddWithValue("@FechaEncuesta", encuesta.FechaEncuesta);
                _command.Parameters.AddWithValue("@CalificacionEncuesta", encuesta.CalificacionEncuesta);
                _command.Parameters.AddWithValue("@TipoEncuesta", encuesta.TipoEncuesta);
                _command.Parameters.AddWithValue("@EstadoEncuesta", encuesta.EstadoEncuesta);

                _command.ExecuteNonQuery();

                _connection.Close();
                _connection.Dispose();
                _command.Dispose();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // Método para eliminar una encuesta de la base de datos
        public void EliminarEncuesta(int idEncuesta)
        {
            try
            {
                _connection = new SqlConnection(StringConexion);

                _connection.Open();

                _command = new SqlCommand();

                _command.Connection = _connection;

                _command.CommandType = CommandType.StoredProcedure;

                _command.CommandText = "[Sp_Del_Encuesta]";
                _command.Parameters.AddWithValue("@IdEncuesta", idEncuesta);

                _command.ExecuteNonQuery();

                _connection.Close();

                _connection.Dispose();

                _command.Dispose();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // Método para buscar encuestas por Tipo de Encuesta
        public DataSet BuscarPorTipoEncuesta(string tipoEncuesta)
        {
            try
            {
                _connection = new SqlConnection(StringConexion);

                _connection.Open();

                _command = new SqlCommand();

                _command.Connection = _connection;

                _command.CommandType = CommandType.StoredProcedure;

                _command.CommandText = "[Sp_Buscar_TiposEncuestas]";

                _command.Parameters.AddWithValue("@TipoEncuesta", tipoEncuesta);

                SqlDataAdapter adapter = new SqlDataAdapter();
                DataSet datos = new DataSet();

                adapter.SelectCommand = _command;

                adapter.Fill(datos);

                _connection.Close();

                _connection.Dispose();

                _command.Dispose();

                adapter.Dispose();

                return datos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // Método para buscar una encuesta por su ID
        public Encuestas BuscarPorIdEncuesta(int idEncuesta)
        {
            try
            {
                // Se instancia la conexión a la base de datos utilizando la cadena de conexión.
                _connection = new SqlConnection(StringConexion);

                // Se abre la conexión a la base de datos.
                _connection.Open();

                // Se instancia el comando SQL que se ejecutará.
                _command = new SqlCommand();

                // Se asigna la conexión al comando.
                _command.Connection = _connection;

                // Se especifica que el comando es de tipo procedimiento almacenado.
                _command.CommandType = CommandType.StoredProcedure;

                // Se asigna el nombre del procedimiento almacenado que se ejecutará.
                _command.CommandText = "[Sp_Buscar_IdEncuesta]";

                // Se añade el parámetro del procedimiento almacenado con el valor del ID proporcionado.
                _command.Parameters.AddWithValue("@IdEncuesta", idEncuesta);

                // Se ejecuta el comando y se obtiene un lector para procesar los resultados de la consulta
                _reader = _command.ExecuteReader();

                // Variable para almacenar los datos obtenidos de la base de datos
                Encuestas temp = null;

                // Se verifica si el lector tiene resultados, es decir, si se encontró una encuesta que coincida
                if (_reader.Read())
                {
                    // Si se encontró la encuesta, se crea un objeto Encuesta y se llenan sus propiedades con los valores obtenidos
                    temp = new Encuestas();

                    temp.IdEncuesta = Convert.ToInt32(_reader["IdEncuesta"]);

                    // Verificación para el IdCliente: Si es DBNull, asigna null, si no, asigna el valor de la base de datos
                    temp.IdCliente = _reader.IsDBNull(_reader.GetOrdinal("IdCliente")) ? (int?)null : Convert.ToInt32(_reader["IdCliente"]);

                    temp.IdServicio = Convert.ToInt32(_reader["IdServicio"]);
                    temp.Comentarios = _reader["Comentarios"].ToString();
                    temp.FechaEncuesta = Convert.ToDateTime(_reader["FechaEncuesta"]);
                    temp.CalificacionEncuesta = Convert.ToInt32(_reader["CalificacionEncuesta"]);
                    temp.TipoEncuesta = _reader["TipoEncuesta"].ToString();
                    temp.EstadoEncuesta = _reader["EstadoEncuesta"].ToString();
                }

                // Se cierra la conexión a la base de datos
                _connection.Close();

                // Se liberan los recursos asociados a la conexión y el comando
                _connection.Dispose();
                _command.Dispose();

                // Se retorna el objeto Encuesta con los datos obtenidos o null si no se encontró
                return temp;
            }
            catch (Exception ex)
            {
                // Si ocurre una excepción, se vuelve a lanzar para ser manejada por el llamador.
                throw ex;
            }
        }

        public int CerrarEncuestasPendientes()
        {
            try
            {
                using (SqlConnection _connection = new SqlConnection(StringConexion))
                {
                    _connection.Open();
                    using (SqlCommand _command = new SqlCommand("[Sp_Cerrar_EncuestasPendientes]", _connection))
                    {
                        _command.CommandType = CommandType.StoredProcedure;

                        // Ejecutar el procedimiento almacenado y obtener el número de filas afectadas
                        var result = _command.ExecuteScalar();
                        return Convert.ToInt32(result); // Convertir el valor de @@ROWCOUNT a int
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al cerrar encuestas pendientes: " + ex.Message);
            }
        }


        public Encuestas ObtenerUltimaEncuestaPorCliente(int idCliente)
        {
            _connection.Open();
            // Realizar la consulta para obtener la última encuesta asociada al cliente
            string query = "SELECT TOP 1 * FROM Encuestas WHERE IdCliente = @idCliente ORDER BY FechaEncuesta DESC";
            using (SqlCommand cmd = new SqlCommand(query, _connection))
            {
                cmd.Parameters.AddWithValue("@idCliente", idCliente);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Encuestas
                        {
                            IdCliente = Convert.ToInt32(reader["IdCliente"]),
                            FechaEncuesta = Convert.ToDateTime(reader["FechaEncuesta"]),
                            // Otros campos necesarios de la encuesta
                        };
                    }
                }
            }
            return null;  // Si no encuentra ninguna encuesta
        }

        public bool ClienteDuplicado(string nombreCompleto, string telefono, string correoElectronico)
        {
            try
            {
                using (SqlConnection _connection = new SqlConnection(StringConexion))
                {
                    _connection.Open();

                    // Consulta SQL para verificar si ya existe un cliente con los mismos datos (nombre, teléfono o correo)
                    string query = @"
                SELECT COUNT(1) 
                FROM Clientes 
                WHERE NombreCompleto = @nombreCompleto 
                   OR Telefono = @telefono 
                   OR CorreoElectronico = @correoElectronico";

                    using (SqlCommand _command = new SqlCommand(query, _connection))
                    {
                        // Agregar los parámetros de la consulta
                        _command.Parameters.AddWithValue("@nombreCompleto", nombreCompleto);
                        _command.Parameters.AddWithValue("@telefono", telefono);
                        _command.Parameters.AddWithValue("@correoElectronico", correoElectronico);

                        // Ejecutar la consulta y verificar si ya existe un cliente con estos datos
                        int existe = (int)_command.ExecuteScalar();
                        return existe > 0; // Si existe un duplicado, retorna true
                    }
                }
            }
            catch (Exception ex)
            {
                // Lanza una excepción detallada si ocurre un error
                throw new Exception("Error al verificar duplicados del cliente: " + ex.Message, ex);
            }
        }

        public void VerificarClientesInactivos()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(StringConexion))
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand("VerificarClientesInactivos", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al verificar los clientes: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



    }
}
