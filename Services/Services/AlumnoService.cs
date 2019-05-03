using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Services.DAO;

namespace Services.Services
{
    public class AlumnoService : baseService
    {
        public List<Alumno> GetList()
        {
            AlumnoDAO dao = new AlumnoDAO();
            return dao.GetAll();

            //List<Alumno> lList = new List<Alumno>();

            //foreach (DataRow lRow in ds.Tables[0].Rows)
            //{
            //    lList.Add(Make(lRow, false));
            //}

            //return lList;
        }

        //private Alumno Make(DataRow dataRow, bool complete)
        //{
        //    Alumno entidad = new Alumno();

        //    //entidad.DNI = (int)dataRow["DNI"];
        //    entidad.Apellido = (string)dataRow["APELLIDO"];
        //    entidad.Nombre = (string)dataRow["NOMBRE"];
        //    entidad.FechaNac = (DateTime)dataRow["FECHA_NAC"];
            
        //    if (complete) { }

        //    return entidad;
        //}
    }
}
