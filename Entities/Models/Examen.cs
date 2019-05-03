using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Examen : Evaluacion
    {
        public TipoExamen TipoExamen { get; set; }
    }
}
