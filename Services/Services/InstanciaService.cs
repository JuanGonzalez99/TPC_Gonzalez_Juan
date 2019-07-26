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
    public class InstanciaService
    {
        public List<Instancia> GetAll()
        {
            List<Instancia> listado = new List<Instancia>();
            DataAccessManager accesoDatos = new DataAccessManager();
            try
            {
                accesoDatos.setearConsulta("SELECT * FROM TB_INSTANCIAS");
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

        public List<InstanciaAlumno> GetAllIncludeNotasAlumnos()
        {
            List<InstanciaAlumno> listado = new List<InstanciaAlumno>();
            DataAccessManager accesoDatos = new DataAccessManager();
            InstanciaAlumno entidad = new InstanciaAlumno();
            try
            {
                accesoDatos.setearConsulta("SELECT * FROM TB_NOTAS_ALUMNOS_INSTANCIAS");
                accesoDatos.abrirConexion();
                accesoDatos.ejecutarConsulta();
                while (accesoDatos.Lector.Read())
                {
                    entidad = new InstanciaAlumno();
                    entidad.Alumno = new AlumnoService().GetById(Converter.ToInt(accesoDatos.Lector["CD_ALUMNO"]));
                    entidad.Instancia = GetById(Converter.ToLong(accesoDatos.Lector["CD_INSTANCIA"]));
                    entidad.Nota = Converter.ToString(accesoDatos.Lector["NOTA"]);
                    entidad.Comentarios = Converter.ToString(accesoDatos.Lector["COMENTARIOS"]);
                    entidad.Deshabilitado = Converter.ToBoolean(accesoDatos.Lector["DESHABILITADO"]);

                    listado.Add(entidad);
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

        public List<TipoInstancia> GetAllTipoInstancias()
        {
            List<TipoInstancia> listado = new List<TipoInstancia>();
            DataAccessManager accesoDatos = new DataAccessManager();
            try
            {
                accesoDatos.setearConsulta("SELECT * FROM TB_TIPO_INSTANCIAS");
                accesoDatos.abrirConexion();
                accesoDatos.ejecutarConsulta();
                while (accesoDatos.Lector.Read())
                {
                    listado.Add(MakeTipo(accesoDatos.Lector));
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

        public Instancia GetById(long id)
        {
            DataAccessManager accesoDatos = new DataAccessManager();
            Instancia entidad = new Instancia();
            try
            {
                accesoDatos.setearConsulta("SELECT * FROM TB_INSTANCIAS WHERE CD_INSTANCIA = @Id");
                accesoDatos.Comando.Parameters.Clear();
                accesoDatos.Comando.Parameters.AddWithValue("@Id", id);
                accesoDatos.abrirConexion();
                accesoDatos.ejecutarConsulta();
                while (accesoDatos.Lector.Read())
                {
                    entidad = Make(accesoDatos.Lector, false);
                }

                return entidad;
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

        public TipoInstancia GetTipoInstanciaById(byte tipoId)
        {
            DataAccessManager accesoDatos = new DataAccessManager();
            TipoInstancia entidad = new TipoInstancia();
            try
            {
                accesoDatos.setearConsulta("SELECT * FROM TB_TIPO_INSTANCIAS " +
                    "WHERE CD_TIPO = @Id");
                accesoDatos.Comando.Parameters.Clear();
                accesoDatos.Comando.Parameters.AddWithValue("@Id", tipoId);
                accesoDatos.abrirConexion();
                accesoDatos.ejecutarConsulta();
                while (accesoDatos.Lector.Read())
                {
                    entidad = MakeTipo(accesoDatos.Lector);
                }

                return entidad;
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

        public TipoInstancia GetTipoInstanciaByDesc(string descripcion)
        {
            DataAccessManager accesoDatos = new DataAccessManager();
            TipoInstancia entidad = new TipoInstancia();
            try
            {
                accesoDatos.setearConsulta("SELECT * FROM TB_TIPO_INSTANCIAS " +
                    "WHERE DESCRIPCION = @Descripcion");
                accesoDatos.Comando.Parameters.Clear();
                accesoDatos.Comando.Parameters.AddWithValue("@Descripcion", descripcion);
                accesoDatos.abrirConexion();
                accesoDatos.ejecutarConsulta();
                while (accesoDatos.Lector.Read())
                {
                    entidad = MakeTipo(accesoDatos.Lector);
                }

                return entidad;
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

        public void Insert(Instancia nuevo)
        {
            DataAccessManager accesoDatos = new DataAccessManager();

            try
            {
                accesoDatos.setearConsulta("INSERT INTO TB_INSTANCIAS(CD_COMISION, NOMBRE, CD_TIPO) " +
                    "VALUES(@IdComision, @Nombre, @IdTipo)");
                accesoDatos.Comando.Parameters.Clear();
                accesoDatos.Comando.Parameters.AddWithValue("@IdComision", nuevo.Comision.Id);
                accesoDatos.Comando.Parameters.AddWithValue("@Nombre", nuevo.Nombre);
                accesoDatos.Comando.Parameters.AddWithValue("@IdTipo", nuevo.Tipo.Id);
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

        public void InsertNota(InstanciaAlumno nuevo)
        {
            DataAccessManager accesoDatos = new DataAccessManager();

            try
            {
                accesoDatos.setearConsulta("INSERT INTO TB_NOTAS_ALUMNOS_INSTANCIAS(CD_ALUMNO, CD_INSTANCIA, NOTA, COMENTARIOS) " +
                    "VALUES(@IdAlumno, @IdInstancia, @Nota, @Comentarios)");
                accesoDatos.Comando.Parameters.Clear();
                accesoDatos.Comando.Parameters.AddWithValue("@IdAlumno", nuevo.Alumno.Id);
                accesoDatos.Comando.Parameters.AddWithValue("@IdInstancia", nuevo.Instancia.Id);
                accesoDatos.Comando.Parameters.AddWithValue("@Nota", nuevo.Nota);
                accesoDatos.Comando.Parameters.AddWithValue("@Comentarios", nuevo.Comentarios);
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
                accesoDatos.setearConsulta("UPDATE TB_INSTANCIAS " +
                    "SET DESHABILITADO = 1 " +
                    "WHERE CD_INSTANCIA = " + id.ToString());
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

        public void DeleteNota(long instanciaId, int alumnoId)
        {
            DataAccessManager accesoDatos = new DataAccessManager();

            try
            {
                accesoDatos.setearConsulta("UPDATE TB_NOTAS_ALUMNOS_INSTANCIAS " +
                    "SET DESHABILITADO = 1 " +
                    "WHERE CD_INSTANCIA = @IdInstancia " +
                    "AND CD_ALUMNO = @IdAlumno");
                accesoDatos.Comando.Parameters.Clear();
                accesoDatos.Comando.Parameters.AddWithValue("@IdInstancia", instanciaId);
                accesoDatos.Comando.Parameters.AddWithValue("@IdAlumno", alumnoId);
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

        public Instancia Make(SqlDataReader lector, bool complete)
        {
            Instancia entidad = new Instancia();
            entidad.Id = Converter.ToLong(lector["CD_INSTANCIA"]);
            entidad.Comision = new ComisionService().GetById(Converter.ToLong(lector["CD_COMISION"]));
            entidad.Nombre = Converter.ToString(lector["NOMBRE"]);
            entidad.Tipo = this.GetTipoInstanciaById(Converter.ToByte(lector["CD_TIPO"]));
            entidad.Deshabilitado = Converter.ToBoolean(lector["DESHABILITADO"]);

            if (complete) { }

            return entidad;
        }

        public TipoInstancia MakeTipo(SqlDataReader lector)
        {
            TipoInstancia entidad = new TipoInstancia();
            entidad.Id = Converter.ToByte(lector["CD_TIPO"]);
            entidad.Descripcion = Converter.ToString(lector["DESCRIPCION"]);

            return entidad;
        }
    }
}
