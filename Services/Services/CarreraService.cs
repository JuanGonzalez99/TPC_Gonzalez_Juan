using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace Services.Services
{
    public class CarreraService
    {
        public List<Carrera> GetAll()
        {
            List<Carrera> listado = new List<Carrera>();
            DataAccessManager accesoDatos = new DataAccessManager();
            try
            {
                accesoDatos.setearConsulta("SELECT * FROM TB_CARRERAS");
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

        public Carrera GetById(int id)
        {
            Carrera carrera = new Carrera();
            DataAccessManager accesoDatos = new DataAccessManager();
            try
            {
                accesoDatos.setearConsulta("SELECT * FROM TB_CARRERAS WHERE CD_CARRERAS = @Id");
                accesoDatos.Comando.Parameters.Clear();
                accesoDatos.Comando.Parameters.AddWithValue("@Id", id);
                accesoDatos.abrirConexion();
                accesoDatos.ejecutarConsulta();
                while (accesoDatos.Lector.Read())
                {
                    carrera = Make(accesoDatos.Lector, true);
                }

                return carrera;
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

        private Carrera Make(SqlDataReader lector, bool complete)
        {
            Carrera entidad = new Carrera();
            entidad.Id = (short)lector["CD_MATERIA"];
            entidad.Nombre = (string)lector["NOMBRE"];

            if (complete) { }

            return entidad;
        }
    }
}
