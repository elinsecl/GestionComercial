using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Clientes
    {
        public int IdCliente { get; set; }

        public string NombreCompleto { get; set; }
        public string CorreoElectronico { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public string EstadoCuenta { get; set; }
        public string Foto { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public DateTime FechaRegistro { get; set; }
        public ICollection<Encuestas> Encuestas { get; set; }
    }
}
