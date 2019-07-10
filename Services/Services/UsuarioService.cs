using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public List<TipoUsuario> GetAllTipoUsuarios()
        {
            List<TipoUsuario> listado = new List<TipoUsuario>();
            DataAccessManager accesoDatos = new DataAccessManager();
            TipoUsuario tipoUsuario;
            try
            {
                accesoDatos.setearConsulta("SELECT * FROM TB_TIPOS_USUARIO");
                accesoDatos.abrirConexion();
                accesoDatos.ejecutarConsulta();
                while (accesoDatos.Lector.Read())
                {
                    tipoUsuario = new TipoUsuario();
                    tipoUsuario.Id = (byte)accesoDatos.Lector["CD_TIPO"];
                    tipoUsuario.Nombre = (string)accesoDatos.Lector["NOMBRE"];
                    tipoUsuario.Deshabilitado = (bool)accesoDatos.Lector["DESHABILITADO"];

                    listado.Add(tipoUsuario);
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

        public TipoUsuario GetTipoUsuarioById(byte id)
        {
            DataAccessManager accesoDatos = new DataAccessManager();
            TipoUsuario tipoUsuario = new TipoUsuario();
            try
            {
                accesoDatos.setearConsulta("SELECT * FROM TB_TIPOS_USUARIO WHERE CD_TIPO = @Id");
                accesoDatos.Comando.Parameters.Clear();
                accesoDatos.Comando.Parameters.AddWithValue("@Id", id);
                accesoDatos.abrirConexion();
                accesoDatos.ejecutarConsulta();
                while (accesoDatos.Lector.Read())
                {
                    tipoUsuario = new TipoUsuario();
                    tipoUsuario.Id = (byte)accesoDatos.Lector["CD_TIPO"];
                    tipoUsuario.Nombre = (string)accesoDatos.Lector["NOMBRE"];
                }

                return tipoUsuario;
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

        public void Insert(Usuario nuevo)
        {
            DataAccessManager accesoDatos = new DataAccessManager();

            try
            {
                accesoDatos.setearConsulta("INSERT INTO TB_USUARIOS (NOMBRE_USUARIO, CONTRASEÑA, TIPO_USUARIO) " +
                    "values(@Nombre, @Contraseña, @IdTipo)");
                accesoDatos.Comando.Parameters.Clear();
                accesoDatos.Comando.Parameters.AddWithValue("@Nombre", nuevo.Nombre);
                accesoDatos.Comando.Parameters.AddWithValue("@Contraseña", nuevo.Contraseña);
                accesoDatos.Comando.Parameters.AddWithValue("@IdTipo", nuevo.TipoUsuario.Id);
                accesoDatos.abrirConexion();
                accesoDatos.ejecutarAccion();
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
                accesoDatos.Comando.Parameters.AddWithValue("@IdTipo", modificar.TipoUsuario.Id);
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
                accesoDatos.setearConsulta("UPDATE TB_USUARIOS" +
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

        private Usuario Make(SqlDataReader lector, bool complete)
        {
            Usuario entidad = new Usuario();

            entidad.Id = (long)lector["CD_USUARIO"];
            entidad.Nombre = (string)lector["NOMBRE_USUARIO"];
            entidad.Contraseña = (string)lector["CONTRASEÑA"];
            entidad.TipoUsuario = GetTipoUsuarioById((byte)lector["TIPO_USUARIO"]);
            entidad.Deshabilitado = (bool)lector["DESHABILITADO"];

            if (complete) { }

            return entidad;
        }
    }
}
