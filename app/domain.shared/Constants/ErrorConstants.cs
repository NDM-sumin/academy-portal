namespace domain.shared.Constants
{
    public class ErrorConstants
    {

        public const string DEFAULT_ERROR_MSG = "An error has occured";
        public static readonly string ERROR_LOG_PATH = Path.Combine(Directory.GetCurrentDirectory(), "Log", "log.txt");
    }
}
