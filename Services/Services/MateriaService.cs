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

        public List<Materia> GetCorrelativasById(int id)
        {
            List<Materia> listado = new List<Materia>();
            DataAccessManager accesoDatos = new DataAccessManager();
            try
            {
                accesoDatos.setearConsulta("SELECT * FROM TB_MATERIAS_CORRELATIVAS " +
                    "WHERE CD_MATERIA = @Id " +
                    "AND DESHABILITADO = 0");
                accesoDatos.Comando.Parameters.Clear();
                accesoDatos.Comando.Parameters.AddWithValue("@Id", id);
                accesoDatos.abrirConexion();
                accesoDatos.ejecutarConsulta();
                while (accesoDatos.Lector.Read())
                {
                    listado.Add(GetById((int)accesoDatos.Lector["CD_MATERIA_REQUERIDA"]));
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

        public List<EstadoMateria> GetAllEstados()
        {
            List<EstadoMateria> listado = new List<EstadoMateria>();
            DataAccessManager accesoDatos = new DataAccessManager();
            EstadoMateria estado;
            try
            {
                accesoDatos.setearConsulta("SELECT * FROM TB_ESTADOS_MATERIA");
                accesoDatos.abrirConexion();
                accesoDatos.ejecutarConsulta();
                while (accesoDatos.Lector.Read())
                {
                    estado = new EstadoMateria();

                    estado.Id = (byte)accesoDatos.Lector["CD_ESTADO"];
                    estado.Descripcion = (string)accesoDatos.Lector["DESCRIPCION"];

                    listado.Add(estado);
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

        public EstadoMateria GetEstadoById(byte id)
        {
            DataAccessManager accesoDatos = new DataAccessManager();
            EstadoMateria estado = new EstadoMateria();

            try
            {
                accesoDatos.setearConsulta("SELECT * FROM TB_ESTADOS_MATERIA " +
                    "WHERE CD_MATERIA = @Id");
                accesoDatos.Comando.Parameters.Clear();
                accesoDatos.Comando.Parameters.AddWithValue("@Id", id);
                accesoDatos.abrirConexion();
                accesoDatos.ejecutarConsulta();

                while (accesoDatos.Lector.Read())
                {
                    estado = new EstadoMateria();
                    estado.Id = (byte)accesoDatos.Lector["CD_ESTADO"];
                    estado.Descripcion = (string)accesoDatos.Lector["DESCRIPCION"];
                }

                return estado;
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
                accesoDatos.Comando.Parameters.AddWithValue("@Cuatrimestre", nuevo.Cuatrimestre == null ? (object)DBNull.Value : nuevo.Cuatrimestre);
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

        public void InsertCorrelativa(int id, int correlativaId, EstadoMateria estadoRequerido)
        {
            DataAccessManager accesoDatos = new DataAccessManager();
            try
            {
                accesoDatos.setearConsulta("INSERT INTO TB_MATERIAS_CORRELATIVAS " +
                    "(CD_MATERIA, CD_MATERIA_REQUERIDA, CD_ESTADO_REQUERIDO) " +
                    "values(@Id, @IdCorrelativa, @IdEstado)");
                accesoDatos.Comando.Parameters.Clear();
                accesoDatos.Comando.Parameters.AddWithValue("@Id", id);
                accesoDatos.Comando.Parameters.AddWithValue("@IdCorrelativa", correlativaId);
                accesoDatos.Comando.Parameters.AddWithValue("@IdEstado", estadoRequerido.Id);
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
                accesoDatos.Comando.Parameters.AddWithValue("@Cuatrimestre", modificar.Cuatrimestre == null ? (object)DBNull.Value : modificar.Cuatrimestre);
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

        public void DeleteCorrelativa(int id, int correlativaId)
        {
            DataAccessManager accesoDatos = new DataAccessManager();
            try
            {
                accesoDatos.setearConsulta("UPDATE TB_MATERIAS_CORRELATIVAS " +
                    "SET DESHABILITADO = 1 " +
                    "WHERE CD_MATERIA = @Id " +
                    "AND CD_MATERIA_REQUERIDA = @IdCorrelativa");
                accesoDatos.Comando.Parameters.Clear();
                accesoDatos.Comando.Parameters.AddWithValue("@Id", id);
                accesoDatos.Comando.Parameters.AddWithValue("@IdCorrelativa", correlativaId);
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
            entidad.Deshabilitado = (bool)lector["DESHABILITADO"];

            entidad.Carrera = new CarreraService().GetById((short)lector["CD_CARRERA"]);

            if (complete) { }

            return entidad;
        }
    }
}
