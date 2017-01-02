using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace CAMAcademyApp.Core
{
    /// <summary>
    /// Defines the structure of a selectable master page item.
    /// </summary>
    public class SelectableItem
    {
        /// <summary>
        /// The type of the view to be displayed when the item is selected.
        /// </summary>
        public Type TargetType { get; set; }

        /// <summary>
        /// Optional extra arguments passed to the page item.
        /// </summary>
        public object[] Arguments { get; set; }
    }
}
