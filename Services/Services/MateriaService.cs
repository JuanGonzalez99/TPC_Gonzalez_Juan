using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace Services.Services
{
    public class MateriaService
    {
        public List<Materia> GetAll()
        {
            List<Materia> listado = new List<Materia>();
            DataAccessManager accesoDatos = new DataAccessManager();
            try
            {
                accesoDatos.setearConsulta("SELECT * FROM TB_MATERIAS");
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

        public Materia GetById(int id)
        {
            Materia materia = new Materia();
            DataAccessManager accesoDatos = new DataAccessManager();
            try
            {
                accesoDatos.setearConsulta("SELECT * FROM TB_MATERIAS WHERE CD_Materias = @Id");
                accesoDatos.Comando.Parameters.Clear();
                accesoDatos.Comando.Parameters.AddWithValue("@Id", id);
                accesoDatos.abrirConexion();
                accesoDatos.ejecutarConsulta();
                while (accesoDatos.Lector.Read())
                {
                    materia = Make(accesoDatos.Lector, true);
                }

                return materia;
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

        public void InsertMateria(Materia nuevo)
        {
            DataAccessManager accesoDatos = new DataAccessManager();
            try
            {
                accesoDatos.setearConsulta("INSERT INTO TB_MATERIAS (NOMBRE, CD_CARRERA, CD_PROFESOR, CD_AYUDANTE, AÑO, CUATRIMESTRE) " +
                    "values('" + nuevo.Nombre + "', '" + nuevo.Carrera.Id + "', '" + nuevo.Año + "', '" + nuevo.Cuatrimestre + "')");
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

        private Materia Make(SqlDataReader lector, bool complete)
        {
            Materia entidad = new Materia();
            entidad.Id = (int)lector["CD_MATERIA"];
            entidad.Nombre = (string)lector["NOMBRE"];

            if (complete) { }

            return entidad;
        }
    }
}
