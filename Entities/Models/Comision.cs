using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Comision
    {
        public long Id { get; set; }
        public Materia Materia { get; set; }
        public int Año { get; set; }
        public byte? Cuatrimestre { get; set; }
        public Turno Turno { get; set; }
        public Modalidad Modalidad { get; set; }
        public Profesor Profesor { get; set; }
        public Profesor Ayudante { get; set; }
        public bool Deshabilitado { get; set; }

        public List<Horario> Horarios { get; set; }

        public override string ToString()
        {
            return Materia.Nombre + " " + Año.ToString() + (Cuatrimestre == null ? "" : " " + Cuatrimestre.ToString() + "C");
        }
    }
}
