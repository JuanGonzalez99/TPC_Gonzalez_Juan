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
    public class UsuarioService
    {
        public List<Usuario> GetAll()
        {
            List<Usuario> listado = new List<Usuario>();
            DataAccessManager accesoDatos = new DataAccessManager();
            try
            {
                accesoDatos.setearConsulta("SELECT * FROM TB_USUARIOS");
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

        public Usuario GetById(long id, bool complete = false)
        {
            Usuario usuario = new Usuario();
            DataAccessManager accesoDatos = new DataAccessManager();
            try
            {
                accesoDatos.setearConsulta("SELECT * FROM TB_USUARIOS WHERE CD_USUARIO = @Id");
                accesoDatos.Comando.Parameters.Clear();
                accesoDatos.Comando.Parameters.AddWithValue("@Id", id);
                accesoDatos.abrirConexion();
                accesoDatos.ejecutarConsulta();
                while (accesoDatos.Lector.Read())
                {
                    usuario = Make(accesoDatos.Lector, complete);
                }

                return usuario;
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

        public Usuario GetByUsername(string nombreUsuario, bool complete = false)
        {
            Usuario usuario = new Usuario();
            DataAccessManager accesoDatos = new DataAccessManager();
            try
            {
                accesoDatos.setearConsulta("SELECT * FROM TB_USUARIOS " +
                    "WHERE NOMBRE_USUARIO = @Nombre " +
                    "AND DESHABILITADO = 0");
                accesoDatos.Comando.Parameters.Clear();
                accesoDatos.Comando.Parameters.AddWithValue("@Nombre", nombreUsuario);
                accesoDatos.abrirConexion();
                accesoDatos.ejecutarConsulta();
                while (accesoDatos.Lector.Read())
                {
                    usuario = Make(accesoDatos.Lector, complete);
                }

                return usuario;
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

        public Usuario GetByDNI(string DNI)
        {
            List<Usuario> listado = new List<Usuario>();
            DataAccessManager accesoDatos = new DataAccessManager();
            try
            {
                accesoDatos.setearSP("SP_GET_USUARIOS_BY_DNI");
                accesoDatos.Comando.Parameters.Clear();
                accesoDatos.Comando.Parameters.AddWithValue("@p_DNI", DNI);
                accesoDatos.abrirConexion();
                accesoDatos.ejecutarConsulta();
                while (accesoDatos.Lector.Read())
                {
                    listado.Add(Make(accesoDatos.Lector, false));
                }

                return listado.FirstOrDefault();
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

        public List<UsuarioAlumno> GetAllAlumnos()
        {
            DataAccessManager accesoDatos = new DataAccessManager();
            List<UsuarioAlumno> listado = new List<UsuarioAlumno>();
            UsuarioAlumno usuarioAlumno;
            try
            {
                accesoDatos.setearConsulta("SELECT * FROM TB_USUARIOS_ALUMNOS");
                accesoDatos.abrirConexion();
                accesoDatos.ejecutarConsulta();
                while (accesoDatos.Lector.Read())
                {
                    long usuarioId = Converter.ToLong(accesoDatos.Lector["CD_USUARIO"]);
                    int alumnoId = Converter.ToInt(accesoDatos.Lector["CD_ALUMNO"]);

                    usuarioAlumno = new UsuarioAlumno();
                    usuarioAlumno.Usuario = GetById(usuarioId);
                    usuarioAlumno.Alumno = new AlumnoService().GetById(alumnoId);

                    listado.Add(usuarioAlumno);
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

        public List<UsuarioProfesor> GetAllProfesores()
        {
            DataAccessManager accesoDatos = new DataAccessManager();
            List<UsuarioProfesor> listado = new List<UsuarioProfesor>();
            UsuarioProfesor usuarioProfesor;
            try
            {
                accesoDatos.setearConsulta("SELECT * FROM TB_USUARIOS_PROFESORES");
                accesoDatos.abrirConexion();
                accesoDatos.ejecutarConsulta();
                while (accesoDatos.Lector.Read())
                {
                    long usuarioId = Converter.ToLong(accesoDatos.Lector["CD_USUARIO"]);
                    int profesorId = Converter.ToInt(accesoDatos.Lector["CD_PROFESOR"]);

                    usuarioProfesor = new UsuarioProfesor();
                    usuarioProfesor.Usuario = GetById(usuarioId);
                    usuarioProfesor.Profesor = new ProfesorService().GetById(profesorId);

                    listado.Add(usuarioProfesor);
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

        public long Insert(Usuario nuevo)
        {
            DataAccessManager accesoDatos = new DataAccessManager();

            try
            {
                accesoDatos.setearConsulta("INSERT INTO TB_USUARIOS (NOMBRE_USUARIO, CONTRASEÑA, TIPO_USUARIO) " +
                    "values(@Nombre, @Contraseña, @IdTipo) " +
                    "select IDENT_CURRENT('TB_USUARIOS')");
                accesoDatos.Comando.Parameters.Clear();
                accesoDatos.Comando.Parameters.AddWithValue("@Nombre", nuevo.Nombre);
                accesoDatos.Comando.Parameters.AddWithValue("@Contraseña", nuevo.Contraseña);
                accesoDatos.Comando.Parameters.AddWithValue("@IdTipo", nuevo.TipoUsuario);
                accesoDatos.abrirConexion();
                return accesoDatos.ejecutarAccionReturn<long>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Update(Usuario modificar)
        {
            DataAccessManager accesoDatos = new DataAccessManager();

            try
            {
                accesoDatos.setearConsulta("UPDATE TB_USUARIOS SET " +
                    "NOMBRE_USUARIO = @Nombre, " +
                    "CONTRASEÑA = @Contraseña, " +
                    "TIPO_USUARIO = @IdTipo " +
                "Where CD_USUARIO = @Id");
                accesoDatos.Comando.Parameters.Clear();
                accesoDatos.Comando.Parameters.AddWithValue("@Id", modificar.Id);
                accesoDatos.Comando.Parameters.AddWithValue("@Nombre", modificar.Nombre);
                accesoDatos.Comando.Parameters.AddWithValue("@Contraseña", modificar.Contraseña);
                accesoDatos.Comando.Parameters.AddWithValue("@IdTipo", modificar.TipoUsuario);
                accesoDatos.abrirConexion();
                accesoDatos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Delete(long id)
        {
            DataAccessManager accesoDatos = new DataAccessManager();

            try
            {
                accesoDatos.setearConsulta("UPDATE TB_USUARIOS " +
                    "SET DESHABILITADO = 1 WHERE CD_USUARIO = " + id.ToString());
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

        public void Restaurar(long id)
        {
            DataAccessManager accesoDatos = new DataAccessManager();

            try
            {
                accesoDatos.setearConsulta("UPDATE TB_USUARIOS " +
                    "SET DESHABILITADO = 0 WHERE CD_USUARIO = " + id.ToString());
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

        public void AsignarAlumno(long usuarioId, int alumnoId)
        {
            DataAccessManager accesoDatos = new DataAccessManager();
            try
            {
                accesoDatos.setearConsulta("INSERT INTO TB_USUARIOS_ALUMNOS (CD_USUARIO, CD_ALUMNO) " +
                    "values(@IdUsuario, @IdAlumno)");
                accesoDatos.Comando.Parameters.Clear();
                accesoDatos.Comando.Parameters.AddWithValue("@IdUsuario", usuarioId);
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

        public void AsignarProfesor(long usuarioId, int profesorId)
        {
            DataAccessManager accesoDatos = new DataAccessManager();
            try
            {
                accesoDatos.setearConsulta("INSERT INTO TB_USUARIOS_PROFESORES (CD_USUARIO, CD_PROFESOR) " +
                    "values(@IdUsuario, @IdProfesor)");
                accesoDatos.Comando.Parameters.Clear();
                accesoDatos.Comando.Parameters.AddWithValue("@IdUsuario", usuarioId);
                accesoDatos.Comando.Parameters.AddWithValue("@IdProfesor", profesorId);
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

        private Usuario Make(SqlDataReader lector, bool complete)
        {
            Usuario entidad = new Usuario();

            entidad.Id = Converter.ToLong(lector["CD_USUARIO"]);
            entidad.Nombre = Converter.ToString(lector["NOMBRE_USUARIO"]);
            entidad.Contraseña = Converter.ToString(lector["CONTRASEÑA"]);
            entidad.TipoUsuario = (TipoUsuario)Converter.ToByte(lector["TIPO_USUARIO"]);
            entidad.Deshabilitado = Converter.ToBoolean(lector["DESHABILITADO"]);

            if (complete) { }

            return entidad;
        }
    }
}
