using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Text;
using domain.shared.Constants;
using domain.shared.Extensions;

namespace service.AppServices
{
    public class HashService
    {
        private readonly byte[] _salt;
        private readonly string _encryptedPassword;
        public string EncryptedPassword { get { return _encryptedPassword; } }
        public HashService(string password, string saltString)
        {
            _salt = Encoding.UTF8.GetBytes(saltString);
            _encryptedPassword = EncryptPassword(password, _salt);
        }
        private static string EncryptPassword(string password, byte[] salt)
        {
            string encryptedPass = GetKeyDerivation(password, salt, HashContanst.ALGORITHM, HashContanst.ITERATION_COUNT, HashContanst.NUM_BYTES_REQUESTED).ToBase64String();
            return encryptedPass;
        }
        private static byte[] GetKeyDerivation(string password, byte[] salt, KeyDerivationPrf algorithm, int iterationCount, int numByteRequested)
        {
            return KeyDerivation.Pbkdf2(
                 password: password,
                 salt: salt,
                 prf: algorithm,
                 iterationCount: iterationCount,
            numBytesRequested: numByteRequested
             );
        }
        public bool IsPassed(string storedPassword) => _encryptedPassword == storedPassword;
    }
}
