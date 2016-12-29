using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace CAMAcademyApp.Core
{
    /// <summary>
    /// Defines a selectable item on the master page.
    /// </summary>
    public class CustomCell : ViewCell
    {
        private Label label;

        /// <summary>
        /// The text of the cell.
        /// </summary>
        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        public static readonly BindableProperty TextProperty = BindableProperty.Create("Text", typeof(string), typeof(CustomCell), string.Empty);

        /// <summary>
        /// Initializes a new CustomCell.
        /// </summary>
        public CustomCell()
        {
            label = new Label
            {
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
                TextColor = CAMColors.Accent,
                FontAttributes = FontAttributes.Bold,
            };

            label.SetBinding(Label.TextProperty, "Text");
            
            View = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                VerticalOptions = LayoutOptions.Center,
                Margin = new Thickness(16, 8, 0, 8),
                Children =
                {
                    label
                }
            };
        }
    }
}
