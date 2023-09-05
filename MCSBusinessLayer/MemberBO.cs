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
    public class MemberBO : IMemberBO
    {
        private readonly MemberDAL memberDAL;
        public MemberBO() 
        {
            memberDAL = new MemberDAL();
        }
        public DataTable GetAllMembers(string cmdtxt)
        {
            return memberDAL.GetAllMembers(cmdtxt);
        }
    }
}
