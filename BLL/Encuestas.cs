using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Encuestas
    {
        public int IdEncuesta { get; set; }
        public int? IdCliente { get; set; }
        public int IdServicio { get; set; }
        public string Comentarios { get; set; }
        public DateTime FechaEncuesta { get; set; }
        public int CalificacionEncuesta { get; set; }
        public string TipoEncuesta { get; set; }
        public string EstadoEncuesta { get; set; }

        public Servicios Servicios { get; set; }
        public Clientes Clientes { get; set; }

    }
}