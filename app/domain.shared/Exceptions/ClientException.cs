namespace domain.shared.Exceptions
{
    [Serializable]
    public class ClientException : AppException
    {
        public ClientException(int code, Exception? innerException = null)
            : base(code, innerException)
        {
        }

        public ClientException(Exception? innerException = null)
            : base(3, innerException)
        {
        }

        public ClientException(string message, Exception? innerException = null)
            : base(3, message, innerException)
        {
        }
    }
}