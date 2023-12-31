namespace domain.shared.Extensions
{
    public static class ByteExtensions
    {
        public static string ToBase64String(this byte[] byteArray) => Convert.ToBase64String(byteArray);
    }
}
