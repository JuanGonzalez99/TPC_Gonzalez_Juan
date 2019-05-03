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
    class ProfesorDAO : baseDAO
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

        public List<Profesor> GetAll()
        {
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;
            try
            {
                conexion.ConnectionString = CadenaConeccion;
                comando.CommandType = CommandType.Text;
                comando.CommandText = "SELECT * FROM TB_PROFESORES";
                comando.Connection = conexion;
                conexion.Open();
                lector = comando.ExecuteReader();

                List<Profesor> list = new List<Profesor>();
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

        private Profesor Make(SqlDataReader lector, bool complete)
        {
            Profesor entidad = new Profesor();

            entidad.Id = (long)lector["CD_PROFESOR"];
            entidad.Apellido = (string)lector["APELLIDO"];
            entidad.Nombre = (string)lector["NOMBRE"];
            entidad.FechaNac = (DateTime)lector["FECHA_NAC"];
            entidad.FechaIngreso = (DateTime)lector["FECHA_INGRESO"];

            if (complete) { }

            return entidad;
        }
    }
}
