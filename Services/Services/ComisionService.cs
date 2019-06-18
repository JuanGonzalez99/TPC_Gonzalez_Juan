using AccesoDatos;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class ComisionService
    {
        public List<Comision> GetAll()
        {
            List<Comision> listado = new List<Comision>();
            DataAccessManager accesoDatos = new DataAccessManager();
            try
            {
                accesoDatos.setearConsulta("SELECT * FROM TB_COMISIONES");
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

        public Comision GetById(int id)
        {
            Comision comision = new Comision();
            DataAccessManager accesoDatos = new DataAccessManager();
            try
            {
                accesoDatos.setearConsulta("SELECT * FROM TB_COMISIONES WHERE CD_COMISION = @Id");
                accesoDatos.Comando.Parameters.Clear();
                accesoDatos.Comando.Parameters.AddWithValue("@Id", id);
                accesoDatos.abrirConexion();
                accesoDatos.ejecutarConsulta();
                while (accesoDatos.Lector.Read())
                {
                    comision = Make(accesoDatos.Lector, true);
                }

                return comision;
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


        public void Insert(Comision nuevo)
        {
            DataAccessManager accesoDatos = new DataAccessManager();
            try
            {
                accesoDatos.setearConsulta("SET DATEFORMAT 'DMY' INSERT INTO TB_ALUMNOS (APELLIDO, NOMBRE, FECHA_NAC) " +
                    "values (@Apellido, @Nombre, @FechaNac)");
                accesoDatos.Comando.Parameters.Clear();
                //accesoDatos.Comando.Parameters.AddWithValue("@Apellido", nuevo.Apellido);
                //accesoDatos.Comando.Parameters.AddWithValue("@Nombre", nuevo.Nombre);
                //accesoDatos.Comando.Parameters.AddWithValue("@FechaNac", nuevo.FechaNac.ToShortDateString());
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

        public void Update(Comision modificar)
        {
            DataAccessManager accesoDatos = new DataAccessManager();
            try
            {
                accesoDatos.setearConsulta("SET DATEFORMAT 'DMY' UPDATE TB_COMISIONES SET APELLIDO=@Apellido, NOMBRE=@Nombre, FECHA_NAC=@FechaNac Where CD_ALUMNO=" + modificar.Id.ToString());
                accesoDatos.Comando.Parameters.Clear();
                //accesoDatos.Comando.Parameters.AddWithValue("@Apellido", modificar.Apellido);
                //accesoDatos.Comando.Parameters.AddWithValue("@Nombre", modificar.Nombre);
                //accesoDatos.Comando.Parameters.AddWithValue("@FechaNac", modificar.FechaNac.ToShortDateString());
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

        public void Delete(long id)
        {
            DataAccessManager accesoDatos = new DataAccessManager();
            try
            {
                accesoDatos.setearConsulta("DELETE FROM TB_COMISIONES WHERE CD_COMISION = " + id.ToString());
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


        private Comision Make(SqlDataReader lector, bool complete)
        {
            Comision entidad = new Comision();
            entidad.Id = (int)lector["CD_COMISION"];
            //entidad.Apellido = (string)lector["APELLIDO"];
            //entidad.Nombre = (string)lector["NOMBRE"];
            //entidad.FechaNac = (DateTime)lector["FECHA_NAC"];
            entidad.Deshabilitado = (bool)lector["DESHABILITADO"];

            if (complete) { }

            return entidad;
        }
    }
}
