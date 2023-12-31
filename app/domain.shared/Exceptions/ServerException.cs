namespace domain.shared.Exceptions
{
    [Serializable]
    public class ServerException : AppException
    {
        public ServerException(int code, Exception? innerException = null)
            : base(code, innerException)
        {
        }

        public ServerException(Exception? innerException = null)
            : base(1, innerException)
        {
        }

        public ServerException(string message, Exception? innerException = null)
            : base(1, message, innerException)
        {
        }
    }
}