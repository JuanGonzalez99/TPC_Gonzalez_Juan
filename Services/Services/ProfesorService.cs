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
    public class ProfesorService : baseService
    {
        public List<Profesor> GetList()
        {
            ProfesorDAO dao = new ProfesorDAO();
            DataSet ds = dao.GetAll();

            List<Profesor> lList = new List<Profesor>();

            foreach (DataRow lRow in ds.Tables[0].Rows)
            {
                lList.Add(Make(lRow, false));
            }

            return lList;
        }

        private Profesor Make(DataRow dataRow, bool complete)
        {
            Profesor entidad = new Profesor();

            entidad.DNI = (int)dataRow["DNI"];
            entidad.Apellido = (string)dataRow["APELLIDO"];
            entidad.Nombre = (string)dataRow["NOMBRE"];

            if (complete) { }

            return entidad;
        }
    }
}
