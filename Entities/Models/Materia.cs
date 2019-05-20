using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Materia
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public Carrera Carrera { get; set; }
        public byte Año { get; set; }
        public byte? Cuatrimestre { get; set; }

        public override string ToString()
        {
            return Nombre;
        }
    }
}
