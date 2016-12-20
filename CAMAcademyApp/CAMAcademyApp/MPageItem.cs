using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace CAMAcademyApp
{
    /// <summary>
    /// Defines the structure of a master page item.
    /// </summary>
    public class MPageItem
    {
        /// <summary>
        /// The source of the image loaded.
        /// </summary>
        public ImageSource ImageSource { get; set; }

        /// <summary>
        /// The text of the page item.
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// The type of the view to be displayed when the item is selected.
        /// </summary>
        public Type TargetType { get; set; }
    }
}
