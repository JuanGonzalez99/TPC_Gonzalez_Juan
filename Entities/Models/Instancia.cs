using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Instancia
    {
        public long Id { get; set; }
        public Comision Comision { get; set; }
        public string Nombre { get; set; }
        public TipoInstancia Tipo { get; set; }
        public bool Deshabilitado { get; set; }

        public override string ToString()
        {
            return Nombre + " - " + Comision;
        }
    }
}
