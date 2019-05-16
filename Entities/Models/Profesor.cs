using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Profesor : Persona
    {
        public int Id { get; set; }
        public DateTime FechaIngreso { get; set; }
        public List<Materia> Materias { get; set; }
    }
}
