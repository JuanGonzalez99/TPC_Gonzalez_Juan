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
        public Modalidad Modalidad { get; set; }
        public List<AlumnoComision> Alumnos { get; set; }
        public List<ProfesorComision> Profesores { get; set; }
        public bool Deshabilitado { get; set; }

        public override string ToString()
        {
            return Materia.Nombre + " " + Año.ToString() + (Cuatrimestre == 0 ? "" : " " + Cuatrimestre.ToString() + "C");
        }
    }
}
