using System.Data;

namespace MCSDataLayer
{
    public class MemberDAL
    {
        public DataTable GetAllMembers(string cmdtxt)
        {
            return SqlHelper.ExecuteDataTable(cmdtxt);
        }
    }
}