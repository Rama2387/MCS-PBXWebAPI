using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCSDataLayer
{
    public class InputParam
    {
        public string? ParamName { get; set; }
        public SqlDbType ParamType { get; set; }
        public string? ParamValue { get; set; }
        public string? TableType { get; set; }
    }
}
