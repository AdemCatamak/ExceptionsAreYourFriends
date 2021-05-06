namespace ServiceWithOperationResult
{
    public class OperationResult<T>
    {
        public T Result { get; private set; }
        public bool Succeed { get; private set; }
        public string ErrorCode { get; private set; }

        public OperationResult(T result)
        {
            Result = result;
            Succeed = true;
        }

        public OperationResult(string errorCode)
        {
            ErrorCode = errorCode;
            Succeed = false;
        }
    }
}