using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Nota
    {
        public long Id { get; set; }
        public byte NotaNumerica { get; set; }
        public string Comentarios { get; set; }
        public bool Deshabilitado { get; set; }
    }
}
