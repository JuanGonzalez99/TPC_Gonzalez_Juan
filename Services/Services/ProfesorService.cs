using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Models;

namespace AccesoDatos.Services
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

        public Profesor GetById(int id, bool complete = false)
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
                    profesor = Make(accesoDatos.Lector, complete);
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


        public void Insert(Profesor nuevo)
        {
            DataAccessManager accesoDatos = new DataAccessManager();
            try
            {
                accesoDatos.setearConsulta("SET DATEFORMAT 'DMY' " +
                    "INSERT INTO TB_PROFESORES (DNI, APELLIDO, NOMBRE, FECHA_NAC, FECHA_INGRESO) " +
                    "values(@DNI, @Apellido, @Nombre, @FechaNac, @FechaIngreso)");
                accesoDatos.Comando.Parameters.Clear();
                accesoDatos.Comando.Parameters.AddWithValue("@DNI", nuevo.DNI);
                accesoDatos.Comando.Parameters.AddWithValue("@Apellido", nuevo.Apellido);
                accesoDatos.Comando.Parameters.AddWithValue("@Nombre", nuevo.Nombre);
                accesoDatos.Comando.Parameters.AddWithValue("@FechaNac", nuevo.FechaNac.ToShortDateString());
                accesoDatos.Comando.Parameters.AddWithValue("@FechaIngreso", nuevo.FechaIngreso.ToShortDateString());
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

        public void Update(Profesor modificar)
        {
            DataAccessManager accesoDatos = new DataAccessManager();
            try
            {
                accesoDatos.setearConsulta("SET DATEFORMAT 'DMY' " +
                    "UPDATE TB_PROFESORES SET " +
                    "DNI = @DNI, " +
                    "APELLIDO = @Apellido, " +
                    "NOMBRE = @Nombre, " +
                    "FECHA_NAC = @FechaNac, " +
                    "FECHA_INGRESO = @FechaIngreso " +
                "Where CD_PROFESOR = @Id");
                accesoDatos.Comando.Parameters.Clear();
                accesoDatos.Comando.Parameters.AddWithValue("@Id", modificar.Id);
                accesoDatos.Comando.Parameters.AddWithValue("@DNI", modificar.DNI);
                accesoDatos.Comando.Parameters.AddWithValue("@Apellido", modificar.Apellido);
                accesoDatos.Comando.Parameters.AddWithValue("@Nombre", modificar.Nombre);
                accesoDatos.Comando.Parameters.AddWithValue("@FechaNac", modificar.FechaNac.ToShortDateString());
                accesoDatos.Comando.Parameters.AddWithValue("@FechaIngreso", modificar.FechaIngreso.ToShortDateString());
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

        public void Delete(int id)
        {
            DataAccessManager accesoDatos = new DataAccessManager();
            try
            {
                accesoDatos.setearConsulta("UPDATE TB_PROFESORES " +
                    "SET DESHABILITADO = 1 WHERE CD_PROFESOR = " + id.ToString());
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
            entidad.DNI = (string)lector["DNI"];
            entidad.Apellido = (string)lector["APELLIDO"];
            entidad.Nombre = (string)lector["NOMBRE"];
            entidad.FechaNac = (DateTime)lector["FECHA_NAC"];
            entidad.FechaIngreso = (DateTime)lector["FECHA_INGRESO"];
            entidad.Deshabilitado = (bool)lector["DESHABILITADO"];

            if (complete) { }

            return entidad;
        }
    }
}
