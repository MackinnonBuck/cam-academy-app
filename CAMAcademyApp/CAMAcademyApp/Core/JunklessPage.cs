﻿using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CAMAcademyApp.Core
{
    /// <summary>
    /// Used for loading specific parts of a webpage.
    /// </summary>
    public class JunklessPage : ContentPage
    {
        /// <summary>
        /// Returns the Content as a StackLayout.
        /// </summary>
        protected StackLayout StackLayout { get { return Content as StackLayout; } }

        /// <summary>
        /// The view the SelectiveWebPage displays.
        /// </summary>
        private View _mainView;

        /// <summary>
        /// Gets or sets the main view.
        /// </summary>
        private View MainView
        {
            get
            {
                return _mainView;
            }
            set
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    if (_mainView != null && StackLayout.Children.Contains(_mainView))
                        StackLayout.Children.Remove(_mainView);

                    _mainView = value;

                    StackLayout.Children.Add(_mainView);

                    StackLayout.ForceLayout();
                });
            }
        }

        /// <summary>
        /// Initializes a new SelectiveWebPage with the given title.
        /// </summary>
        /// <param name="title"></param>
        public JunklessPage(string title, string baseUri)
        {
            Title = title;
            BackgroundColor = CAMColors.PrimaryDark;

            Content = new StackLayout
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand
            };

            MainView = new ActivityIndicator
            {
                Color = CAMColors.Accent,
                IsRunning = true
            };

            Task.Run(() => ShaveJunkHtml(baseUri)).ContinueWith((x) => MainView = x.Result == null ? new Label
            {
                Text = "Could not load from webpage.",
                TextColor = CAMColors.Accent,
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
                HorizontalOptions = LayoutOptions.CenterAndExpand
            } as View : new CustomWebView
            {
                SourceHTML = x.Result,
                BaseUri = baseUri,
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand
            });
        }

        /// <summary>
        /// Loads and parses HTML from the given base URI and HTML target attributes.
        /// </summary>
        /// <param name="baseUri"></param>
        /// <param name="attributesList"></param>
        /// <returns></returns>
        async Task<string> ShaveJunkHtml(string baseUri)
        {
            HtmlDocument document = await GenerateHtmlDocument(baseUri);

            if (document == null)
                return null;

            HtmlNode node = SearchNode(document.DocumentNode, "class", new string[] { SiteAttributes.ContentClassName });

            if (node == null)
                return null;

            node = SearchNode(node, "style", SiteAttributes.ContentStyleAttributes);

            if (node == null)
                return null;

            return node.OuterHtml;
        }

        /// <summary>
        /// Generates an HtmlDocument from the given baseUri.
        /// </summary>
        /// <param name="baseUri"></param>
        /// <returns></returns>
        public static async Task<HtmlDocument> GenerateHtmlDocument(string baseUri)
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
                return doc;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Searches the given HtmlNode's children for an attribute with the given name and value.
        /// </summary>
        /// <param name="parentNode"></param>
        /// <param name="attributeName"></param>
        /// <param name="attributeValue"></param>
        /// <returns></returns>
        HtmlNode SearchNode(HtmlNode parentNode, string attributeName, string[] attributeValues)
        {
            foreach (HtmlAttribute a in parentNode.Descendants().Select(x => x.Attributes[attributeName]))
            {
                if (a == null)
                    continue;

                foreach (string value in attributeValues)
                    if (a.Value.Contains(value))
                        return a.OwnerNode;
            }

            return null;
        }
    }
}
