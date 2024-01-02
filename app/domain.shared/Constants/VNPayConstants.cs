using System.Globalization;
using System.Net;
using System.Security.Cryptography;
using System.Text;

namespace domain.shared.Constants
{
    public sealed class VnPayCompare : IComparer<string>
    {
        public int Compare(string x, string y)
        {
            if (x == y) return 0;
            if (x == null) return -1;
            if (y == null) return 1;
            var vnpCompare = CompareInfo.GetCompareInfo("en-US");
            return vnpCompare.Compare(x, y, CompareOptions.Ordinal);
        }
    }
    public static class VNPayHelper
    {
        public static string HmacSHA512(string key, string input)
        {
            var hash = new StringBuilder();
            byte[] keyBytes = Encoding.UTF8.GetBytes(key);
            byte[] inputBytes = Encoding.UTF8.GetBytes(input);
            using (var hmac = new HMACSHA512(keyBytes))
            {
                byte[] hashValue = hmac.ComputeHash(inputBytes);
                foreach (var theByte in hashValue)
                {
                    hash.Append(theByte.ToString("x2"));
                }
            }

            return hash.ToString();
        }
        public static bool ValidateSignature(IDictionary<string, string> queryString, string secretKey)
        {
            string secureHash = queryString[VNPayConstants.Key.SecureHash];
            string rspRaw = GetResponseData(queryString);
            string myChecksum = HmacSHA512(secretKey, rspRaw);
            return myChecksum.Equals(secureHash, StringComparison.InvariantCultureIgnoreCase);
        }
        private static string GetResponseData(IDictionary<string, string> queryString)
        {
            SortedList<string, string> sortedResponse = new SortedList<string, string>(new VnPayCompare());
            foreach (var s in queryString)
            {
                if (!string.IsNullOrEmpty(s.Value) && s.Key.StartsWith("vnp_"))
                {
                    sortedResponse.Add(s.Key, s.Value);
                }
            }
            StringBuilder data = new StringBuilder();
            if (sortedResponse.ContainsKey("vnp_SecureHashType"))
            {
                sortedResponse.Remove("vnp_SecureHashType");
            }
            if (sortedResponse.ContainsKey("vnp_SecureHash"))
            {
                sortedResponse.Remove("vnp_SecureHash");
            }
            foreach (KeyValuePair<string, string> kv in sortedResponse)
            {
                if (!String.IsNullOrEmpty(kv.Value))
                {
                    data.Append(WebUtility.UrlEncode(kv.Key) + "=" + WebUtility.UrlEncode(kv.Value) + "&");
                }
            }
            //remove last '&'
            if (data.Length > 0)
            {
                data.Remove(data.Length - 1, 1);
            }
            return data.ToString();
        }
    }

    public class VNPayConstants
    {
        public static class Key
        {
            public const string Command = "vnp_Command";
            public const string BankCode = "vnp_BankCode";
            public const string IpAddress = "vnp_IpAddr";
            public const string CreateDate = "vnp_CreateDate";
            public const string ExpireDate = "vnp_ExpireDate";
            public const string TxnRef = "vnp_TxnRef"; //Mã giao dịch
            public const string Amount = "vnp_Amount";
            public const string OrderInfo = "vnp_OrderInfo";
            public const string SecureHash = "vnp_SecureHash";
        }
        public static class Value
        {
            public const string Command = "pay";
        }
    }
}
