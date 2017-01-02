using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CAMAcademyApp.Core
{
    public class Card : Frame
    {
        private Label primaryLabel;
        private Label secondaryLabel;

        private string _primaryText;
        private string _secondaryText;

        /// <summary>
        /// Used for attaching extra data to the card to be referenced later.
        /// </summary>
        public object UserData { get; set; }

        /// <summary>
        /// Sets or gets the primary text of the Card.
        /// </summary>
        public string PrimaryText
        {
            get
            {
                return _primaryText;
            }
            set
            {
                _primaryText = value;

                if (primaryLabel == null)
                {
                    primaryLabel = new Label
                    {
                        TextColor = Color.Black,
                        FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label))
                    };

                    ((StackLayout)Content).Children.Add(primaryLabel);
                }

                primaryLabel.Text = value;
            }
        }

        /// <summary>
        /// Sets or gets the secondary text of the card.
        /// </summary>
        public string SecondaryText
        {
            get
            {
                return _secondaryText;
            }
            set
            {
                _secondaryText = value;

                if (secondaryLabel == null)
                {
                    secondaryLabel = new Label
                    {
                        TextColor = Color.Gray,
                        FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label))
                    };

                    ((StackLayout)Content).Children.Add(secondaryLabel);
                }

                secondaryLabel.Text = value;
            }
        }

        /// <summary>
        /// Initializes a new Card instance.
        /// </summary>
        public Card()
        {
            _primaryText = string.Empty;
            _secondaryText = string.Empty;

            BackgroundColor = CAMColors.Accent;
            Content = new StackLayout
            {
                HorizontalOptions = LayoutOptions.StartAndExpand,
                VerticalOptions = LayoutOptions.StartAndExpand,
            };
        }
    }
}
