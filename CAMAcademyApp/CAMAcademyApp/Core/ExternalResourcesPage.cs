using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace CAMAcademyApp.Core
{
    public class ExternalResourcesPage : ContentPage
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
        public ExternalResourcesPage(List<LinkNode> nodes)
        {
            resourceNodes = nodes;

            Title = "External Resources...";

            BackgroundColor = CAMColors.PrimaryDark;

            Content = new ScrollView
            {
                Content = new StackLayout
                {
                    HorizontalOptions = LayoutOptions.FillAndExpand,
                    VerticalOptions = LayoutOptions.StartAndExpand,
                    Padding = new Thickness(8)
                }
            };

            TapGestureRecognizer tapRecognizer = new TapGestureRecognizer();
            tapRecognizer.Tapped += TapRecognizerTapped;
            
            foreach (LinkNode node in resourceNodes)
            {
                Frame frame = new Frame
                {
                    BackgroundColor = CAMColors.Accent,
                    Content = new StackLayout
                    {
                        HorizontalOptions = LayoutOptions.StartAndExpand,
                        VerticalOptions = LayoutOptions.StartAndExpand,
                        Children =
                        {
                            new Label
                            {
                                Text = node.Name,
                                TextColor = Color.Black,
                                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label))
                            },
                            new Label
                            {
                                Text = node.Link,
                                TextColor = Color.Gray,
                                FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label))
                            }
                        }
                    }
                };

                frame.GestureRecognizers.Add(tapRecognizer);
                StackContent.Children.Add(frame);
            }
        }

        /// <summary>
        /// Opens the URL associated with the tapped frame.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TapRecognizerTapped(object sender, EventArgs e)
        {
            Device.OpenUri(new Uri(resourceNodes[StackContent.Children.IndexOf((View)sender)].Link));
        }
    }
}
