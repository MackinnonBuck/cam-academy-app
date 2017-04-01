using HtmlAgilityPack;
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
        /// Represents the values from a style HTML attribute.
        /// </summary>
        public class Stylesheet
        {
            /// <summary>
            /// The styles associated with the Stylesheet.
            /// </summary>
            public Dictionary<string, string> Styles { get; private set; }

            /// <summary>
            /// Initializes a new Stylesheet from the given style text.
            /// </summary>
            /// <param name="styleText"></param>
            public Stylesheet(string styleText)
            {
                Styles = new Dictionary<string, string>();

                foreach (string style in styleText.Split(';'))
                {
                    string[] keyvalue = style.Split(':');

                    if (keyvalue.Length == 2)
                        Styles[keyvalue[0]] = keyvalue[1];
                }
            }
        }

        /// <summary>
        /// Converts a regular string to title case.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ToTitleCase(this string value)
        {
            return Regex.Replace(value, @"(?<=\w)\w", new MatchEvaluator(v => v.Value.ToLower()));
        }

        /// <summary>
        /// Gets all child nodes of the given root HtmlNode.
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public static IEnumerable<HtmlNode> AllChildNodes(this HtmlNode root)
        {
            foreach (HtmlNode child in root.ChildNodes)
            {
                yield return child;

                if (child.ChildNodes.Count > 0)
                    foreach (HtmlNode grandChild in AllChildNodes(child))
                        yield return grandChild;
            }
        }

        /// <summary>
        /// Returns true if the given HtmlNode is CDATA.
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public static bool IsCData(this HtmlNode node)
        {
            return node.ChildNodes.Count == 0 && !string.IsNullOrEmpty(node.InnerText) && !string.IsNullOrWhiteSpace(node.InnerText);
        }

        /// <summary>
        /// Gets the Stylesheet from a given HtmlNode with a style attribute.
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public static Stylesheet GetStylesheet(this HtmlNode node)
        {
            HtmlAttribute styleAttribute = node.Attributes["style"];

            if (styleAttribute != null)
                return new Stylesheet(styleAttribute.Value);

            return null;
        }
    }
}
