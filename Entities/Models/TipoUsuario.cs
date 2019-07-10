using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class TipoUsuario
    {
        public byte Id { get; set; }
        public string Nombre { get; set; }
        public bool Deshabilitado { get; set; }

        public override string ToString()
        {
            return Nombre;
        }
    }
}
