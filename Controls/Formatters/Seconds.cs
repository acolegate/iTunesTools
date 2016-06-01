using System;

namespace CustomControls.Formatters
{
    public class Seconds : IFormatProvider, ICustomFormatter
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
            return FormatSeconds(Convert.ToInt64(arg));
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

        /// <summary>Formats the seconds.</summary>
        /// <param name="seconds">The seconds.</param>
        /// <returns></returns>
        private static string FormatSeconds(long seconds)
        {
            TimeSpan timeSpan = TimeSpan.FromSeconds(seconds);

            return timeSpan.Hours > 0 ? string.Format("{0}:{1:mm}:{1:ss}", timeSpan.Hours, timeSpan) : (timeSpan.Minutes > 0 ? string.Format("{0}:{1:ss}", timeSpan.Minutes, timeSpan) : string.Format("0:{0:ss}", timeSpan));
        }
    }
}
