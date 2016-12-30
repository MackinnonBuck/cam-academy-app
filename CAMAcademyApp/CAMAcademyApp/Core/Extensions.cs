using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CAMAcademyApp.Core
{
    public static class Extensions
    {
        /// <summary>
        /// Converts a regular string to title case.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ToTitleCase(this string value)
        {
            return Regex.Replace(value, @"(?<=\w)\w", new MatchEvaluator(v => v.Value.ToLower()));
        }
    }
}
