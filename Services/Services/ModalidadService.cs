using AccesoDatos;
using Entities.Helpers;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.Services
{
    public class ModalidadService
    {
        public List<Modalidad> GetAll()
        {
            List<Modalidad> listado = new List<Modalidad>();
            DataAccessManager accesoDatos = new DataAccessManager();
            try
            {
                accesoDatos.setearConsulta("SELECT * FROM TB_MODALIDADES");
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

        public Modalidad GetById(byte id, bool complete = false)
        {
            Modalidad modalidad = new Modalidad();
            DataAccessManager accesoDatos = new DataAccessManager();
            try
            {
                accesoDatos.setearConsulta("SELECT * FROM TB_MODALIDADES WHERE CD_MODALIDAD = @Id");
                accesoDatos.Comando.Parameters.Clear();
                accesoDatos.Comando.Parameters.AddWithValue("@Id", id);
                accesoDatos.abrirConexion();
                accesoDatos.ejecutarConsulta();
                while (accesoDatos.Lector.Read())
                {
                    modalidad = Make(accesoDatos.Lector, complete);
                }

                return modalidad;
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

        private Modalidad Make(SqlDataReader lector, bool complete)
        {
            Modalidad entidad = new Modalidad();
            entidad.Id = Converter.ToByte(lector["CD_MODALIDAD"]);
            entidad.Descripcion = Converter.ToString(lector["DESCRIPCION"]);
            entidad.Deshabilitado = Converter.ToBoolean(lector["DESHABILITADO"]);

            if (complete) { }

            return entidad;
        }
    }
}
