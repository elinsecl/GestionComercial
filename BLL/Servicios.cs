using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Servicios
    {
        public int IdServicio { get; set; }

        public string NombreServicio { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public int Duracion { get; set; }
        public string Categoria { get; set; }
        public string Estado { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string Foto { get; set; }

        public ICollection<Encuestas> Encuestas { get; set; }
    }
}
