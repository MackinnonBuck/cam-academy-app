using Google.Apis.Sheets.v4.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAMAcademyApp.Core
{
    public class LinkNode
    {
        /// <summary>
        /// The name of the LinkNode.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The link associated with the LinkNode.
        /// </summary>
        public string Link { get; private set; }

        /// <summary>
        /// The LinkNode's children.
        /// </summary>
        public List<LinkNode> Children { get; private set; }

        /// <summary>
        /// Initializes a new LinkNode.
        /// </summary>
        private LinkNode()
        {
            Children = new List<LinkNode>();
        }

        /// <summary>
        /// Reads from the given ValueRange to generate the root LinkNode.
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        public static LinkNode Generate(ValueRange table)
        {
            LinkNode root = new LinkNode();

            for (int endRow = 0; endRow < table.Values.Count;)
                root.Children.Add(ParseSpreadsheet(table, out endRow, endRow));

            return root;
        }

        /// <summary>
        /// Literally so complicated. Don't even bother.
        /// </summary>
        /// <param name="table"></param>
        /// <param name="endRow"></param>
        /// <param name="row"></param>
        /// <param name="column"></param>
        /// <returns></returns>
        private static LinkNode ParseSpreadsheet(ValueRange table, out int endRow, int row = 0, int column = 0)
        {
            LinkNode node = new LinkNode();

            node.Name = table.Values[row][column].ToString();
            node.Link = table.Values[row][column + 1].ToString();

            endRow = row + 1;

            if (column >= table.Values[row].Count - 2 || table.Values[row][column + 2].ToString().Equals(string.Empty))
                return node;

            for (; endRow < table.Values.Count && (table.Values[endRow].Count == 0 || table.Values[endRow][column].ToString().Equals(string.Empty)); endRow++) ;

            for (int i = row; i < endRow; i++)
            {
                List<object> subRow = (List<object>)table.Values[i];

                if (column + 2 > subRow.Count - 1)
                    continue;

                string value = subRow[column + 2].ToString();

                if (!value.Equals(string.Empty) && !value.StartsWith("&"))
                {
                    int placebo;
                    node.Children.Add(ParseSpreadsheet(table, out placebo, i, column + 2));
                }
            }

            return node;
        }
    }
}
