﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Materia
    {
        public long Id { get; set; }
        public string Nombre { get; set; }
        public Carrera Carrera { get; set; }
        public Profesor Profesor { get; set; }
        public Profesor Ayudante { get; set; }
        public short Año { get; set; }
        public byte Cuatrimestre { get; set; }
        public bool Deshabilitado { get; set; }
        public DateTime FechaDeshabilitado { get; set; }
    }
}
