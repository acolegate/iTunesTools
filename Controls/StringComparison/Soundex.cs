/*
using System;
using System.Linq;
using System.Text;

namespace CustomControls.StringComparison
{
    /// <summary>
    /// Classic soundex algorithm
    /// </summary>
    public static class Soundex
    {
        //  ABCDEFGHIJKLMNOPQRSTUVWXYZ
        private const int EncodingLength = 30;
        private const string Values = "01230120022455012623010202";

        /// <summary>
        /// Soundex-encodes the given text
        /// </summary>
        /// <param name="text">Text to be encoded</param>
        /// <returns></returns>
        public static string Encode(string text)
        {
            char prevChar = ' ';

            // Normalize input
            text = Normalize(text);
            if (text.Length == 0)
            {
                return text;
            }

            // Write result to StringBuilder
            StringBuilder builder = new StringBuilder();
            builder.Append(text[0]);
            for (int i = 1; i < text.Length && builder.Length < EncodingLength; i++)
            {
                // Get digit for this letter
                char c = Values[text[i] - 'A'];

                // Add if not zero or same as last character
                if (c != '0' && c != prevChar)
                {
                    builder.Append(c);
                    prevChar = c;
                }
            }

            // Pad with trailing zeros
            while (builder.Length < EncodingLength)
            {
                builder.Append('0');
            }

            // Return result
            return builder.ToString();
        }

        private static string RemoveDiacritics(string accentedStr)
        {
            return Encoding.UTF8.GetString(Encoding.GetEncoding("ISO-8859-8").GetBytes(accentedStr));
        }

        /// <summary>
        /// Normalizes the given string by removing characters
        /// that are not letters and converting the result to
        /// upper case.
        /// </summary>
        /// <param name="text">Text to be normalized</param>
        /// <returns></returns>
        private static string Normalize(string text)
        {
            StringBuilder builder = new StringBuilder();
            foreach (char c in text.Where(Char.IsLetter))
            {
                builder.Append(Char.ToUpper(c));
            }
            return RemoveDiacritics(builder.ToString());
        }
    }
}
*/