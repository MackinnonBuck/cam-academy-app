using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace CAMAcademyApp
{
    /// <summary>
    /// The side panel used to switch between pages.
    /// </summary>
    public class MPage : ContentPage
    {
        /// <summary>
        /// A view containing each cell.
        /// </summary>
        public ListView ListView { get; private set; }

        /// <summary>
        /// Initializes a new MPage instance.
        /// </summary>
        public MPage()
        {
            MPageItem[] cells =
            {
                new MPageItem
                {
                    ImageSource = ImageSource.FromFile("ic_home_white_24dp.png"),
                    Text = "Home",
                    TargetType = typeof(HomePage)
                },
                new MPageItem
                {
                    ImageSource = ImageSource.FromFile("ic_local_library_white_24dp.png"),
                    Text = "High School",
                    TargetType = typeof(HighSchoolPage)
                }
            };

            ListView = new ListView
            {
                Header = new Image
                {
                    Source = ImageSource.FromFile("CoverImage.jpg"),
                    Aspect = Aspect.AspectFit,
                    Margin = new Thickness(0, 0, 0, 8)
                },
                ItemsSource = cells,
                ItemTemplate = new DataTemplate(() =>
                {
                    CustomCell cell = new CustomCell();
                    cell.SetBinding(CustomCell.ImageSourceProperty, "ImageSource");
                    cell.SetBinding(CustomCell.TextProperty, "Text");
                    return cell;
                }),
                VerticalOptions = LayoutOptions.FillAndExpand,
                SeparatorVisibility = SeparatorVisibility.None
            };

            BackgroundColor = CAMColors.Primary;
            Title = "View Switcher";
            Content = new StackLayout
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                Children =
                {
                    ListView
                }
            };
        }
    }
}
