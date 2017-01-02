using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace CAMAcademyApp.Core
{
    public class CardView : ScrollView
    {
        TapGestureRecognizer tapRecognizer;

        /// <summary>
        /// An event called when a card is tapped.
        /// </summary>
        public event EventHandler CardTapped;

        /// <summary>
        /// Gets the number of cards in the cardview.
        /// </summary>
        public int Count
        {
            get
            {
                return ((StackLayout)Content).Children.Count;
            }
        }

        /// <summary>
        /// Initializes a new CardView instance.
        /// </summary>
        public CardView()
        {
            BackgroundColor = CAMColors.PrimaryDark;
            
            tapRecognizer = new TapGestureRecognizer();
            tapRecognizer.Tapped += TapRecognizerTapped;

            Content = new StackLayout
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.StartAndExpand,
                Padding = new Thickness(8)
            };
        }

        /// <summary>
        /// Called when a card is tapped.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TapRecognizerTapped(object sender, EventArgs e)
        {
            CardTapped?.Invoke(sender, e);
        }

        /// <summary>
        /// Adds the given card to the CardView.
        /// </summary>
        /// <param name="card"></param>
        public void AddCard(Card card)
        {
            card.GestureRecognizers.Add(tapRecognizer);
            ((StackLayout)Content).Children.Add(card);
        }

        /// <summary>
        /// Removes all cards from the view.
        /// </summary>
        public void Clear()
        {
            ((StackLayout)Content).Children.Clear();
        }
    }
}
