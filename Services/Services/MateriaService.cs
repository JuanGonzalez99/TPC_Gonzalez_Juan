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
    public class MateriaService : baseService
    {
        public List<Materia> GetList()
        {
            MateriaDAO dao = new MateriaDAO();
            DataSet ds = dao.GetAll();

            List<Materia> lList = new List<Materia>();

            foreach (DataRow lRow in ds.Tables[0].Rows)
            {
                lList.Add(Make(lRow, false));
            }

            return lList;
        }

        private Materia Make(DataRow dataRow, bool complete)
        {
            Materia entidad = new Materia();

            entidad.ID = (int)dataRow["CD_MATERIA"];
            entidad.Nombre = (string)dataRow["NOMBRE"];
            
            if (complete) { }

            return entidad;
        }
    }
}
