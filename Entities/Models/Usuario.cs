using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Usuario
    {
        public long Id { get; set; }
        public string Nombre { get; set; }
        public string Contraseña { get; set; }
        public TipoUsuario TipoUsuario { get; set; }
        public bool Deshabilitado { get; set; }

        public override string ToString()
        {
            return Nombre + " - " + TipoUsuario;
        }
    }

    public class UsuarioAlumno
    {
        public Alumno Alumno { get; set; }
        public Usuario Usuario { get; set; }
    }

    public class UsuarioProfesor
    {
        public Profesor Profesor { get; set; }
        public Usuario Usuario { get; set; }
    }
}
