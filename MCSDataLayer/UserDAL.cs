using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCSDataLayer
{
    public  class UserDAL
    {
        public DataTable GetAllUsers(string cmdtxt)
        {
            return SqlHelper.ExecuteDataTable(cmdtxt);
        }
    }
}
