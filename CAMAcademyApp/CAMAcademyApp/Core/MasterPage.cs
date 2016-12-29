using CAMAcademyApp.About;
using CAMAcademyApp.High;
using CAMAcademyApp.Home;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace CAMAcademyApp.Core
{
    /// <summary>
    /// The side panel used to switch between pages.
    /// </summary>
    public class MasterPage : ContentPage
    {
        /// <summary>
        /// A view containing each cell.
        /// </summary>
        public ListView ListView { get; private set; }

        /// <summary>
        /// Initializes a new MPage instance.
        /// </summary>
        public MasterPage()
        {
            //MPageItem[] cells =
            //{
            //    new MPageItem
            //    {
            //        ImageSource = ImageSource.FromFile("ic_home_white_24dp.png"),
            //        Text = "Home",
            //        TargetType = typeof(HomePage)
            //    },
            //    new MPageItem
            //    {
            //        ImageSource = ImageSource.FromFile("ic_help_white_24dp.png"),
            //        Text = "About Us",
            //        TargetType = typeof(SchoolProfilePage)//typeof(AboutPage)
            //    },
            //    new MPageItem
            //    {
            //        ImageSource = ImageSource.FromFile("ic_local_library_white_24dp.png"),
            //        Text = "High School",
            //        TargetType = typeof(HighSchoolAboutPage)//typeof(HighSchoolPage)
            //    },
            //    new MPageItem
            //    {
            //        ImageSource = ImageSource.FromFile("ic_local_library_white_24dp.png"),
            //        Text = "Middle School",
            //        TargetType = typeof(Middle)//typeof(HighSchoolPage)
            //    }
            //};

            List<MasterPageItem> cells = new List<MasterPageItem>
            {
                new MasterPageItem
                {
                    Text = "HOME",
                    TargetType = typeof(HomePage)
                }
            };

            // TODO: Use the App's RootNode to generate the MasterPageItems.

            //int currentIndex = 0;

            //for (int nextIndex = 0; nextIndex < App.MenuValues.Values.Count;)
            //{
            //    List<object> section = (List<object>)App.MenuValues.Values[currentIndex];
            //    string title = section[0].ToString().ToUpper();

            //    nextIndex++;
            //    for (; nextIndex < App.MenuValues.Values.Count; nextIndex++)
            //    {
            //        List<object> nextSection = (List<object>)App.MenuValues.Values[nextIndex];

            //        if (nextSection.Count > 0 && !nextSection[0].ToString().Equals(string.Empty))
            //            break;
            //    }

            //    cells.Add(new MasterPageItem
            //    {
            //        Text = title,
            //        TargetType = typeof(AutoPage),
            //        Arguments = new object[] { title, currentIndex, nextIndex - 1 }
            //    });

            //    currentIndex = nextIndex;
            //}

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
