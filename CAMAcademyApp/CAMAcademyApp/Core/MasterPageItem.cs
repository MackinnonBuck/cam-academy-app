using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace CAMAcademyApp.Core
{
    /// <summary>
    /// Defines the structure of a master page item.
    /// </summary>
    public class MasterPageItem
    {
        /// <summary>
        /// The text of the page item.
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// The type of the view to be displayed when the item is selected.
        /// </summary>
        public Type TargetType { get; set; }

        /// <summary>
        /// The type of the cell to be generated.
        /// </summary>
        public CustomCell.CellType CellType { get; set; }

        /// <summary>
        /// Optional extra arguments passed to the page item.
        /// </summary>
        public object[] Arguments { get; set; }
    }
}
