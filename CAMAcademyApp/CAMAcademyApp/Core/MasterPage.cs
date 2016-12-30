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
            List<MasterPageItem> cells = new List<MasterPageItem>
            {
                new MasterPageItem
                {
                    Text = "Home",
                    TargetType = typeof(JunklessPage),
                    Arguments = new object[] { "Home", SiteAttributes.BaseUri }
                }
            };
            
            foreach (LinkNode node in App.RootNode.Children)
            {
                cells.Add(new MasterPageItem
                {
                    Text = node.Name,
                    CellType = CustomCell.CellType.Primary
                });

                for (int i = 0; i < node.Children.Count; i++)
                {
                    cells.Add(new MasterPageItem
                    {
                        Text = node.Children[i].Name,
                        TargetType = typeof(AutoPage),
                        CellType = CustomCell.CellType.Secondary,
                        Arguments = new object[] { node, i }
                    });
                }
            }

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
                    cell.SetBinding(CustomCell.CellTypeProperty, "CellType");
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
