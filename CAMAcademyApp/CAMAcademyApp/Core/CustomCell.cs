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
        /// Returns the View property as a StackLayout.
        /// </summary>
        private StackLayout StackView
        {
            get
            {
                return (StackLayout)View;
            }
        }

        /// <summary>
        /// Used for determining what type of cell is created.
        /// </summary>
        public enum CellType
        {
            Primary,
            Secondary
        }

        /// <summary>
        /// Specifies whether the cell is a primary or secondary cell.
        /// </summary>
        public CellType Type
        {
            get { return (CellType)GetValue(CellTypeProperty); }
            set { SetValue(CellTypeProperty, value); }
        }

        /// <summary>
        /// The text of the cell.
        /// </summary>
        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        public static readonly BindableProperty CellTypeProperty = BindableProperty.Create("Type", typeof(CellType), typeof(CustomCell), CellType.Primary);
        public static readonly BindableProperty TextProperty = BindableProperty.Create("Text", typeof(string), typeof(CustomCell), string.Empty);

        /// <summary>
        /// Initializes a new CustomCell.
        /// </summary>
        public CustomCell()
        {
            PropertyChanged += CustomCellPropertyChanged;

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

        private void CustomCellPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "Type")
            {
                switch (Type)
                {
                    case CellType.Primary:
                        label.FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label));
                        label.FontAttributes = FontAttributes.Bold;
                        StackView.Margin = new Thickness(16, 8, 0, 8);
                        break;
                    case CellType.Secondary:
                        label.FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label));
                        label.FontAttributes = FontAttributes.None;
                        StackView.Margin = new Thickness(32, 8, 0, 8);
                        break;
                }
            }
        }
    }
}
