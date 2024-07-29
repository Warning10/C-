using System;
using System.Text.RegularExpressions;

namespace EventManagementSystem.Validations
{
    public static class Validator
    {
        public static bool TryParseDate(string input, out DateTime date)
        {
            return DateTime.TryParse(input, out date) && date >= DateTime.Today;
        }

        public static bool TryParseInt(string input, out int result)
        {
            return int.TryParse(input, out result) && result > 0;
        }

        public static bool IsValidEmail(string email)
        {
            return Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
        }

        public static bool IsValidTitle(string title)
        {
            if (string.IsNullOrWhiteSpace(title)) return false;

            // Replace multiple spaces with a single space
            title = Regex.Replace(title, @"\s+", " ");

            // Check if there are any leading or trailing spaces
            if (title.StartsWith(" ") || title.EndsWith(" ")) return false;

            return true;
        }

        public static string NormalizeTitle(string title)
        {
            return Regex.Replace(title, @"\s+", " ").Trim();
        }
    }
}
