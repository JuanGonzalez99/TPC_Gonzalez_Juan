﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Alumno : Persona
    {
        public int Id { get; set; }
        public bool Deshabilitado { get; set; }

        public override string ToString()
        {
            return Apellido + ", " + Nombre;
        }
    }
}
