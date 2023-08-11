using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Encodings.Web;

namespace Xem.Api.Extensions
{
    public static class StringExtensions
    {
        public static string AddQueryValues(this string path, IDictionary<string, string> values)
        {
            if (path == null)
            {
                throw new ArgumentNullException(nameof(path));
            }

            if (values == null)
            {
                throw new ArgumentNullException(nameof(values));
            }

            var num = path.IndexOf('#');
            var text = path;
            var value = "";
            if (num != -1)
            {
                value = path.Substring(num);
                text = path.Substring(0, num);
            }

            var flag = text.IndexOf('?') != -1;
            var stringBuilder = new StringBuilder();
            stringBuilder.Append(text);
            foreach (KeyValuePair<string, string> item in values)
            {
                stringBuilder.Append(flag ? '&' : '?');
                stringBuilder.Append(UrlEncoder.Default.Encode(item.Key));
                stringBuilder.Append('=');
                stringBuilder.Append(UrlEncoder.Default.Encode(item.Value));
                flag = true;
            }

            stringBuilder.Append(value);
            return stringBuilder.ToString();
        }
    }
}
