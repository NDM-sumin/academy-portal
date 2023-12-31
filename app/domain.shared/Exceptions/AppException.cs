using domain.shared.Exceptions.Error;

namespace domain.shared.Exceptions
{
    [Serializable]
    public abstract class AppException : Exception
    {
        public int Code { get; set; }

        public AppException(string message, Exception? innerException = null)
            : base(message, innerException)
        {
            Code = 1;
        }

        public AppException(int code, string message, Exception? innerException = null)
            : base(message, innerException)
        {
            Code = code;
        }

        public AppException(int code, Exception? innerException = null)
            : this(code, AppError.Instance.GetErrorMessage(code), innerException)
        {
        }
    }
}