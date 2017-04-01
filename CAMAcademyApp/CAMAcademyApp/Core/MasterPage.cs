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
            List<object> cells = new List<object>
            {
                new SearchItem
                {
                    TargetType = typeof(SearchPage),
                },
                new SecondaryItem
                {
                    Text = "Home",
                    Appearance = MasterListCell.CellAppearance.Category,
                    TargetType = typeof(JunklessPage),
                    Arguments = new object[] { "Home", SiteAttributes.BaseUri }
                }
            };
            
            foreach (LinkNode node in App.RootNode.Children)
            {
                cells.Add(new CategoryItem
                {
                    Text = node.Name
                });

                for (int i = 0; i < node.Children.Count; i++)
                {
                    cells.Add(new SecondaryItem
                    {
                        Text = node.Children[i].Name,
                        Appearance = MasterListCell.CellAppearance.Item,
                        TargetType = typeof(AutoPage),
                        Arguments = new object[] { node, i, }
                    });
                }
            }

            ListView = new ListView
            {
                BackgroundColor = CAMColors.Primary,
                Header = new Image
                {
                    Source = ImageSource.FromFile("cover_image.jpg"),
                    Aspect = Aspect.AspectFit,
                    Margin = new Thickness(0, 0, 0, 8)
                },
                ItemsSource = cells,
                ItemTemplate = new MasterTemplateSelector(),
                VerticalOptions = LayoutOptions.FillAndExpand,
                SeparatorVisibility = SeparatorVisibility.None,
                HasUnevenRows = true
            };
            
            BackgroundColor = CAMColors.Primary;
            Title = "Menu";
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
