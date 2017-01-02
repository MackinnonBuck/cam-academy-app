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
                    View = new Label
                    {
                        Text = "Search...",
                        TextColor = CAMColors.Accent,
                        HorizontalTextAlignment = TextAlignment.Center,
                        VerticalTextAlignment = TextAlignment.Center,
                        FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label))
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
