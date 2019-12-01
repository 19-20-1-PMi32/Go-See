using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GS.WebAPI.Parameters.Validation
{
    internal static class ValidationErrors
    {
        public static string Required => "Please ensure you have filled all required fields";

        public static string ValueTooLong => "Maximum allowed length of {PropertyName} is {MaxLength}";

        public static string EmailNotValid => "{PropertyValue} is not a valid email address";

        public static string PhoneNotValid => "{PropertyValue} is not a valid phone number";
    }
}
