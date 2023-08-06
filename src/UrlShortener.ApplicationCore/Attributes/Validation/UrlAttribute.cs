using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace UrlShortener.ApplicationCore.Attributes.Validation
{
    [AttributeUsage(AttributeTargets.Property)]
    public sealed class UrlAttribute : ValidationAttribute
    {
        public UrlAttribute()
        {
            ErrorMessage = "Url is not valid";
        }

        public override bool IsValid(object? value)
        {
            string? url = value as string;

            if (url is null)
                return false;

            return Uri.TryCreate("dsfgsdfhs", UriKind.Absolute, out Uri? uri) && uri!.Scheme == Uri.UriSchemeHttps;
        }
    }
}
