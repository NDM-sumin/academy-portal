using System.Text.Json.Serialization;

namespace domain.shared.AppSettings
{
    public class VNPayConfiguration
    {
        [JsonPropertyName("vnp_Version")]
        public string Vnp_Version { get; set; } = null!;
        [JsonPropertyName("vnp_TmnCode")]
        public string Vnp_TmnCode { get; set; } = null!;
        [JsonPropertyName("url")]
        public string Url { set; get; } = null!;
        [JsonPropertyName("hashSecret")]
        public string HashSecret { get; set; } = null!;
        [JsonPropertyName("vnp_ReturnUrl")]
        public string Vnp_ReturnUrl { get; set; } = null!;
        [JsonPropertyName("vnp_CurrCode")]
        public string Vnp_CurrCode { get; set; } = null!;
        [JsonPropertyName("vnp_Locale")]
        public string Vnp_Locale { get; set; } = null!;
        [JsonPropertyName("vnp_OrderType")]
        public string Vnp_OrderType { get; set; } = null!;

        [JsonPropertyName("expireMinutes")]
        public int ExpireMinutes { get; set; }
    }
}
