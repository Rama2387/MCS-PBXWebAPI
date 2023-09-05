using MCSLogging;
using System.Text;

namespace MCS_PBXWebAPI.Common
{
    public class ErrorHandler
    {
        private readonly RequestDelegate _next;
        public ErrorHandler(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next.Invoke(context);
            }
            catch (Exception ex)
            {
                StringBuilder errorMsg = new StringBuilder();
                errorMsg.Append(string.Format("Exception :" + ex.Message
                                                + Environment.NewLine + "Inner Exception (1) : {0}"
                                                + Environment.NewLine + "Inner Exception (2) : {1}"
                                                + Environment.NewLine + "Inner Exception (3) : {2}"
                                                , ex.InnerException != null ? ex.InnerException.Message + Environment.NewLine + ex.InnerException.StackTrace : ""
                                                , ex.InnerException != null && ex.InnerException.InnerException != null ? ex.InnerException.Message + Environment.NewLine + ex.InnerException.StackTrace : ""
                                                , ex.InnerException != null && ex.InnerException.InnerException != null && ex.InnerException.InnerException != null ? ex.InnerException.Message + Environment.NewLine + ex.InnerException.StackTrace : ""));
                LoggingHelper.LogError(new AppLog()
                {
                    FileName = ex.TargetSite.DeclaringType.Name,
                    MethodName = ex.TargetSite.Name,
                    Description = ex.StackTrace,
                    ErrorMessage = errorMsg.ToString(),
                    UserID = "SYSTEM"
                });
            }
        }
    }
}
