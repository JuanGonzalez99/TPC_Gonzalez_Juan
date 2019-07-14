using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class AlumnoComision
    {
        public Comision Comision { get; set; }
        public Alumno Alumno { get; set; }
        public EstadoMateria Estado { get; set; }
        public byte? Nota { get; set; }
        public bool Deshabilitado { get; set; }
    }
}
