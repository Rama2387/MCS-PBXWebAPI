using MCSDataLayer;
using Serilog;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCSLogging
{
    public static class LoggingHelper
    {
        //For DB and also textfile

        public static void LogError(AppLog appLog)
        {

            StringBuilder sb = new StringBuilder();
            sb.Append(string.Format("...Log Start..."
                                    + Environment.NewLine + "File Name : " + appLog.FileName
                                    + Environment.NewLine + "Method Name : " + appLog.MethodName
                                    + Environment.NewLine + "Description : " + appLog.Description
                                    + Environment.NewLine + "Message : " + appLog.Message
                                    + Environment.NewLine + "Error Message : " + appLog.ErrorMessage
                                    + Environment.NewLine + "Line Number : " + appLog.LineNumber
                                    + Environment.NewLine + "User ID : " + appLog.UserID
                                    + Environment.NewLine + "... Log End ... "
                                    ));
            List<InputParam> inputParams = new List<InputParam>
            {
                new InputParam{ ParamName = "OBJ_NAME", ParamType = SqlDbType.VarChar ,ParamValue = "ERROR"  },
                new InputParam{ ParamName = "ERR_MSG", ParamType = SqlDbType.VarChar ,ParamValue = appLog.ErrorMessage  },
                new InputParam{ ParamName = "USER_ID", ParamType = SqlDbType.VarChar ,ParamValue = appLog.UserID  }

                };
            SqlHelper.ExecuteDataTable("SP_LOG_EXCPTION", inputParams, "SP");
            Log.Error(sb.ToString());

        }


        //For DB and also textfile
        public static void LogInfo(AppLog appLog)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(string.Format("...Log Start..."
                                    + Environment.NewLine + "File Name : " + appLog.FileName
                                    + Environment.NewLine + "Method Name : " + appLog.MethodName
                                    + Environment.NewLine + "Description : " + appLog.Description
                                    + Environment.NewLine + "Message : " + appLog.Message
                                    + Environment.NewLine + "Error Message : " + appLog.ErrorMessage
                                    + Environment.NewLine + "Line Number : " + appLog.LineNumber
                                    + Environment.NewLine + "User ID : " + appLog.UserID
                                    + Environment.NewLine + "... Log End ... "
                                    ));
            List<InputParam> inputParams = new List<InputParam>
            {
                new InputParam{ ParamName = "OBJ_NAME", ParamType = SqlDbType.VarChar ,ParamValue = "INFORMATION"  },
                new InputParam{ ParamName = "ERR_MSG", ParamType = SqlDbType.VarChar ,ParamValue = appLog.ErrorMessage  },
                new InputParam{ ParamName = "USER_ID", ParamType = SqlDbType.VarChar ,ParamValue = appLog.UserID  }

            };
            SqlHelper.ExecuteDataTable("SP_LOG_EXCPTION", inputParams, "SP");
            Log.Information(sb.ToString());
        }
    }
}
