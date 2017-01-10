using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CAMAcademyApp.Core
{
    public class CustomWebView : View
    {
        /// <summary>
        /// Defines the SourceHTML BindableProperty.
        /// </summary>
        public static readonly BindableProperty SourceHTMLProperty = BindableProperty.Create(
            "SourceHTML",
            typeof(string),
            typeof(CustomWebView),
            default(string));

        /// <summary>
        /// Defines the BaseUri BindableProperty.
        /// </summary>
        public static readonly BindableProperty BaseUriProperty = BindableProperty.Create(
            "BaseUri",
            typeof(string),
            typeof(CustomWebView),
            default(string));

        /// <summary>
        /// Controls the webview's source HTML.
        /// </summary>
        public string SourceHTML
        {
            get { return (string)GetValue(SourceHTMLProperty); }
            set { SetValue(SourceHTMLProperty, value); }
        }

        /// <summary>
        /// The base uri of the webview's source.
        /// </summary>
        public string BaseUri
        {
            get { return (string)GetValue(BaseUriProperty); }
            set { SetValue(BaseUriProperty, value); }
        }
    }
}
