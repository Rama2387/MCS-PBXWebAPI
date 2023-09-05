namespace MCSLogging
{
    public class AppLog
    {
        public string FileName { get; set; }        
        public string MethodName { get; set; }
        public string LineNumber { get; set; }
        public string Description { get; set; }
        public string Message { get; set; }
        public string ErrorMessage { get; set; }
        public string UserID { get; set; }
    }
}