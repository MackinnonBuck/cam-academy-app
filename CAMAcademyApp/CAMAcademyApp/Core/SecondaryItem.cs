using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAMAcademyApp.Core
{
    /// <summary>
    /// Defines the structure of a secondary master page item.
    /// </summary>
    public class SecondaryItem : SelectableItem
    {
        /// <summary>
        /// The text of the page item.
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// Defines the appearance of the cell.
        /// </summary>
        public MasterListCell.CellAppearance Appearance { get; set; }
    }
}
