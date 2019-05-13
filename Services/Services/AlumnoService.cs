using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace Services.Services
{
    public class AlumnoService
    {
        public List<Alumno> GetAll()
        {
            List<Alumno> listado = new List<Alumno>();
            DataAccessManager accesoDatos = new DataAccessManager();
            try
            {
                accesoDatos.setearConsulta("SELECT * FROM TB_ALUMNOS");
                accesoDatos.abrirConexion();
                accesoDatos.ejecutarConsulta();
                while (accesoDatos.Lector.Read())
                {
                    listado.Add(Make(accesoDatos.Lector, false));
                }

                return listado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                accesoDatos.cerrarConexion();
            }
        }

        public Alumno GetById(long id)
        {
            Alumno alumno = new Alumno();
            DataAccessManager accesoDatos = new DataAccessManager();
            try
            {
                accesoDatos.setearConsulta("SELECT * FROM TB_ALUMNOS WHERE CD_PROFESOR = @Id");
                accesoDatos.Comando.Parameters.Clear();
                accesoDatos.Comando.Parameters.AddWithValue("@Id", id);
                accesoDatos.abrirConexion();
                accesoDatos.ejecutarConsulta();
                while (accesoDatos.Lector.Read())
                {
                    alumno = Make(accesoDatos.Lector, true);
                }

                return alumno;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                accesoDatos.cerrarConexion();
            }
        }

        public void InsertAlumno(Alumno nuevo)
        {
            DataAccessManager accesoDatos = new DataAccessManager();
            try
            {
                accesoDatos.setearConsulta("INSERT INTO TB_ALUMNOS (APELLIDO, NOMBRE, FECHA_NAC) " +
                    "values('" + nuevo.Apellido + "', '" + nuevo.Nombre + "', '" + nuevo.FechaNac + "')");
                accesoDatos.abrirConexion();
                accesoDatos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                accesoDatos.cerrarConexion();
            }
        }

        public void UpdateAlumno(Alumno modificar)
        {
            DataAccessManager accesoDatos = new DataAccessManager();
            try
            {
                accesoDatos.setearConsulta("UPDATE TB_ALUMNOS SET APELLIDO=@Apellido, NOMBRE=@Nombre, FECHA_NAC=@FechaNac Where CD_ALUMNO=" + modificar.Id.ToString());
                accesoDatos.Comando.Parameters.Clear();
                accesoDatos.Comando.Parameters.AddWithValue("@Apellido", modificar.Apellido);
                accesoDatos.Comando.Parameters.AddWithValue("@Nombre", modificar.Nombre);
                accesoDatos.Comando.Parameters.AddWithValue("@FechaNac", modificar.FechaNac);
                accesoDatos.abrirConexion();
                accesoDatos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                accesoDatos.cerrarConexion();
            }
        }

        private Alumno Make(SqlDataReader lector, bool complete)
        {
            Alumno entidad = new Alumno
            {
                Id = (long)lector["CD_ALUMNO"],
                Apellido = (string)lector["APELLIDO"],
                Nombre = (string)lector["NOMBRE"],
                FechaNac = (DateTime)lector["FECHA_NAC"]
            };

            if (complete) { }

            return entidad;
        }
    }
}
