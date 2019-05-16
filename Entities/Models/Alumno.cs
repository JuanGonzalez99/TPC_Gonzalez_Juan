using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Alumno : Persona
    {
        public int Id { get; set; }
        public List<Materia> Materias { get; set; }
    }
}
