using domain.shared.Extensions;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace domain.shared.Attributes
{
    public class PhoneNumberAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value == null)
            {
                return true;
            }

            string? mobile = value.ToString();
            if (mobile.IsNullOrEmpty())
            {
                return true;
            }
            return Regex.IsMatch(mobile, @"^\d+$");
        }
    }
}
