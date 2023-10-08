namespace EmployeeApplication.Models
{
    public class ErrorResponseModel
    {
        public object Error { get; set; }
        public string Message { get; set; }
        public bool Status { get; set; }
    }
}