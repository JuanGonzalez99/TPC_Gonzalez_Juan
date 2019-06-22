using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Models;

namespace AccesoDatos.Services
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

        public Carrera GetById(short id, bool complete = false)
        {
            Carrera carrera = new Carrera();
            DataAccessManager accesoDatos = new DataAccessManager();
            try
            {
                accesoDatos.setearConsulta("SELECT * FROM TB_CARRERAS WHERE CD_CARRERA = @Id");
                accesoDatos.Comando.Parameters.Clear();
                accesoDatos.Comando.Parameters.AddWithValue("@Id", id);
                accesoDatos.abrirConexion();
                accesoDatos.ejecutarConsulta();
                while (accesoDatos.Lector.Read())
                {
                    carrera = Make(accesoDatos.Lector, complete);
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


        public void Insert(Carrera nuevo)
        {
            DataAccessManager accesoDatos = new DataAccessManager();
            try
            {
                accesoDatos.setearConsulta("INSERT INTO TB_CARRERAS (NOMBRE, NOMBRE_CORTO, DURACION) " +
                    "values(@Nombre, @NombreCorto, @Duracion)");
                accesoDatos.Comando.Parameters.Clear();
                accesoDatos.Comando.Parameters.AddWithValue("@Nombre", nuevo.Nombre);
                accesoDatos.Comando.Parameters.AddWithValue("@NombreCorto", nuevo.NombreCorto);
                accesoDatos.Comando.Parameters.AddWithValue("@Duracion", nuevo.Duracion);
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

        public void Update(Carrera modificar)
        {
            DataAccessManager accesoDatos = new DataAccessManager();
            try
            {
                accesoDatos.setearConsulta("UPDATE TB_CARRERAS SET " +
                    "NOMBRE = @Nombre, " +
                    "NOMBRE_CORTO = @NombreCorto, " +
                    "DURACION = @Duracion " +
                "Where CD_CARRERA = @Id");
                accesoDatos.Comando.Parameters.Clear();
                accesoDatos.Comando.Parameters.AddWithValue("@Id", modificar.Id);
                accesoDatos.Comando.Parameters.AddWithValue("@Nombre", modificar.Nombre);
                accesoDatos.Comando.Parameters.AddWithValue("@NombreCorto", modificar.NombreCorto);
                accesoDatos.Comando.Parameters.AddWithValue("@Duracion", modificar.Duracion);
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
                accesoDatos.setearConsulta("UPDATE TB_CARRERAS " +
                    "SET DESHABILITADO = 1 WHERE CD_CARRERA = " + id.ToString());
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


        private Carrera Make(SqlDataReader lector, bool complete)
        {
            Carrera entidad = new Carrera();
            entidad.Id = (short)lector["CD_CARRERA"];
            entidad.Nombre = (string)lector["NOMBRE"];
            entidad.NombreCorto = (string)lector["NOMBRE_CORTO"];
            entidad.Duracion = (byte)lector["DURACION"];
            entidad.Deshabilitado = (bool)lector["DESHABILITADO"];

            if (complete) { }

            return entidad;
        }
    }
}
