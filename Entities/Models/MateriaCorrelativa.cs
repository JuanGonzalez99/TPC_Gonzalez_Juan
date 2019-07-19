using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class MateriaCorrelativa
    {
        public long Id { get; set; }
        public Materia Materia { get; set; }
        public Materia Correlativa { get; set; }
        public EstadoMateria EstadoRequerido { get; set; }
        public bool Deshabilitado { get; set; }

        public override string ToString()
        {
            return Correlativa + " - " + EstadoRequerido;
        }
    }
}
