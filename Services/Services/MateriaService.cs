using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

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
                accesoDatos.setearConsulta("SELECT M.*, C.NOMBRE AS NOMBRE_CARRERA, C.NOMBRE_CORTO AS NM_CORTO_CARRERA," +
                    " C.DURACION FROM TB_MATERIAS M, TB_CARRERAS C WHERE M.CD_CARRERA = C.CD_CARRERA");
                accesoDatos.abrirConexion();
                accesoDatos.ejecutarConsulta();
                while (accesoDatos.Lector.Read())
                {
                    listado.Add(Make(accesoDatos.Lector, true));
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
                accesoDatos.setearConsulta("SELECT M.*, C.NOMBRE AS NOMBRE_CARRERA, C.NOMBRE_CORTO AS NM_CORTO_CARRERA, C.DURACION FROM TB_MATERIAS M " +
                    "INNER JOIN TB_CARRERAS C ON M.CD_CARRERA = C.CD_CARRERA WHERE CD_Materias = @Id");
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

        public List<Materia> GetByCarreraId(short carreraId)
        {
            List<Materia> listado = new List<Materia>();
            DataAccessManager accesoDatos = new DataAccessManager();
            try
            {
                accesoDatos.setearConsulta("SELECT * FROM TB_MATERIAS WHERE CD_CARRERA = @CarreraId");
                accesoDatos.Comando.Parameters.Clear();
                accesoDatos.Comando.Parameters.AddWithValue("@CarreraId", carreraId);
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
                    "values('" + nuevo.Nombre + "', " + nuevo.Carrera.Id + ", " + nuevo.Año + ", " + nuevo.Cuatrimestre + ")");
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
                    "NOMBRE=@Nombre, CD_CARRERA=@Carrera, AÑO=@Año, CUATRIMESTRE=@Cuatrimestre WHERE CD_MATERIA=" + modificar.Id.ToString());
                accesoDatos.Comando.Parameters.Clear();
                accesoDatos.Comando.Parameters.AddWithValue("@Nombre", modificar.Nombre);
                accesoDatos.Comando.Parameters.AddWithValue("@Carrera", modificar.Carrera.Id);
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
                accesoDatos.setearConsulta("DELETE FROM TB_MATERIAS WHERE CD_MATERIA = " + id.ToString());
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
            if (!Convert.IsDBNull(lector["CUATRIMESTRE"]))
                entidad.Cuatrimestre = (byte)lector["CUATRIMESTRE"];

            if (complete)
            {
                entidad.Carrera = new Carrera();
                entidad.Carrera.Id = (short)lector["CD_CARRERA"];
                entidad.Carrera.Nombre = (string)lector["NOMBRE_CARRERA"];
                entidad.Carrera.NombreCorto = (string)lector["NM_CORTO_CARRERA"];
                entidad.Carrera.Duracion = (byte)lector["DURACION"];
            }

            return entidad;
        }
    }
}
