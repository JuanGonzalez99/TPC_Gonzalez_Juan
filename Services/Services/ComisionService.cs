using Entities.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.Services
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

        public Comision GetById(int id, bool complete = false)
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
                    comision = Make(accesoDatos.Lector, complete);
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
                accesoDatos.setearSP("INSERT INTO TB_COMISIONES (CD_MATERIA, AÑO, CUATRIMESTRE, CD_MODALIDAD)" +
                    "values (@IdMateria, @Año, @Cuatrimestre, @IdModalidad)");
                accesoDatos.Comando.Parameters.Clear();
                accesoDatos.Comando.Parameters.AddWithValue("@IdMateria", nuevo.Materia.Id);
                accesoDatos.Comando.Parameters.AddWithValue("@Año", nuevo.Año);
                accesoDatos.Comando.Parameters.AddWithValue("@Cuatrimestre", nuevo.Cuatrimestre);
                accesoDatos.Comando.Parameters.AddWithValue("@IdModalidad", nuevo.Modalidad.Id);
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
                accesoDatos.setearConsulta("UPDATE TB_COMISIONES SET " +
                    "CD_MATERIA = @IdMateria, " +
                    "AÑO = @Año, " +
                    "CUATRIMESTRE = @Cuatrimestre, " +
                    "CD_MODALIDAD = @IdModalidad " +
                "Where CD_COMISION = @Id");
                accesoDatos.Comando.Parameters.Clear();
                accesoDatos.Comando.Parameters.AddWithValue("@Id", modificar.Id);
                accesoDatos.Comando.Parameters.AddWithValue("@IdMateria", modificar.Materia.Id);
                accesoDatos.Comando.Parameters.AddWithValue("@Año", modificar.Año);
                accesoDatos.Comando.Parameters.AddWithValue("@Cuatrimestre", modificar.Cuatrimestre);
                accesoDatos.Comando.Parameters.AddWithValue("@IdModalidad", modificar.Modalidad.Id);
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
                accesoDatos.setearConsulta("UPDATE TB_COMISIONES " +
                    "SET DESHABILITADO = 1 WHERE CD_COMISION = " + id.ToString());
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
            entidad.Id = (long)lector["CD_COMISION"];
            entidad.Año = (int)lector["AÑO"];
            entidad.Cuatrimestre = (byte)lector["CUATRIMESTRE"];
            entidad.Deshabilitado = (bool)lector["DESHABILITADO"];

            entidad.Materia = new MateriaService().GetById((int)lector["CD_MATERIA"]);
            entidad.Modalidad = new ModalidadService().GetById((byte)lector["CD_MODALIDAD"]);

            if (complete) { }

            return entidad;
        }
    }
}
