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
        public virtual string CadenaConeccion
        {
            get
            {
                return "data source=(local); initial catalog=GONZALEZ_JUAN_DB; integrated security=sspi";
            }
        }
        public abstract void Insert();
        public abstract void Update();
        public abstract void Delete();
        //public abstract DataSet GetAll();
    }
}
