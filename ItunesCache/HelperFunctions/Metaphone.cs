using System;
using System.Linq;
using System.Text;

namespace ItunesCache.HelperFunctions
{
    /// <summary>Implements the Metaphone algorithm</summary>
    internal static class Metaphone
    {
        // Constants
        private const int MaxEncodedLength = 30;
        private const char NullChar = (char)0;
        private const string Vowels = "AEIOU";

        // For tracking position within current string

        /// <summary>Encodes the given text using the Metaphone algorithm.</summary>
        /// <param name="text">The text.</param>
        /// <returns></returns>
        public static string Encode(string text)
        {
            // Process normalized text

            text = Normalize(text);
            int pos = 0;

            // Write encoded string to StringBuilder
            StringBuilder builder = new StringBuilder();

            // Special handling of some string prefixes:
            //     PN, KN, GN, AE, WR, WH and X
            switch (Peek(text, pos))
            {
                case 'P':
                case 'K':
                case 'G':
                    if (Peek(text, pos, 1) == 'N')
                    {
                        MoveAhead(text, ref pos);
                    }
                    break;

                case 'A':
                    if (Peek(text, pos, 1) == 'E')
                    {
                        MoveAhead(text, ref pos);
                    }
                    break;

                case 'W':
                    if (Peek(text, pos, 1) == 'R')
                    {
                        MoveAhead(text, ref pos);
                    }
                    else if (Peek(text, pos, 1) == 'H')
                    {
                        builder.Append('W');
                        MoveAhead(text, ref pos, 2);
                    }
                    break;

                case 'X':
                    builder.Append('S');
                    MoveAhead(text,ref  pos);
                    break;
            }

            //
            while (!(pos >= text.Length) && builder.Length < MaxEncodedLength)
            {
                // Cache this character
                char c = Peek(text, pos);

                // Ignore duplicates except CC
                if (c == Peek(text, pos, -1) && c != 'C')
                {
                    MoveAhead(text, ref pos);
                    continue;
                }

                // Don't change F, J, L, M, N, R or first-letter vowel
                if (IsOneOf(c, "FJLMNR") || (builder.Length == 0 && IsOneOf(c, Vowels)))
                {
                    builder.Append(c);
                    MoveAhead(text, ref pos);
                }
                else
                {
                    int charsConsumed = 1;

                    switch (c)
                    {
                        case 'B':
                            // B = 'B' if not -MB
                            if (Peek(text, pos, -1) != 'M' || Peek(text, pos, 1) != NullChar)
                            {
                                builder.Append('B');
                            }
                            break;

                        case 'C':
                            // C = 'X' if -CIA- or -CH-
                            // Else 'S' if -CE-, -CI- or -CY-
                            // Else 'K' if not -SCE-, -SCI- or -SCY-
                            if (Peek(text, pos, -1) != 'S' || !IsOneOf(Peek(text, pos, 1), "EIY"))
                            {
                                if (Peek(text, pos, 1) == 'I' && Peek(text, pos, 2) == 'A')
                                {
                                    builder.Append('X');
                                }
                                else if (IsOneOf(Peek(text, pos, 1), "EIY"))
                                {
                                    builder.Append('S');
                                }
                                else if (Peek(text, pos, 1) == 'H')
                                {
                                    if ((pos == 0 && !IsOneOf(Peek(text, pos, 2), Vowels)) || Peek(text, pos, -1) == 'S')
                                    {
                                        builder.Append('K');
                                    }
                                    else
                                    {
                                        builder.Append('X');
                                    }
                                    charsConsumed++; // Eat 'CH'
                                }
                                else
                                {
                                    builder.Append('K');
                                }
                            }
                            break;

                        case 'D':
                            // D = 'J' if DGE, DGI or DGY
                            // Else 'T'
                            if (Peek(text, pos, 1) == 'G' && IsOneOf(Peek(text, pos, 2), "EIY"))
                            {
                                builder.Append('J');
                            }
                            else
                            {
                                builder.Append('T');
                            }
                            break;

                        case 'G':
                            // G = 'F' if -GH and not B--GH, D--GH, -H--GH, -H---GH
                            // Else dropped if -GNED, -GN, -DGE-, -DGI-, -DGY-
                            // Else 'J' if -GE-, -GI-, -GY- and not GG
                            // Else K
                            if ((Peek(text, pos, 1) != 'H' || IsOneOf(Peek(text, pos, 2), Vowels)) && (Peek(text, pos, 1) != 'N' || (Peek(text, pos, 1) != NullChar && (Peek(text, pos, 2) != 'E' || Peek(text, pos, 3) != 'D'))) && (Peek(text, pos, -1) != 'D' || !IsOneOf(Peek(text, pos, 1), "EIY")))
                            {
                                if (IsOneOf(Peek(text, pos, 1), "EIY") && Peek(text, pos, 2) != 'G')
                                {
                                    builder.Append('J');
                                }
                                else
                                {
                                    builder.Append('K');
                                }
                            }
                            // Eat GH
                            if (Peek(text, pos, 1) == 'H')
                            {
                                charsConsumed++;
                            }
                            break;

                        case 'H':
                            // H = 'H' if before or not after vowel
                            if (!IsOneOf(Peek(text, pos, -1), Vowels) || IsOneOf(Peek(text, pos, 1), Vowels))
                            {
                                builder.Append('H');
                            }
                            break;

                        case 'K':
                            // K = 'C' if not CK
                            if (Peek(text, pos, -1) != 'C')
                            {
                                builder.Append('K');
                            }
                            break;

                        case 'P':
                            // P = 'F' if PH
                            // Else 'P'
                            if (Peek(text, pos, 1) == 'H')
                            {
                                builder.Append('F');
                                charsConsumed++; // Eat 'PH'
                            }
                            else
                            {
                                builder.Append('P');
                            }
                            break;

                        case 'Q':
                            // Q = 'K'
                            builder.Append('K');
                            break;

                        case 'S':
                            // S = 'X' if SH, SIO or SIA
                            // Else 'S'
                            if (Peek(text, pos, 1) == 'H')
                            {
                                builder.Append('X');
                                charsConsumed++; // Eat 'SH'
                            }
                            else if (Peek(text, pos, 1) == 'I' && IsOneOf(Peek(text, pos, 2), "AO"))
                            {
                                builder.Append('X');
                            }
                            else
                            {
                                builder.Append('S');
                            }
                            break;

                        case 'T':
                            // T = 'X' if TIO or TIA
                            // Else '0' if TH
                            // Else 'T' if not TCH
                            if (Peek(text, pos, 1) == 'I' && IsOneOf(Peek(text, pos, 2), "AO"))
                            {
                                builder.Append('X');
                            }
                            else if (Peek(text, pos, 1) == 'H')
                            {
                                builder.Append('0');
                                charsConsumed++; // Eat 'TH'
                            }
                            else if (Peek(text, pos, 1) != 'C' || Peek(text, pos, 2) != 'H')
                            {
                                builder.Append('T');
                            }
                            break;

                        case 'V':
                            // V = 'F'
                            builder.Append('F');
                            break;

                        case 'W':
                        case 'Y':
                            // W,Y = Keep if not followed by vowel
                            if (IsOneOf(Peek(text, pos, 1), Vowels))
                            {
                                builder.Append(c);
                            }
                            break;

                        case 'X':
                            // X = 'S' if first character (already done)
                            // Else 'KS'
                            builder.Append("KS");
                            break;

                        case 'Z':
                            // Z = 'S'
                            builder.Append('S');
                            break;
                    }
                    // Advance over consumed characters
                    MoveAhead(text, ref pos, charsConsumed);
                }
            }
            // Return result
            return builder.ToString();
        }

        /// <summary>
        /// Indicates if the specified character occurs within
        /// the specified string.
        /// </summary>
        /// <param name="c">Character to find</param>
        /// <param name="chars">String to search</param>
        /// <returns></returns>
        private static bool IsOneOf(char c, string chars)
        {
            return (chars.IndexOf(c) != -1);
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
            foreach (char c in text.Where(c => Char.IsLetter(c) || Char.IsNumber(c)))
            {
                builder.Append(Char.ToUpper(c));
            }
            return builder.ToString();
        }

        /// <summary>Returns the character at the specified position.</summary>
        /// <param name="text">The _text.</param>
        /// <param name="pos">The _pos.</param>
        /// <param name="ahead">Position to read relative
        /// to the current position.</param>
        /// <returns></returns>
        private static char Peek(string text, int pos, int ahead = 0)
        {
            pos = (pos + ahead);
            if (pos < 0 || pos >= text.Length)
            {
                return NullChar;
            }
            return text[pos];
        }

        /// <summary>
        /// Moves the current position ahead the specified number.
        /// of characters.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <param name="pos">The position.</param>
        /// <param name="count">Number of characters to move
        /// ahead.</param>
        private static void MoveAhead(string text, ref int pos, int count = 1)
        {
            pos = Math.Min(pos + count, text.Length);
        }
    }
}
