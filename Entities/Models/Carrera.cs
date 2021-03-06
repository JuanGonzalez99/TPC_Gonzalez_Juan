﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Carrera
    {
        public short Id { get; set; }
        public string Nombre { get; set; }
        public string NombreCorto { get; set; }
        public byte Duracion { get; set; }
        public List<Materia> Materias { get; set; }
        public bool Deshabilitado { get; set; }

        public override string ToString()
        {
            return Nombre;
        }
    }
}
