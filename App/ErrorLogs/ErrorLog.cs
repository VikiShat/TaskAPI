using TaskAPI.Shared.BaseAbstractions;

namespace TaskAPI.App.ErrorLogs;

public class ErrorLog :  BaseEntity
{
    public string ErrorMessage { get; set; }

    public string StackTrace { get; set; }

    public DateTime DateOccurred { get; set; }

    public string Path { get; set; }

    public string QueryString { get; set; }

    public string Method { get; set; }  

    public ErrorLog(string errorMessage, string stackTrace, DateTime dateOccurred, string path, string queryString, string method)
    {
        ErrorMessage = errorMessage;
        StackTrace = stackTrace;
        DateOccurred = dateOccurred;
        Path = path;
        QueryString = queryString;
        Method = method;
    }
 
}