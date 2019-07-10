using Entities.Models;
using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.Services
{
    public class TurnoService
    {
        public List<Turno> GetAll()
        {
            List<Turno> listado = new List<Turno>();
            DataAccessManager accesoDatos = new DataAccessManager();
            try
            {
                accesoDatos.setearConsulta("SELECT * FROM TB_TURNOS");
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

        public Turno GetById(byte id)
        {
            Turno turno = new Turno();
            DataAccessManager accesoDatos = new DataAccessManager();
            try
            {
                accesoDatos.setearConsulta("SELECT * FROM TB_TURNOS WHERE CD_TURNO = @Id");
                accesoDatos.Comando.Parameters.Clear();
                accesoDatos.Comando.Parameters.AddWithValue("@Id", id);
                accesoDatos.abrirConexion();
                accesoDatos.ejecutarConsulta();
                while (accesoDatos.Lector.Read())
                {
                    turno = Make(accesoDatos.Lector, false);
                }

                return turno;
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

        public Turno Make(SqlDataReader lector, bool complete)
        {
            Turno entidad = new Turno();
            entidad.Id = (byte)lector["CD_TURNO"];
            entidad.Descripcion = (string)lector["DESCRIPCION"];

            if (complete) { }

            return entidad;
        }
    }
}
