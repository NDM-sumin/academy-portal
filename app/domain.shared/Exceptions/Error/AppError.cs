namespace domain.shared.Exceptions.Error
{
    public abstract class AppError
    {
        private static AppError? instance;

        public static AppError Instance
        {
            get
            {
                instance ??= new AppErrorWithFile();
                return instance;
            }
        }

        public abstract string GetErrorMessage(int code);
    }

   
}