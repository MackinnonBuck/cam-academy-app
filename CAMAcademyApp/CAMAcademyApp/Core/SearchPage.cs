using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CAMAcademyApp.Core
{
    public class SearchPage : ContentPage
    {
        private SearchBar searchBar;
        private Label resultsLabel;
        private CardView cardView;

        /// <summary>
        /// Initializes a new SearchPage instance.
        /// </summary>
        public SearchPage()
        {
            Title = "Search Pages/Documents";
            BackgroundColor = CAMColors.PrimaryDark;

            searchBar = new SearchBar
            {
                Placeholder = "Search...",
                SearchCommand = new Command(() => Search()),
                BackgroundColor = CAMColors.Accent,
                TextColor = Color.Black,
                HeightRequest = 48
            };

            searchBar.TextChanged += SearchBarTextChanged;

            resultsLabel = new Label
            {
                FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label)),
                TextColor = CAMColors.Accent,
                HorizontalTextAlignment = TextAlignment.Center,
                VerticalTextAlignment = TextAlignment.Center
            };

            cardView = new CardView();
            cardView.CardTapped += CardViewCardTapped;

            Content = new StackLayout
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.StartAndExpand,
                Children =
                {
                    searchBar,
                    resultsLabel,
                    cardView
                }
            };

            PropertyChanged += SearchPagePropertyChanged;
        }

        /// <summary>
        /// Brings the focus to the search bar when the page is loaded.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SearchPagePropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (!searchBar.IsFocused)
                searchBar.Focus();
        }

        /// <summary>
        /// Clears the current results when the text in the search bar changes.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SearchBarTextChanged(object sender, TextChangedEventArgs e)
        {
            cardView.Clear();
            resultsLabel.Text = string.Empty;
        }

        /// <summary>
        /// Opens the corresponding page or document when a card is tapped.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CardViewCardTapped(object sender, EventArgs e)
        {
            Card card = (Card)sender;

            if (card.SecondaryText.Equals(string.Empty))
            {
                LinkNode node = (LinkNode)card.UserData;

                AutoPage page = new AutoPage(node.Parent.Parent, node.Parent.Parent.Children.IndexOf(node.Parent));

                ((MainPage)Application.Current.MainPage).Detail = new NavigationPage(page)
                {
                    BarBackgroundColor = CAMColors.Primary,
                    BarTextColor = CAMColors.Accent
                };

                page.CurrentPage = page.Children.First((x) => x.Title == node.Name);
            }
            else
            {
                Device.OpenUri(new Uri(card.SecondaryText));
            }
        }

        /// <summary>
        /// Searches the root LinkNode's leaf nodes and finds close matches to the search text.
        /// </summary>
        private void Search()
        {
            cardView.Clear();

            List<string> registeredNames = new List<string>();

            string[] searchWords = searchBar.Text.ToLower().Split(' ');

            foreach (LinkNode node in App.RootNode.LeafNodes())
            {
                if (registeredNames.Contains(node.Name))
                    continue;

                string nameLower = node.Name.ToLower();

                bool isValid = true;

                foreach (string word in searchWords)
                    if (!nameLower.Contains(word))
                        isValid = false;

                if (!isValid)
                    continue;

                registeredNames.Add(node.Name);

                Card card = new Card
                {
                    PrimaryText = node.Name,
                    UserData = node
                };

                if (!node.Link.StartsWith(SiteAttributes.BaseUri))
                    card.SecondaryText = node.Link;

                cardView.AddCard(card);
            }
            
            switch (cardView.Count)
            {
                case 0:
                    resultsLabel.Text = "No results found";
                    break;
                case 1:
                    resultsLabel.Text = "Found 1 result";
                    break;
                default:
                    resultsLabel.Text = "Found " + cardView.Count + " results";
                    break;
            }
        }
    }
}
