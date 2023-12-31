using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace domain.shared.Constants
{
    public static class HashContanst
    {
        public const int NUM_BYTES_REQUESTED = 256 / 8;
        public const int ITERATION_COUNT = 10000;
        public const KeyDerivationPrf ALGORITHM = KeyDerivationPrf.HMACSHA256;

    }
}
