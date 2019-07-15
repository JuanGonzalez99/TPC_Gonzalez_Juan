using AccesoDatos;
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
    public class HorarioService
    {
        public List<Horario> GetAll()
        {
            List<Horario> listado = new List<Horario>();
            DataAccessManager accesoDatos = new DataAccessManager();
            try
            {
                accesoDatos.setearConsulta("SELECT * FROM TB_HORARIOS");
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

        public Horario GetById(int id, bool complete = false)
        {
            Horario Horario = new Horario();
            DataAccessManager accesoDatos = new DataAccessManager();
            try
            {
                accesoDatos.setearConsulta("SELECT * FROM TB_HORARIOS WHERE CD_HORARIO = @Id");
                accesoDatos.Comando.Parameters.Clear();
                accesoDatos.Comando.Parameters.AddWithValue("@Id", id);
                accesoDatos.abrirConexion();
                accesoDatos.ejecutarConsulta();
                while (accesoDatos.Lector.Read())
                {
                    Horario = Make(accesoDatos.Lector, complete);
                }

                return Horario;
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


        public int Insert(Horario nuevo)
        {
            DataAccessManager accesoDatos = new DataAccessManager();
            try
            {
                accesoDatos.setearConsulta("INSERT INTO TB_HORARIOS (HORA_INICIO, HORA_FIN, DIA_SEMANA) " +
                    "values (@HoraInicio, @HoraFin, @DiaSemana) " +
                    "select IDENT_CURRENT('TB_HORARIOS')");
                accesoDatos.Comando.Parameters.Clear();
                accesoDatos.Comando.Parameters.AddWithValue("@HoraInicio", nuevo.HoraInicio);
                accesoDatos.Comando.Parameters.AddWithValue("@HoraFin", nuevo.HoraFin);
                accesoDatos.Comando.Parameters.AddWithValue("@DiaSemana", nuevo.DiaSemana);
                accesoDatos.abrirConexion();
                return accesoDatos.ejecutarAccionReturn<int>();
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

        public void Update(Horario modificar)
        {
            DataAccessManager accesoDatos = new DataAccessManager();
            try
            {
                accesoDatos.setearConsulta("UPDATE TB_HORARIOS SET " +
                    "HORA_INICIO = @HoraInicio, " +
                    "HORA_FIN= @HoraFin, " +
                    "DIA_SEMANA = @DiaSemana " +
                "Where CD_HORARIO=" + modificar.Id.ToString());
                accesoDatos.Comando.Parameters.Clear();
                accesoDatos.Comando.Parameters.AddWithValue("@HoraInicio", modificar.HoraInicio);
                accesoDatos.Comando.Parameters.AddWithValue("@HoraFin", modificar.HoraFin);
                accesoDatos.Comando.Parameters.AddWithValue("@DiaSemana", modificar.DiaSemana);
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
                accesoDatos.setearConsulta("UPDATE TB_HORARIOS " +
                    "SET DESHABILITADO = 1 WHERE CD_HORARIO = " + id.ToString());
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


        private Horario Make(SqlDataReader lector, bool complete)
        {
            Horario entidad = new Horario();
            entidad.Id = Converter.ToInt(lector["CD_HORARIO"]);
            entidad.HoraInicio = Converter.ToTimeSpan(lector["HORA_INICIO"]);
            entidad.HoraFin = Converter.ToTimeSpan(lector["HORA_FIN"]);
            entidad.DiaSemana = (DiaDeLaSemana)Converter.ToByte(lector["DIA_SEMANA"]);
            
            entidad.Deshabilitado = Converter.ToBoolean(lector["DESHABILITADO"]);

            if (complete) { }

            return entidad;
        }
    }
}
