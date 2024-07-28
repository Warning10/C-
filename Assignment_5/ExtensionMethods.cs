using System.Linq;
using System.Text;

namespace Assignment_5
{
    public static class ExtensionMethods
    {
        public static string ToTitleCase(this string str)
        {
            if (string.IsNullOrWhiteSpace(str))
                return str;

            StringBuilder result = new StringBuilder();
            string[] words = str.Split(' ');
            foreach (string word in words)
            {
                if (word.Length > 0)
                {
                    result.Append(char.ToUpper(word[0]));
                    if (word.Length > 1)
                    {
                        result.Append(word.Substring(1).ToLower());
                    }
                }
                result.Append(' ');
            }
            return result.ToString().Trim();
        }

        public static string RemoveVowels(this string str)
        {
            if (string.IsNullOrWhiteSpace(str))
                return str;

            StringBuilder result = new StringBuilder();
            foreach (char c in str)
            {
                if (!"aeiouAEIOU".Contains(c))
                {
                    result.Append(c);
                }
            }
            return result.ToString();
        }

        public static bool IsWithinRange(this int? value, int min, int max)
        {
            if (!value.HasValue)
                return false;
            return value.Value >= min && value.Value <= max;
        }
    }
}
