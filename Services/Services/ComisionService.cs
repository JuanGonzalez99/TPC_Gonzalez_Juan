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

        public Comision GetById(long id, bool complete = false)
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

        public List<Comision> GetActualesByMateria(int materiaId)
        {
            List<Comision> listado = new List<Comision>();
            DataAccessManager accesoDatos = new DataAccessManager();
            try
            {
                accesoDatos.setearSP("SP_COMISIONES_ACTUALES_POR_MATERIA");
                accesoDatos.Comando.Parameters.Clear();
                accesoDatos.Comando.Parameters.AddWithValue("@p_materia_id", materiaId);
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

        public void InscribirAlumno(long comisionId, int alumnoId)
        {
            DataAccessManager accesoDatos = new DataAccessManager();

            try
            {
                accesoDatos.setearConsulta("INSERT INTO TB_ALUMNOS_COMISIONES (CD_COMISION, CD_ALUMNO, CD_ESTADO, NOTA) " +
                    "values (@IdComision, @IdAlumno, @IdEstado, NULL)");
                accesoDatos.Comando.Parameters.Clear();
                accesoDatos.Comando.Parameters.AddWithValue("@IdComision", comisionId);
                accesoDatos.Comando.Parameters.AddWithValue("@IdAlumno", alumnoId);
                accesoDatos.Comando.Parameters.AddWithValue("@IdEstado", EstadoMateria.Cursando);
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

        public void Insert(Comision nuevo)
        {
            DataAccessManager accesoDatos = new DataAccessManager();
            try
            {
                accesoDatos.setearConsulta("INSERT INTO TB_COMISIONES(CD_MATERIA, AÑO, CUATRIMESTRE, CD_TURNO, CD_MODALIDAD, CD_PROFESOR, CD_AYUDANTE)" +
                    "values (@IdMateria, @Año, @Cuatrimestre, @IdTurno, @IdModalidad, @IdProfesor, @IdAyudante)");
                accesoDatos.Comando.Parameters.Clear();
                accesoDatos.Comando.Parameters.AddWithValue("@IdMateria", nuevo.Materia.Id);
                accesoDatos.Comando.Parameters.AddWithValue("@Año", nuevo.Año);
                accesoDatos.Comando.Parameters.AddWithValue("@Cuatrimestre", nuevo.Cuatrimestre == null ? (object)DBNull.Value : nuevo.Cuatrimestre);
                accesoDatos.Comando.Parameters.AddWithValue("@IdTurno", nuevo.Turno.Id);
                accesoDatos.Comando.Parameters.AddWithValue("@IdModalidad", nuevo.Modalidad.Id);
                accesoDatos.Comando.Parameters.AddWithValue("@IdProfesor", nuevo.Profesor.Id);
                accesoDatos.Comando.Parameters.AddWithValue("@IdAyudante", nuevo.Ayudante == null ? (object)DBNull.Value : nuevo.Ayudante.Id);
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
                    "CD_TURNO = @IdTurno, " +
                    "CD_MODALIDAD = @IdModalidad, " +
                    "CD_PROFESOR = @IdProfesor, " +
                    "CD_AYUDANTE = @IdAyudante " +
                "Where CD_COMISION = @Id");
                accesoDatos.Comando.Parameters.Clear();
                accesoDatos.Comando.Parameters.AddWithValue("@Id", modificar.Id);
                accesoDatos.Comando.Parameters.AddWithValue("@IdMateria", modificar.Materia.Id);
                accesoDatos.Comando.Parameters.AddWithValue("@Año", modificar.Año);
                accesoDatos.Comando.Parameters.AddWithValue("@Cuatrimestre", modificar.Cuatrimestre == null ? (object)DBNull.Value : modificar.Cuatrimestre);
                accesoDatos.Comando.Parameters.AddWithValue("@IdTurno", modificar.Turno.Id);
                accesoDatos.Comando.Parameters.AddWithValue("@IdModalidad", modificar.Modalidad.Id);
                accesoDatos.Comando.Parameters.AddWithValue("@IdProfesor", modificar.Profesor.Id);
                accesoDatos.Comando.Parameters.AddWithValue("@IdAyudante", modificar.Ayudante == null ? (object)DBNull.Value : modificar.Ayudante.Id); accesoDatos.abrirConexion();
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


        public List<Horario> GetHorariosById(long id)
        {
            List<Horario> listado = new List<Horario>();
            DataAccessManager accesoDatos = new DataAccessManager();
            Horario horario;
            HorarioService horarioService = new HorarioService();
            try
            {
                accesoDatos.setearConsulta("SELECT * FROM TB_HORARIOS_COMISIONES " +
                    "WHERE CD_COMISION = @IdComision " +
                    "AND DESHABILITADO = 0");
                accesoDatos.Comando.Parameters.Clear();
                accesoDatos.Comando.Parameters.AddWithValue("@IdComision", id);
                accesoDatos.abrirConexion();
                accesoDatos.ejecutarConsulta();
                while (accesoDatos.Lector.Read())
                {
                    horario = horarioService.GetById(Converter.ToInt(accesoDatos.Lector["CD_HORARIO"]));
                    listado.Add(horario);
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

        public void AsignarHorario(long comisionId, int horarioId)
        {
            DataAccessManager accesoDatos = new DataAccessManager();
            try
            {
                accesoDatos.setearConsulta("INSERT INTO TB_HORARIOS_COMISIONES(CD_COMISION, CD_HORARIO)" +
                    "values (@IdComision, @IdHorario)");
                accesoDatos.Comando.Parameters.Clear();
                accesoDatos.Comando.Parameters.AddWithValue("@IdComision", comisionId);
                accesoDatos.Comando.Parameters.AddWithValue("@IdHorario", horarioId);
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

        public void QuitarHorario(long comisionId, int horarioId)
        {
            DataAccessManager accesoDatos = new DataAccessManager();
            try
            {
                accesoDatos.setearConsulta("UPDATE TB_HORARIOS_COMISIONES " +
                    "SET DESHABILITADO = 1 " +
                    "WHERE CD_COMISION = @IdComision " +
                    "AND CD_HORARIO = @IdHorario");
                accesoDatos.Comando.Parameters.Clear();
                accesoDatos.Comando.Parameters.AddWithValue("@IdComision", comisionId);
                accesoDatos.Comando.Parameters.AddWithValue("@IdHorario", horarioId);
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
            entidad.Id = Converter.ToLong(lector["CD_COMISION"]);
            entidad.Año = Converter.ToInt(lector["AÑO"]);
            entidad.Cuatrimestre = Converter.ToNulleableByte(lector["CUATRIMESTRE"]);
            entidad.Deshabilitado = Converter.ToBoolean(lector["DESHABILITADO"]);

            entidad.Materia = new MateriaService().GetById(Converter.ToInt(lector["CD_MATERIA"]));
            entidad.Turno = new TurnoService().GetById(Converter.ToByte(lector["CD_TURNO"]));
            entidad.Modalidad = new ModalidadService().GetById(Converter.ToByte(lector["CD_MODALIDAD"]));

            ProfesorService profesorService = new ProfesorService();
            entidad.Profesor = profesorService.GetById(Converter.ToInt(lector["CD_PROFESOR"]));

            var ayudanteId = Converter.ToInt(lector["CD_AYUDANTE"]);
            if (ayudanteId != 0)
                entidad.Ayudante = profesorService.GetById(ayudanteId);

            if (complete)
            {
                entidad.Horarios = this.GetHorariosById(entidad.Id);
            }

            return entidad;
        }
    }
}
