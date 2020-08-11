using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace SwissLocations
{
    public static class StringExtension
    {
        public static bool MatchWildcard(this string s, string pattern)
        {
            var p = "^" + Regex.Escape(pattern).Replace("\\*", ".*").Replace("\\?", ".") + "$";
            return Regex.IsMatch(s, p, RegexOptions.IgnoreCase);
        }

    }
}
