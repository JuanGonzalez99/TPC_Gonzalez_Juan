using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Helpers;
using Entities.Models;

namespace AccesoDatos.Services
{
    public class InscripcionService
    {
        public List<Inscripcion> GetAll()
        {
            List<Inscripcion> listado = new List<Inscripcion>();
            DataAccessManager accesoDatos = new DataAccessManager();
            try
            {
                accesoDatos.setearConsulta("SELECT * FROM TB_INSCRIPCIONES");
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

        public Inscripcion GetById(int id, bool complete = false)
        {
            Inscripcion inscripcion = new Inscripcion();
            DataAccessManager accesoDatos = new DataAccessManager();
            try
            {
                accesoDatos.setearConsulta("SELECT * FROM TB_INSCRIPCIONES WHERE ID = @Id");
                accesoDatos.Comando.Parameters.Clear();
                accesoDatos.Comando.Parameters.AddWithValue("@Id", id);
                accesoDatos.abrirConexion();
                accesoDatos.ejecutarConsulta();
                while (accesoDatos.Lector.Read())
                {
                    inscripcion = Make(accesoDatos.Lector, complete);
                }

                return inscripcion;
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

        public List<Inscripcion> GetAllByActualDate()
        {
            List<Inscripcion> listado = new List<Inscripcion>();
            DataAccessManager accesoDatos = new DataAccessManager();
            try
            {
                accesoDatos.setearConsulta("SELECT * FROM TB_INSCRIPCIONES" +
                    "WHERE GETDATE() BETWEEN FECHA_APERTURA AND FECHA_CIERRE");
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

        public Inscripcion GetByAñoAndCuatrimestre(int año, byte? cuatrimestre)
        {
            Inscripcion inscripcion = new Inscripcion();
            DataAccessManager accesoDatos = new DataAccessManager();
            try
            {
                accesoDatos.setearConsulta("SELECT * FROM TB_INSCRIPCIONES " +
                    "WHERE AÑO = @Año " +
                    "AND CUATRIMESTRE = @Cuatrimestre");
                accesoDatos.Comando.Parameters.Clear();
                accesoDatos.Comando.Parameters.AddWithValue("@Año", año);
                accesoDatos.Comando.Parameters.AddWithValue("@Cuatrimestre", cuatrimestre == null ? (object)DBNull.Value : cuatrimestre);
                accesoDatos.abrirConexion();
                accesoDatos.ejecutarConsulta();
                while (accesoDatos.Lector.Read())
                {
                    inscripcion = Make(accesoDatos.Lector, false);
                }

                return inscripcion;
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

        public void Insert(Inscripcion nuevo)
        {
            DataAccessManager accesoDatos = new DataAccessManager();
            try
            {
                accesoDatos.setearConsulta("INSERT INTO TB_INSCRIPCIONES(AÑO, CUATRIMESTRE, FECHA_APERTURA, FECHA_CIERRE) " +
                    "values(@Año, @Cuatrimestre, @FechaApertura, @FechaCierre)");
                accesoDatos.Comando.Parameters.Clear();
                accesoDatos.Comando.Parameters.AddWithValue("@Año", nuevo.Año);
                accesoDatos.Comando.Parameters.AddWithValue("@Cuatrimestre", nuevo.Cuatrimestre == null ? (object)DBNull.Value : nuevo.Cuatrimestre);
                accesoDatos.Comando.Parameters.AddWithValue("@FechaApertura", nuevo.FechaApertura);
                accesoDatos.Comando.Parameters.AddWithValue("@FechaCierre", nuevo.FechaCierre);
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

        public void Update(Inscripcion modificar)
        {
            DataAccessManager accesoDatos = new DataAccessManager();
            try
            {
                accesoDatos.setearConsulta("UPDATE TB_INSCRIPCIONES SET " +
                    "AÑO = @Año, " +
                    "CUATRIMESTRE = @Cuatrimestre, " +
                    "FECHA_APERTURA = @FechaApertura, " +
                    "FECHA_CIERRE = @FechaCierre " +
                "Where ID = @Id");
                accesoDatos.Comando.Parameters.Clear();
                accesoDatos.Comando.Parameters.AddWithValue("@Id", modificar.Id);
                accesoDatos.Comando.Parameters.AddWithValue("@Año", modificar.Año);
                accesoDatos.Comando.Parameters.AddWithValue("@Cuatrimestre", modificar.Cuatrimestre == null ? (object)DBNull.Value : modificar.Cuatrimestre);
                accesoDatos.Comando.Parameters.AddWithValue("@FechaApertura", modificar.FechaApertura);
                accesoDatos.Comando.Parameters.AddWithValue("@FechaCierre", modificar.FechaCierre);
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

        private Inscripcion Make(SqlDataReader lector, bool complete)
        {
            Inscripcion entidad = new Inscripcion();
            entidad.Id = Converter.ToInt(lector["ID"]);
            entidad.Año = Converter.ToInt(lector["AÑO"]);
            entidad.Cuatrimestre = Converter.ToNulleableByte(lector["CUATRIMESTRE"]);
            entidad.FechaApertura = Converter.ToDateTime(lector["FECHA_APERTURA"]);
            entidad.FechaCierre = Converter.ToDateTime(lector["FECHA_CIERRE"]);

            if (complete) { }

            return entidad;
        }
    }
}
