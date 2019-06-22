using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Models;

namespace AccesoDatos.Services
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

        public Materia GetById(int id, bool complete = false)
        {
            Materia materia = new Materia();
            DataAccessManager accesoDatos = new DataAccessManager();
            try
            {
                accesoDatos.setearConsulta("SELECT * FROM TB_MATERIAS WHERE CD_MATERIA = @Id");
                accesoDatos.Comando.Parameters.Clear();
                accesoDatos.Comando.Parameters.AddWithValue("@Id", id);
                accesoDatos.abrirConexion();
                accesoDatos.ejecutarConsulta();
                while (accesoDatos.Lector.Read())
                {
                    materia = Make(accesoDatos.Lector, complete);
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

        public List<Materia> GetByCarreraId(short carreraId)
        {
            List<Materia> listado = new List<Materia>();
            DataAccessManager accesoDatos = new DataAccessManager();
            try
            {
                accesoDatos.setearConsulta("SELECT * FROM TB_MATERIAS WHERE CD_CARRERA = @IdCarrera");
                accesoDatos.Comando.Parameters.Clear();
                accesoDatos.Comando.Parameters.AddWithValue("@IdCarrera", carreraId);
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


        public void Insert(Materia nuevo)
        {
            DataAccessManager accesoDatos = new DataAccessManager();
            try
            {
                accesoDatos.setearConsulta("INSERT INTO TB_MATERIAS (NOMBRE, CD_CARRERA, AÑO, CUATRIMESTRE) " +
                    "values(@Nombre, @IdCarrera, @Año, @Cuatrimestre)");
                accesoDatos.Comando.Parameters.Clear();
                accesoDatos.Comando.Parameters.AddWithValue("@Nombre", nuevo.Nombre);
                accesoDatos.Comando.Parameters.AddWithValue("@IdCarrera", nuevo.Carrera.Id);
                accesoDatos.Comando.Parameters.AddWithValue("@Año", nuevo.Año);
                accesoDatos.Comando.Parameters.AddWithValue("@Cuatrimestre", nuevo.Cuatrimestre);
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

        public void Update(Materia modificar)
        {
            DataAccessManager accesoDatos = new DataAccessManager();
            try
            {
                accesoDatos.setearConsulta("UPDATE TB_MATERIAS SET " +
                    "NOMBRE = @Nombre, " +
                    "CD_CARRERA = @IdCarrera, " +
                    "AÑO = @Año, " +
                    "CUATRIMESTRE = @Cuatrimestre " +
                "Where CD_MATERIA = @Id");
                accesoDatos.Comando.Parameters.Clear();
                accesoDatos.Comando.Parameters.AddWithValue("@Id", modificar.Id);
                accesoDatos.Comando.Parameters.AddWithValue("@Nombre", modificar.Nombre);
                accesoDatos.Comando.Parameters.AddWithValue("@IdCarrera", modificar.Carrera.Id);
                accesoDatos.Comando.Parameters.AddWithValue("@Año", modificar.Año);
                accesoDatos.Comando.Parameters.AddWithValue("@Cuatrimestre", modificar.Cuatrimestre);
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
                accesoDatos.setearConsulta("UPDATE TB_MATERIAS " +
                    "SET DESHABILITADO = 1 WHERE CD_MATERIA = " + id.ToString());
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
            entidad.Año = (byte)lector["AÑO"];
            entidad.Cuatrimestre = (byte)lector["CUATRIMESTRE"];
            entidad.Deshabilitado = (bool)lector["DESHABILITADO"];

            entidad.Carrera = new CarreraService().GetById((short)lector["CD_CARRERA"]);

            if (complete) { }

            return entidad;
        }
    }
}
