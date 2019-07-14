using Entities.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Horario
    {
        public int Id { get; set; }

        public TimeSpan HoraInicio { get; set; }
        public TimeSpan HoraFin { get; set; }

        public DiaDeLaSemana DiaSemana { get; set; }
        public bool Deshabilitado { get; set; }

        public override string ToString()
        {
            return DiaSemana.ToString() + " - " + HoraInicio.ToString() + " a " + HoraFin.ToString();
        }
    }
}
