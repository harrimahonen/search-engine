using System;
using System.Text;
using System.Linq;
using System.Globalization;

namespace search_engine
{
    public static class StringProcessor
    {
        public static string RemoveDiacritics(string text)
        {
            var normalizedString = text.Normalize(NormalizationForm.FormD);
            var stringBuilder = new StringBuilder();

            foreach (var c in normalizedString)
            {
                var unicodeCategory = CharUnicodeInfo.GetUnicodeCategory(c);
                if (unicodeCategory != UnicodeCategory.NonSpacingMark)
                {
                    stringBuilder.Append(c);
                }
            }

            return stringBuilder.ToString().Normalize(NormalizationForm.FormC);
        }

        public static string RemoveSpecialCharacters(this string str)
        {
            StringBuilder sb = new StringBuilder();
            foreach (char c in str)
            {
                if (char.IsLetter(c) || c == ' ')
                {
                    sb.Append(c);
                }
            }
            return sb.ToString();
        }
        public static string FilterWhiteSpaces(string input)
        {
            if (input == null)
                return string.Empty;

            StringBuilder stringBuilder = new StringBuilder(input.Length);
            for (int i = 0; i < input.Length; i++)
            {
                char c = input[i];
                if (i == 0 || c != ' ' || (c == ' ' && input[i - 1] != ' '))
                    stringBuilder.Append(c);
            }
            return stringBuilder.ToString();
        }
    }
}