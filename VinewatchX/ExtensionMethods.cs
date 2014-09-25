using System;
using System.Text;

namespace VinewatchX
{
    public static class ExtensionMethods
    {
        public static bool Contains(this string source, string toCheck, StringComparison comp)
        {
            return source.IndexOf(toCheck, comp) >= 0;
        }

        static public string Replace(this string original, string pattern, string replacement, StringComparison comparisonType) {
            return Replace(original, pattern, replacement, comparisonType, -1);
        }

        static public string Replace(this string original, string pattern, string replacement, StringComparison comparisonType, int stringBuilderInitialSize) {
            if (original == null) {
                return null;
            }

            if (String.IsNullOrEmpty(pattern)) {
                return original;
            }


            int posCurrent = 0;
            int lenPattern = pattern.Length;
            int idxNext = original.IndexOf(pattern, comparisonType);
            StringBuilder result = new StringBuilder(stringBuilderInitialSize < 0 ? Math.Min(4096, original.Length) : stringBuilderInitialSize);

            while (idxNext >= 0) {
                result.Append(original, posCurrent, idxNext - posCurrent);
                result.Append(replacement);

                posCurrent = idxNext + lenPattern;

                idxNext = original.IndexOf(pattern, posCurrent, comparisonType);
            }

            result.Append(original, posCurrent, original.Length - posCurrent);

            return result.ToString();
        }
    }
}
