using System.Data;

namespace MCSBusinessLayer.Interfaces
{
    public interface IMemberBO
    {
        public DataTable GetAllMembers(string cmdtxt);
    }
}