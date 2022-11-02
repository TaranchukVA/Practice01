namespace Exercise1
{
    public class MethodResult : IMethodResult
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }

        public MethodResult(bool success = false)
        {
            Success = success;
        }

        public MethodResult(string message, bool success = false) : this(success)
        {
            Message = message;
        }
        public MethodResult(object data, string message = null, bool success = false) : this(message, success)
        {
            Data = data;
        }
    }
}
