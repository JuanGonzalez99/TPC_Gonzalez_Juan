using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public abstract class baseDAO
    {
        public virtual string Coneccion
        {
            get
            {
                return "data source=localhost\\SQLEXPRESS; initial catalog=DB_Gonzalez_Juan; integrated security=sspi";
            }
        }
        public abstract void Insert();
        public abstract void Update();
        public abstract void Delete();
        public abstract DataSet GetAll();
    }
}
