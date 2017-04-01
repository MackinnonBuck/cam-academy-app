using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CAMAcademyApp.Core
{
    public class MasterTemplateSelector : DataTemplateSelector
    {
        private DataTemplate DefaultTemplate;
        private DataTemplate CategoryTemplate;
        private DataTemplate SecondaryTemplate;
        private DataTemplate SearchTemplate;

        /// <summary>
        /// Initializes a new MasterTemplateSelector.
        /// </summary>
        public MasterTemplateSelector()
        {
            DefaultTemplate = new DataTemplate(() =>
            {
                return new TextCell
                {
                    Text = "<invalid item>",
                    IsEnabled = false
                };
            });

            CategoryTemplate = new DataTemplate(() =>
            {
                MasterListCell cell = new MasterListCell();
                cell.SetBinding(MasterListCell.TextProperty, "Text");
                cell.IsEnabled = false;
                return cell;
            });

            SecondaryTemplate = new DataTemplate(() =>
            {
                MasterListCell cell = new MasterListCell();
                cell.SetBinding(MasterListCell.AppearanceProperty, "Appearance");
                cell.SetBinding(MasterListCell.TextProperty, "Text");
                return cell;
            });

            SearchTemplate = new DataTemplate(() =>
            {
                ViewCell cell = new ViewCell
                {
                    View = new StackLayout
                    {
                        Orientation = StackOrientation.Horizontal,
                        HorizontalOptions = LayoutOptions.Center,
                        VerticalOptions = LayoutOptions.Center,
                        Margin = new Thickness(0, 8),
                        Children =
                        {
                            new Image
                            {
                                Source = ImageSource.FromFile("ic_search_white_24dp.png")
                            },
                            new Label
                            {
                                Text = "Search...",
                                TextColor = CAMColors.Accent,
                                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
                                HorizontalTextAlignment = TextAlignment.Center,
                                VerticalTextAlignment = TextAlignment.Center
                            }
                        }
                    }
                };

                return cell;
            });
        }

        /// <summary>
        /// Determines what template to use given the provided item.
        /// </summary>
        /// <param name="item"></param>
        /// <param name="container"></param>
        /// <returns></returns>
        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            Type itemType = item.GetType();

            return
                itemType == typeof(CategoryItem) ? CategoryTemplate :
                itemType == typeof(SecondaryItem) ? SecondaryTemplate :
                itemType == typeof(SearchItem) ? SearchTemplate : DefaultTemplate;
        }
    }
}
