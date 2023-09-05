using MCSBusinessLayer.Interfaces;
using MCSDataLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCSBusinessLayer
{
    public class UserBO:IUserBO
    {
        public readonly UserDAL userDAL;
        public UserBO()
        {
                userDAL = new UserDAL();    
        }
        public DataTable GetAllUsers(string cmdtext)
        {
            return userDAL.GetAllUsers(cmdtext);
        }
    }
}
