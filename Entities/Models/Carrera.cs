using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Carrera
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public byte Duracion { get; set; }
        public List<Materia> Materias { get; set; }
        public bool Deshabilitado { get; set; }
        public DateTime FechaDeshabilitado { get; set; }
    }
}
