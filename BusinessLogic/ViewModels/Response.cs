namespace BusinessLogic.ViewModels

{
    public enum Status
    {
        Success = 0,
        Failure = 1,
        ValidationError = 2,
        // Thêm các giá trị khác tùy theo yêu cầu của ứng dụng
    }

    public class Response
    {
        public Status StatusCode { get; set; } 
        public string Message { get; set; }

        public Response( Status statusCode, string message)
        {
            StatusCode = statusCode;
            Message = message;
        }
    }
}
