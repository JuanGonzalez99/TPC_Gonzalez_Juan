using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Profesor : Persona
    {
        public int Id { get; set; }
        public DateTime FechaIngreso { get; set; }
        public bool Deshabilitado { get; set; }

        public override string ToString()
        {
            return (string.IsNullOrEmpty(Apellido) || string.IsNullOrEmpty(Nombre) ? string.Empty : Apellido + ", " + Nombre);
        }
    }
}
