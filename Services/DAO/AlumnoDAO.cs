using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace Services.DAO
{
    public class AlumnoDAO : baseDAO
    {
        public override void Insert()
        {
            throw new NotImplementedException();
        }

        public override void Update()
        {
            throw new NotImplementedException();
        }

        public override void Delete()
        {
            throw new NotImplementedException();
        }

        public List<Alumno> GetAll()
        {
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;
            try
            {
                conexion.ConnectionString = CadenaConeccion;
                comando.CommandType = CommandType.Text;
                comando.CommandText = "SELECT * FROM TB_ALUMNOS";
                comando.Connection = conexion;
                conexion.Open();
                lector = comando.ExecuteReader();

                List<Alumno> list = new List<Alumno>();
                while (lector.Read())
                {
                    list.Add(Make(lector, false));
                }

                return list;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conexion.Close();
            }
        }

        private Alumno Make(SqlDataReader lector, bool complete)
        {
            Alumno entidad = new Alumno();

            entidad.Id = (long)lector["CD_ALUMNO"];
            entidad.Apellido = (string)lector["APELLIDO"];
            entidad.Nombre = (string)lector["NOMBRE"];
            entidad.FechaNac = (DateTime)lector["FECHA_NAC"];

            if (complete) { }

            return entidad;
        }
    }
}
