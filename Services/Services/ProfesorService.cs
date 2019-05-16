using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace Services.Services
{
    public class ProfesorService
    {
        public List<Profesor> GetAll()
        {
            List<Profesor> listado = new List<Profesor>();
            DataAccessManager accesoDatos = new DataAccessManager();
            try
            {
                accesoDatos.setearConsulta("SELECT * FROM TB_PROFESORES");
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

        public Profesor GetById(long id)
        {
            Profesor profesor = new Profesor();
            DataAccessManager accesoDatos = new DataAccessManager();
            try
            {
                accesoDatos.setearConsulta("SELECT * FROM TB_PROFESORES WHERE CD_PROFESOR = @Id");
                accesoDatos.Comando.Parameters.Clear();
                accesoDatos.Comando.Parameters.AddWithValue("@Id", id);
                accesoDatos.abrirConexion();
                accesoDatos.ejecutarConsulta();
                while (accesoDatos.Lector.Read())
                {
                    profesor = Make(accesoDatos.Lector, true);
                }

                return profesor;
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

        public void InsertProfesor(Profesor nuevo)
        {
            DataAccessManager accesoDatos = new DataAccessManager();
            try
            {
                accesoDatos.setearConsulta("INSERT INTO TB_PROFESOR (APELLIDO, NOMBRE, FECHA_NAC, FECHA_INGRESO) " +
                    "values('" + nuevo.Apellido + "', '" + nuevo.Nombre + "', '" + nuevo.FechaNac + "', '" + nuevo.FechaIngreso + "')");
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

        public void UpdateProfesor(Profesor modificar)
        {
            DataAccessManager accesoDatos = new DataAccessManager();
            try
            {
                accesoDatos.setearConsulta("UPDATE TB_PROFESORES SET APELLIDO=@Apellido, NOMBRE=@Nombre, " +
                    "FECHA_NAC=@FechaNac, FECHA_INGRESO=@FechaIngreso Where CD_ALUMNO=" + modificar.Id.ToString());
                accesoDatos.Comando.Parameters.Clear();
                accesoDatos.Comando.Parameters.AddWithValue("@Apellido", modificar.Apellido);
                accesoDatos.Comando.Parameters.AddWithValue("@Nombre", modificar.Nombre);
                accesoDatos.Comando.Parameters.AddWithValue("@FechaNac", modificar.FechaNac);
                accesoDatos.Comando.Parameters.AddWithValue("@FechaIngreso", modificar.FechaIngreso);
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

        private Profesor Make(SqlDataReader lector, bool complete)
        {
            Profesor entidad = new Profesor();
            entidad.Id = (int)lector["CD_PROFESOR"];
            entidad.Apellido = (string)lector["APELLIDO"];
            entidad.Nombre = (string)lector["NOMBRE"];
            entidad.FechaNac = (DateTime)lector["FECHA_NAC"];
            entidad.FechaIngreso = (DateTime)lector["FECHA_INGRESO"];

            if (complete) { }

            return entidad;
        }
    }
}
