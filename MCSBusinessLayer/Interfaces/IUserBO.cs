using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCSBusinessLayer.Interfaces
{
    public interface IUserBO
    {
        public DataTable GetAllUsers(string cmdtxt);

    }
}
