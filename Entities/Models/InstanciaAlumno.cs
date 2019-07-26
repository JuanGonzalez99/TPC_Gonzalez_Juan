using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class InstanciaAlumno
    {
        public Instancia Instancia { get; set; }
        public Alumno Alumno { get; set; }
        public string Nota { get; set; }
        public string Comentarios { get; set; }
        public bool Deshabilitado { get; set; }
    }
}
