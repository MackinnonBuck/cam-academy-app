using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CAMAcademyApp.Core
{
    public class MasterListCell : ViewCell
    {
        private Label label;

        /// <summary>
        /// Returns the View property as a StackLayout.
        /// </summary>
        private StackLayout StackView { get { return (StackLayout)View; } }

        /// <summary>
        /// Used for defining the appearance of the MasterListCell.
        /// </summary>
        public enum CellAppearance
        {
            Category,
            Item
        }

        /// <summary>
        /// Defines the appearance of the MasterListCell.
        /// </summary>
        public CellAppearance Appearance
        {
            get { return (CellAppearance)GetValue(AppearanceProperty); }
            set { SetValue(AppearanceProperty, value); }
        }

        /// <summary>
        /// The text of the cell.
        /// </summary>
        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        public static readonly BindableProperty AppearanceProperty = BindableProperty.Create("Appearance", typeof(CellAppearance), typeof(MasterListCell), CellAppearance.Category);
        public static readonly BindableProperty TextProperty = BindableProperty.Create("Text", typeof(string), typeof(MasterListCell), string.Empty);

        /// <summary>
        /// Initializes a new CustomCell.
        /// </summary>
        public MasterListCell()
        {
            PropertyChanged += MasterListCellPropertyChanged;

            label = new Label
            {
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
                TextColor = CAMColors.Accent,
                FontAttributes = FontAttributes.Bold
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

        /// <summary>
        /// Updates the visible properties of the MasterListCell when a class property is changed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MasterListCellPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case "Appearance":
                    switch (Appearance)
                    {
                        case CellAppearance.Category:
                            label.FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label));
                            label.FontAttributes = FontAttributes.Bold;
                            StackView.Margin = new Thickness(16, 8, 0, 8);
                            break;
                        case CellAppearance.Item:
                            label.FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label));
                            label.FontAttributes = FontAttributes.None;
                            StackView.Margin = new Thickness(32, 8, 0, 8);
                            break;
                    }
                    break;
            }
        }
    }
}
