﻿namespace domain.shared.Exceptions
{
    public class ForbidenException : AppException
    {
        public ForbidenException(int code, Exception? innerException = null)
            : base(code, innerException)
        {
        }

        public ForbidenException(Exception? innerException = null)
            : base(5, innerException)
        {
        }

        public ForbidenException(string message, Exception? innerException = null)
            : base(5, message, innerException)
        {
        }
    }
}