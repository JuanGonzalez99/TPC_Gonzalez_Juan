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
    public class HorarioService
    {
        public List<Horario> GetAll()
        {
            List<Horario> listado = new List<Horario>();
            DataAccessManager accesoDatos = new DataAccessManager();
            try
            {
                accesoDatos.setearConsulta("SELECT * FROM TB_HORARIOS");
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

        public Horario GetById(int id)
        {
            Horario Horario = new Horario();
            DataAccessManager accesoDatos = new DataAccessManager();
            try
            {
                accesoDatos.setearConsulta("SELECT * FROM TB_HORARIOS WHERE CD_HORARIO = @Id");
                accesoDatos.Comando.Parameters.Clear();
                accesoDatos.Comando.Parameters.AddWithValue("@Id", id);
                accesoDatos.abrirConexion();
                accesoDatos.ejecutarConsulta();
                while (accesoDatos.Lector.Read())
                {
                    Horario = Make(accesoDatos.Lector, true);
                }

                return Horario;
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


        public void Insert(Horario nuevo)
        {
            DataAccessManager accesoDatos = new DataAccessManager();
            try
            {
                accesoDatos.setearConsulta("SET DATEFORMAT 'DMY' INSERT INTO TB_HORARIOS (APELLIDO, NOMBRE, FECHA_NAC) " +
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

        public void Update(Horario modificar)
        {
            DataAccessManager accesoDatos = new DataAccessManager();
            try
            {
                accesoDatos.setearConsulta("SET DATEFORMAT 'DMY' UPDATE TB_HorarioS SET APELLIDO=@Apellido, NOMBRE=@Nombre, FECHA_NAC=@FechaNac Where CD_Horario=" + modificar.Id.ToString());
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

        public void Delete(int id)
        {
            DataAccessManager accesoDatos = new DataAccessManager();
            try
            {
                accesoDatos.setearConsulta("DELETE FROM TB_HORARIOS WHERE CD_HORARIO = " + id.ToString());
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


        private Horario Make(SqlDataReader lector, bool complete)
        {
            Horario entidad = new Horario();
            entidad.Id = (int)lector["CD_HORARIO"];
            //entidad.Apellido = (string)lector["APELLIDO"];
            //entidad.Nombre = (string)lector["NOMBRE"];
            //entidad.FechaNac = (DateTime)lector["FECHA_NAC"];

            if (complete) { }

            return entidad;
        }
    }
}
