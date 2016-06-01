using System.Collections.Generic;

namespace CustomControls.ExtensionMethods
{
    public static class ListExtensionMethods
    {
        public static bool IsMultiple<T>(this IEnumerable<T> source)
        {
            IEnumerator<T> enumerator = source.GetEnumerator();
            return enumerator.MoveNext() && enumerator.MoveNext();
        }
    }
}
