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
    public class AlumnoService
    {
        public List<Alumno> GetAll()
        {
            List<Alumno> listado = new List<Alumno>();
            DataAccessManager accesoDatos = new DataAccessManager();
            try
            {
                accesoDatos.setearConsulta("SELECT * FROM TB_ALUMNOS");
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

        public Alumno GetById(int id, bool complete = false)
        {
            Alumno alumno = new Alumno();
            DataAccessManager accesoDatos = new DataAccessManager();
            try
            {
                accesoDatos.setearConsulta("SELECT * FROM TB_ALUMNOS WHERE CD_ALUMNO = @Id");
                accesoDatos.Comando.Parameters.Clear();
                accesoDatos.Comando.Parameters.AddWithValue("@Id", id);
                accesoDatos.abrirConexion();
                accesoDatos.ejecutarConsulta();
                while (accesoDatos.Lector.Read())
                {
                    alumno = Make(accesoDatos.Lector, complete);
                }

                return alumno;
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

        public Alumno GetAlumnoByUserName(string nombreUsuario, bool complete = false)
        {
            Alumno alumno = new Alumno();
            DataAccessManager accesoDatos = new DataAccessManager();
            try
            {
                accesoDatos.setearConsulta("SELECT * FROM TB_USUARIOS_ALUMNOS " +
                    "INNER JOIN TB_USUARIOS ON TB_USUARIOS_ALUMNOS.CD_USUARIO = TB_USUARIOS.CD_USUARIO " +
                    "WHERE NOMBRE_USUARIO = @Nombre");
                accesoDatos.Comando.Parameters.Clear();
                accesoDatos.Comando.Parameters.AddWithValue("@Nombre", nombreUsuario);
                accesoDatos.abrirConexion();
                accesoDatos.ejecutarConsulta();
                while (accesoDatos.Lector.Read())
                {
                    var id = Converter.ToInt(accesoDatos.Lector["CD_ALUMNO"]);
                    alumno = GetById(id, complete);
                }

                return alumno;
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

        public List<AlumnoComision> GetAlumnosComision()
        {
            List<AlumnoComision> listado = new List<AlumnoComision>();
            DataAccessManager accesoDatos = new DataAccessManager();
            AlumnoComision alumno;
            try
            {
                accesoDatos.setearConsulta("SELECT * FROM TB_ALUMNOS_COMISIONES");
                accesoDatos.abrirConexion();
                accesoDatos.ejecutarConsulta();
                while (accesoDatos.Lector.Read())
                {
                    int alumnoId = Converter.ToInt(accesoDatos.Lector["CD_ALUMNO"]);
                    long comisionId = Converter.ToLong(accesoDatos.Lector["CD_COMISION"]);

                    alumno = new AlumnoComision();
                    alumno.Alumno = GetById(alumnoId);
                    alumno.Comision = new ComisionService().GetById(comisionId);
                    alumno.Estado = (EstadoMateria)Converter.ToByte(accesoDatos.Lector["CD_ESTADO"]);
                    alumno.Nota = Converter.ToNulleableByte(accesoDatos.Lector["NOTA"]);
                    alumno.Deshabilitado = Converter.ToBoolean(accesoDatos.Lector["DESHABILITADO"]);

                    listado.Add(alumno);
                }

                return listado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Insert(Alumno nuevo)
        {
            DataAccessManager accesoDatos = new DataAccessManager();
            try
            {
                accesoDatos.setearConsulta("SET DATEFORMAT 'DMY' " +
                    "INSERT INTO TB_ALUMNOS (DNI, APELLIDO, NOMBRE, FECHA_NAC) " +
                    "values (@DNI, @Apellido, @Nombre, @FechaNac)");
                accesoDatos.Comando.Parameters.Clear();
                accesoDatos.Comando.Parameters.AddWithValue("@DNI", nuevo.DNI);
                accesoDatos.Comando.Parameters.AddWithValue("@Apellido", nuevo.Apellido);
                accesoDatos.Comando.Parameters.AddWithValue("@Nombre", nuevo.Nombre);
                accesoDatos.Comando.Parameters.AddWithValue("@FechaNac", nuevo.FechaNac.ToShortDateString());
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

        public void AsignarCarrera(int id, short carreraId)
        {
            DataAccessManager accesoDatos = new DataAccessManager();
            try
            {
                accesoDatos.setearConsulta("INSERT INTO TB_ALUMNOS_CARRERAS (CD_ALUMNO, CD_CARRERA) " +
                    "values (@IdAlumno, @IdCarrera)");
                accesoDatos.Comando.Parameters.Clear();
                accesoDatos.Comando.Parameters.AddWithValue("@IdAlumno", id);
                accesoDatos.Comando.Parameters.AddWithValue("@IdCarrera", carreraId);
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

        public void QuitarCarrera(int id, short carreraId)
        {
            DataAccessManager accesoDatos = new DataAccessManager();
            try
            {
                accesoDatos.setearConsulta("UPDATE TB_ALUMNOS_CARRERAS " +
                    "SET DESHABILITADO = 1 " +
                    "WHERE CD_ALUMNO = @IdAlumno " +
                    "AND CD_CARRERA = @IdCarrera");
                accesoDatos.Comando.Parameters.Clear();
                accesoDatos.Comando.Parameters.AddWithValue("@IdAlumno", id);
                accesoDatos.Comando.Parameters.AddWithValue("@IdCarrera", carreraId);
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

        public void Update(Alumno modificar)
        {
            DataAccessManager accesoDatos = new DataAccessManager();
            try
            {
                accesoDatos.setearConsulta("SET DATEFORMAT 'DMY' " +
                    "UPDATE TB_ALUMNOS SET " +
                    "DNI = @DNI, " +
                    "APELLIDO = @Apellido, " +
                    "NOMBRE = @Nombre, " +
                    "FECHA_NAC = @FechaNac " +
                "Where CD_ALUMNO = @Id");
                accesoDatos.Comando.Parameters.Clear();
                accesoDatos.Comando.Parameters.AddWithValue("@Id", modificar.Id);
                accesoDatos.Comando.Parameters.AddWithValue("@DNI", modificar.DNI);
                accesoDatos.Comando.Parameters.AddWithValue("@Apellido", modificar.Apellido);
                accesoDatos.Comando.Parameters.AddWithValue("@Nombre", modificar.Nombre);
                accesoDatos.Comando.Parameters.AddWithValue("@FechaNac", modificar.FechaNac.ToShortDateString());
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
                accesoDatos.setearConsulta("UPDATE TB_ALUMNOS " +
                    "SET DESHABILITADO = 1 WHERE CD_ALUMNO = " + id.ToString());
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

        public void Restaurar(int id)
        {
            DataAccessManager accesoDatos = new DataAccessManager();
            try
            {
                accesoDatos.setearConsulta("UPDATE TB_ALUMNOS " +
                    "SET DESHABILITADO = 0 WHERE CD_ALUMNO = " + id.ToString());
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


        private Alumno Make(SqlDataReader lector, bool complete)
        {
            Alumno entidad = new Alumno();
            entidad.Id = Converter.ToInt(lector["CD_ALUMNO"]);
            entidad.DNI = Converter.ToString(lector["DNI"]);
            entidad.Apellido = Converter.ToString(lector["APELLIDO"]);
            entidad.Nombre = Converter.ToString(lector["NOMBRE"]);
            entidad.FechaNac = Converter.ToDateTime(lector["FECHA_NAC"]);
            entidad.Deshabilitado = Converter.ToBoolean(lector["DESHABILITADO"]);

            if (complete) { }

            return entidad;
        }
    }
}
