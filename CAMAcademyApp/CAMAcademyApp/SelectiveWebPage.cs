using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CAMAcademyApp
{
    /// <summary>
    /// Used for loading specific parts of a webpage.
    /// </summary>
    public class SelectiveWebPage : ContentPage
    {
        /// <summary>
        /// Initializes a new SelectiveWebPage with the given title.
        /// </summary>
        /// <param name="title"></param>
        public SelectiveWebPage(string title)
        {
            Title = title;
            BackgroundColor = CAMColors.PrimaryDark;

            Content = new StackLayout
            {
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                Children =
                {
                    new Label
                    {
                        Text = "Loading...",
                        TextColor = CAMColors.Accent,
                        FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label))
                    }
                }
            };
        }

        /// <summary>
        /// Loads the webpage from the given base URI and HTML target attributes.
        /// </summary>
        /// <param name="baseUri"></param>
        /// <param name="htmlTargets"></param>
        public void Load(string baseUri, List<KeyValuePair<string, string>> htmlTargets)
        {
            Task.Run(() => ParseHTML(baseUri, htmlTargets)).ContinueWith((x) => GenerateWebView(x.Result));
        }

        /// <summary>
        /// Loads and parses HTML from the given base URI and HTML target attributes.
        /// </summary>
        /// <param name="baseUri"></param>
        /// <param name="htmlTargets"></param>
        /// <returns></returns>
        async Task<string> ParseHTML(string baseUri, List<KeyValuePair<string, string>> htmlTargets)
        {
            WebRequest request;
            WebResponse response;
            HtmlDocument doc;

            try
            {
                request = WebRequest.Create(baseUri);
                response = await Task.Factory.FromAsync(request.BeginGetResponse, request.EndGetResponse, null);

                doc = new HtmlDocument();
                doc.Load(response.GetResponseStream());
            }
            catch
            {
                return null;
            }

            HtmlNode node = doc.DocumentNode;

            foreach (var target in htmlTargets)
            {
                node = SearchNode(node, target.Key, target.Value);

                if (node == null)
                    return null;
            }

            return node.OuterHtml;
        }

        /// <summary>
        /// Searches the given HtmlNode's children for an attribute with the given name and value.
        /// </summary>
        /// <param name="parentNode"></param>
        /// <param name="attributeName"></param>
        /// <param name="attributeValue"></param>
        /// <returns></returns>
        HtmlNode SearchNode(HtmlNode parentNode, string attributeName, string attributeValue)
        {
            foreach (HtmlAttribute a in parentNode.Descendants().Select(x => x.Attributes[attributeName]))
            {
                if (a == null)
                    continue;

                if (a.Value == attributeValue)
                    return a.OwnerNode;
            }

            return null;
        }

        /// <summary>
        /// Generates a CustomWebView from the given HTML, if valid.
        /// </summary>
        /// <param name="html"></param>
        void GenerateWebView(string html)
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                if (html == null)
                {
                    Content = new StackLayout
                    {
                        HorizontalOptions = LayoutOptions.CenterAndExpand,
                        VerticalOptions = LayoutOptions.CenterAndExpand,
                        Children =
                        {
                            new Label
                            {
                                Text = "Could not load from webpage.",
                                TextColor = CAMColors.Accent,
                                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label))
                            }
                        }
                    };
                }
                else
                {
                    Content = new StackLayout
                    {
                        BackgroundColor = CAMColors.PrimaryDark,
                        VerticalOptions = LayoutOptions.FillAndExpand,
                        HorizontalOptions = LayoutOptions.FillAndExpand,
                        Children =
                        {
                            new CustomWebView
                            {
                                SourceHTML = html,
                                VerticalOptions = LayoutOptions.FillAndExpand,
                                HorizontalOptions = LayoutOptions.FillAndExpand
                            }
                        }
                    };
                }
            });
        }
    }
}
