using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Modalidad
    {
        public byte Id { get; set; }
        public string Descripcion { get; set; }
        public bool Deshabilitado { get; set; }

        public override string ToString()
        {
            return Descripcion;
        }
    }
}
