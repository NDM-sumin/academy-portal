using domain;
using domain.shared.AppSettings;
using domain.shared.Constants;
using service.contract.DTOs.VNPay;
using service.contract.IAppServices;
using service.contract.IAppServices.Base;
using System.Net;
using System.Reflection;
using System.Text;
using System.Text.Json.Serialization;

namespace service.AppServices
{
    public class VNPayService : IVnPayService
    {
        SortedList<string, string> sortedRequestParams = new SortedList<string, string>(new VnPayCompare());
        readonly VNPayConfiguration vnPayConfig;
        public VNPayService(VNPayConfiguration vnPayConfig)
        {
            this.vnPayConfig = vnPayConfig;
            AddDefaultRequestParams();
            sortedRequestParams.Add(VNPayConstants.Key.Command, VNPayConstants.Value.Command);

        }
        public IVnPayService InitRequestParams(string customerIpAddress, out string transactionId)
        {
            //sortedRequestParams.Add(VNPayConstants.Key.BankCode, bankCode.ToString());
            sortedRequestParams.Add(VNPayConstants.Key.IpAddress, customerIpAddress);
            transactionId = DateTime.Now.Ticks.ToString();
            sortedRequestParams.Add(VNPayConstants.Key.TxnRef, transactionId);
            return this;
        }
        public string CreateRequestUrl(CreatePayUrlDto createPayUrlDto, out string secureHash)
        {

            sortedRequestParams.Add(VNPayConstants.Key.Amount, (createPayUrlDto.Amount * 100).ToString("0"));
            sortedRequestParams.Add(VNPayConstants.Key.OrderInfo, createPayUrlDto.OrderInfo);
            DateTime createdAt = DateTime.Now;
            DateTime expire = createdAt.Add(TimeSpan.FromMinutes(createPayUrlDto.Expires));
            sortedRequestParams.Add(VNPayConstants.Key.CreateDate, createdAt.ToString("yyyyMMddHHmmss"));
            sortedRequestParams.Add(VNPayConstants.Key.ExpireDate, expire.ToString("yyyyMMddHHmmss"));
            var queryString = GetQueryStringFromRequestParams();
            secureHash = HashQueryString(queryString.ToString());

            return $"{vnPayConfig.Url}?{queryString}{secureHash}";
        }

        void AddDefaultRequestParams()
        {
            var properties = typeof(VNPayConfiguration).GetProperties();
            foreach (var item in properties)
            {
                if (!item.Name.StartsWith("Vnp_")) continue;
                var jsonName = item.GetCustomAttribute<JsonPropertyNameAttribute>(false).Name;
                sortedRequestParams.Add(jsonName, item.GetValue(vnPayConfig).ToString());
            }
        }

        StringBuilder GetQueryStringFromRequestParams()
        {
            StringBuilder data = new();
            foreach (KeyValuePair<string, string> kv in sortedRequestParams)
            {
                if (!string.IsNullOrEmpty(kv.Value))
                {
                    data.Append(WebUtility.UrlEncode(kv.Key) + "=" + WebUtility.UrlEncode(kv.Value) + "&");
                }
            }
            return data;
        }

        string HashQueryString(string queryString)
        {
            string signData = queryString.ToString();
            if (signData.Length > 0)
            {
                signData = signData.Remove(signData.Length - 1, 1);
            }
            string secureHash = VNPayHelper.HmacSHA512(vnPayConfig.HashSecret, signData);
            return secureHash;
        }
    }
}
