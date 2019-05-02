using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Evaluacion
    {
        public long ID { get; set; }
        public DateTime Fecha { get; set; }
        public Calificacion Calificacion { get; set; }
    }
}
