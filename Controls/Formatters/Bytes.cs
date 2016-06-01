using System;

namespace CustomControls.Formatters
{
    public class Bytes : IFormatProvider, ICustomFormatter
    {
        /// <summary>
        /// Converts the value of a specified object to an equivalent string representation using specified format and culture-specific formatting information.
        /// </summary>
        /// <param name="format">A format string containing formatting specifications.</param>
        /// <param name="arg">An object to format.</param>
        /// <param name="formatProvider">An object that supplies format information about the current instance.</param>
        /// <returns>
        /// The string representation of the value of <paramref name="arg" />, formatted as specified by <paramref name="format" /> and <paramref name="formatProvider" />.
        /// </returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public string Format(string format, object arg, IFormatProvider formatProvider)
        {
            return FormatBytes(Convert.ToInt64(arg));
        }

        /// <summary>Returns an object that provides formatting services for the specified type.</summary>
        /// <param name="formatType">An object that specifies the type of format object to return.</param>
        /// <returns>
        /// An instance of the object specified by <paramref name="formatType" />, if the <see cref="T:System.IFormatProvider" /> implementation can supply that type of object; otherwise, null.
        /// </returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public object GetFormat(Type formatType)
        {
            return formatType == typeof(ICustomFormatter) ? this : null;
        }

        private static string FormatBytes(long bytes)
        {
            string[] orders = { "GB", "MB", "KB", "Bytes" };
            long max = (long)Math.Pow(1024, orders.Length - 1);
            foreach (string order in orders)
            {
                if (bytes > max)
                {
                    return string.Format("{0:#.#} {1}", decimal.Divide(bytes, max), order);
                }
                max /= 1024;
            }
            return "0 Bytes";
        }
    }
}
