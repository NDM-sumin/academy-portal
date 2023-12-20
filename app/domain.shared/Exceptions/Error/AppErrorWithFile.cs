using System.Text.Json.Serialization;
using System.Text.Json;
using domain.shared.Constants;

namespace domain.shared.Exceptions.Error
{
    public class AppErrorWithFile : AppError
    {

        public class ErrorModel
        {
            [JsonPropertyName("code")] public int Code { get; set; }
            [JsonPropertyName("message")] public string Message { get; set; } = null!;
        }

        static readonly string exceptionsStorePath = $"{Directory.GetCurrentDirectory()}/exceptions.json";
        static DateTime lastModifiedErrorFile;
        static ICollection<ErrorModel>? errors;

        ICollection<ErrorModel>? Errors
        {
            get
            {
                try
                {
                    DateTime lastModifiedErrorFile = File.GetLastWriteTime(exceptionsStorePath);
                    bool isNeedUpdate = errors == null || lastModifiedErrorFile > AppErrorWithFile.lastModifiedErrorFile;
                    if (isNeedUpdate)
                    {
                        AppErrorWithFile.lastModifiedErrorFile = lastModifiedErrorFile;
                        using FileStream fileReadStream = new(exceptionsStorePath, FileMode.Open, FileAccess.Read);
                        errors = JsonSerializer.Deserialize<List<ErrorModel>>(fileReadStream);
                    }

                    return errors;
                }
                catch (Exception)
                {
                    return null;
                }
            }
        }

        public override string GetErrorMessage(int code)
        {
            if (Errors is null || Errors.Count == 0) return ErrorConstants.DEFAULT_ERROR_MSG;
            bool predicate(ErrorModel errorModel) => errorModel.Code == code;
            bool isContainCode = Errors.Any(predicate);
            if (isContainCode)
            {
                return Errors.FirstOrDefault(predicate)!.Message;
            }

            return ErrorConstants.DEFAULT_ERROR_MSG;
        }
    }
}
