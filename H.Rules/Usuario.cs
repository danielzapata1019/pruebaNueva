using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace H.Rules
{
    public class Usuario: ClaseBase
    {
        public DataTable getUser()
        {
            SQLGet("");
            return Dtg;
        }
    }
}
