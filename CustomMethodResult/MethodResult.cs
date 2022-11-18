namespace CustomMethodResult
{
    public class MethodResult<T>:IMethodResult<T>
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }

        public MethodResult(bool success = false)
        {
            Success = success;
        }

        public MethodResult(string message, bool success = false) : this(success)
        {
            Message = message;
        }
        public MethodResult(T data, string message = null, bool success = false) : this(message, success)
        {
            Data = data;
        }
    }
}
