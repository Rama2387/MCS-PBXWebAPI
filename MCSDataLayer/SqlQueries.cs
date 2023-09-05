using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCSDataLayer
{
    public class SqlQueries
    {
        public static string GET_ALL_MEMBERS = @"SELECT MEMBERID,MEMBERNAME FROM tblMemberMaster";
        public static string GET_ALL_USERS = @"SELECT Username,Password FROM LoginRequest";
    }
}
