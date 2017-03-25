using System.Text;
using System.Text.RegularExpressions;

namespace NS.Infrastructure.Extensions
{
    public static class StringExtensions
    {
        public static string ToUrlSlug(this string value)
        {
            value = value.ToLowerInvariant();

            var bytes = Encoding.GetEncoding("Cyrillic").GetBytes(value);

            value = Encoding.ASCII.GetString(bytes);

            value = Regex.Replace(value, @"\s", "-", RegexOptions.Compiled);

            value = Regex.Replace(value, @"[^a-z0-9\s-_]", "", RegexOptions.Compiled);

            value = value.Trim('-', '_');

            value = Regex.Replace(value, @"([-_]){2,}", "$1", RegexOptions.Compiled);

            return value;
        }

        public static string ShortenText(this string value, int length)
        {
            if (string.IsNullOrEmpty(value))
                return string.Empty;

            if (value.Length > length)
                return string.Format("{0}...", value.Substring(0, length));

            return value;
        }

        public static string RemoveHtml(this string value)
        {
            if (string.IsNullOrEmpty(value))
                return string.Empty;

            return Regex.Replace(value, @"<[^>]*>", string.Empty);
        }
    }
}
