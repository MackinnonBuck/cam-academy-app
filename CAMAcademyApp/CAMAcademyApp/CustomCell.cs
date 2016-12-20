using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace CAMAcademyApp
{
    /// <summary>
    /// Defines a selectable item on the master page.
    /// </summary>
    public class CustomCell : ViewCell
    {
        private Label label;
        private Image image;

        /// <summary>
        /// The source of the image loaded.
        /// </summary>
        public ImageSource ImageSource
        {
            get { return (ImageSource)GetValue(ImageSourceProperty); }
            set { SetValue(ImageSourceProperty, value); }
        }

        /// <summary>
        /// The text of the cell.
        /// </summary>
        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        public static readonly BindableProperty ImageSourceProperty = BindableProperty.Create("ImageSource", typeof(ImageSource), typeof(CustomCell));
        public static readonly BindableProperty TextProperty = BindableProperty.Create("Text", typeof(string), typeof(CustomCell), string.Empty);

        /// <summary>
        /// Initializes a new CustomCell.
        /// </summary>
        public CustomCell()
        {
            image = new Image
            {
                Aspect = Aspect.AspectFit,
                Margin = new Thickness(0, 0, 8, 0)
            };
            
            label = new Label
            {
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
                TextColor = CAMColors.Accent,
                FontAttributes = FontAttributes.Bold,
            };

            image.SetBinding(Image.SourceProperty, "ImageSource");
            label.SetBinding(Label.TextProperty, "Text");
            
            View = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                VerticalOptions = LayoutOptions.Center,
                Margin = new Thickness(16, 8, 0, 8),
                Children =
                {
                    image,
                    label
                }
            };
        }
    }
}
