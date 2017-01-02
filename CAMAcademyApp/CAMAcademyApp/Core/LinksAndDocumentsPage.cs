using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace CAMAcademyApp.Core
{
    public class LinksAndDocumentsPage : ContentPage
    {
        private List<LinkNode> resourceNodes;

        /// <summary>
        /// Returns the Content property as a StackLayout.
        /// </summary>
        private StackLayout StackContent
        {
            get
            {
                return (StackLayout)((ScrollView)Content).Content;
            }
        }

        /// <summary>
        /// Initializes a new ExternalResourcesPage.
        /// </summary>
        /// <param name="nodes"></param>
        public LinksAndDocumentsPage(List<LinkNode> nodes)
        {
            resourceNodes = nodes;

            Title = "Links and Documents";

            BackgroundColor = CAMColors.PrimaryDark;

            CardView cardView = new CardView();
            cardView.CardTapped += CardViewCardTapped;

            foreach (LinkNode node in resourceNodes)
            {
                cardView.AddCard(new Card
                {
                    PrimaryText = node.Name,
                    SecondaryText = node.Link
                });
            }

            Content = cardView;
        }

        /// <summary>
        /// Opens the URL associated with the tapped card.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CardViewCardTapped(object sender, EventArgs e)
        {
            Device.OpenUri(new Uri(((Card)sender).SecondaryText));
        }
    }
}
