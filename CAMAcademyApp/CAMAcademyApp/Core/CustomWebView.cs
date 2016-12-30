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
        /// Controls the webview's source HTML.
        /// </summary>
        public string SourceHTML
        {
            get { return (string)GetValue(SourceHTMLProperty); }
            set { SetValue(SourceHTMLProperty, value); }
        }
    }
}
